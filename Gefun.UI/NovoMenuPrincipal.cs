using DevExpress.XtraBars;
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
    public partial class NovoMenuPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public NovoMenuPrincipal()
        {
            InitializeComponent();
        }

        private void Funcionario_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFuncionarioPesquisa frm = new frmFuncionarioPesquisa();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCidadePesquisa frm = new frmCidadePesquisa();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFormacaoPesquisa frm = new frmFormacaoPesquisa();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}