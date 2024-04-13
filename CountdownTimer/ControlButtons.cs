namespace CountdownTimer;

public class ControlButtons : UserControl
{
    private readonly CountdownTimer? _timer;
    private ControlButton? _startButton, _stopButton, _pauseButton, _continueButton;

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
        Location = new Point(1080, 0);
        
        Resize += OnResize;
    }
    
    private void OnResize(object? sender, EventArgs e)
    {
        if (Parent != null)
        {
            Location = new Point(Parent.ClientSize.Width - Parent.ClientSize.Height / 2, 0);
        }

        if (_startButton != null)
        {
            _startButton.Location = new Point(
                0,
                ClientSize.Height / 5 - _startButton.ClientSize.Height / 2
            );
        }

        if (_stopButton != null)
        {
            _stopButton.Location = new Point(
                0,
                ClientSize.Height * 2 / 5 - _stopButton.ClientSize.Height / 2
            );
        }

        if (_pauseButton != null)
        {
            _pauseButton.Location = new Point(
                0,
                ClientSize.Height * 3 / 5 - _pauseButton.ClientSize.Height / 2
            );
        }

        if (_continueButton != null)
        {
            _continueButton.Location = new Point(
                0,
                ClientSize.Height * 4 / 5 - _continueButton.ClientSize.Height / 2
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
                ClientSize.Height / 5 - _startButton.ClientSize.Height / 2
            );

            _stopButton = new ControlButton(_timer, "stop");
            _stopButton.SetButtonText(ClientSize.Width / 15, "停止计时");
            _stopButton.Location = new Point(
                0,
                ClientSize.Height * 2 / 5 - _stopButton.ClientSize.Height / 2
            );
            
            _pauseButton = new ControlButton(_timer, "pause");
            _pauseButton.SetButtonText(ClientSize.Width / 15, "暂停计时");
            _pauseButton.Location = new Point(
                0,
                ClientSize.Height * 3 / 5 - _pauseButton.ClientSize.Height / 2
            );

            _continueButton = new ControlButton(_timer, "continue");
            _continueButton.SetButtonText(ClientSize.Width / 15, "继续计时");
            _continueButton.Location = new Point(
                0,
                ClientSize.Height * 4 / 5 - _continueButton.ClientSize.Height / 2
            );
        }
        
        Controls.Add(_startButton);
        Controls.Add(_stopButton);
        Controls.Add(_pauseButton);
        Controls.Add(_continueButton);
    }
}