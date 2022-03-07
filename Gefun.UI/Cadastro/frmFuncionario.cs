using DevExpress.XtraEditors;
using Gefun.Dominio.Classe;
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
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _servicoFuncionario.ObterCompleto(Funcionario.Id);
        }

        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {
            Funcionario.FormacaoId = (int)lkpFormacao.EditValue;

            if (Funcionario.FormacaoId == 0)
                return;
            var formacao = _servicoFormacao.Obter(Funcionario.Id);
            
            
        }
    }
}