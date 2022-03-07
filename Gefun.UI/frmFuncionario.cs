using DevExpress.XtraEditors;
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
        public frmFuncionario()
        {
            InitializeComponent();
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}