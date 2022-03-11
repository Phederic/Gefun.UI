using DevExpress.XtraEditors;
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
    public partial class frmCidadePesquisa : DevExpress.XtraEditors.XtraForm
    {
        private ICidadeServico _cidadeServico = GerenciadorDependencia.ObterInstancia<ICidadeServico>();

        public IEnumerable<Cidade> Cidades
        {
            get => cidadesBindingSource.DataSource as IEnumerable<Cidade>;
            set => cidadesBindingSource.DataSource = value;
        }


        public frmCidadePesquisa()
        {
            InitializeComponent();
            Pesquisar();

        }

        public void Pesquisar()
        {
            Cidades = _cidadeServico.Todos();
            cidadesBindingSource.ResetBindings(false);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmCidades();
            frm.ShowDialog();
            Pesquisar();
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
                    View.ExportToXlsx("ListaCidade.csv");
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
                    View.ExportToPdf("ListaCidade.pdf");
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var linha = (Cidade)gridView1.GetRow(gridView1.FocusedRowHandle);
            {
                if (linha == null)
                    return;
                var result = MessageBox.Show("Deseja excluir?", "EXCLUSÃO", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (linha.Id > 0)
                    {
                        _cidadeServico.Excluir(linha.Id);
                    }
                }
                Pesquisar();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var linha = (Cidade)gridView1.GetFocusedRow();
            var frm = new frmCidades(linha);
            frm.ShowDialog();
            Pesquisar();
        }
    }
}