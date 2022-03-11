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
    public partial class frmCidades : DevExpress.XtraEditors.XtraForm
    {
        private ICidadeServico _cidadeServico = GerenciadorDependencia.ObterInstancia<ICidadeServico>();

        public Cidade Cidades
        {
            get => cidadesBindingSource.DataSource as Cidade;
            set => cidadesBindingSource.DataSource = value;
        }
        
        public frmCidades()
        {
            InitializeComponent();
          
            Novo();
        }

        public frmCidades(Cidade cidades) : this()
        {
            Text = "Alterar cidade";
            Cidades = _cidadeServico.Obter(cidades.Id);
            btnCadastrar.Text = "Alterar";
        }

        private void Novo() => Cidades = new Cidade();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                _cidadeServico.InserirOuAtualizar(Cidades);
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
            dxErrorProvider1.SetError(txtCidade, "Campo obrigatorio");
            return dxErrorProvider1.HasErrors;
        }
    }
}