using Gefun.Dominio.Classe;
using Gefun.Dominio.Classe.Enum;
using Gefun.Servico.Servico;
using Gefun.UI.Cadastro;
using System;
using System.Windows.Forms;

namespace Gefun.UI
{
    public partial class frmFuncionario : DevExpress.XtraEditors.XtraForm
    {
        private FuncionarioServico _servicoFuncionario;
        private FormacaoServico _servicoFormacao;

        public Funcionario Funcionario
        {
            get => funcionarioBindingSource.DataSource as Funcionario;
            set => funcionarioBindingSource.DataSource = value;
        }


        public frmFuncionario()
        {
            InitializeComponent();
            _servicoFuncionario = new FuncionarioServico();
            _servicoFormacao = new FormacaoServico();
            AtualizarLookup();
            Novo();
        }

        private void Novo()
        {
            Funcionario = new Funcionario();
        }

        private void AtualizarLookup() 
        {
            lkpSexo.Properties.DataSource = EnumHelper.ObterLista<ESexo>();
            lkpFormacao.Properties.DataSource = _servicoFormacao.Todos();
            lkpEstadoCivil.Properties.DataSource = EnumHelper.ObterLista<EEstadoCivil>();
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var frm = new frmFormacao();
            frm.ShowDialog();
            AtualizarLookup();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _servicoFuncionario.Inserir(Funcionario);
        }

        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {
    
        }
    }
}