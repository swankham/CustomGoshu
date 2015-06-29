using System.Drawing;
namespace Ice.Custom.UI.Auth
{
    partial class TeamManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamManagement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1. Earth Work");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Civil work", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("P41402050", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.tlNew = new System.Windows.Forms.ToolStripButton();
            this.tlFind = new System.Windows.Forms.ToolStripButton();
            this.tlSave = new System.Windows.Forms.ToolStripButton();
            this.tlDelete = new System.Windows.Forms.ToolStripButton();
            this.tlRefresh = new System.Windows.Forms.ToolStripButton();
            this.tlClear = new System.Windows.Forms.ToolStripButton();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAction = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReviseEstimate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDuplicate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.gennerateQuotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.butRemove = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvAuthorized = new System.Windows.Forms.DataGridView();
            this.id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ponumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTeam = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.division = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.department = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.section = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.team1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkTeam = new System.Windows.Forms.CheckBox();
            this.chkSection = new System.Windows.Forms.CheckBox();
            this.chkDepartment = new System.Windows.Forms.CheckBox();
            this.chkDivision = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.cboFind = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvAvailable = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdteam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trvNev = new System.Windows.Forms.TreeView();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.toolBar.SuspendLayout();
            this.MenuBar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthorized)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeam)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1431679199_kuser.png");
            this.imageList1.Images.SetKeyName(1, "1432388566_home.png");
            this.imageList1.Images.SetKeyName(2, "1432388973_edu_languages.png");
            // 
            // toolBar
            // 
            this.toolBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(250)))));
            this.toolBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlNew,
            this.tlFind,
            this.tlSave,
            this.tlDelete,
            this.tlRefresh,
            this.tlClear});
            this.toolBar.Location = new System.Drawing.Point(0, 24);
            this.toolBar.Name = "toolBar";
            this.toolBar.Padding = new System.Windows.Forms.Padding(0);
            this.toolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolBar.Size = new System.Drawing.Size(967, 25);
            this.toolBar.TabIndex = 3;
            resources.ApplyResources(this.toolBar, "toolBar");
            // 
            // tlNew
            // 
            this.tlNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlNew.Image = ((System.Drawing.Image)(resources.GetObject("tlNew.Image")));
            this.tlNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlNew.Name = "tlNew";
            this.tlNew.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.tlNew.Size = new System.Drawing.Size(23, 22);
            resources.ApplyResources(this.tlNew, "tlNew");
            this.tlNew.Click += new System.EventHandler(this.tlNew_Click);
            // 
            // tlFind
            // 
            this.tlFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlFind.Image = ((System.Drawing.Image)(resources.GetObject("tlFind.Image")));
            this.tlFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlFind.Name = "tlFind";
            this.tlFind.Size = new System.Drawing.Size(23, 22);
            resources.ApplyResources(this.tlFind, "tlFind");
            this.tlFind.Click += new System.EventHandler(this.tlFind_Click);
            // 
            // tlSave
            // 
            this.tlSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlSave.Image = ((System.Drawing.Image)(resources.GetObject("tlSave.Image")));
            this.tlSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlSave.Name = "tlSave";
            this.tlSave.Size = new System.Drawing.Size(23, 22);
            resources.ApplyResources(this.tlSave, "tlSave");
            this.tlSave.Click += new System.EventHandler(this.tlSave_Click);
            // 
            // tlDelete
            // 
            this.tlDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlDelete.Image = ((System.Drawing.Image)(resources.GetObject("tlDelete.Image")));
            this.tlDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlDelete.Name = "tlDelete";
            this.tlDelete.Size = new System.Drawing.Size(23, 22);
            resources.ApplyResources(this.tlDelete, "tlDelete");
            this.tlDelete.Click += new System.EventHandler(this.tlDelete_Click);
            // 
            // tlRefresh
            // 
            this.tlRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tlRefresh.Image")));
            this.tlRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlRefresh.Name = "tlRefresh";
            this.tlRefresh.Size = new System.Drawing.Size(23, 22);
            resources.ApplyResources(this.tlRefresh, "tlRefresh");
            this.tlRefresh.Click += new System.EventHandler(this.tlRefresh_Click);
            // 
            // tlClear
            // 
            this.tlClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlClear.Image = ((System.Drawing.Image)(resources.GetObject("tlClear.Image")));
            this.tlClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlClear.Name = "tlClear";
            this.tlClear.Size = new System.Drawing.Size(23, 22);
            resources.ApplyResources(this.tlClear, "tlClear");
            this.tlClear.Click += new System.EventHandler(this.tlClear_Click);
            // 
            // MenuBar
            // 
            this.MenuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(250)))));
            this.MenuBar.GripMargin = new System.Windows.Forms.Padding(0);
            this.MenuBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuAction});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Padding = new System.Windows.Forms.Padding(0);
            this.MenuBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MenuBar.Size = new System.Drawing.Size(967, 24);
            this.MenuBar.TabIndex = 2;
            resources.ApplyResources(this.MenuBar, "MenuBar");
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuSave,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.mnuFile.Size = new System.Drawing.Size(33, 24);
            resources.ApplyResources(this.mnuFile, "mnuFile");
            // 
            // mnuNew
            // 
            this.mnuNew.Image = ((System.Drawing.Image)(resources.GetObject("mnuNew.Image")));
            this.mnuNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(100, 24);
            resources.ApplyResources(this.mnuNew, "mnuNew");
            // 
            // mnuSave
            // 
            this.mnuSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuSave.Image")));
            this.mnuSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(100, 24);
            resources.ApplyResources(this.mnuSave, "mnuSave");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(97, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuExit.Image")));
            this.mnuExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(100, 24);
            resources.ApplyResources(this.mnuExit, "mnuExit");
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClear,
            this.mnuDelete,
            this.toolStripMenuItem2,
            this.mnuRefresh});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 24);
            resources.ApplyResources(this.mnuEdit, "mnuEdit");
            // 
            // mnuClear
            // 
            this.mnuClear.Image = ((System.Drawing.Image)(resources.GetObject("mnuClear.Image")));
            this.mnuClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuClear.Name = "mnuClear";
            this.mnuClear.Size = new System.Drawing.Size(113, 24);
            resources.ApplyResources(this.mnuClear, "mnuClear");
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuDelete.Image")));
            this.mnuDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(113, 24);
            resources.ApplyResources(this.mnuDelete, "mnuDelete");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(110, 6);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuRefresh.Image")));
            this.mnuRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(113, 24);
            resources.ApplyResources(this.mnuRefresh, "mnuRefresh");
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // mnuAction
            // 
            this.mnuAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReviseEstimate,
            this.mnuDuplicate,
            this.toolStripMenuItem3,
            this.gennerateQuotationToolStripMenuItem});
            this.mnuAction.Enabled = false;
            this.mnuAction.Name = "mnuAction";
            this.mnuAction.Size = new System.Drawing.Size(54, 24);
            resources.ApplyResources(this.mnuAction, "mnuAction");
            // 
            // mnuReviseEstimate
            // 
            this.mnuReviseEstimate.Image = ((System.Drawing.Image)(resources.GetObject("mnuReviseEstimate.Image")));
            this.mnuReviseEstimate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuReviseEstimate.Name = "mnuReviseEstimate";
            this.mnuReviseEstimate.Size = new System.Drawing.Size(172, 22);
            resources.ApplyResources(this.mnuReviseEstimate, "mnuReviseEstimate");
            // 
            // mnuDuplicate
            // 
            this.mnuDuplicate.Image = ((System.Drawing.Image)(resources.GetObject("mnuDuplicate.Image")));
            this.mnuDuplicate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuDuplicate.Name = "mnuDuplicate";
            this.mnuDuplicate.Size = new System.Drawing.Size(172, 22);
            resources.ApplyResources(this.mnuDuplicate, "mnuDuplicate");
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(169, 6);
            // 
            // gennerateQuotationToolStripMenuItem
            // 
            this.gennerateQuotationToolStripMenuItem.Name = "gennerateQuotationToolStripMenuItem";
            this.gennerateQuotationToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            resources.ApplyResources(this.gennerateQuotationToolStripMenuItem, "gennerateQuotationToolStripMenuItem");
            // 
            // butRemove
            // 
            this.butRemove.Image = ((System.Drawing.Image)(resources.GetObject("butRemove.Image")));
            this.butRemove.Location = new System.Drawing.Point(641, 410);
            this.butRemove.Name = "butRemove";
            this.butRemove.Size = new System.Drawing.Size(32, 23);
            this.butRemove.TabIndex = 5;
            this.butRemove.Click += new System.EventHandler(this.butRemove_Click_1);
            // 
            // butAdd
            // 
            this.butAdd.Image = ((System.Drawing.Image)(resources.GetObject("butAdd.Image")));
            this.butAdd.Location = new System.Drawing.Point(641, 381);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(32, 23);
            this.butAdd.TabIndex = 4;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dgvAuthorized);
            this.groupBox2.Location = new System.Drawing.Point(313, 307);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 346);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            // 
            // dgvAuthorized
            // 
            this.dgvAuthorized.AllowUserToAddRows = false;
            this.dgvAuthorized.AllowUserToDeleteRows = false;
            this.dgvAuthorized.AllowUserToResizeRows = false;
            this.dgvAuthorized.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAuthorized.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuthorized.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAuthorized.BackgroundColor = System.Drawing.Color.White;
            this.dgvAuthorized.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAuthorized.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAuthorized.ColumnHeadersHeight = 25;
            this.dgvAuthorized.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAuthorized.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id1,
            this.ponumber,
            this.team});
            this.dgvAuthorized.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAuthorized.EnableHeadersVisualStyles = false;
            this.dgvAuthorized.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvAuthorized.Location = new System.Drawing.Point(7, 19);
            this.dgvAuthorized.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAuthorized.Name = "dgvAuthorized";
            this.dgvAuthorized.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvAuthorized.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuthorized.Size = new System.Drawing.Size(304, 317);
            this.dgvAuthorized.TabIndex = 51;
            // 
            // id1
            // 
            this.id1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.NullValue = "0";
            this.id1.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.id1, "id1");
            this.id1.Name = "id1";
            this.id1.ReadOnly = true;
            this.id1.Width = 42;
            // 
            // ponumber
            // 
            resources.ApplyResources(this.ponumber, "ponumber");
            this.ponumber.Name = "ponumber";
            this.ponumber.ReadOnly = true;
            // 
            // team
            // 
            resources.ApplyResources(this.team, "team");
            this.team.Name = "team";
            this.team.ReadOnly = true;
            this.team.Visible = false;
            // 
            // dgvTeam
            // 
            this.dgvTeam.AllowDrop = true;
            this.dgvTeam.AllowUserToAddRows = false;
            this.dgvTeam.AllowUserToDeleteRows = false;
            this.dgvTeam.AllowUserToResizeRows = false;
            this.dgvTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTeam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeam.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTeam.BackgroundColor = System.Drawing.Color.White;
            this.dgvTeam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTeam.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTeam.ColumnHeadersHeight = 25;
            this.dgvTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTeam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.teamcode,
            this.teamname,
            this.auth,
            this.company,
            this.division,
            this.department,
            this.section,
            this.team1});
            this.dgvTeam.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTeam.EnableHeadersVisualStyles = false;
            this.dgvTeam.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvTeam.Location = new System.Drawing.Point(313, 76);
            this.dgvTeam.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTeam.MultiSelect = false;
            this.dgvTeam.Name = "dgvTeam";
            this.dgvTeam.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvTeam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeam.Size = new System.Drawing.Size(647, 224);
            this.dgvTeam.TabIndex = 53;
            this.dgvTeam.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTeam_CellMouseDown);
            this.dgvTeam.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvTeam_DragDrop);
            this.dgvTeam.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvTeam_DragEnter);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = "0";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 48;
            // 
            // teamcode
            // 
            this.teamcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.teamcode, "teamcode");
            this.teamcode.Name = "teamcode";
            this.teamcode.ReadOnly = true;
            this.teamcode.Width = 58;
            // 
            // teamname
            // 
            resources.ApplyResources(this.teamname, "teamname");
            this.teamname.Name = "teamname";
            this.teamname.ReadOnly = true;
            // 
            // auth
            // 
            resources.ApplyResources(this.auth, "auth");
            this.auth.Name = "auth";
            this.auth.ReadOnly = true;
            // 
            // company
            // 
            resources.ApplyResources(this.company, "company");
            this.company.Name = "company";
            this.company.ReadOnly = true;
            // 
            // division
            // 
            this.division.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.division, "division");
            this.division.Name = "division";
            this.division.ReadOnly = true;
            this.division.Width = 49;
            // 
            // department
            // 
            this.department.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.department, "department");
            this.department.Name = "department";
            this.department.ReadOnly = true;
            this.department.Width = 67;
            // 
            // section
            // 
            this.section.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.section, "section");
            this.section.Name = "section";
            this.section.ReadOnly = true;
            this.section.Width = 48;
            // 
            // team1
            // 
            this.team1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.team1, "team1");
            this.team1.Name = "team1";
            this.team1.ReadOnly = true;
            this.team1.Width = 39;
            // 
            // chkTeam
            // 
            this.chkTeam.AutoSize = true;
            this.chkTeam.Location = new System.Drawing.Point(611, 52);
            this.chkTeam.Name = "chkTeam";
            this.chkTeam.Size = new System.Drawing.Size(53, 17);
            this.chkTeam.TabIndex = 4;
            resources.ApplyResources(this.chkTeam, "chkTeam");
            this.chkTeam.CheckedChanged += new System.EventHandler(this.chkTeam_CheckedChanged);
            // 
            // chkSection
            // 
            this.chkSection.AutoSize = true;
            this.chkSection.Location = new System.Drawing.Point(532, 52);
            this.chkSection.Name = "chkSection";
            this.chkSection.Size = new System.Drawing.Size(62, 17);
            this.chkSection.TabIndex = 3;
            resources.ApplyResources(this.chkSection, "chkSection");
            this.chkSection.CheckedChanged += new System.EventHandler(this.chkSection_CheckedChanged);
            // 
            // chkDepartment
            // 
            this.chkDepartment.AutoSize = true;
            this.chkDepartment.Location = new System.Drawing.Point(434, 52);
            this.chkDepartment.Name = "chkDepartment";
            this.chkDepartment.Size = new System.Drawing.Size(81, 17);
            this.chkDepartment.TabIndex = 2;
            resources.ApplyResources(this.chkDepartment, "chkDepartment");
            this.chkDepartment.CheckedChanged += new System.EventHandler(this.chkDepartment_CheckedChanged);
            // 
            // chkDivision
            // 
            this.chkDivision.AutoSize = true;
            this.chkDivision.Location = new System.Drawing.Point(352, 52);
            this.chkDivision.Name = "chkDivision";
            this.chkDivision.Size = new System.Drawing.Size(63, 17);
            this.chkDivision.TabIndex = 1;
            resources.ApplyResources(this.chkDivision, "chkDivision");
            this.chkDivision.CheckedChanged += new System.EventHandler(this.chkDivision_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            resources.ApplyResources(this.label1, "label1");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtFind);
            this.groupBox1.Controls.Add(this.cboFind);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dgvAvailable);
            this.groupBox1.Location = new System.Drawing.Point(679, 307);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 343);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Location = new System.Drawing.Point(141, 19);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(134, 20);
            this.txtFind.TabIndex = 55;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // cboFind
            // 
            this.cboFind.FormattingEnabled = true;
            this.cboFind.Items.AddRange(new object[] {
            "ID",
            "Name",
            "Team"});
            this.cboFind.Location = new System.Drawing.Point(61, 19);
            this.cboFind.Name = "cboFind";
            this.cboFind.Size = new System.Drawing.Size(74, 21);
            this.cboFind.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 53;
            resources.ApplyResources(this.label3, "label3");
            // 
            // dgvAvailable
            // 
            this.dgvAvailable.AllowUserToAddRows = false;
            this.dgvAvailable.AllowUserToDeleteRows = false;
            this.dgvAvailable.AllowUserToResizeRows = false;
            this.dgvAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAvailable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAvailable.BackgroundColor = System.Drawing.Color.White;
            this.dgvAvailable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAvailable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAvailable.ColumnHeadersHeight = 25;
            this.dgvAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAvailable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.dataGridViewTextBoxColumn2,
            this.stdteam});
            this.dgvAvailable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAvailable.EnableHeadersVisualStyles = false;
            this.dgvAvailable.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvAvailable.Location = new System.Drawing.Point(9, 46);
            this.dgvAvailable.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAvailable.Name = "dgvAvailable";
            this.dgvAvailable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvAvailable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailable.Size = new System.Drawing.Size(265, 290);
            this.dgvAvailable.TabIndex = 52;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.NullValue = "0";
            this.id.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.id, "id");
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 42;
            // 
            // dataGridViewTextBoxColumn2
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // stdteam
            // 
            resources.ApplyResources(this.stdteam, "stdteam");
            this.stdteam.Name = "stdteam";
            this.stdteam.ReadOnly = true;
            // 
            // trvNev
            // 
            this.trvNev.AllowDrop = true;
            this.trvNev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trvNev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trvNev.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            resources.ApplyResources(this.trvNev, "trvNev");
            this.trvNev.ImageList = this.imageList1;
            this.trvNev.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.trvNev.Indent = 20;
            this.trvNev.ItemHeight = 20;
            this.trvNev.Location = new System.Drawing.Point(12, 75);
            this.trvNev.Name = "trvNev";
            treeNode1.Name = "Node1";
            resources.ApplyResources(treeNode1, "treeNode1");
            treeNode2.Name = "Node0";
            resources.ApplyResources(treeNode2, "treeNode2");
            resources.ApplyResources(treeNode3, "treeNode3");
            treeNode3.Name = "Node5";
            this.trvNev.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.trvNev.Size = new System.Drawing.Size(294, 578);
            this.trvNev.TabIndex = 55;
            this.trvNev.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvNev_NodeMouseClick);
            this.trvNev.DragDrop += new System.Windows.Forms.DragEventHandler(this.trvNev_DragDrop);
            this.trvNev.DragEnter += new System.Windows.Forms.DragEventHandler(this.trvNev_DragEnter);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(12, 52);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 0;
            resources.ApplyResources(this.chkEnabled, "chkEnabled");
            // 
            // TeamManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 665);
            this.Controls.Add(this.chkTeam);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.chkSection);
            this.Controls.Add(this.trvNev);
            this.Controls.Add(this.chkDepartment);
            this.Controls.Add(this.chkDivision);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvTeam);
            this.Controls.Add(this.butRemove);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.MenuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TeamManagement";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.TeamManagement_Load);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthorized)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeam)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton tlNew;
        private System.Windows.Forms.ToolStripButton tlSave;
        private System.Windows.Forms.ToolStripButton tlDelete;
        private System.Windows.Forms.ToolStripButton tlRefresh;
        private System.Windows.Forms.ToolStripButton tlClear;
        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuClear;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuAction;
        private System.Windows.Forms.ToolStripMenuItem mnuReviseEstimate;
        private System.Windows.Forms.ToolStripMenuItem mnuDuplicate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem gennerateQuotationToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton tlFind;
        private System.Windows.Forms.Button butRemove;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvAuthorized;
        private System.Windows.Forms.DataGridViewTextBoxColumn id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ponumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn team;
        private System.Windows.Forms.DataGridView dgvTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamname;
        private System.Windows.Forms.DataGridViewTextBoxColumn auth;
        private System.Windows.Forms.DataGridViewTextBoxColumn company;
        private System.Windows.Forms.DataGridViewCheckBoxColumn division;
        private System.Windows.Forms.DataGridViewCheckBoxColumn department;
        private System.Windows.Forms.DataGridViewCheckBoxColumn section;
        private System.Windows.Forms.DataGridViewCheckBoxColumn team1;
        private System.Windows.Forms.CheckBox chkTeam;
        private System.Windows.Forms.CheckBox chkSection;
        private System.Windows.Forms.CheckBox chkDepartment;
        private System.Windows.Forms.CheckBox chkDivision;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.ComboBox cboFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdteam;
        public System.Windows.Forms.TreeView trvNev;
        private System.Windows.Forms.CheckBox chkEnabled;
    }
}