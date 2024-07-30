using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace PingMonitor
{
  public partial class frmConfig : Form
  {
    private DataTable dtHosts = new DataTable();
    private SqlDataAdapter daHosts;

    public frmConfig()
    {
      InitializeComponent();
    }

    private void frmConfig_Load(object sender, EventArgs e)
    {
            chkDoPing.Hide();
            chkShowInMonitor.Hide();
            txtPingFreq.Hide();
            lblPingFreq.Hide();
      string ConnStr = ConfigurationManager.AppSettings["ConnStr"].ToString();           
            daHosts = new SqlDataAdapter("SELECT * FROM PingLog", ConnStr);
            SqlCommandBuilder cb = new SqlCommandBuilder(daHosts);
      daHosts.InsertCommand = cb.GetInsertCommand();
      daHosts.UpdateCommand = cb.GetUpdateCommand();
      daHosts.DeleteCommand = cb.GetDeleteCommand();
      lblVer.Text = Application.ProductVersion;
      ReLoadTree();
    }

    private void ReLoadTree()
    {
      dtHosts.Clear();
      daHosts.Fill(dtHosts);

      tvHosts.Nodes.Clear();
      tvHosts.Nodes.Add("Root");
            LoadChildNodes("IDparent IS NULL", tvHosts.Nodes[0]);
            tvHosts.SelectedNode = tvHosts.Nodes[0];
    }

    private void LoadChildNodes(string Filter, TreeNode Node)
    {
      DataView dv = new DataView(dtHosts, Filter, "Host", DataViewRowState.Unchanged);
      DataRowView dr;
      for (int i = 0; i <= dv.Count - 1; i++)
      {
        dr = dv[i];
        Node.Nodes.Add(dr["Host"].ToString());
        Node.Nodes[i].Tag = dr;
        //if ((!object.ReferenceEquals(dr["IsHost"], DBNull.Value)) && dr["IsHost"].ToString() == "Y")
        if (!object.ReferenceEquals(dr["Host"], DBNull.Value))
        {
          Node.Nodes[i].ImageIndex = 1;
          Node.Nodes[i].SelectedImageIndex = 2;
        }
        else
        {
          Node.Nodes[i].ImageIndex = 0;
        }
                LoadChildNodes("IDparent=" + dr["ID"], Node.Nodes[i]);
                //LoadChildNodes("Host=" + dr["Host"], Node.Nodes[i]);
                Node.Expand();
      }
    }

    private void mniDelete_Click(object sender, System.EventArgs e)
    {
      if (tvHosts.SelectedNode.Tag == null) return; // TODO: might not be correct. Was : Exit Sub

      DataRowView dr = (DataRowView)tvHosts.SelectedNode.Tag;
      if (dtHosts.Select("IDparent=" + dr["ID"]).Length > 0)
      {
        MessageBox.Show("You can only delete leaf nodes!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return; 
      }
      foreach (DataRow r in dtHosts.Rows)
      {
                //if (r["ID"] == dr["ID"])
                if (r["Host"] == dr["Host"])
                {
          r.Delete();
          break; 
        }
      }
      daHosts.Update(dtHosts);
      ReLoadTree();
    }

    private void mniAddFolder_Click(object sender, System.EventArgs e)
    {
      object ParentID;
      if (tvHosts.SelectedNode.Tag == null)
      {
        ParentID = DBNull.Value;
      }
      else
      {
        DataRowView dr = (DataRowView)tvHosts.SelectedNode.Tag;
        if ((!object.ReferenceEquals(dr["IsHost"], DBNull.Value)) && dr["IsHost"].ToString() == "Y")
        {
          MessageBox.Show("You can only add children to folder nodes!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          return; 
        }
        ParentID = dr["ID"];
      }

      DataRow r = dtHosts.NewRow();
      r["Host"] = "New folder";
     
      dtHosts.Rows.Add(r);

      daHosts.Update(dtHosts);
      ReLoadTree();
    }

    private void tvHosts_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
    {
            lblStatus.Text = "";
      if (tvHosts.SelectedNode.Tag == null)
      {
        // Root node
        pnlDetail.Visible = false;
      }
      else
      {
        pnlDetail.Visible = true;
        DataRowView dr = (DataRowView)tvHosts.SelectedNode.Tag;
       
        if (!object.ReferenceEquals(dr["Host"], DBNull.Value))
                {
          // Host node
          chkDoPing.Visible = false;
          lblPingFreq.Visible = false;
          txtPingFreq.Visible = false;
          chkShowInMonitor.Visible = false;
          txtHost.Text = dr["Host"].ToString();
          comboBoxHostType.Text = dr["HostType"].ToString();
          
        }
        else
        {
          // Folder node
          chkDoPing.Visible = false;
          lblPingFreq.Visible = false;
          txtPingFreq.Visible = false;
          chkShowInMonitor.Visible = false;
          txtHost.Text = dr["Host"].ToString();
        }
      }
    }

    private void chkDoPing_CheckedChanged(object sender, System.EventArgs e)
    {
      try
      {
        if (tvHosts.SelectedNode.Tag == null) 
          return; 
      }
      catch
      {
        return; 
      }
      txtPingFreq.Enabled = chkDoPing.Checked;
      chkShowInMonitor.Enabled = chkDoPing.Checked;
      DataRowView dr = (DataRowView)tvHosts.SelectedNode.Tag;
      if (chkDoPing.Checked)
      {
        dr["DoPing"] = "Y";
      }
      else
      {
        dr["DoPing"] = DBNull.Value;
      }
      daHosts.Update(dtHosts);
    }

    private void chkShowInMonitor_CheckedChanged(object sender, System.EventArgs e)
    {
      try
      {
        if (tvHosts.SelectedNode.Tag == null) 
          return; 
      }
      catch
      {
        return; 
      }
      DataRowView dr = (DataRowView)tvHosts.SelectedNode.Tag;
      if (chkShowInMonitor.Checked)
      {
        dr["ShowInMonitor"] = "Y";
      }
      else
      {
        dr["ShowInMonitor"] = DBNull.Value;
      }
      daHosts.Update(dtHosts);
    }

    private void txtPingFreq_LostFocus(object sender, System.EventArgs e)
    {
      try
      {
        if (tvHosts.SelectedNode.Tag == null) 
          return; 
      }
      catch
      {
        return; 
      }
      DataRowView dr = (DataRowView)tvHosts.SelectedNode.Tag;
      if (Information.IsNumeric(txtPingFreq.Text))
      {
        dr["PingFreq"] = int.Parse(txtPingFreq.Text);
        daHosts.Update(dtHosts);
      }
    }

        private void txtHost_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                if (tvHosts.SelectedNode.Tag == null)
                    return;
            }
            catch
            {
                return;
            }
            DataRowView dr = (DataRowView)tvHosts.SelectedNode.Tag;
            if (txtHost.Text.Trim() != "")
            {
                try
                {
                    tvHosts.SelectedNode.Text = txtHost.Text.Trim();
                    dr["Host"] = txtHost.Text.Trim();
                    daHosts.Update(dtHosts);
                }
                catch
                {
                    return;
                }
            }
        }


    private void mniAddHost_Click(object sender, System.EventArgs e)
    {
            object ParentID;
      if (tvHosts.SelectedNode.Tag == null)
      {
                ParentID = DBNull.Value;
            }
      else
      {
        DataRowView dr = (DataRowView)tvHosts.SelectedNode.Tag;
                if (!object.ReferenceEquals(dr["Host"], DBNull.Value))
                {
                    lblStatus.Text = "Add Host to root only";
                    
                    return; 
                }
                ParentID = (int)dr["Host"];
                      }

      DataRow r = dtHosts.NewRow();
            r["Host"] = "New IP";            
            r["IDparent"] = ParentID;
            r["Status"] = "ON";
      r["RecordingDate"] = DateAndTime.Now;
      r["HostType"] = "Perforce";
      dtHosts.Rows.Add(r);

      daHosts.Update(dtHosts);
      ReLoadTree();
    }

        private void comboBoxHostType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tvHosts.SelectedNode.Tag == null)
                    return;
            }
            catch
            {
                return;
            }
            DataRowView dr = (DataRowView)tvHosts.SelectedNode.Tag;
            if (txtHost.Text.Trim() != "")
            {
                tvHosts.SelectedNode.Text = comboBoxHostType.Text.Trim();
                dr["HostType"] = comboBoxHostType.Text.Trim();
                try
                {
                    daHosts.Update(dtHosts);
                }
                catch {
                    lblStatus.Text = "Add Host to root only";
                }
            }
        }
        
        private void btnHost_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconn"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "INSERT INTO dbo.PingLog (Host, RecordingDate, HostType, Status) values (@Host, @RecordingDate, @HostType, @Status)";

            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@HostType", comboBoxHostType.Text.ToString());
            sqlcomm.Parameters.AddWithValue("@Host", txtHost.Text.ToString());
            sqlcomm.Parameters.AddWithValue("@RecordingDate", DateTime.Now);
            sqlcomm.Parameters.AddWithValue("@Status", "ON");
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();

            ReLoadTree();
        }

        
    }
}