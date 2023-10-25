namespace FormWithTestControls
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtFloat = new System.Windows.Forms.TextBox();
            this.txtInteger = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.cmbCombobox = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkNo = new System.Windows.Forms.CheckBox();
            this.chkYes = new System.Windows.Forms.CheckBox();
            this.lblComboBox = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblFloat = new System.Windows.Forms.Label();
            this.lblInteger = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.txtFloat);
            this.panel1.Controls.Add(this.txtInteger);
            this.panel1.Controls.Add(this.txtText);
            this.panel1.Controls.Add(this.cmbCombobox);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.chkNo);
            this.panel1.Controls.Add(this.chkYes);
            this.panel1.Controls.Add(this.lblComboBox);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblFloat);
            this.panel1.Controls.Add(this.lblInteger);
            this.panel1.Controls.Add(this.lblText);
            this.panel1.Location = new System.Drawing.Point(6, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 331);
            this.panel1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "DD-MMM-YYYY";
            this.dateTimePicker1.Location = new System.Drawing.Point(146, 118);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 13;
            this.dateTimePicker1.Value = new System.DateTime(2022, 11, 28, 0, 0, 0, 0);
            // 
            // txtFloat
            // 
            this.txtFloat.Location = new System.Drawing.Point(142, 81);
            this.txtFloat.Name = "txtFloat";
            this.txtFloat.Size = new System.Drawing.Size(200, 20);
            this.txtFloat.TabIndex = 12;
            this.txtFloat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFloat_KeyPress);
            this.txtFloat.Validating += new System.ComponentModel.CancelEventHandler(this.txtFloat_Validating);
            // 
            // txtInteger
            // 
            this.txtInteger.Location = new System.Drawing.Point(142, 50);
            this.txtInteger.Name = "txtInteger";
            this.txtInteger.Size = new System.Drawing.Size(200, 20);
            this.txtInteger.TabIndex = 11;
            this.txtInteger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteger_KeyPress);
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(142, 23);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(200, 20);
            this.txtText.TabIndex = 10;
            // 
            // cmbCombobox
            // 
            this.cmbCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCombobox.FormattingEnabled = true;
            this.cmbCombobox.Location = new System.Drawing.Point(147, 152);
            this.cmbCombobox.Name = "cmbCombobox";
            this.cmbCombobox.Size = new System.Drawing.Size(200, 21);
            this.cmbCombobox.TabIndex = 9;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(130, 288);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 26);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(18, 291);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 24);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // chkNo
            // 
            this.chkNo.AutoSize = true;
            this.chkNo.Location = new System.Drawing.Point(85, 182);
            this.chkNo.Name = "chkNo";
            this.chkNo.Size = new System.Drawing.Size(40, 17);
            this.chkNo.TabIndex = 6;
            this.chkNo.Text = "No";
            this.chkNo.UseVisualStyleBackColor = true;
            this.chkNo.CheckedChanged += new System.EventHandler(this.chkFemale_CheckedChanged);
            // 
            // chkYes
            // 
            this.chkYes.AutoSize = true;
            this.chkYes.Location = new System.Drawing.Point(17, 182);
            this.chkYes.Name = "chkYes";
            this.chkYes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.chkYes.Size = new System.Drawing.Size(54, 17);
            this.chkYes.TabIndex = 5;
            this.chkYes.Text = "Yes";
            this.chkYes.UseVisualStyleBackColor = true;
            this.chkYes.CheckedChanged += new System.EventHandler(this.chkMale_CheckedChanged);
            // 
            // lblComboBox
            // 
            this.lblComboBox.AutoSize = true;
            this.lblComboBox.Location = new System.Drawing.Point(18, 152);
            this.lblComboBox.Name = "lblComboBox";
            this.lblComboBox.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblComboBox.Size = new System.Drawing.Size(67, 13);
            this.lblComboBox.TabIndex = 4;
            this.lblComboBox.Text = "Combobox";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 118);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblDate.Size = new System.Drawing.Size(40, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date";
            // 
            // lblFloat
            // 
            this.lblFloat.AutoSize = true;
            this.lblFloat.Location = new System.Drawing.Point(21, 84);
            this.lblFloat.Name = "lblFloat";
            this.lblFloat.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblFloat.Size = new System.Drawing.Size(80, 13);
            this.lblFloat.TabIndex = 2;
            this.lblFloat.Text = "Floating point";
            // 
            // lblInteger
            // 
            this.lblInteger.AutoSize = true;
            this.lblInteger.Location = new System.Drawing.Point(18, 50);
            this.lblInteger.Name = "lblInteger";
            this.lblInteger.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblInteger.Size = new System.Drawing.Size(50, 13);
            this.lblInteger.TabIndex = 1;
            this.lblInteger.Text = "Integer";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(15, 20);
            this.lblText.Name = "lblText";
            this.lblText.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblText.Size = new System.Drawing.Size(38, 13);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Text";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 355);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtFloat;
        private System.Windows.Forms.TextBox txtInteger;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.ComboBox cmbCombobox;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkNo;
        private System.Windows.Forms.CheckBox chkYes;
        private System.Windows.Forms.Label lblComboBox;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblFloat;
        private System.Windows.Forms.Label lblInteger;
        private System.Windows.Forms.Label lblText;
    }
}

