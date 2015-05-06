using Erp.Custom.Session.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erp.Custom.UI.Common.Views.CostManagement
{
    public partial class ApproveReq : baseInitialize
    {
        public ApproveReq(CustomSession _session = null, string param = null)
        {
            InitializeComponent();
        }

        private void trvMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            textBox2.Text = e.Node.Text.GetString();
        }
    }
}
