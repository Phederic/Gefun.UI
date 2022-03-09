
using Gefun.Dominio.Base;
using Gefun.Dominio.Classe;
using Gefun.Dominio.Classe.Cadastro;
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
        private CidadeServico _cidadeServico;
        private TreinamentoServico _treinamentoServico;
        private TreinamentosRealizadosServico _treinamentosRealizadosServico;

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
            _cidadeServico = new CidadeServico();
            _treinamentoServico = new TreinamentoServico();
            _treinamentosRealizadosServico = new TreinamentosRealizadosServico();
            AtualizarLookup();
            Novo();
        }

        public frmFuncionario(Funcionario funcionario) : this()
        {
            Text = "Alterar funcionario";
            Funcionario = _servicoFuncionario.Obter(funcionario.Id);
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
            lkpCidade.DataSource = _cidadeServico.Todos();
            lkpTipo.DataSource = EnumHelper.ObterLista<ETipoParentesco>();
            lkpTreinamentos.DataSource = _treinamentoServico.Todos();


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

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            Funcionario = _servicoFuncionario.InserirOuAtualizar(Funcionario);
            Close();
        }

        private void lkpCidade_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frm = new frmCidades();
            frm.ShowDialog();
            AtualizarLookup();
        }

        private void riDeletar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var linha = (Parentesco)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (linha == null)
                return;

            if (linha.Id > 0)
            {
                var repositorioParentesco = new ParentescoServico();
                repositorioParentesco.Excluir(linha.Id);
            }
            Funcionario.Parentescos.Remove(linha);
            funcionarioBindingSource.ResetBindings(false);
        }

        private void lkpTreinamentos_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frm = new frmTreinamento();
            frm.ShowDialog();
            AtualizarLookup();
        }

        private void riDeletarTreinamento_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var linha = (TreinamentosRealizados)gridView2.GetRow(gridView2.FocusedRowHandle);
            if (linha == null)
                return;

            if (linha.Id > 0)
            {
                var repositoroTreinamentosRealizados = new TreinamentosRealizadosServico();
                repositoroTreinamentosRealizados.Excluir(linha.Id);
            }
            Funcionario.TreinamentosRealizados.Remove(linha);
            funcionarioBindingSource.ResetBindings(false);
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            var frm = new frmFormacao();
            frm.ShowDialog();
            AtualizarLookup();

        }
    }
}