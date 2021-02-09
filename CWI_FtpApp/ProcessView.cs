using Controllers;
using ICW_FtpApp.Controller;
using ICW_FtpApp ;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Controllers.Services;

namespace ICW_FtpApp
{
    public partial class ProcessView : Form, IProcessView
    {
     
        private bool _IsDownload;
        private string _OwnerScheme;  //used for the downloads.
        List <string> _SelectedUploadIDs = new List<string>();

        public ProcessView(bool isDownload, string OwnerScheme = "")
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; 

         
            if (isDownload)
            {
                grpDetails.Text = "Pharmacy FTP Downloads"; 
            }
            else
                grpDetails.Text = "Pharmacy FTP Uploads";

            _OwnerScheme = OwnerScheme;
            _IsDownload = isDownload; 

            rdoDownloads.Checked = isDownload;
            rdoUploads.Checked = !isDownload;

            txtHoursGoBack.Text = "48";

            SetupStaticData();
              
        }

        //The view needs an instance of controller for the events/actions requested from this view.
        //IE: Get data, Start Ftp, Save-click, etc
        ProcessController _controller; 
        public void SetController(ProcessController controller)
        {
            _controller = controller;
        }

        public void SetupStaticData()
        { 
            FtpTypes = new List<FTPTypes> { new FTPTypes(eFtpTypes.None.ToString()),
                                            new FTPTypes(eFtpTypes.SFTP.ToString()), 
                                            new FTPTypes(eFtpTypes.FTP.ToString()) }; 
            cboFtpType.DataSource = FtpTypes;
            cboFtpType.DisplayMember = "FtpType";
            cboFtpType.ValueMember = "FtpType";

            List<KeyValuePair<string, string>> myChoices = new List<KeyValuePair<string, string>>();

            myChoices.Add(new KeyValuePair<string, string>("SUSPENDED", "SUSPENDED"));
            myChoices.Add(new KeyValuePair<string, string>("ACTIVE", "ACTIVE"));
            cboStatus.DataSource = myChoices;
            cboStatus.DisplayMember = "Value";
            cboStatus.ValueMember = "Value";

            //show the scheme owner dropdown only for Uploads
            if (_IsDownload)
            {
                cboSchemeOwner.Visible = false;
                btnSchemeOwnerGO.Visible = false;
                txtShowUploadMsg.Visible = false;
                txtUploadFolder.Visible = false;
                btnBrowseUploadFolder.Visible = false;
            }
            else 
            {
                txtShowUploadMsg.Visible = true;
                cboSchemeOwner.Visible = true;
                btnSchemeOwnerGO.Visible = true;
                txtUploadFolder.Visible = true;
                btnBrowseUploadFolder.Visible = true;

                myChoices = new List<KeyValuePair<string, string>>();
                myChoices.Add(new KeyValuePair<string, string>("All", "All"));
                myChoices.Add(new KeyValuePair<string, string>("PURE", "PURE"));
                myChoices.Add(new KeyValuePair<string, string>("DEBOORD", "DEBOORD"));
                myChoices.Add(new KeyValuePair<string, string>("STELKOR", "STELKOR"));
                myChoices.Add(new KeyValuePair<string, string>("SENTINELWH", "SENTINELWH"));
                myChoices.Add(new KeyValuePair<string, string>("Other", "Other"));
                cboSchemeOwner.DataSource = myChoices;
                cboSchemeOwner.DisplayMember = "Value";
                cboSchemeOwner.ValueMember = "Value"; 

                if (_OwnerScheme != "")
                    cboSchemeOwner.SelectedValue = _OwnerScheme;

                txtShowUploadMsg.Text = "Uploads for " + _OwnerScheme + " schemes ";
                txtShowUploadMsg.BorderStyle = BorderStyle.None;

                lblShowSchemeSelected.Text = txtShowUploadMsg.Text;
                lblShowSchemeSelected.Text += _SelectedUploadIDs.Count.ToString() + " items selected!";    
                 
            }
            _SelectedUploadIDs.Clear();
            lblSelectedRowsWaiting.Visible = false;
            lblSelectedRowsWaiting.Text = "";
        }
        public void ClearGrid()
        {
            // Define columns in grid
            this.lvwProcesses.Columns.Clear();

            this.lvwProcesses.Columns.Add("Id", 30, HorizontalAlignment.Left);
            this.lvwProcesses.Columns.Add("RAM", 60, HorizontalAlignment.Left);
            this.lvwProcesses.Columns.Add("Pharmacy", 150, HorizontalAlignment.Left);
            this.lvwProcesses.Columns.Add("Host IP", 110, HorizontalAlignment.Left);
            this.lvwProcesses.Columns.Add("Port", 40, HorizontalAlignment.Left);
            this.lvwProcesses.Columns.Add("Login", 50, HorizontalAlignment.Left);
            this.lvwProcesses.Columns.Add("Password", 80, HorizontalAlignment.Left);
            this.lvwProcesses.Columns.Add("FtpType", 60, HorizontalAlignment.Left);
            this.lvwProcesses.Columns.Add("Remote Dir", 80, HorizontalAlignment.Left);
            this.lvwProcesses.Columns.Add("Local Dir", 150, HorizontalAlignment.Left);
            this.lvwProcesses.Columns.Add("Pattern", 70, HorizontalAlignment.Left);
            this.lvwProcesses.Columns.Add("Owner", 70, HorizontalAlignment.Left);
            this.lvwProcesses.Columns.Add("Status", 70, HorizontalAlignment.Left);
         
            // Add rows to grid
            this.lvwProcesses.Items.Clear();  

        }
        public void AddProcToGrid(Process proc)
        { 

            ListViewItem lvwi = new ListViewItem();
            lvwi.Text = proc.ID;// myRow["RID"].ToString();
            lvwi.SubItems.Add(proc.RAM);
            lvwi.SubItems.Add(proc.PharmacyName);
            lvwi.SubItems.Add(proc.HostIP);
            lvwi.SubItems.Add(proc.Port);
            lvwi.SubItems.Add(proc.Login);
            lvwi.SubItems.Add(proc.Password);
            lvwi.SubItems.Add(proc.FtpType); 
            lvwi.SubItems.Add(proc.RemoteDir);
            lvwi.SubItems.Add(proc.LocalDir);
            lvwi.SubItems.Add(proc.Pattern);
            lvwi.SubItems.Add(proc.OwnerScheme);
            lvwi.SubItems.Add(proc.Status);
            //lvwi.SubItems.Add(proc.Status.ToString());  
            lvwProcesses.Items.Add(lvwi);
       

        }
        public void SetSelectedProcessInGrid(Process proc)
        {
            foreach (ListViewItem row in this.lvwProcesses.Items)
            {
                if (row.Text == proc.ID)
                {
                    row.Selected = true;
                }
            }
        }
        public void UpdateGridWithChangedProcess(Process proc)
        {
            ListViewItem rowToUpdate = null;

            foreach (ListViewItem row in  lvwProcesses.Items)
            {
                if (row.Text == proc.ID)
                {
                    rowToUpdate = row;
                }
            }

            if (rowToUpdate != null)
            {
                rowToUpdate.Text = proc.ID;
                rowToUpdate.SubItems[1].Text = proc.RAM;
                rowToUpdate.SubItems[2].Text = proc.PharmacyName;
                rowToUpdate.SubItems[3].Text = proc.HostIP;
                rowToUpdate.SubItems[4].Text = proc.Port;
                rowToUpdate.SubItems[5].Text = proc.Login;
                rowToUpdate.SubItems[6].Text = proc.Password;
                rowToUpdate.SubItems[7].Text = proc.FtpType;
                rowToUpdate.SubItems[8].Text = proc.RemoteDir;
                rowToUpdate.SubItems[9].Text = proc.LocalDir;
                rowToUpdate.SubItems[10].Text = proc.Pattern;
                rowToUpdate.SubItems[11].Text = proc.OwnerScheme; 
                rowToUpdate.SubItems[12].Text = proc.Status;
                //rowToUpdate.SubItems[8].Text = proc.Status.ToString(); 

            }
        }

        public void RemoveFromGrid(Process proc)
        {

            ListViewItem rowToRemove = null;

            foreach (ListViewItem row in  lvwProcesses.Items)
            {
                if (row.Text == proc.ID)
                {
                    rowToRemove = row;
                }
            }

            if (rowToRemove != null)
            {
                lvwProcesses.Items.Remove(rowToRemove);
                lvwProcesses.Focus();
            }
        }

        public string GetIdOfSelectedProcessInGrid()
        {
            if ( lvwProcesses.SelectedItems.Count > 0)
                return lvwProcesses.SelectedItems[0].Text;
            else
                return "";
        }
        private List<FTPTypes> FtpTypes = new List<FTPTypes>();


        public string PharmacyName
        {
            get { return this.txtPharmacyName.Text; }
            set { this.txtPharmacyName.Text = value; }
        }
        public string ID
        {
            get { return this.txtID.Text; }
            set { this.txtID.Text = value; }
        }
        public string RAM
        {
            get { return this.txtRAM.Text; }
            set { this.txtRAM.Text = value; }
        }
        public string LocalDir
        {
            get { return this.txtLocalDir.Text; }
            set { this.txtLocalDir.Text = value; }
        }

        public string RemoteDir
        {
            get { return this.txtRemoteDir.Text; }
            set { this.txtRemoteDir.Text = value; }
        }

        public string HostIP
        {
            get { return this.txtHostIP.Text; }
            set { this.txtHostIP.Text = value; }
        }

        public string Port
        {
            get { return this.txtPort.Text; }
            set { this.txtPort.Text = value; }
        }

        public string Password
        {
            get { return this.txtPassword.Text; }
            set { this.txtPassword.Text = value; }
        }

        public string Login
        {
            get { return this.txtLogin.Text; }
            set { this.txtLogin.Text = value; }
        }

        public string FtpType
        {
            get { return this.cboFtpType.SelectedValue.ToString(); }
            set { this.cboFtpType.SelectedValue = value; }
        }

        public string Account
        {
            get { return this.txtAccount.Text; }
            set { this.txtAccount.Text = value; }
        }
        public string Pattern  
        {
            get { return this.txtPattern.Text; }
            set { this.txtPattern.Text = value; }
        }
        public string   OwnerScheme
        {
            get { return this.txtOwnerScheme.Text; }
            set { this.txtOwnerScheme.Text = value; }
        }


        public string Status
        {
            get { return this.cboStatus.SelectedValue.ToString(); }
            set { this.cboStatus.SelectedValue = value; }
        }
         

        public bool IsDownload
        {
            get { return this._IsDownload; }
        }

        
        public bool CanModifyID
        {
            set { this.txtID.Enabled = value; }
        } 
    
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidEntry())
                    return; 

                _controller.Save();
                MessageBox.Show(this, "Save completed successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            catch (Exception ex)
            {
               MessageBox.Show(this, "Save failed! " + ex.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cboFtpType.SelectedIndex = cboFtpType.Items.IndexOf("None");
           _controller.AddNewProcess();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
             _controller.RemoveProcess();
        }

        private void btnDownloadFtp_Click(object sender, EventArgs e)
        { 
            //Activates the FTP process 
            if (ValidDownloadRequest())
            {
                DownloadFtp controllerFtp = new DownloadFtp();
                controllerFtp.ProcessAllFtp(Convert.ToInt32(txtHoursGoBack.Text));
                richTextBox1.Text = controllerFtp._results;
            }
        }
          
        private void btnFtpUpload_Click(object sender, EventArgs e)
        {
            string[] FolderFiles;
            string[] Folders;
            try
            {
                 FolderFiles = Directory.GetFiles(txtUploadFolder.Text);
                 Folders = Directory.GetFileSystemEntries( txtUploadFolder.Text, "*", SearchOption.TopDirectoryOnly);

            }
            catch(Exception )
            {
                MessageBox.Show(this, "Please select a valid folder for upload files", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboFtpType.Focus();
                return; 
            }
            if (FolderFiles.Length == null)    
            {
                MessageBox.Show(this, "Please select a folder with files in it", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboFtpType.Focus();
                return; 
            }
            if (FolderFiles.Length == 0 && Folders.Length == 0)
            {
                MessageBox.Show(this, "Please select a folder with contents", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboFtpType.Focus();
                return  ;
            }


            DialogResult dialogResult = MessageBox.Show("Are you sure you want to upload from this directory? \n\r" + txtUploadFolder.Text, "Continue?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {   
                UploadFtp controllerFtp = new UploadFtp();

                controllerFtp._UploadFolder = txtUploadFolder.Text;
                controllerFtp._SelectedUploadIDs = _SelectedUploadIDs;

                controllerFtp.ProcessAllFtp();

                rtbUploadResults.Text = controllerFtp._results;
                _SelectedUploadIDs.Clear();
                lblSelectedRowsWaiting.Visible = false;
                lblSelectedRowsWaiting.Text = "";


            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
             
        }
 

        private void btnToggleSubmit_Click(object sender, EventArgs e) //c
        { 
            this.Dispose(); 
            this.Close(); 
 
            ProcessView view = new ProcessView(rdoDownloads.Checked); 
            
            view.Visible = false;
            ProcessController controller = new ProcessController(view);
            controller.LoadView();
            view.ShowDialog(); 
        }


        private void btnSchemeOwnerGO_Click(object sender, EventArgs e)
        {
            //reload the entire page!

            this.Dispose();
            this.Close();

            ProcessView view = new ProcessView(rdoDownloads.Checked, cboSchemeOwner.SelectedValue.ToString());
            
            view.Visible = false;
            ProcessController controller = new ProcessController(view, view.cboSchemeOwner.SelectedValue.ToString());
            controller.LoadView();
            view.ShowDialog();
        }

        private void btnBrowseUploadFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtUploadFolder.Text = fbd.SelectedPath;
                }
            }
        }
        private void btnLoadRow_Click(object sender, EventArgs e)
        {
            if (lvwProcesses.SelectedItems.Count > 0)
            {
                _SelectedUploadIDs.Clear();

                foreach (ListViewItem item in lvwProcesses.SelectedItems)
                {
                    _controller.SelectedProcessChanged(item.Text);
                    _SelectedUploadIDs.Add(item.Text);
                }
                lblSelectedRowsWaiting.Visible = true;
                lblSelectedRowsWaiting.Text = String.Format("you have selected {0} rows", _SelectedUploadIDs.Count.ToString());
                lblShowSchemeSelected.Text = String.Format("{0} {1} items selected", txtShowUploadMsg.Text, _SelectedUploadIDs.Count.ToString());
                //lblShowSchemeSelected.Text += _SelectedUploadIDs.Count.ToString() + " items selected!";    
            }
        }

        private Boolean ValidEntry()
        { 
            try
            {
                if (cboFtpType.SelectedValue == null)
                {
                    MessageBox.Show(this, "Please select a FTP Type", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboFtpType.Focus();
                    return false;
                }

                if (cboFtpType.SelectedIndex <= 0)
                {
                    MessageBox.Show(this, "Please select a FTP Type", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboFtpType.Focus();
                    return false;
                }
      
                if (  txtLocalDir.Text.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >  0)
                {
                    MessageBox.Show(this, "Please enter a valid Local Directory", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLocalDir.Focus();
                    return false;
                }
                if (!string.IsNullOrEmpty(txtRemoteDir.Text) && txtRemoteDir.Text.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0)
                   {
                    MessageBox.Show(this, "Please enter a valid Remote Directory", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRemoteDir.Focus();
                    return false;
                }

                if (txtRAM.Text.Trim().Length == 0)
                {
                    MessageBox.Show(this, "Please enter a valid value for RAM", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     txtRAM.Focus(); 
                    return false;
                } 
                
                if (Convert.ToInt32(txtHoursGoBack.Text) < 0)
                {
                    MessageBox.Show(this, "Please enter a valid value for Hours go-back", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     txtHoursGoBack.Focus();
                    return false;
                } 
                return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        private Boolean ValidDownloadRequest()
        {
            try
            { 
                if (Convert.ToDecimal(txtHoursGoBack.Text) < 0)
                {
                    MessageBox.Show(this, "Please enter a valid value for Hours go-back", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoursGoBack.Focus();
                    return false;
                }
                return true;
            }
            catch (FormatException fe)
            {
                MessageBox.Show(this, "Please enter a valid value for Hours go-back", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoursGoBack.Focus();
                return false;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        enum eFtpTypes
        {
            None,
            SFTP = 1,
            FTP = 2
        };

       
    }
    public class FTPTypes
    {
        public string FTPType { get; set; }
        public FTPTypes(string _name)
        {
            FTPType = _name;
        }
    }
}