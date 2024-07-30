using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.Net.Mail;
using System.Linq;


namespace PingMonitor
{
  public partial class frmMon : Form
  {
        private static AutoResetEvent _wait = new AutoResetEvent(false);
        public frmMon()
            
    {
      InitializeComponent();
    }

        int counter = 0;
        private DataTable dtHosts = new DataTable();
        DataTable dtLog = new DataTable(); //-original DataTable
        SqlDataAdapter daLog;   //-original DataTable
        private SqlDataAdapter daHosts;
        public string pause;
        public SqlCommand cm { get; private set; }


        private void frmMonitoringPage_Load(object sender, System.EventArgs e)
        {
            string ConnStr = ConfigurationManager.AppSettings["ConnStr"].ToString(); //Loads the PingLog list
            string SQLstr;
            SQLstr = "SELECT AllPing.HostType, AllPing.Host, AllPing.RecordingDate, AllPing.Status FROM PingLog AS AllPing";
            SQLstr += " INNER JOIN (SELECT Host, MAX(RecordingDate) AS LastRecordingDate FROM PingLog GROUP BY Host) LastPing";
            SQLstr += " ON AllPing.Host=LastPing.Host AND AllPing.RecordingDate=LastPing.LastRecordingDate";
            SQLstr += " INNER JOIN PingLog ON PingLog.Host=AllPing.Host";

            daLog = new SqlDataAdapter(SQLstr, ConnStr);
            btnRes.Visible = false;
            groupBoxhide.Visible = false;
            int ReloadFrequency = int.Parse(ConfigurationManager.AppSettings["ReloadFrequency"].ToString());
            //timRefresh.Interval = 8000 * ReloadFrequency; //6 minutes between ping
            timRefresh.Interval = 20000 * ReloadFrequency;
            timRefresh_Tick(null, null);
            timRefresh.Enabled = true;
            dgMonitor.BringToFront();
            btnHide.Hide();
            CheckForIllegalCrossThreadCalls = false;


            string ConnStrUpdate = ConfigurationManager.AppSettings["ConnStr"].ToString(); //Updates PingLog "Status" to OFF if host unreachable
            daHosts = new SqlDataAdapter("SELECT * FROM PingLog", ConnStrUpdate);
            SqlCommandBuilder cb = new SqlCommandBuilder(daHosts);
            daHosts.InsertCommand = cb.GetInsertCommand();
            daHosts.UpdateCommand = cb.GetUpdateCommand();
            daHosts.DeleteCommand = cb.GetDeleteCommand();

            string sPath = Path.Combine(Path.GetTempPath(), "PingLogs");
            try
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(sPath);
            }
            catch
            { }
            }
         

        private void timRefresh_Tick(object sender, System.EventArgs e)
        {
            
            string sPath = Path.Combine(Path.GetTempPath(), "PingLogs");
            // Create a DirectoryInfo of the directory of the files to enumerate.
            DirectoryInfo DirInfo = new DirectoryInfo(sPath);

            try
            {
                Directory.GetFiles(sPath)
         .Select(f => new FileInfo(f))
         .Where(f => f.LastAccessTime < DateTime.Now.AddDays(-4))
         .ToList()
         .ForEach(f => f.Delete());
            }
            catch
            {
                // Create dir if missing
                DirectoryInfo di = Directory.CreateDirectory(sPath);
            }
        

        lblNetwork.Text = "";
            try
            {
                dtLog.Clear();
                daLog.Fill(dtLog);
                dgMonitor.DataSource = dtLog;
            }
            catch
            {
                lblNetwork.Text = "Network issue?: Lost connection";
                lblNetwork.ForeColor = System.Drawing.Color.Red;
                    }

            try
            {
                backgroundWorkerPing.RunWorkerAsync(); //ping each IP in PingLog
               }
            catch
            { }
           
        }

       

        void frmConfig_FormClosing(object sender, EventArgs e)
        {
          
        }
        

        private bool HostIsAlive(string Host)
        {
            Ping pingSender = new Ping();
            PingReply reply;
            try
            {
                reply = pingSender.Send(Host);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
       
       

        private void mniConfig_Click(object sender, System.EventArgs e)
    {
      frmConfig f = new frmConfig();
      f.ShowDialog();
    }

        private void dgMonitor_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            object v = dgMonitor.Rows[e.RowIndex].Cells["Status"].Value;
            //foreach (DataGridViewCell i in dgMonitor.Rows[e.RowIndex].Cells) //Checks status of each Host Machine
                //if (v != null && v.ToString() == "ON") 
               // {
                  //  notifyIconsuspend.Icon = new Icon("\\Program Files (x86)\\Microsoft Visual Studio 14.0\\code.cs\\PingMonitorService\\computer_orig.ico");
                //}
               // else if (v != null && v.ToString() == "OFF")
                //{
                  //  i.Style.BackColor = Color.Orange;
                   // notifyIconsuspend.Icon = SystemIcons.Exclamation;
                //}
            foreach (DataGridViewCell i in dgMonitor.Rows[e.RowIndex].Cells) //Checks status of each Host Machine
               
               if (v != null && v.ToString() == "NOTIF" || v.ToString() == "OFF")
                { 
                    i.Style.BackColor = Color.Orange;
                    notifyIconsuspend.Icon = SystemIcons.Exclamation;
                    //break;
                }
           
            //foreach (DataGridViewCell i in dgMonitor.Rows[e.RowIndex].Cells) //Checks status of each Host Machine
            else if (v != null && v.ToString() == "ON")
            {
               // notifyIconsuspend.Icon = new Icon("\\Program Files (x86)\\Microsoft Visual Studio 14.0\\code.cs\\PingMonitorService\\computer_orig.ico");
            }
        }

      

        private void btnResize_Click(object sender, EventArgs e)
        {
            dgMonitor.Size = new Size(667, 190);
            btnHide.Show();
            btnResize.Hide();

            
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            dgMonitor.Size = new Size(667, 322);
            btnResize.Show();
            btnHide.Hide();
        }

        private void UpdateListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            e.DrawBackground();
            var myValue = lstBox.SelectedIndex.ToString();

            if (myValue.Contains("TimeOut"))
                e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            
            else
                                           e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            e.Graphics.DrawString(lstBox.SelectedIndex.ToString(), e.Font, Brushes.Black, new PointF(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
            
        }

  
        private void backgroundWorkerPing_DoWork(object sender, DoWorkEventArgs e)
        {
            
            List<string> lstJobs = new List<string>();
            foreach (DataGridViewRow row in dgMonitor.Rows)
            {
                string StringPass = row.Cells[1].Value.ToString();

                if (StringPass != null)
                {

                    Ping p = new Ping();
                    PingReply r;
                    string s;
                    DateTime d = DateTime.Now;
                    s = StringPass;


                    try
                    {
                        r = p.Send(s);
                        {
                            string ConnStr = ConfigurationManager.AppSettings["ConnStr"].ToString(); //Loads the PingLog list
                            SqlConnection cnn = new SqlConnection(ConnStr);
                            SqlCommand cmd = cnn.CreateCommand();
                            
                             string sPath = Path.Combine(Path.GetTempPath(), "PingLogs");

                            if (r.Status == IPStatus.Success)
                            {

                                lstBox.Items.Add("Ping to " + s.ToString() + " " + "[" + " " + r.Status.ToString() + "!" + " " + "]" + " Successful" + " Response delay = " + r.RoundtripTime.ToString() + " ms" + " " + d.ToString() + "\n");

                                //Set the current directory.
                                Directory.SetCurrentDirectory(sPath);
                                string dateAndTime = DateTime.Now.ToString("M-dd-yyyy");
                                File.AppendAllText($"Log-" + dateAndTime + ".txt", "Ping to " + s.ToString() + " " + "[" + " " + r.Status.ToString() + "!" + " " + "]" + " Successful" + " Response delay = " + r.RoundtripTime.ToString() + " ms" + " " + d.ToString() + Environment.NewLine);

                                //Updates PingLog SQL table
                                cmd.CommandText = "UPDATE PingLog SET Status = 'ON' Where HOST = '" + s + "'";
                                try
                                {
                                    cnn.Open();
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }
                                finally
                                {
                                    cnn.Close();

                                }

                            }
                            else
                            {
                                lstBox.Items.Add("Ping to " + s.ToString() + " " + "[" + " " + r.Status.ToString() + " " + "]"
                                 + " Response delay = " + " " + r.Status.ToString() + " " + d.ToString() + "\n");

                                //Set the current directory.
                                Directory.SetCurrentDirectory(sPath);
                                string dateAndTime = DateTime.Now.ToString("M-dd-yyyy");
                                File.AppendAllText($"Log-" + dateAndTime + ".txt", "Ping to " + s.ToString() + " " + "[" + " " + r.Status.ToString() + "!" + " " + "]" + " TimedOut" + " Response delay = " + r.RoundtripTime.ToString() + " ms" + " " + d.ToString() + Environment.NewLine);


                                string StringPassNotify = row.Cells[3].Value.ToString(); //Checks to see if value is set to OFF or Notify
                                if (StringPassNotify == "NOTIF")
                                {
                                }
                                else
                                { 
                                    cmd.CommandText = "UPDATE PingLog SET Status = 'OFF', RecordingDate= '" + d + "' Where HOST = '" + s + "'";
                                    try
                                    {
                                        cnn.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch
                                    {
                                    }
                                    finally
                                    {
                                        cnn.Close();

                                    }

                                    counter++; //Keeps track of number of failed pings
                                    if (counter > 3) //Enters here if failed ping more than 3 times
                                    {

                                        counter = 0;
                                        NotifyIconsuspend();
                                        sendemail();
                                        //groupBoxhide.Visible = true;
                                        //groupBoxhide.BringToFront();
                                        //btnRes.Visible = true;
                                        //_wait.WaitOne();//Pause the loop until the button was clicked.
                                        cmd.CommandText = "UPDATE PingLog SET Status = 'NOTIF', RecordingDate= '" + d + "' Where HOST = '" + s + "'";
                                       
                                        try
                                        {
                                            cnn.Open();
                                            cmd.ExecuteNonQuery();
                                        }
                                        catch
                                        {
                                        }
                                        finally
                                        {
                                            cnn.Close();

                                        }

                                    }
                                    else
                                    {

                                    }

                                } 
                                                }
                        }
                    }

                    catch
                    {
                       
                    }

                }
                else
                    lstBox.Items.Add("Can't reach table to Ping" + "\n");

            }
            


        }

        private void lstBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            var myValue = lstBox.GetItemText(lstBox.SelectedValue);

            if (myValue.Contains("TimeOut"))
                e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            //else if (myValue.Contains(" ... Missing!")
            else
                e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            e.Graphics.DrawString(lstBox.SelectedIndex.ToString(), e.Font, Brushes.Black, new PointF(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }

         private void pingResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sPath = Path.Combine(Path.GetTempPath(), "PingLogs");
          
            System.Diagnostics.Process.Start(sPath);
            

        }



        private void sendemail()
            {
            notifyIconsuspend.Icon = SystemIcons.Exclamation;
            MailMessage mail = new MailMessage();
            string ConnStr = ConfigurationManager.AppSettings["ConnStr"].ToString(); //Loads the PingLog list
            SqlConnection cnn = new SqlConnection(ConnStr);

            string status = "OFF";
            var admincmdb = new SqlCommand("SELECT * FROM PingLog WHERE Status = @Status", cnn); // Finds status of PingLog List
            admincmdb.Parameters.AddWithValue("@Status", status);
            admincmdb.Parameters.AddWithValue("@HostType", status);

              cnn.Open();
                SqlDataReader adminreaderJob = admincmdb.ExecuteReader();
                while (adminreaderJob.Read())
                {
                    string strHost = adminreaderJob.GetString(adminreaderJob.GetOrdinal("HostType")).ToString();
                    string strIP = adminreaderJob.GetString(adminreaderJob.GetOrdinal("Host")).ToString();

                if (adminreaderJob.HasRows)
                    {

                    mail.Subject = "Ping Monitor: A Host " + strHost + " is having an issue.";
                    //email info
                    mail.To.Add("CSP_CMTeam@IGT.com");
                        mail.From = new MailAddress("CSPCMTeam@IGT.com");
                        mail.IsBodyHtml = false;
                        DateTime time = DateTime.Now;
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("");
                        sb.AppendLine("What : Failed to respond to Ping");
                        sb.AppendLine("");
                        sb.AppendLine("Who : Machine - " + strHost + " , " + strIP + "");
                        sb.AppendLine("");
                        sb.AppendLine("When : Issue happened at " + time + "");
                        sb.AppendLine("");

                        mail.Body = sb.ToString();

                        SmtpClient smtp = new SmtpClient("156.24.14.160", 587);
                        smtp.EnableSsl = false;

                        try
                        {
                            smtp.Send(mail);
                        }
                        catch
                        {
                        }

                    }
                }
               
            }
        

    public void frmMonitoringPage_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon 
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIconsuspend.Visible = true;
            }
        }

        public void notifyIconsuspend_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIconsuspend.Visible = false;
            Focus();
        }

        
        public void NotifyIconsuspend()
        {
        string ConnStr = ConfigurationManager.AppSettings["ConnStr"].ToString(); //Loads the PingLog list
        SqlConnection cnn = new SqlConnection(ConnStr);

        string status = "OFF";
        var admincmdb = new SqlCommand("SELECT * FROM PingLog WHERE Status = @Status", cnn); // Finds status of PingLog List
        admincmdb.Parameters.AddWithValue("@Status", status);
        admincmdb.Parameters.AddWithValue("@HostType", status); 

        try
        {
        cnn.Open();
        SqlDataReader adminreaderJob = admincmdb.ExecuteReader();
        while (adminreaderJob.Read())
        {
        string strHost = adminreaderJob.GetString(adminreaderJob.GetOrdinal("HostType")).ToString();

        if (adminreaderJob.HasRows)
        {
        
        //displays stuff in the tray balloon
        notifyIconsuspend.Visible = true;
        notifyIconsuspend.BalloonTipTitle = "Ping Monitor - Connection Errors";
        notifyIconsuspend.BalloonTipText = "A Machine: " + strHost + " is having an issue";
        notifyIconsuspend.BalloonTipIcon = ToolTipIcon.Error;
        notifyIconsuspend.ShowBalloonTip(3000);

        }

        else
        {
        }
        }
        cnn.Close();
        }
        catch
        {
        }
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            groupBoxhide.Visible = false;
            btnRes.Visible = false;
            _wait.Set(); //Resumes ping Thread
            //notifyIconsuspend = new System.Windows.Forms.NotifyIcon();
            notifyIconsuspend.Visible = true;
            notifyIconsuspend.Icon = SystemIcons.Application;
        }

        private void notifyIconsuspend_Click(object sender, EventArgs e)
        {
            contextMenuStripTray.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            this.Activate();
            this.Focus();
        }

        private void contextMenuStripTray_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void manualPINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Windows\system32\cmd.exe");
        }

        private void notifyIconsuspend_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
        WindowState = FormWindowState.Normal;
            Activate();
            Focus();
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        Activate();
            Focus();
        }
    }

   }