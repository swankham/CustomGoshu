using Erp.Custom.Core.Session.Models;
using Erp.Custom.UI.Common.Models;
using Erp.Custom.UI.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;
using Erp.Custom.Core.Session.Repositories;
using System.Reflection;
using Ice.Lib;
using Ice.Lib.Framework;
using Ice.CustomUI.PRList;

namespace Erp.Custom.UI.Common
{
    public partial class Main : baseInitialize
    {
        private readonly IMenu _repo;
        private readonly ISession _repoSess;

        private CustomSession session;

        private EpiTransaction iTrans;

        public Main(CustomSession _session = null)
        {
            InitializeComponent();
            this._repo = new CommonRepository(epiSession);
            this._repoSess = new Erp.Custom.Core.Session.Repositories.Session();
            this.session = new CustomSession();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string msgErr = string.Empty;

            //TODO switching offline/online 
            epiSession = _repoSess.IdentifySession("", "", out msgErr);

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
            foreach (var i in item.OrderBy(x => x.Sequence))
            {
                listView.Items.Add(i.MenuDesc);
                listView.Items[n].Name = i.SecCode;
                listView.Items[n].Tag = i.NameSpace;
                listView.Items[n].Text = i.MenuDesc;
                listView.Items[n].ImageIndex = 2;
                n++;
            }
        }

        private void trvMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            GetItemMenu(e.Node.Tag.GetString());
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            if (listView.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView.SelectedItems;
                ListViewItem lvItem = items[0];
                string from = lvItem.Name;
                //ShowForm(from);
                base.ShowForm(lvItem);
               
            }
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(TestMethods frm = new TestMethods(epiSession)){
                frm.ShowDialog();
            }
        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string str2 = "Ice.CustomUI.PRList";
            //string str = "Ice.Lib.App.Launch";

            //Assembly MyDALL = Assembly.Load(str2); 
            //Type MyLoadClass = MyDALL.GetType(str); 
            //object obj = Activator.CreateInstance(MyLoadClass);
            //MethodInfo method = obj.GetType().GetMethod("ShowDialog", new Type[] { typeof(string[]) });
            //method.Invoke(obj, new object[] { sender, e });
        }

    }
}