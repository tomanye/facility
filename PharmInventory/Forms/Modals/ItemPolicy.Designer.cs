namespace PharmInventory.Forms.Modals
{
    partial class ItemPolicy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemPolicy));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstDUs = new System.Windows.Forms.CheckedListBox();
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdC = new System.Windows.Forms.RadioButton();
            this.rdA = new System.Windows.Forms.RadioButton();
            this.rdB = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdN = new System.Windows.Forms.RadioButton();
            this.rdV = new System.Windows.Forms.RadioButton();
            this.rdE = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numNearExpiryTrigger = new System.Windows.Forms.NumericUpDown();
            this.lstPrograms = new System.Windows.Forms.CheckedListBox();
            this.lstSuppliers = new System.Windows.Forms.CheckedListBox();
            this.cboPrograms = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNearExpiryTrigger = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ckExculed = new DevExpress.XtraEditors.CheckEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.grpStorageSettings = new System.Windows.Forms.GroupBox();
            this.lblPickFaceLocation = new System.Windows.Forms.Label();
            this.cmbPickFaceLocation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpPreferredLocation = new System.Windows.Forms.GroupBox();
            this.lstPreferredPalletLocation = new System.Windows.Forms.ListView();
            this.btnAddPreferredLocation = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNearExpiryTrigger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckExculed.Properties)).BeginInit();
            this.grpStorageSettings.SuspendLayout();
            this.grpPreferredLocation.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.ckExculed);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.grpStorageSettings);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 624);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstDUs);
            this.groupBox2.Location = new System.Drawing.Point(445, 336);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 226);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dispensary units";
            // 
            // lstDUs
            // 
            this.lstDUs.CheckOnClick = true;
            this.lstDUs.FormattingEnabled = true;
            this.lstDUs.Location = new System.Drawing.Point(31, 20);
            this.lstDUs.Name = "lstDUs";
            this.lstDUs.Size = new System.Drawing.Size(254, 196);
            this.lstDUs.TabIndex = 12;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(136, 20);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtItemName.Properties.Appearance.Options.UseBackColor = true;
            this.txtItemName.Properties.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(424, 20);
            this.txtItemName.TabIndex = 17;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox3);
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Location = new System.Drawing.Point(445, 91);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(302, 226);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Classifications and Analysis";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdC);
            this.groupBox3.Controls.Add(this.rdA);
            this.groupBox3.Controls.Add(this.rdB);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(50, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(201, 91);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ABC";
            // 
            // rdC
            // 
            this.rdC.AutoSize = true;
            this.rdC.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdC.Location = new System.Drawing.Point(49, 62);
            this.rdC.Name = "rdC";
            this.rdC.Size = new System.Drawing.Size(69, 17);
            this.rdC.TabIndex = 4;
            this.rdC.TabStop = true;
            this.rdC.Text = "C Class";
            // 
            // rdA
            // 
            this.rdA.AutoSize = true;
            this.rdA.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdA.Location = new System.Drawing.Point(49, 16);
            this.rdA.Name = "rdA";
            this.rdA.Size = new System.Drawing.Size(68, 17);
            this.rdA.TabIndex = 4;
            this.rdA.TabStop = true;
            this.rdA.Text = "A Class";
            // 
            // rdB
            // 
            this.rdB.AutoSize = true;
            this.rdB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdB.Location = new System.Drawing.Point(49, 39);
            this.rdB.Name = "rdB";
            this.rdB.Size = new System.Drawing.Size(68, 17);
            this.rdB.TabIndex = 4;
            this.rdB.TabStop = true;
            this.rdB.Text = "B Class";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdN);
            this.groupBox4.Controls.Add(this.rdV);
            this.groupBox4.Controls.Add(this.rdE);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(50, 121);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(201, 92);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "VEN";
            // 
            // rdN
            // 
            this.rdN.AutoSize = true;
            this.rdN.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdN.Location = new System.Drawing.Point(48, 64);
            this.rdN.Name = "rdN";
            this.rdN.Size = new System.Drawing.Size(102, 17);
            this.rdN.TabIndex = 4;
            this.rdN.TabStop = true;
            this.rdN.Text = "Non-Essential";
            // 
            // rdV
            // 
            this.rdV.AutoSize = true;
            this.rdV.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdV.Location = new System.Drawing.Point(48, 18);
            this.rdV.Name = "rdV";
            this.rdV.Size = new System.Drawing.Size(50, 17);
            this.rdV.TabIndex = 4;
            this.rdV.TabStop = true;
            this.rdV.Text = "Vital";
            // 
            // rdE
            // 
            this.rdE.AutoSize = true;
            this.rdE.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdE.Location = new System.Drawing.Point(48, 41);
            this.rdE.Name = "rdE";
            this.rdE.Size = new System.Drawing.Size(75, 17);
            this.rdE.TabIndex = 4;
            this.rdE.TabStop = true;
            this.rdE.Text = "Essential";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numNearExpiryTrigger);
            this.groupBox5.Controls.Add(this.lstPrograms);
            this.groupBox5.Controls.Add(this.lstSuppliers);
            this.groupBox5.Controls.Add(this.cboPrograms);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.lblNearExpiryTrigger);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Location = new System.Drawing.Point(22, 91);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(380, 471);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Programs and Suppliers ";
            // 
            // numNearExpiryTrigger
            // 
            this.numNearExpiryTrigger.Location = new System.Drawing.Point(269, 342);
            this.numNearExpiryTrigger.Name = "numNearExpiryTrigger";
            this.numNearExpiryTrigger.Size = new System.Drawing.Size(64, 21);
            this.numNearExpiryTrigger.TabIndex = 12;
            this.numNearExpiryTrigger.Visible = false;
            // 
            // lstPrograms
            // 
            this.lstPrograms.CheckOnClick = true;
            this.lstPrograms.FormattingEnabled = true;
            this.lstPrograms.Location = new System.Drawing.Point(114, 178);
            this.lstPrograms.Name = "lstPrograms";
            this.lstPrograms.Size = new System.Drawing.Size(220, 132);
            this.lstPrograms.TabIndex = 11;
            // 
            // lstSuppliers
            // 
            this.lstSuppliers.CheckOnClick = true;
            this.lstSuppliers.FormattingEnabled = true;
            this.lstSuppliers.Location = new System.Drawing.Point(114, 24);
            this.lstSuppliers.Name = "lstSuppliers";
            this.lstSuppliers.Size = new System.Drawing.Size(220, 100);
            this.lstSuppliers.TabIndex = 11;
            // 
            // cboPrograms
            // 
            this.cboPrograms.DisplayMember = "Name";
            this.cboPrograms.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPrograms.FormattingEnabled = true;
            this.cboPrograms.Location = new System.Drawing.Point(114, 139);
            this.cboPrograms.Name = "cboPrograms";
            this.cboPrograms.Size = new System.Drawing.Size(220, 21);
            this.cboPrograms.TabIndex = 10;
            this.cboPrograms.ValueMember = "ID";
            this.cboPrograms.SelectedIndexChanged += new System.EventHandler(this.cboPrograms_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Supplier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Programs";
            // 
            // lblNearExpiryTrigger
            // 
            this.lblNearExpiryTrigger.AutoSize = true;
            this.lblNearExpiryTrigger.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNearExpiryTrigger.Location = new System.Drawing.Point(12, 347);
            this.lblNearExpiryTrigger.Name = "lblNearExpiryTrigger";
            this.lblNearExpiryTrigger.Size = new System.Drawing.Size(191, 13);
            this.lblNearExpiryTrigger.TabIndex = 0;
            this.lblNearExpiryTrigger.Text = "Near Expiry trigger point (Days)";
            this.lblNearExpiryTrigger.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Sub Programs";
            // 
            // ckExculed
            // 
            this.ckExculed.EditValue = true;
            this.ckExculed.Location = new System.Drawing.Point(22, 56);
            this.ckExculed.Name = "ckExculed";
            this.ckExculed.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckExculed.Properties.Appearance.Options.UseFont = true;
            this.ckExculed.Properties.Caption = "Used at this facility";
            this.ckExculed.Size = new System.Drawing.Size(134, 19);
            this.ckExculed.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Image = global::PharmInventory.Properties.Resources.cross;
            this.btnCancel.Location = new System.Drawing.Point(413, 590);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::PharmInventory.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(305, 590);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpStorageSettings
            // 
            this.grpStorageSettings.Controls.Add(this.lblPickFaceLocation);
            this.grpStorageSettings.Controls.Add(this.cmbPickFaceLocation);
            this.grpStorageSettings.Controls.Add(this.label2);
            this.grpStorageSettings.Controls.Add(this.grpPreferredLocation);
            this.grpStorageSettings.Location = new System.Drawing.Point(22, 370);
            this.grpStorageSettings.Name = "grpStorageSettings";
            this.grpStorageSettings.Size = new System.Drawing.Size(302, 143);
            this.grpStorageSettings.TabIndex = 18;
            this.grpStorageSettings.TabStop = false;
            this.grpStorageSettings.Text = "Storage Settings";
            this.grpStorageSettings.Visible = false;
            // 
            // lblPickFaceLocation
            // 
            this.lblPickFaceLocation.AutoSize = true;
            this.lblPickFaceLocation.Location = new System.Drawing.Point(12, 186);
            this.lblPickFaceLocation.Name = "lblPickFaceLocation";
            this.lblPickFaceLocation.Size = new System.Drawing.Size(111, 13);
            this.lblPickFaceLocation.TabIndex = 4;
            this.lblPickFaceLocation.Text = "Pick Face Location";
            // 
            // cmbPickFaceLocation
            // 
            this.cmbPickFaceLocation.DisplayMember = "Label";
            this.cmbPickFaceLocation.FormattingEnabled = true;
            this.cmbPickFaceLocation.Location = new System.Drawing.Point(158, 181);
            this.cmbPickFaceLocation.Name = "cmbPickFaceLocation";
            this.cmbPickFaceLocation.Size = new System.Drawing.Size(107, 21);
            this.cmbPickFaceLocation.TabIndex = 3;
            this.cmbPickFaceLocation.ValueMember = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Storage Type";
            // 
            // grpPreferredLocation
            // 
            this.grpPreferredLocation.Controls.Add(this.lstPreferredPalletLocation);
            this.grpPreferredLocation.Controls.Add(this.btnAddPreferredLocation);
            this.grpPreferredLocation.Location = new System.Drawing.Point(3, 61);
            this.grpPreferredLocation.Name = "grpPreferredLocation";
            this.grpPreferredLocation.Size = new System.Drawing.Size(296, 112);
            this.grpPreferredLocation.TabIndex = 2;
            this.grpPreferredLocation.TabStop = false;
            this.grpPreferredLocation.Text = "Preferred Pallet Locations";
            // 
            // lstPreferredPalletLocation
            // 
            this.lstPreferredPalletLocation.Location = new System.Drawing.Point(6, 20);
            this.lstPreferredPalletLocation.Name = "lstPreferredPalletLocation";
            this.lstPreferredPalletLocation.Size = new System.Drawing.Size(257, 80);
            this.lstPreferredPalletLocation.TabIndex = 20;
            this.lstPreferredPalletLocation.UseCompatibleStateImageBehavior = false;
            // 
            // btnAddPreferredLocation
            // 
            this.btnAddPreferredLocation.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPreferredLocation.Appearance.Options.UseFont = true;
            this.btnAddPreferredLocation.Image = global::PharmInventory.Properties.Resources.add_16;
            this.btnAddPreferredLocation.Location = new System.Drawing.Point(263, 20);
            this.btnAddPreferredLocation.Name = "btnAddPreferredLocation";
            this.btnAddPreferredLocation.Size = new System.Drawing.Size(27, 23);
            this.btnAddPreferredLocation.TabIndex = 19;
            // 
            // ItemPolicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 624);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemPolicy";
            this.Text = "Item Details";
            this.Load += new System.EventHandler(this.ItemPolicy_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNearExpiryTrigger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckExculed.Properties)).EndInit();
            this.grpStorageSettings.ResumeLayout(false);
            this.grpStorageSettings.PerformLayout();
            this.grpPreferredLocation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdA;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdN;
        private System.Windows.Forms.RadioButton rdV;
        private System.Windows.Forms.RadioButton rdE;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdC;
        private System.Windows.Forms.RadioButton rdB;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.CheckEdit ckExculed;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPrograms;
        private System.Windows.Forms.CheckedListBox lstSuppliers;
        private System.Windows.Forms.CheckedListBox lstPrograms;
        private System.Windows.Forms.GroupBox grpStorageSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpPreferredLocation;
        private DevExpress.XtraEditors.SimpleButton btnAddPreferredLocation;
        private System.Windows.Forms.ListView lstPreferredPalletLocation;
        private System.Windows.Forms.NumericUpDown numNearExpiryTrigger;
        private System.Windows.Forms.Label lblNearExpiryTrigger;
        private System.Windows.Forms.ComboBox cmbPickFaceLocation;
        private System.Windows.Forms.Label lblPickFaceLocation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox lstDUs;
    }
}