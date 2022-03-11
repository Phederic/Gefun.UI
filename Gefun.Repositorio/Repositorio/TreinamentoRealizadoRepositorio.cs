using Dapper;
using Gefun.Dominio.Classe;
using Gefun.Repositorio.Configuracao;
using System.Collections.Generic;
using System.Linq;

namespace Gefun.Repositorio.Base.Repository
{
    public class TreinamentosRealizadosRepositorio : RepositorioBase<TreinamentoRealizado>
    {
        public List<TreinamentoRealizado> PorFuncionario(int id)
        {
            using ( var myConn= DbContext.ObterConexao())
            {
                myConn.Open();
                string sql = "SELECT * FROM TreinamentosRealizados WHERE FuncionarioId = @Id";
                return myConn.Query<TreinamentoRealizado>(sql, new { id }).ToList();
            }
        }




    }
}
