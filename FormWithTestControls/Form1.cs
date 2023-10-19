using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormWithTestControls
{
    public partial class Form1 : Form
    {
        private clsComboboxItems mclsComboboxItems=new clsComboboxItems();

        public Form1()
        {
            InitializeComponent();
        }

        private class clsItem
        {
            public long ID { get; set; }
            public string ComboboxText { get; set; }
        }

        private class clsComboboxItems
        {
            private List<clsItem> mclsItems = new List<clsItem>();

            public void AddItem(clsItem mclsitem)
            {
                mclsItems.Add(mclsitem);
            }

            //Dit is een property (geen parameter)
            public long Count
            {
                get => mclsItems.Count;
            }

            // Property met parameter is niet mogelijk in C#. Daarom is het hier een functie.
            public clsItem Item(int index)
            {
                return mclsItems[index];
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkMale_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYes.Checked == true && chkNo.Checked == true) {chkNo.Checked = false;}
        }

        private void chkFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYes.Checked == true && chkNo.Checked == true) {chkYes.Checked = false;}
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

        private void txtFloat_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtObj = sender as TextBox;
            //string strTemp;
            //strTemp = Convert.ToString(Convert.ToDouble(txtObj.Text));
            //txtObj.Text = strTemp;
            if (txtObj.Text.StartsWith(".")) { txtObj.Text = "0" + txtObj.Text; }
            if (txtObj.Text.EndsWith(".")) { txtObj.Text = txtObj.Text.Replace(".", ""); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillCombobox();
        }

        private void FillCombobox()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
              "Data Source=localhost;" +
              "Initial Catalog=Northwind;" +
              "Integrated Security=SSPI;";
            try
            {
                conn.Open();
                String sql = "Select TestID, TestDescription from dbo.TestDropdown ORDER BY TestDescription ASC";

                SqlCommand command = new SqlCommand(sql, conn);
                {
                    SqlDataReader reader = command.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            clsItem clsitem = new clsItem();
                            clsitem.ID = reader.GetInt32(0);
                            clsitem.ComboboxText = reader.GetString(1);
                            mclsComboboxItems.AddItem(clsitem);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
            }
        }
    }
}
