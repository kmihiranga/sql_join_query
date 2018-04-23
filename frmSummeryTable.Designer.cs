namespace NW_Pos
{
    partial class frmSummeryTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSummeryTable));
            this.dataGridViewSummery = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.dateDeactive = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdm = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.bunifuTileButton13 = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuTileButton12 = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuTileButton11 = new Bunifu.Framework.UI.BunifuTileButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSummery)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSummery
            // 
            this.dataGridViewSummery.AllowUserToAddRows = false;
            this.dataGridViewSummery.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.dataGridViewSummery.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSummery.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewSummery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSummery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSummery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSummery.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSummery.EnableHeadersVisualStyles = false;
            this.dataGridViewSummery.GridColor = System.Drawing.Color.White;
            this.dataGridViewSummery.Location = new System.Drawing.Point(1, 251);
            this.dataGridViewSummery.Name = "dataGridViewSummery";
            this.dataGridViewSummery.ReadOnly = true;
            this.dataGridViewSummery.Size = new System.Drawing.Size(1131, 407);
            this.dataGridViewSummery.TabIndex = 63;
            this.dataGridViewSummery.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSummery_CellClick);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.cmbtype);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtphone);
            this.groupBox5.Controls.Add(this.dateDeactive);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtdm);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(12, 86);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1108, 159);
            this.groupBox5.TabIndex = 64;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Search Client Details";
            // 
            // cmbtype
            // 
            this.cmbtype.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbtype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbtype.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtype.ForeColor = System.Drawing.Color.White;
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Items.AddRange(new object[] {
            "Expired",
            "Active",
            "Deactive"});
            this.cmbtype.Location = new System.Drawing.Point(117, 119);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(198, 25);
            this.cmbtype.TabIndex = 21;
            this.cmbtype.Text = "Active";
            this.cmbtype.SelectedIndexChanged += new System.EventHandler(this.cmbtype_SelectedIndexChanged);
            this.cmbtype.SelectedValueChanged += new System.EventHandler(this.cmbtype_SelectedValueChanged);
            this.cmbtype.TextChanged += new System.EventHandler(this.cmbtype_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Sort By\r\n";
            // 
            // txtphone
            // 
            this.txtphone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtphone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtphone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtphone.ForeColor = System.Drawing.Color.White;
            this.txtphone.Location = new System.Drawing.Point(117, 23);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(299, 25);
            this.txtphone.TabIndex = 19;
            this.txtphone.TextChanged += new System.EventHandler(this.txtphone_TextChanged_2);
            this.txtphone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtphone_KeyPress);
            // 
            // dateDeactive
            // 
            this.dateDeactive.CalendarForeColor = System.Drawing.Color.Silver;
            this.dateDeactive.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateDeactive.CalendarTitleBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.dateDeactive.CalendarTitleForeColor = System.Drawing.Color.Silver;
            this.dateDeactive.CalendarTrailingForeColor = System.Drawing.Color.DarkGray;
            this.dateDeactive.CustomFormat = "yyyy-MM-dd";
            this.dateDeactive.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDeactive.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDeactive.Location = new System.Drawing.Point(117, 87);
            this.dateDeactive.Name = "dateDeactive";
            this.dateDeactive.Size = new System.Drawing.Size(198, 25);
            this.dateDeactive.TabIndex = 18;
            this.dateDeactive.ValueChanged += new System.EventHandler(this.dateDeactive_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Expire Date\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Domain Name";
            // 
            // txtdm
            // 
            this.txtdm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtdm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdm.ForeColor = System.Drawing.Color.White;
            this.txtdm.Location = new System.Drawing.Point(117, 55);
            this.txtdm.Name = "txtdm";
            this.txtdm.Size = new System.Drawing.Size(970, 25);
            this.txtdm.TabIndex = 15;
            this.txtdm.TextChanged += new System.EventHandler(this.txtdm_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(8, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 17);
            this.label13.TabIndex = 14;
            this.label13.Text = "Phone";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.bunifuTileButton13);
            this.panel3.Controls.Add(this.bunifuTileButton12);
            this.panel3.Controls.Add(this.bunifuTileButton11);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1132, 81);
            this.panel3.TabIndex = 65;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("SEA GARDENS", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(207, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(290, 22);
            this.label12.TabIndex = 7;
            this.label12.Text = "Domain Summery View";
            // 
            // bunifuTileButton13
            // 
            this.bunifuTileButton13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuTileButton13.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuTileButton13.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.bunifuTileButton13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuTileButton13.ForeColor = System.Drawing.Color.White;
            this.bunifuTileButton13.Image = ((System.Drawing.Image)(resources.GetObject("bunifuTileButton13.Image")));
            this.bunifuTileButton13.ImagePosition = 8;
            this.bunifuTileButton13.ImageZoom = 40;
            this.bunifuTileButton13.LabelPosition = 32;
            this.bunifuTileButton13.LabelText = "Logout";
            this.bunifuTileButton13.Location = new System.Drawing.Point(1051, 0);
            this.bunifuTileButton13.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.bunifuTileButton13.Name = "bunifuTileButton13";
            this.bunifuTileButton13.Size = new System.Drawing.Size(77, 81);
            this.bunifuTileButton13.TabIndex = 1;
            this.bunifuTileButton13.Click += new System.EventHandler(this.bunifuTileButton13_Click);
            // 
            // bunifuTileButton12
            // 
            this.bunifuTileButton12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuTileButton12.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuTileButton12.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.bunifuTileButton12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuTileButton12.ForeColor = System.Drawing.Color.White;
            this.bunifuTileButton12.Image = global::NW_Pos.Properties.Resources.new_document1;
            this.bunifuTileButton12.ImagePosition = 8;
            this.bunifuTileButton12.ImageZoom = 40;
            this.bunifuTileButton12.LabelPosition = 32;
            this.bunifuTileButton12.LabelText = "New";
            this.bunifuTileButton12.Location = new System.Drawing.Point(973, 0);
            this.bunifuTileButton12.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.bunifuTileButton12.Name = "bunifuTileButton12";
            this.bunifuTileButton12.Size = new System.Drawing.Size(77, 81);
            this.bunifuTileButton12.TabIndex = 1;
            this.bunifuTileButton12.Click += new System.EventHandler(this.bunifuTileButton12_Click);
            // 
            // bunifuTileButton11
            // 
            this.bunifuTileButton11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuTileButton11.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuTileButton11.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.bunifuTileButton11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuTileButton11.ForeColor = System.Drawing.Color.White;
            this.bunifuTileButton11.Image = ((System.Drawing.Image)(resources.GetObject("bunifuTileButton11.Image")));
            this.bunifuTileButton11.ImagePosition = 8;
            this.bunifuTileButton11.ImageZoom = 40;
            this.bunifuTileButton11.LabelPosition = 32;
            this.bunifuTileButton11.LabelText = "Home";
            this.bunifuTileButton11.Location = new System.Drawing.Point(895, 0);
            this.bunifuTileButton11.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.bunifuTileButton11.Name = "bunifuTileButton11";
            this.bunifuTileButton11.Size = new System.Drawing.Size(77, 81);
            this.bunifuTileButton11.TabIndex = 1;
            this.bunifuTileButton11.Click += new System.EventHandler(this.bunifuTileButton11_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmSummeryTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1132, 658);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.dataGridViewSummery);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSummeryTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Summery Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSummeryTable_FormClosing);
            this.Load += new System.EventHandler(this.frmSummeryTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSummery)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSummery;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton13;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton12;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDeactive;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbtype;
    }
}