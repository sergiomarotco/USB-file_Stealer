using System.Drawing;

using System.Windows.Forms;

namespace USBfileStealer
{
    public partial class about : Form
    {
        public about(Icon ico)
        {
            InitializeComponent();
            this.Icon = ico;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://habrahabr.ru/users/protos/");
        }

        private void about_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/sergiomarotco/USB-file_Stealer");
        }
    }
}
