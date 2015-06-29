namespace Ice.CustomUI.PRList
{
    partial class PRList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PRList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.requisition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reqdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeviewid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actiontree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionteam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butTraker = new System.Windows.Forms.Button();
            this.butDispatch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 410);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(881, 137);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Location = new System.Drawing.Point(6, 25);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.Size = new System.Drawing.Size(869, 106);
            this.txtNote.TabIndex = 0;
            // 
            // dgvList
            // 
            this.dgvList.AllowDrop = true;
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvList.ColumnHeadersHeight = 25;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.requisition,
            this.reqdate,
            this.requestorId,
            this.requestor,
            this.treeviewid,
            this.actiontree,
            this.status,
            this.actionteam,
            this.remark});
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvList.Location = new System.Drawing.Point(13, 13);
            this.dgvList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(880, 360);
            this.dgvList.TabIndex = 54;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
            // 
            // requisition
            // 
            this.requisition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.requisition.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.requisition, "requisition");
            this.requisition.Name = "requisition";
            this.requisition.ReadOnly = true;
            this.requisition.Width = 76;
            // 
            // reqdate
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.reqdate.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.reqdate, "reqdate");
            this.reqdate.Name = "reqdate";
            this.reqdate.ReadOnly = true;
            // 
            // requestorId
            // 
            resources.ApplyResources(this.requestorId, "requestorId");
            this.requestorId.Name = "requestorId";
            this.requestorId.ReadOnly = true;
            this.requestorId.Visible = false;
            // 
            // requestor
            // 
            resources.ApplyResources(this.requestor, "requestor");
            this.requestor.Name = "requestor";
            this.requestor.ReadOnly = true;
            // 
            // treeviewid
            // 
            resources.ApplyResources(this.treeviewid, "treeviewid");
            this.treeviewid.Name = "treeviewid";
            this.treeviewid.Visible = false;
            // 
            // actiontree
            // 
            this.actiontree.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.actiontree, "actiontree");
            this.actiontree.Name = "actiontree";
            this.actiontree.ReadOnly = true;
            this.actiontree.Width = 86;
            // 
            // status
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.status.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.status, "status");
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // actionteam
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.actionteam.DefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(this.actionteam, "actionteam");
            this.actionteam.Name = "actionteam";
            this.actionteam.ReadOnly = true;
            // 
            // remark
            // 
            resources.ApplyResources(this.remark, "remark");
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.Visible = false;
            // 
            // butTraker
            // 
            this.butTraker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTraker.Location = new System.Drawing.Point(163, 380);
            this.butTraker.Name = "butTraker";
            this.butTraker.Size = new System.Drawing.Size(139, 23);
            this.butTraker.TabIndex = 56;
            resources.ApplyResources(this.butTraker, "butTraker");
            this.butTraker.Click += new System.EventHandler(this.butTraker_Click);
            // 
            // butDispatch
            // 
            this.butDispatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDispatch.Location = new System.Drawing.Point(18, 380);
            this.butDispatch.Name = "butDispatch";
            this.butDispatch.Size = new System.Drawing.Size(139, 24);
            this.butDispatch.TabIndex = 55;
            resources.ApplyResources(this.butDispatch, "butDispatch");
            this.butDispatch.Click += new System.EventHandler(this.butDispatch_Click);
            // 
            // PRList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(906, 559);
            this.Controls.Add(this.butTraker);
            this.Controls.Add(this.butDispatch);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PRList";
            resources.ApplyResources(this, "$this");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PRList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butTraker;
        private System.Windows.Forms.Button butDispatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisition;
        private System.Windows.Forms.DataGridViewTextBoxColumn reqdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestor;
        private System.Windows.Forms.DataGridViewTextBoxColumn treeviewid;
        private System.Windows.Forms.DataGridViewTextBoxColumn actiontree;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionteam;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;

        //private System.Windows.Forms.GroupBox groupBox1;
        //private System.Windows.Forms.Button butTraker;
        //private System.Windows.Forms.Button butDispatch;

    }
}