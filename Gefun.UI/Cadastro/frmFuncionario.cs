
using Gefun.Dominio.Base;
using Gefun.Dominio.Classe;
using Gefun.Dominio.Classe.Cadastro;
using Gefun.Dominio.Classe.Enum;
using Gefun.Repositorio.Base;
using Gefun.Servico.Interface;
using Gefun.Servico.Servico;
using Gefun.UI.Cadastro;
using System;
using System.IO;
using System.Windows.Forms;

namespace Gefun.UI
{
    public partial class frmFuncionario : DevExpress.XtraEditors.XtraForm
    {
        private IFuncionarioServico _servicoFuncionario = GerenciadorDependencia.ObterInstancia<IFuncionarioServico>();
        private IFormacaoServico _servicoFormacao = GerenciadorDependencia.ObterInstancia<IFormacaoServico>();
        private ICidadeServico _cidadeServico = GerenciadorDependencia.ObterInstancia<ICidadeServico>();
        private ITreinamentoServico _treinamentoServico = GerenciadorDependencia.ObterInstancia<ITreinamentoServico>();
        private ITreinamentoRealizadoServico _treinamentosRealizadosServico = GerenciadorDependencia.ObterInstancia<ITreinamentoRealizadoServico>();
        private IAnexoServico _anexoServico = GerenciadorDependencia.ObterInstancia<IAnexoServico>();
        private IParentescoServico _parentescoServico = GerenciadorDependencia.ObterInstancia<IParentescoServico>();

        public Funcionario Funcionario
        {
            get => funcionarioBindingSource.DataSource as Funcionario;
            set => funcionarioBindingSource.DataSource = value;
        }

        public frmFuncionario()
        {

            InitializeComponent();
            AtualizarLookup();

            Novo();
        }

        public frmFuncionario(Funcionario funcionario) : this()
        {
            Text = "Alterar funcionario";
            Funcionario = _servicoFuncionario.Obter(funcionario.Id);
            btnCadastrar.Text = "Alterar";
        }

        private void Novo() => Funcionario = new Funcionario();


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
                _parentescoServico.Excluir(linha.Id);
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
            var linha = (TreinamentoRealizado)gridView2.GetRow(gridView2.FocusedRowHandle);
            if (linha == null)
                return;

            if (linha.Id > 0)
            {
                _treinamentosRealizadosServico.Excluir(linha.Id);
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                _servicoFuncionario.InserirOuAtualizar(Funcionario);
                Close();
            }
            catch
            {
                MessageBox.Show("por favor inserir caracteres", "atenção");
                Validar();
            }
        }

        private bool Validar()
        {
            dxErrorProvider1.ClearErrors();
            dxErrorProvider1.SetError(txtCPF, "Campo obrigatorio");
            dxErrorProvider1.SetError(txtNome, "Campo obrigatorio");
            
            return dxErrorProvider1.HasErrors;
        }


        private void btneAnexo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var linha = (Anexo)gridView3.GetRow(gridView3.FocusedRowHandle);
            if (linha == null)
            { 
                linha = new Anexo();
                Funcionario.Anexos.Add(linha);
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.ShowDialog();
            linha.NomeArquivo = dialog.SafeFileName;
            linha.Arquivo = File.ReadAllBytes(dialog.FileName);
            funcionarioBindingSource.ResetBindings(false);
        }


    }  
}