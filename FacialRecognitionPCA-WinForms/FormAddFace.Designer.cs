namespace FacialRecognitionPCA_WinForms
{
    partial class FormAddFace
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
            this.picBoxAddFace = new System.Windows.Forms.PictureBox();
            this.txName = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.txID = new MetroFramework.Controls.MetroTextBox();
            this.txPhone = new MetroFramework.Controls.MetroTextBox();
            this.cbGender = new MetroFramework.Controls.MetroComboBox();
            this.dtDOB = new MetroFramework.Controls.MetroDateTime();
            this.cbPriority = new MetroFramework.Controls.MetroComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAddFace)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBoxAddFace
            // 
            this.picBoxAddFace.BackColor = System.Drawing.Color.Gainsboro;
            this.picBoxAddFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picBoxAddFace.Location = new System.Drawing.Point(23, 39);
            this.picBoxAddFace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picBoxAddFace.Name = "picBoxAddFace";
            this.picBoxAddFace.Size = new System.Drawing.Size(280, 256);
            this.picBoxAddFace.TabIndex = 0;
            this.picBoxAddFace.TabStop = false;
            // 
            // txName
            // 
            // 
            // 
            // 
            this.txName.CustomButton.Image = null;
            this.txName.CustomButton.Location = new System.Drawing.Point(236, 2);
            this.txName.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txName.CustomButton.Name = "";
            this.txName.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.txName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txName.CustomButton.TabIndex = 1;
            this.txName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txName.CustomButton.UseSelectable = true;
            this.txName.CustomButton.Visible = false;
            this.txName.Lines = new string[0];
            this.txName.Location = new System.Drawing.Point(431, 79);
            this.txName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txName.MaxLength = 32767;
            this.txName.Name = "txName";
            this.txName.PasswordChar = '\0';
            this.txName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txName.SelectedText = "";
            this.txName.SelectionLength = 0;
            this.txName.SelectionStart = 0;
            this.txName.ShortcutsEnabled = true;
            this.txName.Size = new System.Drawing.Size(203, 28);
            this.txName.TabIndex = 1;
            this.txName.UseSelectable = true;
            this.txName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(564, 427);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txID
            // 
            // 
            // 
            // 
            this.txID.CustomButton.Image = null;
            this.txID.CustomButton.Location = new System.Drawing.Point(236, 2);
            this.txID.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txID.CustomButton.Name = "";
            this.txID.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.txID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txID.CustomButton.TabIndex = 1;
            this.txID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txID.CustomButton.UseSelectable = true;
            this.txID.CustomButton.Visible = false;
            this.txID.Lines = new string[0];
            this.txID.Location = new System.Drawing.Point(431, 39);
            this.txID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txID.MaxLength = 32767;
            this.txID.Name = "txID";
            this.txID.PasswordChar = '\0';
            this.txID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txID.SelectedText = "";
            this.txID.SelectionLength = 0;
            this.txID.SelectionStart = 0;
            this.txID.ShortcutsEnabled = true;
            this.txID.Size = new System.Drawing.Size(203, 28);
            this.txID.TabIndex = 5;
            this.txID.UseSelectable = true;
            this.txID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txPhone
            // 
            // 
            // 
            // 
            this.txPhone.CustomButton.Image = null;
            this.txPhone.CustomButton.Location = new System.Drawing.Point(236, 2);
            this.txPhone.CustomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txPhone.CustomButton.Name = "";
            this.txPhone.CustomButton.Size = new System.Drawing.Size(31, 28);
            this.txPhone.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txPhone.CustomButton.TabIndex = 1;
            this.txPhone.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txPhone.CustomButton.UseSelectable = true;
            this.txPhone.CustomButton.Visible = false;
            this.txPhone.Lines = new string[0];
            this.txPhone.Location = new System.Drawing.Point(431, 220);
            this.txPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txPhone.MaxLength = 32767;
            this.txPhone.Name = "txPhone";
            this.txPhone.PasswordChar = '\0';
            this.txPhone.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txPhone.SelectedText = "";
            this.txPhone.SelectionLength = 0;
            this.txPhone.SelectionStart = 0;
            this.txPhone.ShortcutsEnabled = true;
            this.txPhone.Size = new System.Drawing.Size(203, 28);
            this.txPhone.TabIndex = 6;
            this.txPhone.UseSelectable = true;
            this.txPhone.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txPhone.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cbGender
            // 
            this.cbGender.FormattingEnabled = true;
            this.cbGender.ItemHeight = 24;
            this.cbGender.Items.AddRange(new object[] {
            "- Not Defined -",
            "Male",
            "Female"});
            this.cbGender.Location = new System.Drawing.Point(431, 170);
            this.cbGender.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(201, 30);
            this.cbGender.TabIndex = 8;
            this.cbGender.UseSelectable = true;
            // 
            // dtDOB
            // 
            this.dtDOB.Location = new System.Drawing.Point(431, 119);
            this.dtDOB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtDOB.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtDOB.Name = "dtDOB";
            this.dtDOB.Size = new System.Drawing.Size(201, 30);
            this.dtDOB.TabIndex = 9;
            // 
            // cbPriority
            // 
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.ItemHeight = 24;
            this.cbPriority.Items.AddRange(new object[] {
            "Low",
            "High"});
            this.cbPriority.Location = new System.Drawing.Point(431, 265);
            this.cbPriority.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(201, 30);
            this.cbPriority.TabIndex = 10;
            this.cbPriority.UseSelectable = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picBoxAddFace);
            this.groupBox1.Controls.Add(this.metroLabel6);
            this.groupBox1.Controls.Add(this.txID);
            this.groupBox1.Controls.Add(this.dtDOB);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.metroLabel5);
            this.groupBox1.Controls.Add(this.txName);
            this.groupBox1.Controls.Add(this.txPhone);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.cbGender);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.cbPriority);
            this.groupBox1.Location = new System.Drawing.Point(31, 82);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(659, 329);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Face Information";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(344, 272);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(52, 20);
            this.metroLabel6.TabIndex = 17;
            this.metroLabel6.Text = "Priority";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(357, 127);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(38, 20);
            this.metroLabel4.TabIndex = 15;
            this.metroLabel4.Text = "DOB";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(348, 224);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(49, 20);
            this.metroLabel5.TabIndex = 16;
            this.metroLabel5.Text = "Phone";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(348, 82);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(47, 20);
            this.metroLabel3.TabIndex = 14;
            this.metroLabel3.Text = "Name";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(339, 177);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(56, 20);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "Gender";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(379, 39);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(22, 20);
            this.metroLabel1.TabIndex = 12;
            this.metroLabel1.Text = "ID";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(447, 427);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormAddFace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 476);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "FormAddFace";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Resizable = false;
            this.Text = "Add Face";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddFace_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAddFace)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxAddFace;
        private MetroFramework.Controls.MetroTextBox txName;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroTextBox txID;
        private MetroFramework.Controls.MetroTextBox txPhone;
        private MetroFramework.Controls.MetroComboBox cbGender;
        private MetroFramework.Controls.MetroDateTime dtDOB;
        private MetroFramework.Controls.MetroComboBox cbPriority;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton btnCancel;
    }
}