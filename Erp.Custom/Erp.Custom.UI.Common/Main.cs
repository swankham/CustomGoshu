using Erp.Custom.Session.Models;
using Erp.Custom.UI.Common.Models;
using Erp.Custom.UI.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Erp.Custom.UI.Common
{
    public partial class Main : baseInitialize
    {
        private readonly IMenu _repo;
        private CustomSession session;

        public Main(CustomSession _session = null)
        {
            InitializeComponent();
            this._repo = new CommonRepository();
            this.session = new CustomSession();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (epiSession.SessionId == null)
            {
                Login frm = new Login();
                frm.ShowDialog();
                epiSession = frm._session;
            }
            if (epiSession != null)
            {
                if (!string.IsNullOrEmpty(epiSession.SessionId))
                {
                    TreeNode nodeRoot = new TreeNode(epiSession.CompanyName);
                    nodeRoot.Tag = 1;
                    trvMenu.Nodes.Add(nodeRoot);

                    var result = _repo.GetAllMenu().ToList();
                    AddMenu(nodeRoot, result, "");
                }
            }
        }

        private void AddMenu(TreeNode root, List<MenuModel> list, string parent)
        {
            foreach (var i in list.Where(x => x.ParentMenuID.Equals(parent) && x.Program.Equals("Menu")))
            {
                TreeNode nodeChild = new TreeNode(i.MenuDesc);
                nodeChild.Tag = i.MenuID;
                root.Nodes.Add(nodeChild);
                AddMenu(nodeChild, list, i.MenuID);
            }            
        }

        private void GetItemMenu(string parentID)
        {
            listView.Clear();
            var item = _repo.GetAllMenu().Where(x => x.ParentMenuID.Equals(parentID) && x.Program.Equals("List")).ToList();
            listView.View = View.List;
            int n = 0;
            foreach (var i in item)
            {
                listView.Items.Add(i.MenuDesc);
                listView.Items[n].Name = i.Module + "." + i.SecCode;
                listView.Items[n].ImageIndex = 2;
                n++;
            }
        }

        private void trvMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            GetItemMenu(e.Node.Tag.GetString());
        }
    }
}