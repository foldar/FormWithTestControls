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
            private int intID;
            public int ID
            {
                get { return intID; }
                set { intID=value; }
            }

            private string strComboboxText;
            public string ComboboxText 
            {
                get {return strComboboxText; }
                set {strComboboxText=value; } 
            }
        }

        private class clsForm
        {
            private bool booNew;
            public bool New 
            {
                get { return booNew; }
                set { booNew = value; }
            }

            private bool booChanged;
            public bool Changed
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

            private bool booTestDateEmpty;
            public bool TestDateEmpty
            {
                get { return booTestDateEmpty; }
                set { booTestDateEmpty = value; }
            }

            private DateTime datTestDate;
            public DateTime TestDate
            {
                get { return datTestDate; }
                set { datTestDate = value; }
            }

            //private DateTime? datTestDate;
            //public DateTime? TestDate 
            //{
            //    get {return datTestDate; }
            //    set {datTestDate = value; } 
            //}

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

            public void DeleteRecord()
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                  "Data Source=localhost;" +
                  "Initial Catalog=Northwind;" +
                  "Integrated Security=SSPI;";
                try
                {
                    conn.Open();
                    //Must be a transaction so it can be committed.Without commit it doesent work.
                    SqlTransaction objTrans = conn.BeginTransaction();
                    String sql = "DELETE FROM dbo.TestTable";

                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Transaction = objTrans;
                    {
                        command.ExecuteNonQuery();
                        objTrans.Commit();
                    }
                }
                catch (SqlException e)
                {
                }
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

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            mclsForm.Changed = true;
            btnSave.Enabled = true;
        }
        private void chkYes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYes.Checked == true && chkNo.Checked == true) {chkNo.Checked = false;}
            if (chkYes.Checked == true) { mclsForm.TestYesNo = true; }
            else { if (chkNo.Checked == true) { mclsForm.TestYesNo = false; } else { mclsForm.TestYesNo = null; } }
            mclsForm.Changed = true;
            btnSave.Enabled = true;
        }

        private void chkNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYes.Checked == true && chkNo.Checked == true) {chkYes.Checked = false;}
            if (chkYes.Checked == true) { mclsForm.TestYesNo = true; }
            else { if (chkNo.Checked == true) { mclsForm.TestYesNo = false; } else { mclsForm.TestYesNo = null; } }
            mclsForm.Changed = true;
            btnSave.Enabled = true;
        }

        private void txtInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                mclsForm.Changed = true;
                btnSave.Enabled = true;
            }
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
            if (e.Handled==false)
            {
                mclsForm.Changed = true;
                btnSave.Enabled = true;
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
                mclsForm.TestDateEmpty = true;
                //                mclsForm.TestDate = null;
            }
            else
            { 
                dateTimePicker1.CustomFormat = "dd/MMM/yyyy";
            }
            mclsForm.Changed = true;
            btnSave.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MMM/yyyy";
            if (dateTimePicker1.CustomFormat == " ")
            { 
 //                mclsForm.TestDate = null;
                mclsForm.TestDateEmpty = true;
            }
            else 
            {
                mclsForm.TestDateEmpty = false;
                mclsForm.TestDate = dateTimePicker1.Value; 
            }
            mclsForm.Changed = true;
            btnSave.Enabled = true;
        }

        private void cmbCombobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbCombobox.SelectedIndex == 0)
            { mclsForm.TestComboID = null; }
            else
            { mclsForm.TestComboID = mclsComboboxItems.Item(cmbCombobox.SelectedIndex).ID; }
            mclsForm.Changed = true;
            btnSave.Enabled = true;
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
                            try
                            {
                                mclsForm.TestText = reader.GetString(1);
                            }
                            catch
                            {
                                mclsForm.TestText = "";
                            }
                            txtText.Text = mclsForm.TestText;
                            try
                            {
                                mclsForm.TestInteger = reader.GetInt32(2);
                            }
                            catch
                            {
                                mclsForm.TestInteger = null;
                            }
                            txtInteger.Text = Convert.ToString(mclsForm.TestInteger);
                            try 
                            {
                                mclsForm.TestFloat = reader.GetFloat(3);
                            }
                            catch
                            { 
                                mclsForm.TestFloat = null;
                            }
                            txtFloat.Text = Convert.ToString(mclsForm.TestFloat).Replace(",",".");
                            //try
                            //{
                            //    mclsForm.TestDate = (DateTime)reader.GetSqlDateTime(4);
                            //    mclsForm.TestDate = (DateTime)reader.GetSqlDateTime(4);
                            //}
                            //catch (Exception e)
                            //{
                            //    mclsForm.TestDate = null;
                            //}

                            try
                            {
                                mclsForm.TestDate = (DateTime)reader.GetValue(4);
                                mclsForm.TestDateEmpty = false;
                                dateTimePicker1.CustomFormat = "dd/MMM/yyyy";
                                dateTimePicker1.Value=mclsForm.TestDate;
                            }
                            catch (Exception e)
                            {
                                mclsForm.TestDateEmpty = true;
                                dateTimePicker1.CustomFormat = " ";
                            }

                            try
                            {
                                mclsForm.TestComboID = reader.GetInt32(5);
                            }
                            catch
                            {
                                mclsForm.TestComboID = null;
                            }
                            SelectComboBox();
                            try
                            {
                                mclsForm.TestYesNo = reader.GetBoolean(6);
                            }
                            catch
                            {
                                mclsForm.TestYesNo = null;
                            }
                            if (mclsForm.TestYesNo == true) 
                                { 
                                    chkYes.Checked = true; 
                                    chkNo.Checked = false;
                                }
                            else
                                if (mclsForm.TestYesNo == false)
                                {
                                    chkYes.Checked = false;
                                    chkNo.Checked = true;
                                }
                                else
                                    { 
                                        chkYes.Checked = false;
                                        chkNo.Checked = false;
                                    }
                            mclsForm.Changed = false;
                            mclsForm.New = false;
                            mclsForm.Changed = false;
                        }
                        btnDelete.Enabled = !mclsForm.New;
                    // Always disabled when nothing has been changed yet
                        btnSave.Enabled = false;
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
                mclsForm.TestDateEmpty = true;
                mclsForm.TestComboID = null;
                mclsForm.TestYesNo = null;
            }
        }

        private void SelectComboBox()
        {
            if (mclsForm.TestID == null) { cmbCombobox.SelectedIndex = 0; }
            else
            {
                for (int i = 1; i <= mclsComboboxItems.Count - 1; i++)
                {
                    if (mclsComboboxItems.Item(i).ID == mclsForm.TestComboID)
                    { cmbCombobox.SelectedIndex = i+1; break; }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mclsForm.DeleteRecord();
            FillForm();
        }
    }
}
