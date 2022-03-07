using DevExpress.XtraBars;
using Gefun.UI.Cadastro;
using Gefun.UI.Pesquisa;
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

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmDependentes();
            frm.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmCidades();
            frm.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmFormacao();
            frm.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new frmFuncionarioPesquisa();
            frm.ShowDialog();
        }
    }
}