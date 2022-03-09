using DevExpress.XtraEditors;
using Gefun.Dominio.Classe.Cadastro;
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

namespace Gefun.UI.Cadastro
{
    public partial class frmTreinamento : DevExpress.XtraEditors.XtraForm
    {
        private TreinamentoServico _treinamentoServico;

        public Treinamentos Treinamentos
        {
            get => treinamentosBindingSource.DataSource as Treinamentos;
            set => treinamentosBindingSource.DataSource = value;
        }

        private void Novo()
        {
            Treinamentos = new Treinamentos();
        }



        public frmTreinamento()
        {
            InitializeComponent();
            _treinamentoServico = new TreinamentoServico();
            Novo();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _treinamentoServico.Inserir(Treinamentos);
            Close();
        }
    }
}