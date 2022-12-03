namespace SimpleTextEditor.Forms
{
    partial class NewUserForm
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
            this.newUserLbl = new System.Windows.Forms.Label();
            this.newUserTitleLbl = new System.Windows.Forms.Label();
            this.newPassLbl = new System.Windows.Forms.Label();
            this.newConfirmPassLbl = new System.Windows.Forms.Label();
            this.newDateOfBirtheLbl = new System.Windows.Forms.Label();
            this.newLastNameLbl = new System.Windows.Forms.Label();
            this.newFirstNameLbl = new System.Windows.Forms.Label();
            this.newUserTypeLbl = new System.Windows.Forms.Label();
            this.dateOfBirthPicker = new System.Windows.Forms.DateTimePicker();
            this.userTypeComboBx = new System.Windows.Forms.ComboBox();
            this.userTxtBx = new System.Windows.Forms.TextBox();
            this.passTxtBx = new System.Windows.Forms.TextBox();
            this.confirmPassTxtBx = new System.Windows.Forms.TextBox();
            this.firstNameTxtBx = new System.Windows.Forms.TextBox();
            this.lastNameTxtBx = new System.Windows.Forms.TextBox();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // newUserLbl
            // 
            this.newUserLbl.AutoSize = true;
            this.newUserLbl.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserLbl.ForeColor = System.Drawing.Color.White;
            this.newUserLbl.Location = new System.Drawing.Point(75, 177);
            this.newUserLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newUserLbl.Name = "newUserLbl";
            this.newUserLbl.Size = new System.Drawing.Size(143, 27);
            this.newUserLbl.TabIndex = 1;
            this.newUserLbl.Text = "Username : ";
            // 
            // newUserTitleLbl
            // 
            this.newUserTitleLbl.AutoSize = true;
            this.newUserTitleLbl.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserTitleLbl.ForeColor = System.Drawing.Color.White;
            this.newUserTitleLbl.Location = new System.Drawing.Point(242, 86);
            this.newUserTitleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newUserTitleLbl.Name = "newUserTitleLbl";
            this.newUserTitleLbl.Size = new System.Drawing.Size(271, 39);
            this.newUserTitleLbl.TabIndex = 3;
            this.newUserTitleLbl.Text = "Create New User";
            this.newUserTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newPassLbl
            // 
            this.newPassLbl.AutoSize = true;
            this.newPassLbl.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassLbl.ForeColor = System.Drawing.Color.White;
            this.newPassLbl.Location = new System.Drawing.Point(75, 221);
            this.newPassLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newPassLbl.Name = "newPassLbl";
            this.newPassLbl.Size = new System.Drawing.Size(138, 27);
            this.newPassLbl.TabIndex = 4;
            this.newPassLbl.Text = "Password : ";
            // 
            // newConfirmPassLbl
            // 
            this.newConfirmPassLbl.AutoSize = true;
            this.newConfirmPassLbl.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newConfirmPassLbl.ForeColor = System.Drawing.Color.White;
            this.newConfirmPassLbl.Location = new System.Drawing.Point(75, 267);
            this.newConfirmPassLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newConfirmPassLbl.Name = "newConfirmPassLbl";
            this.newConfirmPassLbl.Size = new System.Drawing.Size(229, 27);
            this.newConfirmPassLbl.TabIndex = 5;
            this.newConfirmPassLbl.Text = "Confirm Password : ";
            // 
            // newDateOfBirtheLbl
            // 
            this.newDateOfBirtheLbl.AutoSize = true;
            this.newDateOfBirtheLbl.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newDateOfBirtheLbl.ForeColor = System.Drawing.Color.White;
            this.newDateOfBirtheLbl.Location = new System.Drawing.Point(75, 408);
            this.newDateOfBirtheLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newDateOfBirtheLbl.Name = "newDateOfBirtheLbl";
            this.newDateOfBirtheLbl.Size = new System.Drawing.Size(173, 27);
            this.newDateOfBirtheLbl.TabIndex = 8;
            this.newDateOfBirtheLbl.Text = "Date Of Birth : ";
            // 
            // newLastNameLbl
            // 
            this.newLastNameLbl.AutoSize = true;
            this.newLastNameLbl.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newLastNameLbl.ForeColor = System.Drawing.Color.White;
            this.newLastNameLbl.Location = new System.Drawing.Point(75, 360);
            this.newLastNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newLastNameLbl.Name = "newLastNameLbl";
            this.newLastNameLbl.Size = new System.Drawing.Size(148, 27);
            this.newLastNameLbl.TabIndex = 7;
            this.newLastNameLbl.Text = "Last Name : ";
            // 
            // newFirstNameLbl
            // 
            this.newFirstNameLbl.AutoSize = true;
            this.newFirstNameLbl.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newFirstNameLbl.ForeColor = System.Drawing.Color.White;
            this.newFirstNameLbl.Location = new System.Drawing.Point(75, 315);
            this.newFirstNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newFirstNameLbl.Name = "newFirstNameLbl";
            this.newFirstNameLbl.Size = new System.Drawing.Size(150, 27);
            this.newFirstNameLbl.TabIndex = 6;
            this.newFirstNameLbl.Text = "First Name : ";
            // 
            // newUserTypeLbl
            // 
            this.newUserTypeLbl.AutoSize = true;
            this.newUserTypeLbl.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserTypeLbl.ForeColor = System.Drawing.Color.White;
            this.newUserTypeLbl.Location = new System.Drawing.Point(76, 454);
            this.newUserTypeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newUserTypeLbl.Name = "newUserTypeLbl";
            this.newUserTypeLbl.Size = new System.Drawing.Size(142, 27);
            this.newUserTypeLbl.TabIndex = 9;
            this.newUserTypeLbl.Text = "User Type : ";
            // 
            // dateOfBirthPicker
            // 
            this.dateOfBirthPicker.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOfBirthPicker.Location = new System.Drawing.Point(313, 402);
            this.dateOfBirthPicker.Name = "dateOfBirthPicker";
            this.dateOfBirthPicker.Size = new System.Drawing.Size(321, 34);
            this.dateOfBirthPicker.TabIndex = 10;
            // 
            // userTypeComboBx
            // 
            this.userTypeComboBx.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTypeComboBx.FormattingEnabled = true;
            this.userTypeComboBx.Items.AddRange(new object[] {
            "View",
            "Edit"});
            this.userTypeComboBx.Location = new System.Drawing.Point(313, 449);
            this.userTypeComboBx.Name = "userTypeComboBx";
            this.userTypeComboBx.Size = new System.Drawing.Size(121, 34);
            this.userTypeComboBx.TabIndex = 11;
            // 
            // userTxtBx
            // 
            this.userTxtBx.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTxtBx.Location = new System.Drawing.Point(313, 174);
            this.userTxtBx.Name = "userTxtBx";
            this.userTxtBx.Size = new System.Drawing.Size(321, 34);
            this.userTxtBx.TabIndex = 12;
            this.userTxtBx.TextChanged += new System.EventHandler(this.userTxtBx_TextChanged);
            // 
            // passTxtBx
            // 
            this.passTxtBx.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passTxtBx.Location = new System.Drawing.Point(313, 218);
            this.passTxtBx.Name = "passTxtBx";
            this.passTxtBx.Size = new System.Drawing.Size(321, 34);
            this.passTxtBx.TabIndex = 13;
            this.passTxtBx.UseSystemPasswordChar = true;
            // 
            // confirmPassTxtBx
            // 
            this.confirmPassTxtBx.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPassTxtBx.Location = new System.Drawing.Point(313, 263);
            this.confirmPassTxtBx.Name = "confirmPassTxtBx";
            this.confirmPassTxtBx.Size = new System.Drawing.Size(321, 34);
            this.confirmPassTxtBx.TabIndex = 14;
            this.confirmPassTxtBx.UseSystemPasswordChar = true;
            this.confirmPassTxtBx.Leave += new System.EventHandler(this.confirmPassTxtBx_Leave);
            // 
            // firstNameTxtBx
            // 
            this.firstNameTxtBx.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameTxtBx.Location = new System.Drawing.Point(313, 310);
            this.firstNameTxtBx.Name = "firstNameTxtBx";
            this.firstNameTxtBx.Size = new System.Drawing.Size(321, 34);
            this.firstNameTxtBx.TabIndex = 15;
            // 
            // lastNameTxtBx
            // 
            this.lastNameTxtBx.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameTxtBx.Location = new System.Drawing.Point(313, 355);
            this.lastNameTxtBx.Name = "lastNameTxtBx";
            this.lastNameTxtBx.Size = new System.Drawing.Size(321, 34);
            this.lastNameTxtBx.TabIndex = 16;
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitBtn.Location = new System.Drawing.Point(197, 533);
            this.SubmitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(167, 48);
            this.SubmitBtn.TabIndex = 17;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.Location = new System.Drawing.Point(467, 533);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(167, 48);
            this.CancelBtn.TabIndex = 18;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 27);
            this.menuStrip.TabIndex = 19;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripNewUser});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10F);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(49, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logOutToolStripNewUser
            // 
            this.logOutToolStripNewUser.Image = global::SimpleTextEditor.Properties.Resources.gnome_logout;
            this.logOutToolStripNewUser.Name = "logOutToolStripNewUser";
            this.logOutToolStripNewUser.Size = new System.Drawing.Size(149, 26);
            this.logOutToolStripNewUser.Text = "Log Out";
            this.logOutToolStripNewUser.Click += new System.EventHandler(this.logOutToolStripNewUser_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripNewUser});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10F);
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 23);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripNewUser
            // 
            this.aboutToolStripNewUser.Name = "aboutToolStripNewUser";
            this.aboutToolStripNewUser.Size = new System.Drawing.Size(134, 26);
            this.aboutToolStripNewUser.Text = "About";
            // 
            // NewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 665);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.lastNameTxtBx);
            this.Controls.Add(this.firstNameTxtBx);
            this.Controls.Add(this.confirmPassTxtBx);
            this.Controls.Add(this.passTxtBx);
            this.Controls.Add(this.userTxtBx);
            this.Controls.Add(this.userTypeComboBx);
            this.Controls.Add(this.dateOfBirthPicker);
            this.Controls.Add(this.newUserTypeLbl);
            this.Controls.Add(this.newDateOfBirtheLbl);
            this.Controls.Add(this.newLastNameLbl);
            this.Controls.Add(this.newFirstNameLbl);
            this.Controls.Add(this.newConfirmPassLbl);
            this.Controls.Add(this.newPassLbl);
            this.Controls.Add(this.newUserTitleLbl);
            this.Controls.Add(this.newUserLbl);
            this.Name = "NewUserForm";
            this.Text = "New User Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewUserForm_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newUserLbl;
        private System.Windows.Forms.Label newUserTitleLbl;
        private System.Windows.Forms.Label newPassLbl;
        private System.Windows.Forms.Label newConfirmPassLbl;
        private System.Windows.Forms.Label newDateOfBirtheLbl;
        private System.Windows.Forms.Label newLastNameLbl;
        private System.Windows.Forms.Label newFirstNameLbl;
        private System.Windows.Forms.Label newUserTypeLbl;
        private System.Windows.Forms.DateTimePicker dateOfBirthPicker;
        private System.Windows.Forms.ComboBox userTypeComboBx;
        private System.Windows.Forms.TextBox userTxtBx;
        private System.Windows.Forms.TextBox passTxtBx;
        private System.Windows.Forms.TextBox confirmPassTxtBx;
        private System.Windows.Forms.TextBox firstNameTxtBx;
        private System.Windows.Forms.TextBox lastNameTxtBx;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripNewUser;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripNewUser;
    }
}