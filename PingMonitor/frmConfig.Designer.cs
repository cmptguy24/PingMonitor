namespace PingMonitor
{
  partial class frmConfig
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtPingFreq = new System.Windows.Forms.TextBox();
            this.lblPingFreq = new System.Windows.Forms.Label();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblHostIP = new System.Windows.Forms.Label();
            this.labelHotType = new System.Windows.Forms.Label();
            this.comboBoxHostType = new System.Windows.Forms.ComboBox();
            this.chkShowInMonitor = new System.Windows.Forms.CheckBox();
            this.chkDoPing = new System.Windows.Forms.CheckBox();
            this.mnuHosts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAddHost = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteHostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvHosts = new System.Windows.Forms.TreeView();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblVer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDetail.SuspendLayout();
            this.mnuHosts.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHost
            // 
            this.txtHost.BackColor = System.Drawing.SystemColors.Window;
            this.txtHost.Location = new System.Drawing.Point(17, 70);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(144, 20);
            this.txtHost.TabIndex = 0;
            this.txtHost.Leave += new System.EventHandler(this.txtHost_LostFocus);
            // 
            // txtPingFreq
            // 
            this.txtPingFreq.Location = new System.Drawing.Point(398, 205);
            this.txtPingFreq.Name = "txtPingFreq";
            this.txtPingFreq.Size = new System.Drawing.Size(47, 20);
            this.txtPingFreq.TabIndex = 3;
            this.txtPingFreq.Text = "60";
            this.txtPingFreq.Visible = false;
            this.txtPingFreq.Leave += new System.EventHandler(this.txtPingFreq_LostFocus);
            // 
            // lblPingFreq
            // 
            this.lblPingFreq.AutoSize = true;
            this.lblPingFreq.Location = new System.Drawing.Point(311, 205);
            this.lblPingFreq.Name = "lblPingFreq";
            this.lblPingFreq.Size = new System.Drawing.Size(81, 13);
            this.lblPingFreq.TabIndex = 2;
            this.lblPingFreq.Text = "Ping frequency:";
            this.lblPingFreq.Visible = false;
            // 
            // pnlDetail
            // 
            this.pnlDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetail.Controls.Add(this.lblStatus);
            this.pnlDetail.Controls.Add(this.lblHostIP);
            this.pnlDetail.Controls.Add(this.labelHotType);
            this.pnlDetail.Controls.Add(this.comboBoxHostType);
            this.pnlDetail.Controls.Add(this.chkShowInMonitor);
            this.pnlDetail.Controls.Add(this.txtHost);
            this.pnlDetail.Location = new System.Drawing.Point(308, 13);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(175, 191);
            this.pnlDetail.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(17, 109);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 10;
            // 
            // lblHostIP
            // 
            this.lblHostIP.AutoSize = true;
            this.lblHostIP.Location = new System.Drawing.Point(62, 53);
            this.lblHostIP.Name = "lblHostIP";
            this.lblHostIP.Size = new System.Drawing.Size(42, 13);
            this.lblHostIP.TabIndex = 8;
            this.lblHostIP.Text = "Host IP";
            // 
            // labelHotType
            // 
            this.labelHotType.AutoSize = true;
            this.labelHotType.Location = new System.Drawing.Point(58, 5);
            this.labelHotType.Name = "labelHotType";
            this.labelHotType.Size = new System.Drawing.Size(53, 13);
            this.labelHotType.TabIndex = 6;
            this.labelHotType.Text = "HostType";
            // 
            // comboBoxHostType
            // 
            this.comboBoxHostType.FormattingEnabled = true;
            this.comboBoxHostType.Items.AddRange(new object[] {
            "Perforce",
            "JIRA",
            "PC\'s",
            "Other"});
            this.comboBoxHostType.Location = new System.Drawing.Point(17, 23);
            this.comboBoxHostType.Name = "comboBoxHostType";
            this.comboBoxHostType.Size = new System.Drawing.Size(144, 21);
            this.comboBoxHostType.TabIndex = 5;
            this.comboBoxHostType.Leave += new System.EventHandler(this.comboBoxHostType_Leave);
            // 
            // chkShowInMonitor
            // 
            this.chkShowInMonitor.AutoSize = true;
            this.chkShowInMonitor.Checked = true;
            this.chkShowInMonitor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowInMonitor.Location = new System.Drawing.Point(6, 171);
            this.chkShowInMonitor.Name = "chkShowInMonitor";
            this.chkShowInMonitor.Size = new System.Drawing.Size(142, 17);
            this.chkShowInMonitor.TabIndex = 4;
            this.chkShowInMonitor.Text = "Show in monitoring page";
            this.chkShowInMonitor.UseVisualStyleBackColor = true;
            this.chkShowInMonitor.Visible = false;
            this.chkShowInMonitor.CheckedChanged += new System.EventHandler(this.chkShowInMonitor_CheckedChanged);
            // 
            // chkDoPing
            // 
            this.chkDoPing.AutoSize = true;
            this.chkDoPing.Checked = true;
            this.chkDoPing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDoPing.Location = new System.Drawing.Point(325, 221);
            this.chkDoPing.Name = "chkDoPing";
            this.chkDoPing.Size = new System.Drawing.Size(112, 17);
            this.chkDoPing.TabIndex = 1;
            this.chkDoPing.Text = "Monitor with PING";
            this.chkDoPing.UseVisualStyleBackColor = true;
            this.chkDoPing.Visible = false;
            this.chkDoPing.CheckedChanged += new System.EventHandler(this.chkDoPing_CheckedChanged);
            // 
            // mnuHosts
            // 
            this.mnuHosts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAddHost,
            this.deleteHostToolStripMenuItem});
            this.mnuHosts.Name = "mnuHosts";
            this.mnuHosts.Size = new System.Drawing.Size(136, 48);
            // 
            // mniAddHost
            // 
            this.mniAddHost.Name = "mniAddHost";
            this.mniAddHost.Size = new System.Drawing.Size(135, 22);
            this.mniAddHost.Text = "Add Host";
            this.mniAddHost.Click += new System.EventHandler(this.mniAddHost_Click);
            // 
            // deleteHostToolStripMenuItem
            // 
            this.deleteHostToolStripMenuItem.Name = "deleteHostToolStripMenuItem";
            this.deleteHostToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.deleteHostToolStripMenuItem.Text = "Delete Host";
            this.deleteHostToolStripMenuItem.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // tvHosts
            // 
            this.tvHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvHosts.ContextMenuStrip = this.mnuHosts;
            this.tvHosts.ImageIndex = 0;
            this.tvHosts.ImageList = this.ImageList1;
            this.tvHosts.Location = new System.Drawing.Point(11, 18);
            this.tvHosts.Name = "tvHosts";
            this.tvHosts.SelectedImageIndex = 0;
            this.tvHosts.Size = new System.Drawing.Size(285, 243);
            this.tvHosts.TabIndex = 2;
            this.tvHosts.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvHosts_AfterSelect);
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "folder.bmp");
            this.ImageList1.Images.SetKeyName(1, "computer.bmp");
            this.ImageList1.Images.SetKeyName(2, "computer2.bmp");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Right click inside tree to add new Host";
            // 
            // lblVer
            // 
            this.lblVer.AutoSize = true;
            this.lblVer.Location = new System.Drawing.Point(419, 248);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(0, 13);
            this.lblVer.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Version:";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 273);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblVer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.tvHosts);
            this.Controls.Add(this.chkDoPing);
            this.Controls.Add(this.txtPingFreq);
            this.Controls.Add(this.lblPingFreq);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ping Monitor";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.mnuHosts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    internal System.Windows.Forms.TextBox txtHost;
    internal System.Windows.Forms.TextBox txtPingFreq;
    internal System.Windows.Forms.Label lblPingFreq;
    internal System.Windows.Forms.Panel pnlDetail;
    internal System.Windows.Forms.CheckBox chkShowInMonitor;
    internal System.Windows.Forms.CheckBox chkDoPing;
    internal System.Windows.Forms.ContextMenuStrip mnuHosts;
    internal System.Windows.Forms.ToolStripMenuItem mniAddHost;
    internal System.Windows.Forms.TreeView tvHosts;
    internal System.Windows.Forms.ImageList ImageList1;
        private System.Windows.Forms.ComboBox comboBoxHostType;
        private System.Windows.Forms.Label labelHotType;
        private System.Windows.Forms.Label lblHostIP;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem deleteHostToolStripMenuItem;
        private System.Windows.Forms.Label lblVer;
        private System.Windows.Forms.Label label2;
    }
}

