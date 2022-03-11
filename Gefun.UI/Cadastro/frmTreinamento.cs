using DevExpress.XtraEditors;
using Gefun.Dominio.Classe.Cadastro;
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

namespace Gefun.UI.Cadastro
{
    public partial class frmTreinamento : DevExpress.XtraEditors.XtraForm
    {
        private ITreinamentoServico _treinamentoServico = GerenciadorDependencia.ObterInstancia<ITreinamentoServico>();

        public Treinamento Treinamentos
        {
            get => treinamentosBindingSource.DataSource as Treinamento;
            set => treinamentosBindingSource.DataSource = value;
        }

        private void Novo() => Treinamentos = new Treinamento();

        public frmTreinamento()
        {
            InitializeComponent();            
            Novo();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            try
            {
                _treinamentoServico.InserirOuAtualizar(Treinamentos);
                Close();
            }
            catch
            {
                MessageBox.Show("Por favor inserir caracteres", "ATENÇÃO");
                Validar();

            }

        }

        private bool Validar()
        {
            dxErrorProvider1.ClearErrors();
            dxErrorProvider1.SetError(txtDescricao, "Campos obrigatório");

            return dxErrorProvider1.HasErrors;
        }
    }
}