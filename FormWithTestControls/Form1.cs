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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormWithTestControls
{
    public partial class Form1 : Form
    {
        private clsComboboxItems mclsComboboxItems=new clsComboboxItems();
        private clsForm mclsForm = new clsForm();
        string mstrDecimalPoint;

        public Form1()
        {
            InitializeComponent();
            mclsForm.YesNo = null;
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentUICulture;
            mstrDecimalPoint = ci.NumberFormat.NumberDecimalSeparator;
        }

        private class clsItem
        {
            public long ID { get; set; }
            public string ComboboxText { get; set; }
        }

        private class clsForm
        {
            public bool? New { get; set; }
            public bool? Changed { get; set; }
            public string Text { get; set; }
            public int? Integer { get; set; }
            public double? Float { get; set; }
            public DateTime? Date { get; set; }
            public int? ComboID { get; set; }
            public bool? YesNo { get; set; }
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

        private void chkYes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYes.Checked == true && chkNo.Checked == true) {chkNo.Checked = false;}
            if (chkYes.Checked == true) { mclsForm.YesNo = true; }
            else { if (chkNo.Checked == true) { mclsForm.YesNo = false; } else { mclsForm.YesNo = null; } }
        }

        private void chkNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYes.Checked == true && chkNo.Checked == true) {chkYes.Checked = false;}
            if (chkYes.Checked == true) { mclsForm.YesNo = true; }
            else { if (chkNo.Checked == true) { mclsForm.YesNo = false; } else { mclsForm.YesNo = null; } }
        }

        private void txtInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))) {e.Handled = true;}
        }

        private void txtInteger_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox txtObj = sender as System.Windows.Forms.TextBox;
            if (txtObj.Text == "") { mclsForm.Integer = null; }
            else { mclsForm.Integer = Convert.ToInt32(txtObj.Text); }
        }

        private void txtFloat_KeyPress(object sender, KeyPressEventArgs e)
        {
            string st = "0123456789." + (char)8;

            System.Windows.Forms.TextBox txtObj = sender as System.Windows.Forms.TextBox;
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
            System.Windows.Forms.TextBox txtObj = sender as System.Windows.Forms.TextBox;
            //string strTemp;
            //strTemp = Convert.ToString(Convert.ToDouble(txtObj.Text));
            //txtObj.Text = strTemp;
            if (txtObj.Text.StartsWith(".")) { txtObj.Text = "0" + txtObj.Text; }
            if (txtObj.Text.EndsWith(".")) { txtObj.Text = txtObj.Text.Replace(".", ""); }

            if (txtObj.Text == "") {mclsForm.Float = null;}
            else {mclsForm.Float = Convert.ToDouble(txtObj.Text.Replace(".", mstrDecimalPoint));}
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            { 
                dateTimePicker1.CustomFormat = " ";
                mclsForm.Date = null;
            }
            else
            { dateTimePicker1.CustomFormat = "dd/MMM/yyyy"; }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MMM/yyyy";
            if (dateTimePicker1.CustomFormat == " ")
            { mclsForm.Date = null; }
            else 
            { mclsForm.Date = dateTimePicker1.Value; }
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
            cmbCombobox.Items.Clear();
            //Add an empty on top (NULL)
            cmbCombobox.Items.Add("");
            for (int i = 1; i <= mclsComboboxItems.Count; i++)
            {
                cmbCombobox.Items.Add(mclsComboboxItems.Item(i-1).ComboboxText);
            }
        }
    }
}
