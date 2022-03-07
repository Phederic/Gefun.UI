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
<<<<<<< HEAD
            get => formacaoBindingSource.DataSource as Formacao;
            set => formacaoBindingSource.DataSource = value;
=======
            get => bindingFormacao.DataSource as Formacao;
            set => bindingFormacao.DataSource = value;
>>>>>>> f9094f20e329a39ef9df2daf1b7482b87366f89c

        }

        public frmFormacao()
        {
            InitializeComponent();
            _formacaoServico = new FormacaoServico();
<<<<<<< HEAD
            Novo();
        }

        private void Novo()
        {
            Formacao = new Formacao();
=======
>>>>>>> f9094f20e329a39ef9df2daf1b7482b87366f89c
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _formacaoServico.Inserir(Formacao);
<<<<<<< HEAD
            Close();
=======
>>>>>>> f9094f20e329a39ef9df2daf1b7482b87366f89c

        }
    }
}