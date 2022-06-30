using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using Gefun.Dominio.Classe.Cadastro;
using Gefun.Repositorio.Base;
using Gefun.Servico.Interface;
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
        private IFormacaoServico _formacaoServico = GerenciadorDependencia.ObterInstancia<IFormacaoServico>();

        public IEnumerable<Formacao> Formacao
        {
            get => formacaoBindingSource.DataSource as IEnumerable<Formacao>;
            set => formacaoBindingSource.DataSource = value;
        }

        public frmFormacaoPesquisa()
        {
            InitializeComponent();
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
            var linha = (Formacao)gridViewFormacao.GetRow(gridViewFormacao.FocusedRowHandle);
            {
                if (linha == null)
                    return;
                var result = MessageBox.Show("Deseja excluir a formação?", "EXCLUSÃO", MessageBoxButtons.YesNo);
                {
                    if (result == DialogResult.Yes)
                    {
                        if (linha.Id > 0)
                        {
                            _formacaoServico.Excluir(linha.Id);
                        }
                    }
                    if (result == DialogResult.No)
                        return;
                    Pesquisar();
                }



            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = MessageBox.Show("Deseja imprimir?", "IMPRIMIR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                gridControlFormacao.ShowPrintPreview();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = MessageBox.Show("Deseja salvar em excel?", "SALVAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV file (*.csv)|*.csv|";
            dialog.ShowDialog();
            string xlsxExportFile = dialog.FileName;

            DevExpress.XtraGrid.Views.Grid.GridView View = gridControlFormacao.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (View != null)
                {
                    View.OptionsPrint.ExpandAllDetails = true;
                    View.ExportToXlsx(xlsxExportFile);
                }
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = MessageBox.Show("Deseja salvar em pdf?", "SALVAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {


            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Pdf Files|*.pdf";
            dialog.ShowDialog();
            string pdfExportFile = dialog.FileName;


            PdfExportOptions options = new PdfExportOptions();
            options.ShowPrintDialogOnOpen = true;

            DevExpress.XtraGrid.Views.Grid.GridView View = gridControlFormacao.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (View != null)
                {
                    View.OptionsPrint.ExpandAllDetails = true;
                    View.ExportToPdf(pdfExportFile, options);
                }
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var linha = (Formacao)gridViewFormacao.GetFocusedRow();
            var frm = new frmFormacao(linha);
            frm.ShowDialog();
            Pesquisar();
        }
    }
}