using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormWithTestControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkMale_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMale.Checked == true && chkFemale.Checked == true) {chkFemale.Checked = false;}
        }

        private void chkFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMale.Checked == true && chkFemale.Checked == true) {chkMale.Checked = false;}
        }

        private void txtInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))) {e.Handled = true;}
        }

        private void txtFloat_KeyPress(object sender, KeyPressEventArgs e)
        {
            string st = "0123456789." + (char)8;
            TextBox txtObj = sender as TextBox;
            if (st.IndexOf(e.KeyChar) == -1)
            {
               e.Handled = true;
            }
            if (e.KeyChar == '.' && (txtObj.Text =="" || txtObj.Text.IndexOf('.') != -1))
            {
                e.Handled = true;
            }
        }
    }
}
