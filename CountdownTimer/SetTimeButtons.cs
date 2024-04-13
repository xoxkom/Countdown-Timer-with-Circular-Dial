namespace CountdownTimer;

public class SetTimeButtons : UserControl
{
    private readonly CountdownTimer _timer;

    private SetTimeButton?[]? _minutes;
    
    public SetTimeButtons(CountdownTimer timer)
    {
        _timer = timer;
        
        InitControl();
        InitButtons();
    }

    private void InitControl()
    {
        Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        Size = new Size(270, 1080);
        Location = new Point(1430, 0);
        
        Resize += OnResize;
    }

    private void OnResize(object? sender, EventArgs e)
    {
        if (Parent != null)
        {
            Location = new Point(Parent.ClientSize.Width - Parent.ClientSize.Height / 4, 0);
        }

        for (var i = 1; i <= 5; i++)
        {
            if (_minutes?[i - 1] != null)
            {
                _minutes[i - 1]!.Location = new Point(
                    0,
                    ClientSize.Height * i / 8 - _minutes[i - 1]!.ClientSize.Height / 2
                );
            }
        }

        _minutes![5]!.Location = new Point(0, ClientSize.Height * 6 / 8 - _minutes[5]!.ClientSize.Height / 2);
        _minutes![6]!.Location = new Point(0, ClientSize.Height * 7 / 8 - _minutes[6]!.ClientSize.Height / 2);

        foreach (var m in _minutes)
        {
            Controls.Add(m);
        }
    }

    private void InitButtons()
    {
        _minutes = new SetTimeButton[7];
        for(var i = 1; i <= 5; i++)
        {
           _minutes[i - 1] = new SetTimeButton(_timer, i);
        }
        _minutes[5] = new SetTimeButton(_timer, 12);
        _minutes[6] = new SetTimeButton(_timer, 13);

        for (var i = 1; i <= 5; i++)
        {
            _minutes[i - 1]?.SetButtonText(ClientSize.Width / 15, $"{i}分钟");
        }
        _minutes[5]?.SetButtonText(ClientSize.Width / 15, "12分钟");
        _minutes[6]?.SetButtonText(ClientSize.Width / 15, "13分钟");

        for (var i = 1; i <= 5; i++)
        {
            if (_minutes[i - 1] != null)
            {
                _minutes[i - 1]!.Location = new Point(
                    0,
                    ClientSize.Height * i / 8 - _minutes[i - 1]!.ClientSize.Height / 2
                );
            }
        }

        _minutes[5]!.Location = new Point(0, ClientSize.Height * 6 / 8 - _minutes[5]!.ClientSize.Height / 2);
        _minutes[6]!.Location = new Point(0, ClientSize.Height * 7 / 8 - _minutes[6]!.ClientSize.Height / 2);

        foreach (var m in _minutes)
        {
            Controls.Add(m);
        }
    }
}