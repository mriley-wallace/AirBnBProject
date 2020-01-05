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
            this.txtProp = new System.Windows.Forms.TextBox();
            this.lstDist = new System.Windows.Forms.ListBox();
            this.lstHood = new System.Windows.Forms.ListBox();
            this.dgdProp = new System.Windows.Forms.DataGridView();
            this.getFile = new System.Windows.Forms.OpenFileDialog();
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
            // 
            // txtNBHood
            // 
            this.txtNBHood.Location = new System.Drawing.Point(785, 210);
            this.txtNBHood.Name = "txtNBHood";
            this.txtNBHood.Size = new System.Drawing.Size(409, 20);
            this.txtNBHood.TabIndex = 9;
            // 
            // txtProp
            // 
            this.txtProp.Location = new System.Drawing.Point(785, 376);
            this.txtProp.Name = "txtProp";
            this.txtProp.Size = new System.Drawing.Size(409, 20);
            this.txtProp.TabIndex = 10;
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
            // frmAirBnBMenu
            // 
            this.ClientSize = new System.Drawing.Size(1847, 1006);
            this.Controls.Add(this.dgdProp);
            this.Controls.Add(this.lstHood);
            this.Controls.Add(this.lstDist);
            this.Controls.Add(this.txtProp);
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
        private System.Windows.Forms.TextBox txtProp;
        private System.Windows.Forms.ListBox lstDist;
        private System.Windows.Forms.ListBox lstHood;
        private System.Windows.Forms.DataGridView dgdProp;
        private System.Windows.Forms.OpenFileDialog getFile;
    }
}

