using Gefun.Dominio.Classe.Cadastro;
using Gefun.Repositorio.Base;
using Gefun.Servico.Interface;
using Gefun.Servico.Servico;
using System;
using System.Windows.Forms;

namespace Gefun.UI.Cadastro
{
    public partial class frmFormacao : DevExpress.XtraEditors.XtraForm
    {
        private IFormacaoServico _formacaoServico = GerenciadorDependencia.ObterInstancia<IFormacaoServico>();

        public Formacao Formacao
        {

            get => formacaoBindingSource.DataSource as Formacao;
            set => formacaoBindingSource.DataSource = value;


        }

        public frmFormacao()
        {
            InitializeComponent();
          
            Novo();
        }

        public frmFormacao(Formacao formacao) : this()
        {
            Text = "Alterar formação";
            Formacao = _formacaoServico.Obter(formacao.Id);
            btnCadastrar.Text = "Alterar";
        }
        private void Novo() => Formacao = new Formacao();


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                _formacaoServico.InserirOuAtualizar(Formacao);
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
            dxErrorProvider1.SetError(textEdit1, "Campo obrigatorio");
            return dxErrorProvider1.HasErrors;
        }
    }

}