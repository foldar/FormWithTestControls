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
            this.lblText = new System.Windows.Forms.Label();
            this.lblInteger = new System.Windows.Forms.Label();
            this.lblFloat = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblComboBox = new System.Windows.Forms.Label();
            this.chkMale = new System.Windows.Forms.CheckBox();
            this.chkFemale = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.txtInteger = new System.Windows.Forms.TextBox();
            this.txtFloat = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.txtFloat);
            this.panel1.Controls.Add(this.txtInteger);
            this.panel1.Controls.Add(this.txtText);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.chkFemale);
            this.panel1.Controls.Add(this.chkMale);
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
            // chkMale
            // 
            this.chkMale.AutoSize = true;
            this.chkMale.Location = new System.Drawing.Point(17, 182);
            this.chkMale.Name = "chkMale";
            this.chkMale.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.chkMale.Size = new System.Drawing.Size(59, 17);
            this.chkMale.TabIndex = 5;
            this.chkMale.Text = "Male";
            this.chkMale.UseVisualStyleBackColor = true;
            // 
            // chkFemale
            // 
            this.chkFemale.AutoSize = true;
            this.chkFemale.Location = new System.Drawing.Point(85, 182);
            this.chkFemale.Name = "chkFemale";
            this.chkFemale.Size = new System.Drawing.Size(60, 17);
            this.chkFemale.TabIndex = 6;
            this.chkFemale.Text = "Female";
            this.chkFemale.UseVisualStyleBackColor = true;
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(147, 152);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(131, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(142, 23);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(135, 20);
            this.txtText.TabIndex = 10;
            // 
            // txtInteger
            // 
            this.txtInteger.Location = new System.Drawing.Point(142, 50);
            this.txtInteger.Name = "txtInteger";
            this.txtInteger.Size = new System.Drawing.Size(135, 20);
            this.txtInteger.TabIndex = 11;
            // 
            // txtFloat
            // 
            this.txtFloat.Location = new System.Drawing.Point(142, 81);
            this.txtFloat.Name = "txtFloat";
            this.txtFloat.Size = new System.Drawing.Size(135, 20);
            this.txtFloat.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "DD-MMM-YYYY";
            this.dateTimePicker1.Location = new System.Drawing.Point(146, 118);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker1.TabIndex = 13;
            this.dateTimePicker1.Value = new System.DateTime(2022, 11, 28, 0, 0, 0, 0);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 355);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkFemale;
        private System.Windows.Forms.CheckBox chkMale;
        private System.Windows.Forms.Label lblComboBox;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblFloat;
        private System.Windows.Forms.Label lblInteger;
        private System.Windows.Forms.Label lblText;
    }
}

