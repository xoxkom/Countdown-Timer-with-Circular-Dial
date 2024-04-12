namespace CountdownTimer;

public class ControlButton : UserControl
{
    private Button? _button;
    private readonly CountdownTimer? _timer;
    private readonly int _attribute; //按钮属性，0表示开始，1表示重置，2表示停止

    public ControlButton(CountdownTimer timer, string attribute)
    {
        _timer = timer;
        
        _attribute = attribute switch
        {
            "start" => 0,
            "stop" => 1,
            "switch" => 2,
            _ => -1
        };

        InitButton();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (_attribute == 2 && _button != null)
        {
            _button.Text = _timer?.GetTimerStatus() == CountdownTimer.TimerStatus.Paused ? "继续计时" : "暂停计时";
        }

        base.OnPaint(e);
    }

    private void InitButton()
    {
        AutoSize = true;
        
        _button = new Button();
        _button.AutoSize = true;
        _button.Click += ButtonController;
        Controls.Add(_button);
    }

    private void ButtonController(object? sender, EventArgs e)
    {
        if (_timer == null) return;
        switch (_attribute)
        {
            case 0:
                _timer.StartCountdownTimer();
                break;
            case 1:
                _timer.StopCountdownTimer();
                break;
            case 2:
                _timer.SwitchCountdownTimer();
                break;
        }
    }

    public void SetButtonText(int fontSize, string text)
    {
        if (_button != null)
        {
            _button.Font = new Font("Arial", fontSize, FontStyle.Bold);
            _button.Text = text;
        }
    }
    public void SetButtonText(string text)
    {
        if (_button != null)
        {
            _button.Text = text;
        }
    }
}