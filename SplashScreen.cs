using CmlLib.Core.Auth;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RL_RoseLone
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Init_Data();
        }

        private void CloseBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            girisbtn.Enabled = txtUsername.Text.Length >= 2;
        }

        private void UpdateSession(MSession session)
        {
            var mainForm = new Main();
            mainForm.UpdateSession(session);
            mainForm.FormClosed += (s, e) => this.Close();
            mainForm.Show();
            this.Hide();
        }

        private void TimerEventProcessor(object sender, EventArgs e)
        {
            UpdateSession(MSession.GetOfflineSession(txtUsername.Text));
            Timer1.Stop();
        }



        private void Init_Data()
        {
            if (Properties.Settings.Default.Username != string.Empty)
            {
                if (Properties.Settings.Default.RememberMe == true)
                {
                    txtUsername.Text = Properties.Settings.Default.Username;
                    Remember.Checked = true;
                }
                else
                {
                    txtUsername.Text = Properties.Settings.Default.Username;
                }
            }
        }

        private void Save_Data()
        {
            if (Remember.Checked)
            {
                Properties.Settings.Default.Username = txtUsername.Text.Trim();
                Properties.Settings.Default.RememberMe = true;
            }
            else
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.RememberMe = false;
            }
            Properties.Settings.Default.Save();
        }
        private void girisbtn_Click(object sender, EventArgs e)
        {
            string input = txtUsername.Text.ToLower();
            if (!string.IsNullOrEmpty(txtUsername.Text) && Regex.IsMatch(txtUsername.Text, "^[a-zA-Z]+$"))
            {
                if (input.Length < 2)
                {
                    hatatxt.Text = "Lütfen 2 den fazla harf girin";
                    return;
                }
                txtUsername.Visible = false;
                guna2HtmlLabel2.Visible = false;
                Remember.Visible = false;
                girisbtn.Visible = false;
                hatatxt.Visible = false;

                Timer1.Tick += new EventHandler(TimerEventProcessor);
                Timer1.Start();

                loadingbar.Visible = true;

                Save_Data();
            }
            else
            {
                hatatxt.Text = "Lütfen sadece ingilizce harfler kullanın";
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
