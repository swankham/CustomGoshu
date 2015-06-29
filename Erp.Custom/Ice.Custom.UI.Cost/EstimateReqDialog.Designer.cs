namespace Ice.Custom.UI.CostRequest
{
    partial class EstimateReqDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstimateReqDialog));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butSearch = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.butSelect = new System.Windows.Forms.Button();
            this.estimateno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reqdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reqby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowDrop = true;
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvList.ColumnHeadersHeight = 25;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.estimateno,
            this.rev,
            this.reviseno,
            this.reqdate,
            this.reqby,
            this.projectno,
            this.projectname});
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvList.Location = new System.Drawing.Point(5, 70);
            this.dgvList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(571, 311);
            this.dgvList.TabIndex = 57;
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.butSearch);
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Controls.Add(this.cboFilter);
            this.groupBox1.Location = new System.Drawing.Point(5, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 51);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            resources.ApplyResources(this.label2, "label2");
            // 
            // butSearch
            // 
            this.butSearch.Location = new System.Drawing.Point(481, 17);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(84, 23);
            this.butSearch.TabIndex = 3;
            resources.ApplyResources(this.butSearch, "butSearch");
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(266, 19);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(209, 20);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Items.AddRange(new object[] {
            "Estimate No.",
            "Request by",
            "Project No.",
            "Project Name"});
            this.cboFilter.Location = new System.Drawing.Point(97, 19);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(163, 21);
            this.cboFilter.TabIndex = 0;
            // 
            // butSelect
            // 
            this.butSelect.Location = new System.Drawing.Point(492, 385);
            this.butSelect.Name = "butSelect";
            this.butSelect.Size = new System.Drawing.Size(84, 23);
            this.butSelect.TabIndex = 4;
            resources.ApplyResources(this.butSelect, "butSelect");
            this.butSelect.Click += new System.EventHandler(this.butSelect_Click);
            // 
            // estimateno
            // 
            this.estimateno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.estimateno.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.estimateno, "estimateno");
            this.estimateno.Name = "estimateno";
            this.estimateno.ReadOnly = true;
            this.estimateno.Width = 91;
            // 
            // rev
            // 
            this.rev.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.rev, "rev");
            this.rev.Name = "rev";
            this.rev.ReadOnly = true;
            this.rev.Visible = false;
            this.rev.Width = 46;
            // 
            // reviseno
            // 
            this.reviseno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.reviseno.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.reviseno, "reviseno");
            this.reviseno.Name = "reviseno";
            this.reviseno.ReadOnly = true;
            this.reviseno.Width = 84;
            // 
            // reqdate
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.reqdate.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.reqdate, "reqdate");
            this.reqdate.Name = "reqdate";
            this.reqdate.ReadOnly = true;
            // 
            // reqby
            // 
            resources.ApplyResources(this.reqby, "reqby");
            this.reqby.Name = "reqby";
            this.reqby.ReadOnly = true;
            // 
            // projectno
            // 
            resources.ApplyResources(this.projectno, "projectno");
            this.projectno.Name = "projectno";
            this.projectno.ReadOnly = true;
            this.projectno.Visible = false;
            // 
            // projectname
            // 
            resources.ApplyResources(this.projectname, "projectname");
            this.projectname.Name = "projectname";
            this.projectname.ReadOnly = true;
            // 
            // EstimateReqDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 414);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.butSelect);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EstimateReqDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.EstimateReqDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butSelect;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn estimateno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn reqdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn reqby;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectno;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectname;
    }
}