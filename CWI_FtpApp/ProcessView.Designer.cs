namespace ICW_FtpApp
{
    partial class ProcessView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessView));
            this.lvwProcesses = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.btnLoadRow = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOwnerScheme = new System.Windows.Forms.TextBox();
            this.lblSelectedRowsWaiting = new System.Windows.Forms.Label();
            this.btnBrowseUploadFolder = new System.Windows.Forms.Button();
            this.txtUploadFolder = new System.Windows.Forms.TextBox();
            this.txtShowUploadMsg = new System.Windows.Forms.TextBox();
            this.btnSchemeOwnerGO = new System.Windows.Forms.Button();
            this.cboSchemeOwner = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.cboFtpType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoUploads = new System.Windows.Forms.RadioButton();
            this.rdoDownloads = new System.Windows.Forms.RadioButton();
            this.btnToggleSubmit = new System.Windows.Forms.Button();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRAM = new System.Windows.Forms.TextBox();
            this.txtRemoteDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHostIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPharmacyName = new System.Windows.Forms.TextBox();
            this.lblpwd = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtLocalDir = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHoursGoBack = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnDownloadFtp = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblShowSchemeSelected = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rtbUploadResults = new System.Windows.Forms.RichTextBox();
            this.btnFtpUpload = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwProcesses
            // 
            this.lvwProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProcesses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwProcesses.FullRowSelect = true;
            this.lvwProcesses.GridLines = true;
            this.lvwProcesses.Location = new System.Drawing.Point(19, 16);
            this.lvwProcesses.Margin = new System.Windows.Forms.Padding(7);
            this.lvwProcesses.Name = "lvwProcesses";
            this.lvwProcesses.Size = new System.Drawing.Size(2414, 976);
            this.lvwProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwProcesses.TabIndex = 37;
            this.lvwProcesses.UseCompatibleStateImageBehavior = false;
            this.lvwProcesses.View = System.Windows.Forms.View.Details;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.lvwProcesses);
            this.panel1.Location = new System.Drawing.Point(35, 594);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2440, 1020);
            this.panel1.TabIndex = 40;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(44, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2665, 1707);
            this.tabControl1.TabIndex = 41;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpDetails);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(10, 47);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(2645, 1650);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Processes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.btnLoadRow);
            this.grpDetails.Controls.Add(this.label13);
            this.grpDetails.Controls.Add(this.txtOwnerScheme);
            this.grpDetails.Controls.Add(this.lblSelectedRowsWaiting);
            this.grpDetails.Controls.Add(this.btnBrowseUploadFolder);
            this.grpDetails.Controls.Add(this.txtUploadFolder);
            this.grpDetails.Controls.Add(this.txtShowUploadMsg);
            this.grpDetails.Controls.Add(this.btnSchemeOwnerGO);
            this.grpDetails.Controls.Add(this.cboSchemeOwner);
            this.grpDetails.Controls.Add(this.label10);
            this.grpDetails.Controls.Add(this.cboStatus);
            this.grpDetails.Controls.Add(this.cboFtpType);
            this.grpDetails.Controls.Add(this.label9);
            this.grpDetails.Controls.Add(this.txtPort);
            this.grpDetails.Controls.Add(this.groupBox1);
            this.grpDetails.Controls.Add(this.txtPattern);
            this.grpDetails.Controls.Add(this.label6);
            this.grpDetails.Controls.Add(this.btnRegister);
            this.grpDetails.Controls.Add(this.btnRemove);
            this.grpDetails.Controls.Add(this.txtAccount);
            this.grpDetails.Controls.Add(this.btnAdd);
            this.grpDetails.Controls.Add(this.label5);
            this.grpDetails.Controls.Add(this.label4);
            this.grpDetails.Controls.Add(this.txtLogin);
            this.grpDetails.Controls.Add(this.label1);
            this.grpDetails.Controls.Add(this.txtRAM);
            this.grpDetails.Controls.Add(this.txtRemoteDir);
            this.grpDetails.Controls.Add(this.label3);
            this.grpDetails.Controls.Add(this.txtHostIP);
            this.grpDetails.Controls.Add(this.label2);
            this.grpDetails.Controls.Add(this.txtPassword);
            this.grpDetails.Controls.Add(this.txtPharmacyName);
            this.grpDetails.Controls.Add(this.lblpwd);
            this.grpDetails.Controls.Add(this.txtID);
            this.grpDetails.Controls.Add(this.lblID);
            this.grpDetails.Controls.Add(this.txtLocalDir);
            this.grpDetails.Controls.Add(this.lblAccount);
            this.grpDetails.Controls.Add(this.lblFirstName);
            this.grpDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpDetails.Location = new System.Drawing.Point(35, 25);
            this.grpDetails.Margin = new System.Windows.Forms.Padding(7);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Padding = new System.Windows.Forms.Padding(7);
            this.grpDetails.Size = new System.Drawing.Size(2430, 548);
            this.grpDetails.TabIndex = 39;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Pharmacy Ftp Process:";
            // 
            // btnLoadRow
            // 
            this.btnLoadRow.Location = new System.Drawing.Point(803, 489);
            this.btnLoadRow.Name = "btnLoadRow";
            this.btnLoadRow.Size = new System.Drawing.Size(275, 46);
            this.btnLoadRow.TabIndex = 64;
            this.btnLoadRow.Text = "Load row/s";
            this.btnLoadRow.UseVisualStyleBackColor = true;
            this.btnLoadRow.Click += new System.EventHandler(this.btnLoadRow_Click);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(41, 440);
            this.label13.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(176, 51);
            this.label13.TabIndex = 63;
            this.label13.Text = "Owner";
            // 
            // txtOwnerScheme
            // 
            this.txtOwnerScheme.Location = new System.Drawing.Point(226, 440);
            this.txtOwnerScheme.Margin = new System.Windows.Forms.Padding(7);
            this.txtOwnerScheme.Name = "txtOwnerScheme";
            this.txtOwnerScheme.Size = new System.Drawing.Size(506, 35);
            this.txtOwnerScheme.TabIndex = 61;
            // 
            // lblSelectedRowsWaiting
            // 
            this.lblSelectedRowsWaiting.AutoSize = true;
            this.lblSelectedRowsWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedRowsWaiting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblSelectedRowsWaiting.Location = new System.Drawing.Point(34, 46);
            this.lblSelectedRowsWaiting.Name = "lblSelectedRowsWaiting";
            this.lblSelectedRowsWaiting.Size = new System.Drawing.Size(282, 29);
            this.lblSelectedRowsWaiting.TabIndex = 60;
            this.lblSelectedRowsWaiting.Text = " lblSelectedRowsWaiting";
            // 
            // btnBrowseUploadFolder
            // 
            this.btnBrowseUploadFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseUploadFolder.Location = new System.Drawing.Point(2275, 54);
            this.btnBrowseUploadFolder.Margin = new System.Windows.Forms.Padding(7);
            this.btnBrowseUploadFolder.Name = "btnBrowseUploadFolder";
            this.btnBrowseUploadFolder.Size = new System.Drawing.Size(65, 45);
            this.btnBrowseUploadFolder.TabIndex = 59;
            this.btnBrowseUploadFolder.Text = "...";
            this.btnBrowseUploadFolder.UseVisualStyleBackColor = true;
            this.btnBrowseUploadFolder.Click += new System.EventHandler(this.btnBrowseUploadFolder_Click);
            // 
            // txtUploadFolder
            // 
            this.txtUploadFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUploadFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUploadFolder.Location = new System.Drawing.Point(1294, 57);
            this.txtUploadFolder.Margin = new System.Windows.Forms.Padding(7);
            this.txtUploadFolder.Name = "txtUploadFolder";
            this.txtUploadFolder.Size = new System.Drawing.Size(977, 35);
            this.txtUploadFolder.TabIndex = 58;
            // 
            // txtShowUploadMsg
            // 
            this.txtShowUploadMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShowUploadMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtShowUploadMsg.Location = new System.Drawing.Point(1804, 437);
            this.txtShowUploadMsg.Name = "txtShowUploadMsg";
            this.txtShowUploadMsg.Size = new System.Drawing.Size(541, 35);
            this.txtShowUploadMsg.TabIndex = 57;
            // 
            // btnSchemeOwnerGO
            // 
            this.btnSchemeOwnerGO.Image = ((System.Drawing.Image)(resources.GetObject("btnSchemeOwnerGO.Image")));
            this.btnSchemeOwnerGO.Location = new System.Drawing.Point(2293, 482);
            this.btnSchemeOwnerGO.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSchemeOwnerGO.Name = "btnSchemeOwnerGO";
            this.btnSchemeOwnerGO.Size = new System.Drawing.Size(61, 58);
            this.btnSchemeOwnerGO.TabIndex = 56;
            this.btnSchemeOwnerGO.UseVisualStyleBackColor = true;
            this.btnSchemeOwnerGO.Click += new System.EventHandler(this.btnSchemeOwnerGO_Click);
            // 
            // cboSchemeOwner
            // 
            this.cboSchemeOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSchemeOwner.FormattingEnabled = true;
            this.cboSchemeOwner.Location = new System.Drawing.Point(1804, 492);
            this.cboSchemeOwner.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboSchemeOwner.Name = "cboSchemeOwner";
            this.cboSchemeOwner.Size = new System.Drawing.Size(478, 37);
            this.cboSchemeOwner.TabIndex = 55;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(1013, 443);
            this.label10.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 51);
            this.label10.TabIndex = 54;
            this.label10.Text = "Status";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(1181, 443);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(478, 37);
            this.cboStatus.TabIndex = 53;
            // 
            // cboFtpType
            // 
            this.cboFtpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFtpType.FormattingEnabled = true;
            this.cboFtpType.Location = new System.Drawing.Point(226, 495);
            this.cboFtpType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboFtpType.Name = "cboFtpType";
            this.cboFtpType.Size = new System.Drawing.Size(506, 37);
            this.cboFtpType.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(41, 498);
            this.label9.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 51);
            this.label9.TabIndex = 51;
            this.label9.Text = "FTP Type";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(1680, 206);
            this.txtPort.Margin = new System.Windows.Forms.Padding(7);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(130, 35);
            this.txtPort.TabIndex = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoUploads);
            this.groupBox1.Controls.Add(this.rdoDownloads);
            this.groupBox1.Controls.Add(this.btnToggleSubmit);
            this.groupBox1.Location = new System.Drawing.Point(542, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 115);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // rdoUploads
            // 
            this.rdoUploads.AutoSize = true;
            this.rdoUploads.Location = new System.Drawing.Point(35, 41);
            this.rdoUploads.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rdoUploads.Name = "rdoUploads";
            this.rdoUploads.Size = new System.Drawing.Size(193, 33);
            this.rdoUploads.TabIndex = 50;
            this.rdoUploads.TabStop = true;
            this.rdoUploads.Text = "Uploads View";
            this.rdoUploads.UseVisualStyleBackColor = true;
            // 
            // rdoDownloads
            // 
            this.rdoDownloads.AutoSize = true;
            this.rdoDownloads.Location = new System.Drawing.Point(261, 41);
            this.rdoDownloads.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rdoDownloads.Name = "rdoDownloads";
            this.rdoDownloads.Size = new System.Drawing.Size(211, 33);
            this.rdoDownloads.TabIndex = 51;
            this.rdoDownloads.TabStop = true;
            this.rdoDownloads.Text = "Dowloads View";
            this.rdoDownloads.UseVisualStyleBackColor = true;
            // 
            // btnToggleSubmit
            // 
            this.btnToggleSubmit.Image = ((System.Drawing.Image)(resources.GetObject("btnToggleSubmit.Image")));
            this.btnToggleSubmit.Location = new System.Drawing.Point(525, 28);
            this.btnToggleSubmit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnToggleSubmit.Name = "btnToggleSubmit";
            this.btnToggleSubmit.Size = new System.Drawing.Size(61, 58);
            this.btnToggleSubmit.TabIndex = 41;
            this.btnToggleSubmit.UseVisualStyleBackColor = true;
            this.btnToggleSubmit.Click += new System.EventHandler(this.btnToggleSubmit_Click);
            // 
            // txtPattern
            // 
            this.txtPattern.Location = new System.Drawing.Point(1181, 380);
            this.txtPattern.Margin = new System.Windows.Forms.Padding(7);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(478, 35);
            this.txtPattern.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(1013, 383);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 51);
            this.label6.TabIndex = 45;
            this.label6.Text = "Pattern";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.SystemColors.Control;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(2119, 286);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(7);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(226, 51);
            this.btnRegister.TabIndex = 42;
            this.btnRegister.Text = "&Save";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(2119, 213);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(7);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(226, 51);
            this.btnRemove.TabIndex = 41;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(226, 263);
            this.txtAccount.Margin = new System.Windows.Forms.Padding(7);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(506, 35);
            this.txtAccount.TabIndex = 42;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(2119, 150);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(226, 51);
            this.btnAdd.TabIndex = 40;
            this.btnAdd.Text = "&New Process";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1013, 209);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 51);
            this.label5.TabIndex = 43;
            this.label5.Text = "Host IP";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(41, 383);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 51);
            this.label4.TabIndex = 41;
            this.label4.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(226, 380);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(7);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(506, 35);
            this.txtLogin.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 51);
            this.label1.TabIndex = 39;
            this.label1.Text = "RAM:";
            // 
            // txtRAM
            // 
            this.txtRAM.Location = new System.Drawing.Point(227, 143);
            this.txtRAM.Name = "txtRAM";
            this.txtRAM.Size = new System.Drawing.Size(506, 35);
            this.txtRAM.TabIndex = 38;
            // 
            // txtRemoteDir
            // 
            this.txtRemoteDir.Location = new System.Drawing.Point(1181, 320);
            this.txtRemoteDir.Margin = new System.Windows.Forms.Padding(7);
            this.txtRemoteDir.Name = "txtRemoteDir";
            this.txtRemoteDir.Size = new System.Drawing.Size(478, 35);
            this.txtRemoteDir.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1013, 323);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 51);
            this.label3.TabIndex = 32;
            this.label3.Text = "Remote Dir";
            // 
            // txtHostIP
            // 
            this.txtHostIP.Location = new System.Drawing.Point(1181, 206);
            this.txtHostIP.Margin = new System.Windows.Forms.Padding(7);
            this.txtHostIP.Name = "txtHostIP";
            this.txtHostIP.Size = new System.Drawing.Size(478, 35);
            this.txtHostIP.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(41, 323);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 51);
            this.label2.TabIndex = 30;
            this.label2.Text = "Local Dir";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(1181, 263);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(7);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(478, 35);
            this.txtPassword.TabIndex = 27;
            // 
            // txtPharmacyName
            // 
            this.txtPharmacyName.Location = new System.Drawing.Point(227, 206);
            this.txtPharmacyName.Name = "txtPharmacyName";
            this.txtPharmacyName.Size = new System.Drawing.Size(506, 35);
            this.txtPharmacyName.TabIndex = 37;
            // 
            // lblpwd
            // 
            this.lblpwd.Location = new System.Drawing.Point(1013, 263);
            this.lblpwd.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblpwd.Name = "lblpwd";
            this.lblpwd.Size = new System.Drawing.Size(187, 51);
            this.lblpwd.TabIndex = 28;
            this.lblpwd.Text = "Password:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(1181, 143);
            this.txtID.Margin = new System.Windows.Forms.Padding(7);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(478, 35);
            this.txtID.TabIndex = 5;
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(1013, 150);
            this.lblID.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(187, 51);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "ID:";
            // 
            // txtLocalDir
            // 
            this.txtLocalDir.Location = new System.Drawing.Point(226, 320);
            this.txtLocalDir.Margin = new System.Windows.Forms.Padding(7);
            this.txtLocalDir.Name = "txtLocalDir";
            this.txtLocalDir.Size = new System.Drawing.Size(506, 35);
            this.txtLocalDir.TabIndex = 4;
            // 
            // lblAccount
            // 
            this.lblAccount.Location = new System.Drawing.Point(41, 263);
            this.lblAccount.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(176, 51);
            this.lblAccount.TabIndex = 23;
            this.lblAccount.Text = "Account";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(41, 209);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(176, 51);
            this.lblFirstName.TabIndex = 19;
            this.lblFirstName.Text = "Pharm Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtHoursGoBack);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Controls.Add(this.btnDownloadFtp);
            this.tabPage2.Location = new System.Drawing.Point(10, 47);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(2645, 1650);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "FTP Download";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(1497, 401);
            this.label11.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(212, 51);
            this.label11.TabIndex = 58;
            this.label11.Text = "Hours Go Back:";
            // 
            // txtHoursGoBack
            // 
            this.txtHoursGoBack.Location = new System.Drawing.Point(1740, 398);
            this.txtHoursGoBack.Margin = new System.Windows.Forms.Padding(7);
            this.txtHoursGoBack.Name = "txtHoursGoBack";
            this.txtHoursGoBack.Size = new System.Drawing.Size(111, 35);
            this.txtHoursGoBack.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(545, 499);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 51);
            this.label7.TabIndex = 49;
            this.label7.Text = "Results:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(550, 553);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1633, 920);
            this.richTextBox1.TabIndex = 48;
            this.richTextBox1.Text = "";
            // 
            // btnDownloadFtp
            // 
            this.btnDownloadFtp.Location = new System.Drawing.Point(1173, 388);
            this.btnDownloadFtp.Name = "btnDownloadFtp";
            this.btnDownloadFtp.Size = new System.Drawing.Size(226, 54);
            this.btnDownloadFtp.TabIndex = 47;
            this.btnDownloadFtp.Text = "Download";
            this.btnDownloadFtp.UseVisualStyleBackColor = true;
            this.btnDownloadFtp.Click += new System.EventHandler(this.btnDownloadFtp_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblShowSchemeSelected);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.rtbUploadResults);
            this.tabPage3.Controls.Add(this.btnFtpUpload);
            this.tabPage3.Location = new System.Drawing.Point(10, 47);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(2645, 1650);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "FTP Upload";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblShowSchemeSelected
            // 
            this.lblShowSchemeSelected.AutoSize = true;
            this.lblShowSchemeSelected.Location = new System.Drawing.Point(709, 475);
            this.lblShowSchemeSelected.Name = "lblShowSchemeSelected";
            this.lblShowSchemeSelected.Size = new System.Drawing.Size(92, 29);
            this.lblShowSchemeSelected.TabIndex = 52;
            this.lblShowSchemeSelected.Text = "label12";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(560, 475);
            this.label8.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 51);
            this.label8.TabIndex = 51;
            this.label8.Text = "Results:";
            // 
            // rtbUploadResults
            // 
            this.rtbUploadResults.Location = new System.Drawing.Point(565, 529);
            this.rtbUploadResults.Name = "rtbUploadResults";
            this.rtbUploadResults.Size = new System.Drawing.Size(1633, 920);
            this.rtbUploadResults.TabIndex = 50;
            this.rtbUploadResults.Text = "";
            // 
            // btnFtpUpload
            // 
            this.btnFtpUpload.Location = new System.Drawing.Point(1169, 395);
            this.btnFtpUpload.Name = "btnFtpUpload";
            this.btnFtpUpload.Size = new System.Drawing.Size(226, 54);
            this.btnFtpUpload.TabIndex = 48;
            this.btnFtpUpload.Text = "UPload";
            this.btnFtpUpload.UseVisualStyleBackColor = true;
            this.btnFtpUpload.Click += new System.EventHandler(this.btnFtpUpload_Click);
            // 
            // ProcessView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2732, 1728);
            this.Controls.Add(this.tabControl1);
            this.Name = "ProcessView";
            this.Text = "Processes View";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvwProcesses;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnDownloadFtp;
        private System.Windows.Forms.RichTextBox richTextBox1;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnFtpUpload;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox rtbUploadResults;
        internal System.Windows.Forms.GroupBox grpDetails;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.ComboBox cboFtpType;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoUploads;
        private System.Windows.Forms.RadioButton rdoDownloads;
        private System.Windows.Forms.Button btnToggleSubmit;
        internal System.Windows.Forms.TextBox txtPattern;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button btnRegister;
        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.TextBox txtAccount;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtLogin;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRAM;
        internal System.Windows.Forms.TextBox txtRemoteDir;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtHostIP;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPharmacyName;
        internal System.Windows.Forms.Label lblpwd;
        internal System.Windows.Forms.TextBox txtID;
        internal System.Windows.Forms.Label lblID;
        internal System.Windows.Forms.TextBox txtLocalDir;
        internal System.Windows.Forms.Label lblAccount;
        internal System.Windows.Forms.Label lblFirstName;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txtHoursGoBack;
        private System.Windows.Forms.ComboBox cboSchemeOwner;
        private System.Windows.Forms.Button btnSchemeOwnerGO;
        private System.Windows.Forms.TextBox txtShowUploadMsg;
        private System.Windows.Forms.Button btnBrowseUploadFolder;
        private System.Windows.Forms.TextBox txtUploadFolder;
        private System.Windows.Forms.Label lblShowSchemeSelected;
        private System.Windows.Forms.Label lblSelectedRowsWaiting;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txtOwnerScheme;
        private System.Windows.Forms.Button btnLoadRow; 

    }
}