namespace Ice.CustomUI.PRList
{
    partial class Approval
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

        ///Standard Control
        /*
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRequestor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDispatcherTeam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDispatcherRemark = new System.Windows.Forms.TextBox();
            this.txtReplyRemark = new System.Windows.Forms.TextBox();
            this.cboActionTree = new System.Windows.Forms.ComboBox();
            this.rdoApprove = new System.Windows.Forms.RadioButton();
            this.rdoReject = new System.Windows.Forms.RadioButton();
         */

        ///EpiControl
        /*
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
         */
       
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Approval));
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRequestor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butBuyer = new System.Windows.Forms.Button();
            this.cboActionTree = new System.Windows.Forms.ComboBox();
            this.txtDispatcherRemark = new System.Windows.Forms.TextBox();
            this.txtDispatcherTeam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoReject = new System.Windows.Forms.RadioButton();
            this.rdoApprove = new System.Windows.Forms.RadioButton();
            this.txtReplyRemark = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.Location = new System.Drawing.Point(164, 395);
            this.butOK.Name = "butOK";
            this.butOK.TabIndex = 0;
            resources.ApplyResources(this.butOK, "butOK");
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.Location = new System.Drawing.Point(245, 395);
            this.butCancel.Name = "butCancel";
            this.butCancel.TabIndex = 1;
            resources.ApplyResources(this.butCancel, "butCancel");
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRequestor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 52);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // txtRequestor
            // 
            this.txtRequestor.Location = new System.Drawing.Point(119, 23);
            this.txtRequestor.Name = "txtRequestor";
            this.txtRequestor.ReadOnly = true;
            this.txtRequestor.Size = new System.Drawing.Size(183, 20);
            this.txtRequestor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            resources.ApplyResources(this.label1, "label1");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butBuyer);
            this.groupBox2.Controls.Add(this.cboActionTree);
            this.groupBox2.Controls.Add(this.txtDispatcherRemark);
            this.groupBox2.Controls.Add(this.txtDispatcherTeam);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 162);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            // 
            // butBuyer
            // 
            this.butBuyer.Location = new System.Drawing.Point(6, 52);
            this.butBuyer.Name = "butBuyer";
            this.butBuyer.Size = new System.Drawing.Size(107, 23);
            this.butBuyer.TabIndex = 8;
            resources.ApplyResources(this.butBuyer, "butBuyer");
            //this.butBuyer.UseVisualStyleBackColor = true;
            this.butBuyer.Click += new System.EventHandler(this.butBuyer_Click);
            // 
            // cboActionTree
            // 
            this.cboActionTree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActionTree.Location = new System.Drawing.Point(119, 28);
            this.cboActionTree.Name = "cboActionTree";
            this.cboActionTree.Size = new System.Drawing.Size(183, 21);
            this.cboActionTree.TabIndex = 7;
            this.cboActionTree.SelectedIndexChanged += new System.EventHandler(this.cboActionTree_SelectedIndexChanged);
            this.cboActionTree.Leave += new System.EventHandler(this.cboActionTree_Leave);
            // 
            // txtDispatcherRemark
            // 
            this.txtDispatcherRemark.Location = new System.Drawing.Point(6, 80);
            this.txtDispatcherRemark.Multiline = true;
            this.txtDispatcherRemark.Name = "txtDispatcherRemark";
            this.txtDispatcherRemark.ReadOnly = true;
            this.txtDispatcherRemark.Size = new System.Drawing.Size(296, 76);
            this.txtDispatcherRemark.TabIndex = 6;
            // 
            // txtDispatcherTeam
            // 
            this.txtDispatcherTeam.Location = new System.Drawing.Point(119, 54);
            this.txtDispatcherTeam.Name = "txtDispatcherTeam";
            this.txtDispatcherTeam.ReadOnly = true;
            this.txtDispatcherTeam.Size = new System.Drawing.Size(183, 20);
            this.txtDispatcherTeam.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            resources.ApplyResources(this.label3, "label3");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            resources.ApplyResources(this.label2, "label2");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoReject);
            this.groupBox3.Controls.Add(this.rdoApprove);
            this.groupBox3.Controls.Add(this.txtReplyRemark);
            this.groupBox3.Location = new System.Drawing.Point(12, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 127);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            resources.ApplyResources(this.groupBox3, "groupBox3");
            // 
            // rdoReject
            // 
            this.rdoReject.AutoSize = true;
            this.rdoReject.Location = new System.Drawing.Point(233, 19);
            this.rdoReject.Name = "rdoReject";
            this.rdoReject.Size = new System.Drawing.Size(56, 17);
            this.rdoReject.TabIndex = 9;
            this.rdoReject.TabStop = true;
            resources.ApplyResources(this.rdoReject, "rdoReject");
            //this.rdoReject.UseVisualStyleBackColor = true;
            this.rdoReject.Click += new System.EventHandler(this.rdoReject_Click);
            // 
            // rdoApprove
            // 
            this.rdoApprove.AutoSize = true;
            this.rdoApprove.Location = new System.Drawing.Point(152, 19);
            this.rdoApprove.Name = "rdoApprove";
            this.rdoApprove.Size = new System.Drawing.Size(65, 17);
            this.rdoApprove.TabIndex = 8;
            this.rdoApprove.TabStop = true;
            resources.ApplyResources(this.rdoApprove, "rdoApprove");
            //this.rdoApprove.UseVisualStyleBackColor = true;
            this.rdoApprove.Click += new System.EventHandler(this.rdoApprove_Click);
            // 
            // txtReplyRemark
            // 
            this.txtReplyRemark.Location = new System.Drawing.Point(6, 42);
            this.txtReplyRemark.Multiline = true;
            this.txtReplyRemark.Name = "txtReplyRemark";
            this.txtReplyRemark.Size = new System.Drawing.Size(296, 76);
            this.txtReplyRemark.TabIndex = 7;
            // 
            // Approval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(332, 428);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Approval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.Approval_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        //TODO Change UI to Infragistics4

        private System.Windows.Forms.TextBox txtRequestor;
        private System.Windows.Forms.TextBox txtDispatcherTeam;
        private System.Windows.Forms.TextBox txtDispatcherRemark;
        private System.Windows.Forms.TextBox txtReplyRemark;
        private System.Windows.Forms.ComboBox cboActionTree;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoReject;
        private System.Windows.Forms.RadioButton rdoApprove;
        private System.Windows.Forms.Button butBuyer;


    }
}