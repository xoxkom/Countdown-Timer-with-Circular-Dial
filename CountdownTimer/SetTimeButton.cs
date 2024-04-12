namespace CountdownTimer;

public class SetTimeButton : UserControl
{
    private Button? _button;
    private readonly CountdownTimer? _timer;
    private readonly int _countdownMinutes;

    public SetTimeButton(CountdownTimer timer, int minutes = 1)
    {
        _timer = timer;
        _countdownMinutes = minutes;
        
        InitButton();
    }

    private void InitButton()
    {
        //AutoSize = true;
        
        _button = new Button();
        //_button.Text = $"{_countdownMinutes}分钟";
        //_button.AutoSize = true;
        _button.Size = new Size(170, 55);
        Size = _button.Size;
        _button.Click += ButtonController;
        Controls.Add(_button);
    }

    private void ButtonController(object? sender, EventArgs e)
    {
        if (_timer == null || _timer.GetTimerStatus() != CountdownTimer.TimerStatus.Stopped) return;
        _timer.StopCountdownTimer();
        _timer.SetCountdownSeconds(_countdownMinutes * 60);
    }

    public void SetButtonText(int fontSize, string text)
    {
        if (_button == null) return;
        _button.Font = new Font("Arial", fontSize, FontStyle.Bold);
        _button.Text = text;
    }
}