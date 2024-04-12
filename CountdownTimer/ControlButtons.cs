namespace CountdownTimer;

public class ControlButtons : UserControl
{
    private readonly CountdownTimer? _timer;
    private ControlButton? _startButton, _stopButton, _switchButton;

    public ControlButtons(CountdownTimer timer)
    {
        _timer = timer;
        
        InitControl();
        InitButtons();
    }

    private void InitControl()
    {
        Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        Size = new Size(270, 1080);
        Location = new Point(1160, 0);
        
        Resize += OnResize;
    }
    
    private void OnResize(object? sender, EventArgs e)
    {
        if (Parent != null)
        {
            Size = new Size(Parent.ClientSize.Height / 4, Parent.ClientSize.Height);
            Location = new Point(Parent.ClientSize.Width - Parent.ClientSize.Height / 2, 0);
        }

        if (_startButton != null)
        {
            _startButton.SetButtonText(ClientSize.Width / 15, "开始计时");
            _startButton.Location = new Point(
                0,
                ClientSize.Height / 4 - _startButton.ClientSize.Height / 2
            );
        }

        if (_stopButton != null)
        {
            _stopButton.SetButtonText(ClientSize.Width / 15, "停止计时");
            _stopButton.Location = new Point(
                0,
                ClientSize.Height / 2 - _stopButton.ClientSize.Height / 2
            );
        }

        if (_switchButton != null)
        {
            _switchButton.SetButtonText(ClientSize.Width / 15, "暂停计时");
            _switchButton.Location = new Point(
                0,
                ClientSize.Height * 3 / 4 - _switchButton.ClientSize.Height / 2
            );
        }
        
        Invalidate();
    }

    private void InitButtons()
    {
        if (_timer != null)
        {
            _startButton = new ControlButton(_timer, "start");
            _startButton.SetButtonText(ClientSize.Width / 15, "开始计时");
            _startButton.Location = new Point(
                0,
                ClientSize.Height / 4 - _startButton.ClientSize.Height / 2
            );

            _stopButton = new ControlButton(_timer, "stop");
            _stopButton.SetButtonText(ClientSize.Width / 15, "停止计时");
            _stopButton.Location = new Point(
                0,
                ClientSize.Height / 2 - _stopButton.ClientSize.Height / 2
            );
            
            _switchButton = new ControlButton(_timer, "switch");
            _switchButton.SetButtonText(ClientSize.Width / 15, "暂停计时");
            _switchButton.Location = new Point(
                0,
                ClientSize.Height * 3 / 4 - _switchButton.ClientSize.Height / 2
            );
        }
        
        Controls.Add(_startButton);
        Controls.Add(_stopButton);
        Controls.Add(_switchButton);
    }
}