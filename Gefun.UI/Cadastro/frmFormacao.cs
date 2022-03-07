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
    public partial class frmFormacao : DevExpress.XtraEditors.XtraForm
    {
        private FormacaoServico _formacaoServico;

        public Formacao Formacao
        {
            get => formacaoBindingSource.DataSource as Formacao;
            set => formacaoBindingSource.DataSource = value;

        }

        public frmFormacao()
        {
            InitializeComponent();
            _formacaoServico = new FormacaoServico();
            Novo();
        }

        private void Novo()
        {
            Formacao = new Formacao();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _formacaoServico.Inserir(Formacao);
            Close();

        }
    }
}