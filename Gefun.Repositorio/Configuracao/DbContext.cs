using System.Configuration;
using System.Data.SqlClient;

namespace Gefun.Repositorio.Configuracao
{
    public static class DbContext
    {
        public static SqlConnection ObterConexao() 
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["conexaoSqlServer"].ConnectionString);
        }
    }
}
