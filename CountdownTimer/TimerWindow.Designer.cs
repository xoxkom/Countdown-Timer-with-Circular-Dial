namespace CountdownTimer;

partial class TimerWindow
{
    private System.ComponentModel.IContainer components = null;

    private CountdownTimer _countdownTimer;

    private ControlButtons _controlButtons;

    private SetTimeButtons _setTimeButtons;
    
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.ClientSize = new System.Drawing.Size(1700, 1080);
        //this.MinimumSize = new System.Drawing.Size(1700, 1080);
        this.Text = "计时器";
        
        _countdownTimer = new CountdownTimer();
        this.Controls.Add(_countdownTimer);

        _controlButtons = new ControlButtons(_countdownTimer);
        this.Controls.Add(_controlButtons);

        _setTimeButtons = new SetTimeButtons(_countdownTimer);
        this.Controls.Add(_setTimeButtons);
    }

    #endregion
}