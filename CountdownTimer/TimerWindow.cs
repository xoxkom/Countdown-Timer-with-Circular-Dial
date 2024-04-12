namespace CountdownTimer;

public partial class TimerWindow : Form
{
    public TimerWindow()
    {
        InitializeComponent();
        SetStyle(ControlStyles.AllPaintingInWmPaint | 
                 ControlStyles.UserPaint |
                 ControlStyles.DoubleBuffer, true);
        MinimizeBox = false;
    }
}