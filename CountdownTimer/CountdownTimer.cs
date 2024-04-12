using static CountdownTimer.CountdownTimer.TimerStatus;
using Timer = System.Windows.Forms.Timer;

namespace CountdownTimer;

public class CountdownTimer : UserControl
{
    private Timer? _timer;
    private Label? _label;
    private int _countdownSeconds;
    private int _currentSeconds;

    private TimerStatus _status;
    
    public CountdownTimer()
    {
        InitControl();
        InitCountdownTimer();
        InitCircularBoard();
    }
    
    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        
        _center = new((float)Size.Width / 2, (float)Size.Height / 2 + (float)Size.Height / 16);
        _radius = Math.Min(Size.Width * 5 / 16, Size.Height * 5 / 16);

        if (_label != null)
        {
            _label.Font = new Font("Arial", _radius / 15, FontStyle.Bold);
            _label.Location = new Point((int)(_center.X - _radius * 5 / 9), (int)(_center.Y - _radius * 4 / 3));
        }

        UpdateCircularBoard();
        Invalidate(); // 通知控件重绘
    }

    private void InitControl()
    {
        Dock = DockStyle.Left;
        
        SetStyle(ControlStyles.AllPaintingInWmPaint | 
                 ControlStyles.UserPaint |
                 ControlStyles.DoubleBuffer, true);
        
        Resize += OnResize;
    }

    private void OnResize(object? sender, EventArgs e)
    {
        if (Parent == null) return;
        Width = Parent.ClientSize.Height;
        Height = Parent.ClientSize.Height;
    }

    #region CountdownTimer
    
    public enum TimerStatus
    {
        Stopped,    //未运行
        Running,    //运行中
        Paused      //暂停中
    }
    
    private void InitCountdownTimer()
    {
        _currentSeconds = _countdownSeconds = 60;

        _label = new();
        _label.TextAlign = ContentAlignment.MiddleCenter;
        //_label.Font = new("Arial", 24, FontStyle.Bold);
        _label.AutoSize = true;
        Controls.Add(_label);

        _timer = new Timer();
        _status = Stopped;
        _timer.Interval = 1000;
        _timer.Tick += CountdownTimer_Tick;
        UpdateLabel();
    }

    private void CountdownTimer_Tick(object? sender, EventArgs e)
    {
        if (_countdownSeconds > 0)
        {
            _currentSeconds--;
            UpdateLabel();
            UpdateCircularBoard();
            Invalidate();
        }

        if (_currentSeconds <= 0)
        {
            _timer?.Stop();
            _status = Stopped;
            _angle = 0;
            Invalidate();
        }
    }

    private void UpdateLabel()
    {
        if (_label != null)
        {
            _label.Text = $"倒计时：{_currentSeconds / 60}分{(_currentSeconds % 60):D2}秒";
        }
        
        Invalidate();
    }

    public void SetCountdownSeconds(int seconds)
    {
        _countdownSeconds = _currentSeconds = seconds;
        
        UpdateLabel();
        UpdateCircularBoard();
    }

    public void StartCountdownTimer()
    {
        if (_timer != null && _status == Stopped)
        {
            _status = Running;
            _timer.Start();
        }
        UpdateLabel();
        UpdateCircularBoard();
    }

    public void SwitchCountdownTimer()
    {
        if (_timer != null)
        {
            if (_status == Running)
            {
                _timer.Stop();
                _status = Paused;
            }
            else if (_status == Paused)
            {
                _timer.Start();
                _status = Running;
            }
        }
        UpdateLabel();
        UpdateCircularBoard();
    }
    
    public void StopCountdownTimer()
    {
        if (_timer != null && (_status == Paused || _status == Running))
        {
            _timer.Stop();
            _status = Stopped;
            _currentSeconds = _countdownSeconds;
            
            UpdateLabel();
            UpdateCircularBoard();
        }
    }

    public TimerStatus GetTimerStatus()
    {
        return _status;
    }
    
    #endregion

    #region CircularBoard

    private PointF _center;
    private float _radius;
    private Pen? _pen;
    private Brush? _brush;
    private float _angle;

    private void InitCircularBoard()
    {
        _pen = new Pen(Color.Gray, 2);
        _brush = new SolidBrush(Color.Gray);
        _center = new((float)Width / 2, (float)Height / 2);
        _radius = Math.Min(Width / 2, Height / 2);
        UpdateCircularBoard();
        Paint += PaintCircularBoard;
    }

    private void UpdateCircularBoard()
    {
        _angle = _status switch
        {
            Stopped => 0,
            Running => 360f * (1 - (float)_currentSeconds / _countdownSeconds),
            Paused => _angle,
            _ => 0
        };
        
        //Invalidate();
    }

    private void PaintCircularBoard(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        if (_pen != null)
        {
            g.DrawEllipse(_pen, _center.X - _radius, _center.Y - _radius, _radius * 2, _radius * 2);
        }

        if (_brush != null)
        {
            g.FillPie(_brush, _center.X - _radius, _center.Y - _radius, _radius * 2, _radius * 2, -90,
                _angle);
        }
    }

    #endregion
}