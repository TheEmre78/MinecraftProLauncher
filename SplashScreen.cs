using System.Linq;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
                loadingbar.Width += 50;
                if (loadingbar.Width == 600)
                {
                    sayac.Stop();
                    Login giris = new Login();
                    giris.Show();
                    Hide();
                }
        }

        private void splashscreen_Load(object sender, EventArgs e)
        {
            loadingbar.Width = 0;
            sayac.Start();
        }
    }
}
