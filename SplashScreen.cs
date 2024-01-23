using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace RL_RoseLone
{
    public partial class splashscreen : Form
    {
        public splashscreen()
        {
            InitializeComponent();
        }

        private int counter = 0;

        private void splashscreen_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(CheckInternet);
            t.Start();
        }

        private void CheckInternet(object sender, EventArgs e)
        {
            // İnternet bağlantısını kontrol edin
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                // İnternet bağlantısı varsa, loadingtxt'ye Bağlantı kuruldu yazın
                loadingtxt.Text = "Bağlantı kuruldu";

                // Timer'ı durdurun
                (sender as Timer).Stop();

                // Yeni Timer oluşturun ve her 2000 milisaniye (2 saniye) çalışması için ayarlayın
                Timer t = new Timer();
                t.Interval = 100;
                t.Tick += new EventHandler(UpdateUI);
                t.Start();
            }
            else
            {
                // İnternet bağlantısı yoksa, loadingtxt'ye Bağlantı kurulamadı yazın
                loadingtxt.Text = "Bağlantı kurulamadı. Yeniden deneniyor...";
            }
        }

        private void UpdateUI(object sender, EventArgs e)
        {
            // Loadingbarı 10 arttırın
            loadingBar.Value = Math.Min(loadingBar.Value + 10, 100);

            // Her 2 saniye, loadingtxt'nin metnini değiştirin
            counter++;
            if (counter == 2 || counter == 4 || counter == 6 || counter == 8)
            {
                switch (counter)
                {
                    case 2:
                        loadingtxt.Text = "Kontrol Ediliyor...";
                        break;
                    case 4:
                        loadingtxt.Text = "Kontrol Edildi";
                        break;
                    case 6:
                        loadingtxt.Text = "Kontrol Başarılı";
                        break;
                    case 8:
                        loadingtxt.Text = "Başlatılıyor...";
                        break;
                }
            }

            // Loadingbar 100 olduğunda Login formuna geçiş yapın
            if (loadingBar.Value == 100)
            {
                Login loginForm = new Login();
                loginForm.Show();
                (sender as Timer).Stop();
                Hide();
            }
        }
    }
}
