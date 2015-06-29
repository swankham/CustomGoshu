using Erp.Custom.Core.Session.Models;
using Erp.Custom.SecurityAuth.Models;
using Erp.Custom.SecurityAuth.Repositories;
using Ice.CustomUI.PRList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Erp.Custom.UI.Common.Views.TeamManagement
{
    public partial class TeamManagement : baseInitialize
    {
        private readonly IAuth _repo;
        private TransModel trans;

        public TeamManagement(CustomSession _session = null, string param = null)
        {
            InitializeComponent();
            this._repo = new AuthRepo();
            this.trans = new TransModel();
            epiSession = _session;
            DefaultSession();
        }

        private void tlClear_Click(object sender, EventArgs e)
        {
            trans = new TransModel();
            trvNev.Nodes.Clear();
            dgvTeam.Rows.Clear();
            dgvAuthorized.Rows.Clear();
            dgvAvailable.Rows.Clear();
        }

        private void tlSave_Click(object sender, EventArgs e)
        {
            trans.Tree.VisibleFlag = Convert.ToInt32(chkEnabled.Checked);
            trans.Tree = _repo.SaveTree(eSession, trans.Tree);
        }

        private void TeamManagement_Load(object sender, EventArgs e)
        {
            this.dgvTeam.DragEnter += new DragEventHandler(dgvTeam_DragEnter);
            this.dgvTeam.DragDrop += new DragEventHandler(dgvTeam_DragDrop);
            ResetTreeNav();
        }

        private void ResetTreeNav()
        {
            trvNev.Nodes.Clear();
            SetTeamToGrid(trans.Teams);
        }

        private void SetTeamToGrid(IList<TeamModel> list)
        {
            dgvTeam.Rows.Clear();
            int i = 1;
            foreach (var item in list)
            {
                dgvTeam.Rows.Add(i, item.TeamId, item.TeamName, item.Authorized, epiSession.CompanyName, item.Division, item.Department, item.Section, item.Team);
                i++;
            }
        }

        private void SetTeamAuthToGrid(IList<TeamMemberModel> list)
        {
            dgvAuthorized.Rows.Clear();
            foreach (var item in list)
            {
                dgvAuthorized.Rows.Add(item.UserId, item.UserName, item.TeamCode);
            }
        }

        private void SetAvailableToGrid(IList<TeamMemberModel> list)
        {
            dgvAvailable.Rows.Clear();

            foreach (var item in list)
            {
                dgvAvailable.Rows.Add(item.UserId, item.UserName, item.TeamCode);
            }
        }

        private void tlFind_Click(object sender, EventArgs e)
        {
            using (TreeList frm = new TreeList(epiSession, trans))
            {
                frm.ShowDialog();

                if (!string.IsNullOrEmpty(frm.selected.TreeViewName))
                {
                    trvNev.Nodes.Clear();
                    trans.Tree = frm.selected;
                    trans.LoadData(eSession);
                    SetTeamToGrid(trans.Teams);
                    SetAvailableToGrid(trans.Available);

                    TreeNode nodeRoot = new TreeNode(trans.Tree.TreeViewName);
                    nodeRoot.Tag = trans.Tree.TreeViewId;
                    nodeRoot.ImageIndex = 1;
                    trvNev.Nodes.Add(nodeRoot);
                    AddTree(trans, nodeRoot, trans.Tree.TreeViewId.ToString());
                    BindingData(trans);
                }
                else
                {
                    tlClear_Click(sender, e);
                }
            }
        }

        private void AddTree(TransModel model, TreeNode root, string parentId)
        {
            foreach (var item in trans.Hierarchy.Where(x => x.ParentId == parentId))
            {
                TreeNode nodeChild = new TreeNode(item.TeamId);
                nodeChild.Tag = item.TeamId;
                root.Nodes.Add(nodeChild);
                AddTree(trans, nodeChild, item.TeamId);
            }
        }

        private void dgvTeam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void FilterTeam()
        {
            if (chkDivision.Checked || chkDepartment.Checked || chkSection.Checked || chkTeam.Checked)
            {
                IList<TeamModel> result = new List<TeamModel>();

                if (chkDivision.Checked) { result = trans.Teams.Where(x => x.Division.Equals(chkDivision.Checked)).ToList(); };
                if (chkDepartment.Checked) { result = trans.Teams.Where(x => x.Department.Equals(chkDepartment.Checked)).ToList(); };
                if (chkSection.Checked) { result = trans.Teams.Where(x => x.Section.Equals(chkSection.Checked)).ToList(); };
                if (chkTeam.Checked) { result = trans.Teams.Where(x => x.Team.Equals(chkTeam.Checked)).ToList(); };

                SetTeamToGrid(result);
            }
            else
            {
                SetTeamToGrid(trans.Teams);
            }
        }

        private void chkDivision_CheckedChanged(object sender, EventArgs e)
        {
            FilterTeam();
        }

        private void chkDepartment_CheckedChanged(object sender, EventArgs e)
        {
            FilterTeam();
        }

        private void chkSection_CheckedChanged(object sender, EventArgs e)
        {
            FilterTeam();
        }

        private void chkTeam_CheckedChanged(object sender, EventArgs e)
        {
            FilterTeam();
        }

        private void tlNew_Click(object sender, EventArgs e)
        {
            using (AddTree frm = new AddTree(epiSession))
            {
                frm.ShowDialog();
                tlClear_Click(sender, e);
                if (frm.addedModel != null)
                {
                    trans.Tree = frm.addedModel;
                    trans.LoadData(eSession);
                    SetTeamToGrid(trans.Teams);
                    SetAvailableToGrid(trans.Available);

                    TreeNode nodeRoot = new TreeNode(trans.Tree.TreeViewName);
                    nodeRoot.Tag = trans.Tree.TreeViewId;
                    nodeRoot.ImageIndex = 1;
                    trvNev.Nodes.Add(nodeRoot);
                    AddTree(trans, nodeRoot, trans.Tree.TreeViewId.ToString());
                    BindingData(trans);
                }
            }
        }

        private void BindingData(TransModel trans)
        {
            ClearBindingData();
            chkEnabled.DataBindings.Add("Checked", trans.Tree, "VisibleFlag");
        }

        private void ClearBindingData()
        {
            chkEnabled.DataBindings.Clear();
        }

        private void dgvTeam_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.String)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void dgvTeam_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.String)))
            {
                Point clientPoint = trvNev.PointToClient(new Point(e.X, e.Y));
            }
        }

        private void dgvTeam_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            dgvTeam.DoDragDrop(dgvTeam.Rows[e.RowIndex].Cells[1].Value.ToString(), DragDropEffects.Copy);
        }

        private void trvNev_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode nodeOver = null;
            Point p = trvNev.PointToClient(new Point(e.X, e.Y));
            nodeOver = trvNev.GetNodeAt(p.X, p.Y);
            string teamid = (System.String)e.Data.GetData(typeof(System.String));

            if (trans.Tree.VisibleFlag == 1)
            {
                MessageBox.Show("This tree is used. Can't be added.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (!_repo.CheckTeamInTree(trans.Tree.TreeViewId, teamid))
                {
                    nodeOver.TreeView.SelectedNode = nodeOver;
                    TreeNode nodeChild = new TreeNode(teamid);
                    nodeChild.Tag = teamid;
                    nodeOver.Nodes.Add(nodeChild);
                    nodeOver.Expand();

                    TeamHierarchyModel model = new TeamHierarchyModel();
                    model.TreeViewId = trans.Tree.TreeViewId;
                    model.TeamId = teamid;
                    model.ParentId = nodeOver.Tag.ToString();
                    trans.Hierarchy = _repo.InsertTeam(eSession, model).ToList();
                }
                else
                {
                    MessageBox.Show("This team [" + teamid + "] has already.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void trvNev_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void tlDelete_Click(object sender, EventArgs e)
        {
            if (trans.Tree.VisibleFlag == 1)
            {
                MessageBox.Show("This tree is used. Can't be deleted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TreeNode nodeSelected = null;
            nodeSelected = trvNev.SelectedNode;
            var str = trans.Tree.TreeViewName;

           

            trvNev.Nodes.Remove(nodeSelected);
            DeleteNodes(nodeSelected);

            if (nodeSelected.Text.Trim().Equals(str.ToString().Trim())) 
            {
                _repo.DeleteRootNode(eSession, trans.Tree.TreeViewId);
                tlClear_Click(sender, e);
            } 
        }

        private void DeleteNodes(TreeNode node)
        {
            TeamHierarchyModel model = new TeamHierarchyModel();
            model.TreeViewId = trans.Tree.TreeViewId;
            model.TeamId = node.Tag.ToString();
            trans.Hierarchy = _repo.DeleteNode(eSession, model).ToList();

            foreach (TreeNode oSubNode in node.Nodes)
            {
                DeleteNodes(oSubNode);
            }
        }

        private string nodeCurr = null;

        private void trvNev_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nodeCurr = e.Node.Tag.ToString();
            var query = from DataGridViewRow row in dgvTeam.Rows
                        where (row.Cells[1].Value.ToString() == nodeCurr)
                        select row;

            var rw = query.Where(x => x.Cells[1].Value.ToString() == nodeCurr).FirstOrDefault();

            if (rw != null) dgvTeam.Rows[rw.Index].Selected = true;

            SetTeamAuthToGrid(trans.Authorized.Where(x => x.TeamCode == nodeCurr && x.TreeViewId == trans.Tree.TreeViewId).ToList());
        }

        private void AddAuthorized()
        {
            foreach (DataGridViewRow row in dgvAvailable.SelectedRows)
            {
                TeamMemberModel model = new TeamMemberModel();
                model.TreeViewId = trans.Tree.TreeViewId;
                model.TeamCode = nodeCurr;
                model.UserId = row.Cells["id"].Value.ToString();
                _repo.AddAuthorized(eSession, model);
            }

            trans.Authorized = _repo.GetAuthorizedByTree(trans.Tree.TreeViewId).ToList();
            SetTeamAuthToGrid(trans.Authorized.Where(x => x.TeamCode == nodeCurr && x.TreeViewId == trans.Tree.TreeViewId).ToList());
        }

        private void DeletAuthorized()
        {
            foreach (DataGridViewRow row in dgvAuthorized.SelectedRows)
            {
                TeamMemberModel model = new TeamMemberModel();
                model.TreeViewId = trans.Tree.TreeViewId;
                model.TeamCode = nodeCurr;
                model.UserId = row.Cells["id1"].Value.ToString();
                _repo.DeleteAuthorized(eSession, model);
            }

            trans.Authorized = _repo.GetAuthorizedByTree(trans.Tree.TreeViewId).ToList();
            SetTeamAuthToGrid(trans.Authorized.Where(x => x.TeamCode == nodeCurr && x.TreeViewId == trans.Tree.TreeViewId).ToList());
        }

        private void butRemove_Click(object sender, EventArgs e)
        {
            AddAuthorized();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            DeletAuthorized();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            if (cboFind.SelectedIndex == 0)
            {
                SetAvailableToGrid(trans.Available.Where(x => x.UserId.ToUpper().Contains(txtFind.Text.ToUpper().ToString())).ToList());
            }

            if (cboFind.SelectedIndex == 1)
            {
                SetAvailableToGrid(trans.Available.Where(x => x.UserName.ToUpper().Contains(txtFind.Text.ToUpper().ToString())).ToList());
            }

            if (cboFind.SelectedIndex == 2)
            {
                SetAvailableToGrid(trans.Available.Where(x => x.TeamCode.ToUpper().Contains(txtFind.Text.ToUpper().ToString())).ToList());
            }
        }

        private void tlRefresh_Click(object sender, EventArgs e)
        {
            //PRList frm = new PRList(null);
           
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            var result = _repo.GetWaitingTeamById(1, "GS");
        }
    }
}