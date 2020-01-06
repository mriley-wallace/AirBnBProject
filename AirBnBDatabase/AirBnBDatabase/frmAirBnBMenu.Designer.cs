namespace AirBnBDatabase
{
    partial class frmAirBnBMenu
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
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btnExitApp = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.txtNBHood = new System.Windows.Forms.TextBox();
            this.lstDist = new System.Windows.Forms.ListBox();
            this.lstHood = new System.Windows.Forms.ListBox();
            this.dgdProp = new System.Windows.Forms.DataGridView();
            this.getFile = new System.Windows.Forms.OpenFileDialog();
            this.btnDistEdit = new System.Windows.Forms.Button();
            this.btnDistAdd = new System.Windows.Forms.Button();
            this.btnDistConfirm = new System.Windows.Forms.Button();
            this.btnDistCancel = new System.Windows.Forms.Button();
            this.btnHoodCancel = new System.Windows.Forms.Button();
            this.btnHoodConfirm = new System.Windows.Forms.Button();
            this.btnHoodAdd = new System.Windows.Forms.Button();
            this.btnHoodEdit = new System.Windows.Forms.Button();
            this.btnAddDisConfirm = new System.Windows.Forms.Button();
            this.btnAddDisCancel = new System.Windows.Forms.Button();
            this.btnAddHoodConfirm = new System.Windows.Forms.Button();
            this.btnAddHoodCancel = new System.Windows.Forms.Button();
            this.txtAddName = new System.Windows.Forms.TextBox();
            this.txtAddNum = new System.Windows.Forms.TextBox();
            this.lblAddName = new System.Windows.Forms.Label();
            this.lblAddNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdProp)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::AirBnBDatabase.Properties.Resources.districtImage;
            this.pictureBox4.Location = new System.Drawing.Point(30, 87);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(158, 55);
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::AirBnBDatabase.Properties.Resources.neighbourhoodImage;
            this.pictureBox5.Location = new System.Drawing.Point(29, 210);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(159, 57);
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::AirBnBDatabase.Properties.Resources.propertyImage;
            this.pictureBox6.Location = new System.Drawing.Point(29, 431);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(159, 54);
            this.pictureBox6.TabIndex = 2;
            this.pictureBox6.TabStop = false;
            // 
            // btnExitApp
            // 
            this.btnExitApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitApp.Location = new System.Drawing.Point(30, 12);
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(158, 51);
            this.btnExitApp.TabIndex = 6;
            this.btnExitApp.Text = "Exit";
            this.btnExitApp.UseVisualStyleBackColor = true;
            this.btnExitApp.Click += new System.EventHandler(this.BtnExitApp_Click);
            // 
            // btnRead
            // 
            this.btnRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.Location = new System.Drawing.Point(216, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(189, 51);
            this.btnRead.TabIndex = 7;
            this.btnRead.Text = "Select Data File";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(785, 87);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(409, 20);
            this.txtDistrict.TabIndex = 8;
            this.txtDistrict.TextChanged += new System.EventHandler(this.txtDistrict_TextChanged);
            // 
            // txtNBHood
            // 
            this.txtNBHood.Location = new System.Drawing.Point(785, 210);
            this.txtNBHood.Name = "txtNBHood";
            this.txtNBHood.Size = new System.Drawing.Size(409, 20);
            this.txtNBHood.TabIndex = 9;
            // 
            // lstDist
            // 
            this.lstDist.FormattingEnabled = true;
            this.lstDist.Location = new System.Drawing.Point(216, 87);
            this.lstDist.Name = "lstDist";
            this.lstDist.Size = new System.Drawing.Size(270, 108);
            this.lstDist.TabIndex = 11;
            this.lstDist.SelectedIndexChanged += new System.EventHandler(this.lstDist_SelectedIndexChanged);
            // 
            // lstHood
            // 
            this.lstHood.FormattingEnabled = true;
            this.lstHood.Location = new System.Drawing.Point(216, 210);
            this.lstHood.Name = "lstHood";
            this.lstHood.Size = new System.Drawing.Size(270, 186);
            this.lstHood.TabIndex = 12;
            this.lstHood.SelectedIndexChanged += new System.EventHandler(this.lstHood_SelectedIndexChanged);
            // 
            // dgdProp
            // 
            this.dgdProp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdProp.Location = new System.Drawing.Point(216, 411);
            this.dgdProp.Name = "dgdProp";
            this.dgdProp.Size = new System.Drawing.Size(1601, 483);
            this.dgdProp.TabIndex = 13;
            // 
            // getFile
            // 
            this.getFile.FileName = "getFile";
            // 
            // btnDistEdit
            // 
            this.btnDistEdit.Location = new System.Drawing.Point(1051, 113);
            this.btnDistEdit.Name = "btnDistEdit";
            this.btnDistEdit.Size = new System.Drawing.Size(109, 40);
            this.btnDistEdit.TabIndex = 15;
            this.btnDistEdit.Text = "Edit";
            this.btnDistEdit.UseVisualStyleBackColor = true;
            this.btnDistEdit.Click += new System.EventHandler(this.btnDistEdit_Click);
            // 
            // btnDistAdd
            // 
            this.btnDistAdd.Location = new System.Drawing.Point(821, 113);
            this.btnDistAdd.Name = "btnDistAdd";
            this.btnDistAdd.Size = new System.Drawing.Size(109, 40);
            this.btnDistAdd.TabIndex = 17;
            this.btnDistAdd.Text = "Add";
            this.btnDistAdd.UseVisualStyleBackColor = true;
            this.btnDistAdd.Click += new System.EventHandler(this.btnDistAdd_Click);
            // 
            // btnDistConfirm
            // 
            this.btnDistConfirm.Location = new System.Drawing.Point(821, 164);
            this.btnDistConfirm.Name = "btnDistConfirm";
            this.btnDistConfirm.Size = new System.Drawing.Size(109, 40);
            this.btnDistConfirm.TabIndex = 18;
            this.btnDistConfirm.Text = "Confirm";
            this.btnDistConfirm.UseVisualStyleBackColor = true;
            this.btnDistConfirm.Click += new System.EventHandler(this.btnDistConfirm_Click_1);
            // 
            // btnDistCancel
            // 
            this.btnDistCancel.Location = new System.Drawing.Point(1051, 159);
            this.btnDistCancel.Name = "btnDistCancel";
            this.btnDistCancel.Size = new System.Drawing.Size(109, 40);
            this.btnDistCancel.TabIndex = 19;
            this.btnDistCancel.Text = "Cancel";
            this.btnDistCancel.UseVisualStyleBackColor = true;
            this.btnDistCancel.Click += new System.EventHandler(this.btnDistCancel_Click_1);
            // 
            // btnHoodCancel
            // 
            this.btnHoodCancel.Location = new System.Drawing.Point(1051, 282);
            this.btnHoodCancel.Name = "btnHoodCancel";
            this.btnHoodCancel.Size = new System.Drawing.Size(109, 40);
            this.btnHoodCancel.TabIndex = 24;
            this.btnHoodCancel.Text = "Cancel";
            this.btnHoodCancel.UseVisualStyleBackColor = true;
            this.btnHoodCancel.Click += new System.EventHandler(this.btnHoodCancel_Click);
            // 
            // btnHoodConfirm
            // 
            this.btnHoodConfirm.Location = new System.Drawing.Point(821, 282);
            this.btnHoodConfirm.Name = "btnHoodConfirm";
            this.btnHoodConfirm.Size = new System.Drawing.Size(109, 40);
            this.btnHoodConfirm.TabIndex = 23;
            this.btnHoodConfirm.Text = "Confirm";
            this.btnHoodConfirm.UseVisualStyleBackColor = true;
            this.btnHoodConfirm.Click += new System.EventHandler(this.btnHoodConfirm_Click);
            // 
            // btnHoodAdd
            // 
            this.btnHoodAdd.Location = new System.Drawing.Point(821, 236);
            this.btnHoodAdd.Name = "btnHoodAdd";
            this.btnHoodAdd.Size = new System.Drawing.Size(109, 40);
            this.btnHoodAdd.TabIndex = 22;
            this.btnHoodAdd.Text = "Add";
            this.btnHoodAdd.UseVisualStyleBackColor = true;
            this.btnHoodAdd.Click += new System.EventHandler(this.btnHoodAdd_Click);
            // 
            // btnHoodEdit
            // 
            this.btnHoodEdit.Location = new System.Drawing.Point(1051, 236);
            this.btnHoodEdit.Name = "btnHoodEdit";
            this.btnHoodEdit.Size = new System.Drawing.Size(109, 40);
            this.btnHoodEdit.TabIndex = 20;
            this.btnHoodEdit.Text = "Edit";
            this.btnHoodEdit.UseVisualStyleBackColor = true;
            this.btnHoodEdit.Click += new System.EventHandler(this.btnHoodEdit_Click);
            // 
            // btnAddDisConfirm
            // 
            this.btnAddDisConfirm.Location = new System.Drawing.Point(1378, 210);
            this.btnAddDisConfirm.Name = "btnAddDisConfirm";
            this.btnAddDisConfirm.Size = new System.Drawing.Size(109, 40);
            this.btnAddDisConfirm.TabIndex = 25;
            this.btnAddDisConfirm.Text = "Confirm";
            this.btnAddDisConfirm.UseVisualStyleBackColor = true;
            this.btnAddDisConfirm.Click += new System.EventHandler(this.BtnAddDisConfirm_Click);
            // 
            // btnAddDisCancel
            // 
            this.btnAddDisCancel.Location = new System.Drawing.Point(1556, 210);
            this.btnAddDisCancel.Name = "btnAddDisCancel";
            this.btnAddDisCancel.Size = new System.Drawing.Size(109, 40);
            this.btnAddDisCancel.TabIndex = 26;
            this.btnAddDisCancel.Text = "Cancel";
            this.btnAddDisCancel.UseVisualStyleBackColor = true;
            this.btnAddDisCancel.Click += new System.EventHandler(this.BtnAddDisCancel_Click);
            // 
            // btnAddHoodConfirm
            // 
            this.btnAddHoodConfirm.Location = new System.Drawing.Point(1376, 256);
            this.btnAddHoodConfirm.Name = "btnAddHoodConfirm";
            this.btnAddHoodConfirm.Size = new System.Drawing.Size(109, 40);
            this.btnAddHoodConfirm.TabIndex = 27;
            this.btnAddHoodConfirm.Text = "Confirm";
            this.btnAddHoodConfirm.UseVisualStyleBackColor = true;
            this.btnAddHoodConfirm.Click += new System.EventHandler(this.BtnAddHoodConfirm_Click);
            // 
            // btnAddHoodCancel
            // 
            this.btnAddHoodCancel.Location = new System.Drawing.Point(1556, 256);
            this.btnAddHoodCancel.Name = "btnAddHoodCancel";
            this.btnAddHoodCancel.Size = new System.Drawing.Size(109, 40);
            this.btnAddHoodCancel.TabIndex = 28;
            this.btnAddHoodCancel.Text = "Cancel";
            this.btnAddHoodCancel.UseVisualStyleBackColor = true;
            this.btnAddHoodCancel.Click += new System.EventHandler(this.BtnAddHoodCancel_Click);
            // 
            // txtAddName
            // 
            this.txtAddName.Location = new System.Drawing.Point(1378, 86);
            this.txtAddName.Name = "txtAddName";
            this.txtAddName.Size = new System.Drawing.Size(311, 20);
            this.txtAddName.TabIndex = 29;
            // 
            // txtAddNum
            // 
            this.txtAddNum.Location = new System.Drawing.Point(1376, 125);
            this.txtAddNum.Name = "txtAddNum";
            this.txtAddNum.Size = new System.Drawing.Size(312, 20);
            this.txtAddNum.TabIndex = 30;
            // 
            // lblAddName
            // 
            this.lblAddName.AutoSize = true;
            this.lblAddName.Location = new System.Drawing.Point(1166, 89);
            this.lblAddName.Name = "lblAddName";
            this.lblAddName.Size = new System.Drawing.Size(64, 13);
            this.lblAddName.TabIndex = 31;
            this.lblAddName.Text = "lblAddName";
            // 
            // lblAddNumber
            // 
            this.lblAddNumber.AutoSize = true;
            this.lblAddNumber.Location = new System.Drawing.Point(1166, 132);
            this.lblAddNumber.Name = "lblAddNumber";
            this.lblAddNumber.Size = new System.Drawing.Size(73, 13);
            this.lblAddNumber.TabIndex = 32;
            this.lblAddNumber.Text = "lblAddNumber";
            // 
            // frmAirBnBMenu
            // 
            this.ClientSize = new System.Drawing.Size(1847, 1006);
            this.Controls.Add(this.lblAddNumber);
            this.Controls.Add(this.lblAddName);
            this.Controls.Add(this.txtAddNum);
            this.Controls.Add(this.txtAddName);
            this.Controls.Add(this.btnAddHoodCancel);
            this.Controls.Add(this.btnAddHoodConfirm);
            this.Controls.Add(this.btnAddDisCancel);
            this.Controls.Add(this.btnAddDisConfirm);
            this.Controls.Add(this.btnHoodCancel);
            this.Controls.Add(this.btnHoodConfirm);
            this.Controls.Add(this.btnHoodAdd);
            this.Controls.Add(this.btnHoodEdit);
            this.Controls.Add(this.btnDistCancel);
            this.Controls.Add(this.btnDistConfirm);
            this.Controls.Add(this.btnDistAdd);
            this.Controls.Add(this.btnDistEdit);
            this.Controls.Add(this.dgdProp);
            this.Controls.Add(this.lstHood);
            this.Controls.Add(this.lstDist);
            this.Controls.Add(this.txtNBHood);
            this.Controls.Add(this.txtDistrict);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnExitApp);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Name = "frmAirBnBMenu";
            this.Load += new System.EventHandler(this.FrmAirBnBMenu_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdProp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button btnExitApp;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.TextBox txtNBHood;
        private System.Windows.Forms.ListBox lstDist;
        private System.Windows.Forms.ListBox lstHood;
        private System.Windows.Forms.DataGridView dgdProp;
        private System.Windows.Forms.OpenFileDialog getFile;
        private System.Windows.Forms.Button btnDistEdit;
        private System.Windows.Forms.Button btnDistAdd;
        private System.Windows.Forms.Button btnDistConfirm;
        private System.Windows.Forms.Button btnDistCancel;
        private System.Windows.Forms.Button btnHoodCancel;
        private System.Windows.Forms.Button btnHoodConfirm;
        private System.Windows.Forms.Button btnHoodAdd;
        private System.Windows.Forms.Button btnHoodEdit;
        private System.Windows.Forms.Button btnAddDisConfirm;
        private System.Windows.Forms.Button btnAddDisCancel;
        private System.Windows.Forms.Button btnAddHoodConfirm;
        private System.Windows.Forms.Button btnAddHoodCancel;
        private System.Windows.Forms.TextBox txtAddName;
        private System.Windows.Forms.TextBox txtAddNum;
        private System.Windows.Forms.Label lblAddName;
        private System.Windows.Forms.Label lblAddNumber;
    }
}

