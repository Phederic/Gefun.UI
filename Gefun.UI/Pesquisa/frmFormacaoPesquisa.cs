using DevExpress.XtraEditors;
using Gefun.Dominio.Classe.Cadastro;
using Gefun.Servico.Servico;
using Gefun.UI.Cadastro;
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
    public partial class frmFormacaoPesquisa : DevExpress.XtraEditors.XtraForm
    {
        private FormacaoServico _formacaoServico;

        public IEnumerable<Formacao> Formacao
        {
            get => formacaoBindingSource.DataSource as IEnumerable<Formacao>;
            set => formacaoBindingSource.DataSource = value;
        }

        public frmFormacaoPesquisa()
        {
            InitializeComponent();
            _formacaoServico = new FormacaoServico();
            Pesquisar();

        }
        public void Pesquisar()
        {
            Formacao = _formacaoServico.Todos();
            formacaoBindingSource.ResetBindings(false);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmFormacao();
            frm.ShowDialog();
            Pesquisar();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var linha = (Formacao)gridView1.GetRow(gridView1.FocusedRowHandle);
            {
                if (linha == null)
                    return;
                var result = MessageBox.Show("Deseja excluir a formação?", "EXCLUSÃO", MessageBoxButtons.YesNo);
                {
                    if (result == DialogResult.Yes)
                    {
                        if (linha.Id > 0)
                        {
                            var _repositorioFormacao = new FormacaoServico();
                            _repositorioFormacao.Excluir(linha.Id);
                        }
                    }
                    Pesquisar();
                }



            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = MessageBox.Show("Deseja imprimir?", "IMPRIMIR", MessageBoxButtons.YesNo);
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
                    View.ExportToXlsx("ListaFormacao.csv");
                }
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            var result = MessageBox.Show("Deseja salvar em pdf?", "SALVAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (View != null)
                {
                    View.OptionsPrint.ExpandAllDetails = true;
                    View.ExportToPdf("ListaFormacao.pdf");
                }
            }
        }
    }
}