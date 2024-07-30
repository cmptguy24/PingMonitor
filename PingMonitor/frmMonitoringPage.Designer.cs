namespace PingMonitor
{
  partial class frmMon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMon));
            this.mniConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.timRefresh = new System.Windows.Forms.Timer(this.components);
            this.dgMonitor = new System.Windows.Forms.DataGridView();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manualPINGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnResize = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.backgroundWorkerPing = new System.ComponentModel.BackgroundWorker();
            this.notifyIconsuspend = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerOff = new System.Windows.Forms.Timer(this.components);
            this.btnRes = new System.Windows.Forms.Button();
            this.groupBoxhide = new System.Windows.Forms.GroupBox();
            this.lblResume = new System.Windows.Forms.Label();
            this.lblNetwork = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgMonitor)).BeginInit();
            this.MenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStripTray.SuspendLayout();
            this.groupBoxhide.SuspendLayout();
            this.SuspendLayout();
            // 
            // mniConfig
            // 
            this.mniConfig.Name = "mniConfig";
            this.mniConfig.Size = new System.Drawing.Size(72, 20);
            this.mniConfig.Text = "Configure";
            this.mniConfig.Click += new System.EventHandler(this.mniConfig_Click);
            // 
            // timRefresh
            // 
            this.timRefresh.Interval = 300000;
            this.timRefresh.Tick += new System.EventHandler(this.timRefresh_Tick);
            // 
            // dgMonitor
            // 
            this.dgMonitor.AllowUserToAddRows = false;
            this.dgMonitor.AllowUserToDeleteRows = false;
            this.dgMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMonitor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMonitor.Location = new System.Drawing.Point(-1, 28);
            this.dgMonitor.Name = "dgMonitor";
            this.dgMonitor.ReadOnly = true;
            this.dgMonitor.Size = new System.Drawing.Size(667, 322);
            this.dgMonitor.TabIndex = 2;
            this.dgMonitor.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgMonitor_CellFormatting);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniConfig,
            this.manualPINGToolStripMenuItem,
            this.pingResultToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(666, 24);
            this.MenuStrip1.TabIndex = 3;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // manualPINGToolStripMenuItem
            // 
            this.manualPINGToolStripMenuItem.Name = "manualPINGToolStripMenuItem";
            this.manualPINGToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.manualPINGToolStripMenuItem.Text = "cmd PING";
            this.manualPINGToolStripMenuItem.Click += new System.EventHandler(this.manualPINGToolStripMenuItem_Click);
            // 
            // pingResultToolStripMenuItem
            // 
            this.pingResultToolStripMenuItem.Name = "pingResultToolStripMenuItem";
            this.pingResultToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.pingResultToolStripMenuItem.Text = "PingResult.txt";
            this.pingResultToolStripMenuItem.Click += new System.EventHandler(this.pingResultToolStripMenuItem_Click);
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.Location = new System.Drawing.Point(18, 18);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(520, 95);
            this.lstBox.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstBox);
            this.groupBox1.Location = new System.Drawing.Point(50, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 125);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result:";
            // 
            // btnResize
            // 
            this.btnResize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResize.Location = new System.Drawing.Point(290, 356);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(80, 23);
            this.btnResize.TabIndex = 8;
            this.btnResize.Text = "Show Results";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // btnHide
            // 
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHide.Location = new System.Drawing.Point(290, 356);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(80, 23);
            this.btnHide.TabIndex = 9;
            this.btnHide.Text = "Hide Results";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // backgroundWorkerPing
            // 
            this.backgroundWorkerPing.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPing_DoWork);
            // 
            // notifyIconsuspend
            // 
            this.notifyIconsuspend.ContextMenuStrip = this.contextMenuStripTray;
            this.notifyIconsuspend.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconsuspend.Icon")));
            this.notifyIconsuspend.Text = "Ping Monitor";
            this.notifyIconsuspend.Visible = true;
            this.notifyIconsuspend.BalloonTipClicked += new System.EventHandler(this.notifyIconsuspend_BalloonTipClicked);
            this.notifyIconsuspend.Click += new System.EventHandler(this.notifyIconsuspend_Click);
            this.notifyIconsuspend.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconsuspend_MouseDoubleClick);
            // 
            // contextMenuStripTray
            // 
            this.contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStripTray.Name = "contextMenuStripTray";
            this.contextMenuStripTray.Size = new System.Drawing.Size(153, 70);
            this.contextMenuStripTray.Click += new System.EventHandler(this.contextMenuStripTray_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click_1);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // timerOff
            // 
            this.timerOff.Enabled = true;
            this.timerOff.Interval = 10000;
            // 
            // btnRes
            // 
            this.btnRes.Location = new System.Drawing.Point(302, 91);
            this.btnRes.Name = "btnRes";
            this.btnRes.Size = new System.Drawing.Size(68, 35);
            this.btnRes.TabIndex = 10;
            this.btnRes.Text = "Resume";
            this.btnRes.UseVisualStyleBackColor = true;
            this.btnRes.Click += new System.EventHandler(this.btnRes_Click);
            // 
            // groupBoxhide
            // 
            this.groupBoxhide.Controls.Add(this.lblResume);
            this.groupBoxhide.Controls.Add(this.btnRes);
            this.groupBoxhide.Location = new System.Drawing.Point(0, 217);
            this.groupBoxhide.Name = "groupBoxhide";
            this.groupBoxhide.Size = new System.Drawing.Size(666, 171);
            this.groupBoxhide.TabIndex = 11;
            this.groupBoxhide.TabStop = false;
            // 
            // lblResume
            // 
            this.lblResume.AutoSize = true;
            this.lblResume.Location = new System.Drawing.Point(255, 56);
            this.lblResume.Name = "lblResume";
            this.lblResume.Size = new System.Drawing.Size(161, 13);
            this.lblResume.TabIndex = 11;
            this.lblResume.Text = "Click below to resume monitoring";
            // 
            // lblNetwork
            // 
            this.lblNetwork.AutoSize = true;
            this.lblNetwork.Location = new System.Drawing.Point(497, 6);
            this.lblNetwork.Name = "lblNetwork";
            this.lblNetwork.Size = new System.Drawing.Size(0, 13);
            this.lblNetwork.TabIndex = 12;
            // 
            // frmMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 387);
            this.Controls.Add(this.lblNetwork);
            this.Controls.Add(this.groupBoxhide);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.btnResize);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgMonitor);
            this.Controls.Add(this.MenuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMon";
            this.Text = "Ping Monitor";
            this.Load += new System.EventHandler(this.frmMonitoringPage_Load);
            this.Resize += new System.EventHandler(this.frmMonitoringPage_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgMonitor)).EndInit();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStripTray.ResumeLayout(false);
            this.groupBoxhide.ResumeLayout(false);
            this.groupBoxhide.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    internal System.Windows.Forms.ToolStripMenuItem mniConfig;
    internal System.Windows.Forms.Timer timRefresh;
    internal System.Windows.Forms.DataGridView dgMonitor;
    internal System.Windows.Forms.MenuStrip MenuStrip1;
        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.Button btnHide;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPing;
        private System.Windows.Forms.ToolStripMenuItem pingResultToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon notifyIconsuspend;
        private System.Windows.Forms.Timer timerOff;
        private System.Windows.Forms.Button btnRes;
        private System.Windows.Forms.GroupBox groupBoxhide;
        private System.Windows.Forms.Label lblResume;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualPINGToolStripMenuItem;
        private System.Windows.Forms.Label lblNetwork;
    }
}