<<<<<<< HEAD
﻿using Gefun.Dominio.Classe;
using Gefun.Dominio.Classe.Enum;
=======
﻿using DevExpress.XtraEditors;
using Gefun.Dominio.Classe;
using Gefun.Servico.Interface;
>>>>>>> f9094f20e329a39ef9df2daf1b7482b87366f89c
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
<<<<<<< HEAD
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
=======
            
>>>>>>> f9094f20e329a39ef9df2daf1b7482b87366f89c
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