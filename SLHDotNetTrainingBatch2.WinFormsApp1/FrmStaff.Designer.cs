namespace SLHDotNetTrainingBatch2.WinFormsApp1
{
    partial class FrmStaff
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            label1 = new Label();
            txtCode = new TextBox();
            txtName = new TextBox();
            label2 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtMobileNo = new TextBox();
            label6 = new Label();
            cboPosition = new ComboBox();
            dgvData = new DataGridView();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colId = new DataGridViewTextBoxColumn();
            colStaffCode = new DataGridViewTextBoxColumn();
            colStaffName = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(158, 266);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 22);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 26);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 1;
            label1.Text = "Staff Code: ";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(21, 43);
            txtCode.Margin = new Padding(3, 2, 3, 2);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(220, 23);
            txtCode.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(21, 82);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(220, 23);
            txtName.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 65);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 3;
            label2.Text = "Staff Name:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(21, 122);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 23);
            txtEmail.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 105);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 5;
            label3.Text = "Email:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(21, 162);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.ReadOnly = true;
            txtPassword.Size = new Size(220, 23);
            txtPassword.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 145);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 7;
            label4.Text = "Password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 184);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 9;
            label5.Text = "Position:";
            // 
            // txtMobileNo
            // 
            txtMobileNo.Location = new Point(21, 242);
            txtMobileNo.Margin = new Padding(3, 2, 3, 2);
            txtMobileNo.Name = "txtMobileNo";
            txtMobileNo.Size = new Size(220, 23);
            txtMobileNo.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 224);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 11;
            label6.Text = "Mobile No:";
            // 
            // cboPosition
            // 
            cboPosition.FormattingEnabled = true;
            cboPosition.Items.AddRange(new object[] { "--Select One--", "Admin", "Staff" });
            cboPosition.Location = new Point(21, 202);
            cboPosition.Margin = new Padding(3, 2, 3, 2);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(220, 23);
            cboPosition.TabIndex = 13;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colEdit, colDelete, colId, colStaffCode, colStaffName });
            dgvData.Location = new Point(284, 19);
            dgvData.Margin = new Padding(3, 2, 3, 2);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new Size(433, 269);
            dgvData.TabIndex = 14;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.MinimumWidth = 6;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Width = 125;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Delete";
            colDelete.MinimumWidth = 6;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Delete";
            colDelete.UseColumnTextForButtonValue = true;
            colDelete.Width = 125;
            // 
            // colId
            // 
            colId.DataPropertyName = "StaffId";
            colId.HeaderText = "Id";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 125;
            // 
            // colStaffCode
            // 
            colStaffCode.DataPropertyName = "StaffCode";
            colStaffCode.HeaderText = "Staff Code";
            colStaffCode.MinimumWidth = 6;
            colStaffCode.Name = "colStaffCode";
            colStaffCode.ReadOnly = true;
            colStaffCode.Width = 125;
            // 
            // colStaffName
            // 
            colStaffName.DataPropertyName = "StaffName";
            colStaffName.HeaderText = "Staff Name";
            colStaffName.MinimumWidth = 6;
            colStaffName.Name = "colStaffName";
            colStaffName.ReadOnly = true;
            colStaffName.Width = 125;
            // 
            // FrmStaff
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 315);
            Controls.Add(dgvData);
            Controls.Add(cboPosition);
            Controls.Add(txtMobileNo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtCode);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmStaff";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Staff";
            Load += FrmStaff_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Label label1;
        private TextBox txtCode;
        private TextBox txtName;
        private Label label2;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtPassword;
        private Label label4;
        private Label label5;
        private TextBox txtMobileNo;
        private Label label6;
        private ComboBox cboPosition;
        private DataGridView dgvData;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colStaffCode;
        private DataGridViewTextBoxColumn colStaffName;
    }
}
