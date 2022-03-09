using DevExpress.XtraEditors;
using Gefun.Dominio.Classe;
using Gefun.Servico.Servico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gefun.UI.Pesquisa
{
    public partial class frmFuncionarioPesquisa : DevExpress.XtraEditors.XtraForm
    {
        private FuncionarioServico _funcionarioServico;
        private FormacaoServico _formacaoServico;

        public IEnumerable<Funcionario> Funcionario
        {
            get => funcionarioBindingSource.DataSource as IEnumerable<Funcionario>;
            set => funcionarioBindingSource.DataSource = value;
        }

        public frmFuncionarioPesquisa()
        {
            InitializeComponent();
            _funcionarioServico = new FuncionarioServico();
            _formacaoServico = new FormacaoServico();
            CarregarLookup();
            Pesquisar();
        }

        private void CarregarLookup()
        {
            lkpFormacaoId.DataSource = _formacaoServico.Todos();
        }
        private void Pesquisar()
        {
            Funcionario = _funcionarioServico.Todos();
            funcionarioBindingSource.ResetBindings(false);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmFuncionario();
            frm.ShowDialog();
            Pesquisar();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = MessageBox.Show("Deseja imprimir?", "IMPRMIR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                gridControl1.ShowPrintPreview();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            var result = MessageBox.Show("Deseja salvar em excel?", "SALVAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (View != null)
                {
                    View.OptionsPrint.ExpandAllDetails = true;
                    View.ExportToXlsx("ListaFuncionario.csv");
                }
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var linha = (Funcionario)gridView1.GetFocusedRow();
            var frm = new frmFuncionario(linha);
            frm.ShowDialog();
            Pesquisar();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var linha = (Funcionario)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (linha == null)
                return;
            var result = MessageBox.Show("Deseja excluir", "Exclusão", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (linha.Id > 0)
                {
                    var repositorioFuncionario = new FuncionarioServico();
                    repositorioFuncionario.Excluir(linha.Id);
                }
                Pesquisar();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            var result = MessageBox.Show("Deseja salvar em PDF?", "SALVAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (View != null)
                {
                    View.OptionsPrint.ExpandAllDetails = true;
                    View.ExportToPdf("ListaFuncionario.pdf");
                }
            }
        }
    }
}