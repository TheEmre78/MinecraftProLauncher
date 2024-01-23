using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void kapatbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void girisbtn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
            //  MessageBox.Show("Kullanıcı adı boş bırakılamaz","Hata",MessageBoxButtons.OK , MessageBoxIcon.Error ); Bu 1. yöntem (Alttaki kodu aktif ettiyseniz bunu silin!)
                guna2HtmlLabel1.Visible = true;
            }
            else
            {

                Main anapanel = new Main();
                anapanel.Show();
                Hide();
                Save_Data();
            }
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
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
