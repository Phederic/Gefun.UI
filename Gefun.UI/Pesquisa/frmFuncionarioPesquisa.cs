using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using Gefun.Dominio.Classe;
using Gefun.Repositorio.Base;
using Gefun.Servico.Interface;
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
        private IFuncionarioServico _funcionarioServico = GerenciadorDependencia.ObterInstancia<IFuncionarioServico>();
        private IFormacaoServico _formacaoServico = GerenciadorDependencia.ObterInstancia<IFormacaoServico>();

        public IEnumerable<Funcionario> Funcionario
        {
            get => funcionarioBindingSource.DataSource as IEnumerable<Funcionario>;
            set => funcionarioBindingSource.DataSource = value;
        }

        public frmFuncionarioPesquisa()
        {
            InitializeComponent();
  
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
                gridControlFuncionario.ShowPrintPreview();
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

                XlsxExportOptions options = new XlsxExportOptions();
            options.ShowGridLines = true;
            

            DevExpress.XtraGrid.Views.Grid.GridView View = gridControlFuncionario.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (View != null)
                {
                    View.OptionsPrint.ExpandAllDetails = true;
                    View.ExportToXlsx(xlsxExportFile, options);
                }
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var linha = (Funcionario)gridViewFuncionario.GetFocusedRow();
            var frm = new frmFuncionario(linha);
            frm.ShowDialog();
            Pesquisar();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var linha = (Funcionario)gridViewFuncionario.GetRow(gridViewFuncionario.FocusedRowHandle);
            if (linha == null)
                return;
            var result = MessageBox.Show("Deseja excluir", "Exclusão", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (linha.Id > 0)
                {
                    _funcionarioServico.Excluir(linha.Id);
                }
                Pesquisar();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
       
            var result = MessageBox.Show("Deseja salvar em PDF?", "SALVAR", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Pdf Files|*.pdf";
            dialog.ShowDialog();
            string pdfExportFile = dialog.FileName;

            PdfExportOptions options = new PdfExportOptions();
            options.ShowPrintDialogOnOpen = true;
            
           

            DevExpress.XtraGrid.Views.Grid.GridView View = gridControlFuncionario.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (View != null)
                {
                    View.OptionsPrint.ExpandAllDetails = true;
                    View.ExportToPdf(pdfExportFile, options);
                    
                }
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}