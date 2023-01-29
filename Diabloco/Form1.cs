namespace Diabloco;
public partial class Form1 : Form
{
    private readonly BattleNetHosts _hosts;
    private readonly ILanguage _language;
    public Form1()
    {
        InitializeComponent();

        _language = new EnglishLanguage();
        var isoLanguage = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower();
        if (isoLanguage is "pt" or "br")
            _language = new PortugueseLanguage();
        _hosts = new(_language);
        MessageBox.Show(_language.Warning, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        Text = "Diabloco - Diablo III Private Server";
        this.MinimumSize = new Size(Width, Height);
        this.MaximumSize = this.MinimumSize;
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        applyButton.ForeColor = Color.White;
        if (_hosts.HasBattleNet())
        {
            statusLabel.ForeColor = Color.Green;
            statusLabel.Text = _language.Enabled;
            applyButton.BackColor = Color.Red;
            applyButton.Text = _language.Disable;
        }
        else
        {
            statusLabel.ForeColor = Color.Red;
            statusLabel.Text = _language.Disabled;
            applyButton.BackColor = Color.Green;
            applyButton.Text = _language.Enable;
        }
    }

    private async void applyButton_Click(object sender, EventArgs e)
    {
        applyButton.Enabled = false;
        applyButton.BackColor = Color.BlueViolet;
        await Task.Yield();
        if (_hosts.HasBattleNet())
        {
            _hosts.RemoveBattleNetHosts();
        }
        else
        {
            _hosts.AddBattleNetHosts();
        }
        applyButton.Enabled = true;
        UpdateStatus();
    }
}
