namespace CountdownTimer;

public class ControlButton : UserControl
{
    private Button? _button;
    private readonly CountdownTimer? _timer;
    private readonly int _attribute; //按钮属性，0表示开始，1表示重置，2表示暂停，3表示继续

    public ControlButton(CountdownTimer timer, string attribute)
    {
        _timer = timer;
        
        _attribute = attribute switch
        {
            "start" => 0,
            "stop" => 1,
            "pause" => 2,
            "continue" => 3,
            _ => -1
        };

        InitButton();
    }
    
    private void InitButton()
    {
        _button = new Button();
        _button.Size = new Size(200, 55);
        Size = _button.Size;
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
                _timer.PauseCountdownTimer();
                break;
            case 3:
                _timer.ContinueCountdownTimer();
                break;
        }
    }

    public void SetButtonText(int fontSize, string text)
    {
        if (_button != null)
        {
            _button.Font = new Font("Arial", fontSize, FontStyle.Bold);
            _button.Text = text;
            _button.Invalidate();
        }
        
    }
}