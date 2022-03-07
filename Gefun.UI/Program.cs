using Gefun.Repositorio.Configuracao;
using Gefun.Repositorio.VersaoBanco.Atualizador;
using System;
using System.Windows.Forms;

namespace Gefun.UI
{
    static class Program
    {       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //DbContext.CarregarConexao();

            var atualizador = new AtualizadorDb();
            atualizador.ValidaBanco();

            Application.Run(new MenuPrincipal());
        }
    }
}
