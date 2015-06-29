using Erp.Custom.Core.Session.Models;
using System.Windows.Forms;

namespace Erp.Custom.UI.Common.Views.TeamManagement
{
    public partial class MarkUpPrice : baseInitialize
    {
        public MarkUpPrice(CustomSession _session = null, string param = null)
        {
            InitializeComponent();
        }

        private void trvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void SetBillToGrid()
        {
            dgvList.Rows.Clear();

            dgvList.Rows.Add("1", "T00014", "Magnetic motor starter 22 Kw (Y-D)", "10", "Psc", "100.00", "120.00", true);
        }

        private void MarkUpPrice_Load(object sender, System.EventArgs e)
        {
            SetBillToGrid();
        }
    }
}