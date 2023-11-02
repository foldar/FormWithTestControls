using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            mclsForm.TestYesNo = null;
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentUICulture;
            mstrDecimalPoint = ci.NumberFormat.NumberDecimalSeparator;
        }

        private class clsItem
        {
            public int ID { get; set; }
            public string ComboboxText { get; set; }
        }

        private class clsForm
        {
            private bool? booNew;
            public bool? New 
            {
                get { return booNew; }
                set { booNew = value; }
            }

            private bool? booChanged;
            public bool? Changed
            {
                get { return booChanged; }
                set { booChanged = value; }
            }

            private int intTestID;
            public int TestID 
            {
                get { return intTestID; }
                set { intTestID = value; }
            }

            private string strTestText;
            public string TestText
            {
                get {return strTestText; }
                set {strTestText=value; }
            }

            private int? intTestInteger;
            public int? TestInteger 
            {
                get {return intTestInteger; }
                set {intTestInteger = value; }
            }

            private float? floTestFloat;
            public float? TestFloat 
            {
                get { return floTestFloat; }
                set { floTestFloat = value; } 
            }

            private DateTime? datTestDate;
            public DateTime? TestDate 
            {
                get {return datTestDate; }
                set {datTestDate = value; } 
            }

            private int? intTestComboID;
            public int? TestComboID 
            {
                get {return intTestComboID; }
                set {intTestComboID = value; } 
            }

            private bool? booTestYesNo;
            public bool? TestYesNo 
            {
                get {return booTestYesNo; }
                set {booTestYesNo = value; }
            }
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
            if (chkYes.Checked == true) { mclsForm.TestYesNo = true; }
            else { if (chkNo.Checked == true) { mclsForm.TestYesNo = false; } else { mclsForm.TestYesNo = null; } }
        }

        private void chkNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYes.Checked == true && chkNo.Checked == true) {chkYes.Checked = false;}
            if (chkYes.Checked == true) { mclsForm.TestYesNo = true; }
            else { if (chkNo.Checked == true) { mclsForm.TestYesNo = false; } else { mclsForm.TestYesNo = null; } }
        }

        private void txtInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))) {e.Handled = true;}
        }

        private void txtInteger_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox txtObj = sender as System.Windows.Forms.TextBox;
            if (txtObj.Text == "") { mclsForm.TestInteger = null; }
            else { mclsForm.TestInteger = Convert.ToInt32(txtObj.Text); }
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

            if (txtObj.Text == "") {mclsForm.TestFloat = null;}
            else {mclsForm.TestFloat = Convert.ToSingle(txtObj.Text.Replace(".", mstrDecimalPoint));}
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            { 
                dateTimePicker1.CustomFormat = " ";
                mclsForm.TestDate = null;
            }
            else
            { dateTimePicker1.CustomFormat = "dd/MMM/yyyy"; }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MMM/yyyy";
            if (dateTimePicker1.CustomFormat == " ")
            { mclsForm.TestDate = null; }
            else 
            { mclsForm.TestDate = dateTimePicker1.Value; }
        }

        private void cmbCombobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbCombobox.SelectedIndex == 0)
            { mclsForm.TestComboID = null; }
            else
            { mclsForm.TestComboID = mclsComboboxItems.Item(cmbCombobox.SelectedIndex).ID; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillCombobox();
            FillForm();
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

        private void FillForm()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
              "Data Source=localhost;" +
              "Initial Catalog=Northwind;" +
              "Integrated Security=SSPI;";
            try
            {
                conn.Open();
                String sql = "Select TestID, TestText, TestInteger, TestFloatingPoint, TestDate, TestCombobox, TestYesNo from dbo.TestTable";

                SqlCommand command = new SqlCommand(sql, conn);
                {
                    SqlDataReader reader = command.ExecuteReader();
                    {
                        mclsForm.New = true;
                        while (reader.Read())
                        {
                            mclsForm.TestID = reader.GetInt32(0);
                            mclsForm.TestText = reader.GetString(1);
                            txtText.Text = mclsForm.TestText;
                            mclsForm.TestInteger = reader.GetInt32(2);
                            txtInteger.Text = Convert.ToString(mclsForm.TestInteger);
                            mclsForm.TestFloat = reader.GetFloat(3);
                            txtFloat.Text = Convert.ToString(mclsForm.TestFloat).Replace(",",".");
//                          doesnt work cant put datetime in datetime?
//                            mclsForm.TestDate = reader.GetDateTime(4);
//                            if (mclsForm.TestDate == null)
//                            { dateTimePicker1.CustomFormat= " ";}
//                            else
//                            {
//                                dateTimePicker1.CustomFormat = "dd/MMM/yyyy";
//                                dateTimePicker1.Value = Convert.ToDateTime(mclsForm.TestDate);
//                            }
                            mclsForm.TestComboID = reader.GetInt32(5);
                            mclsForm.TestYesNo = reader.GetBoolean(6);
                            if (mclsForm.TestYesNo == true) { chkYes.Checked = true; }
                            else                            { chkNo.Checked = true; }                          mclsForm.Changed = false;
                            mclsForm.New = false;
                            mclsForm.Changed = false;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                mclsForm.Changed = false;
                mclsForm.New = false;
                mclsForm.TestID = 0;
                mclsForm.TestText = "";
                mclsForm.TestInteger = null;
                mclsForm.TestFloat = null;
                mclsForm.TestDate = null;
                mclsForm.TestComboID = null;
                mclsForm.TestYesNo = null;
            }
        }
    }
}
