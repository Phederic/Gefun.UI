using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gefun.UI
{
    public partial class MenuPrincipal : DevExpress.XtraEditors.XtraForm
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new  frmFuncionario();
            frm.ShowDialog();
        }
    }
}