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
    public partial class frmCidades : DevExpress.XtraEditors.XtraForm
    {
        private CidadeServico _cidadeServico;

        public Cidades Cidades
        {
            get => cidadesBindingSource.DataSource as Cidades;
            set => cidadesBindingSource.DataSource = value;
        }
        
        public frmCidades()
        {
            InitializeComponent();
            _cidadeServico = new CidadeServico();
            Novo();
        }

        private void Novo()
        {
            Cidades = new Cidades();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _cidadeServico.Inserir(Cidades);
            Close();
        }
    }
}