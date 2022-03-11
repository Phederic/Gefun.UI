using Gefun.Repositorio;
using Gefun.Repositorio.Base;
using Gefun.Repositorio.Configuracao;
using Gefun.Repositorio.VersaoBanco.Atualizador;
using Gefun.Servico;
using Gefun.Servico.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            ConfigurarDependencias();
            var atualizador = new AtualizadorDb();
            atualizador.ValidaBanco();

            Application.Run(new GeFun());

        }

        public static void ConfigurarDependencias()
        {
            GerenciadorDependencia.RegistrarGerenciador(new SimpleInjectorGerenciadorDependencia());
            GerenciadorDependencia.RegistrarModulos(new List<ModuloDependencia>()
            {
                new ModuloRepositorio(),
                new ModuloServicos()
            });

#if DEBUG
            GerenciadorDependencia.Verify();
#endif
        }
    }
}
