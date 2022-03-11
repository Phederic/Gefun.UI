using Dapper;
using Gefun.Dominio.Base;
using Gefun.Repositorio.Configuracao;
using System.Collections.Generic;
using System.Linq;

namespace Gefun.Repositorio.Base.Repository
{
    public class ParentescoRepositorio : RepositorioBase<Parentesco>
    {
        public List<Parentesco> PorFuncionario(int id)
        {
            using (var myConn = DbContext.ObterConexao())
            {
                myConn.Open();
                string sql = "SELECT * FROM Parentesco WHERE FuncionarioId = @id";
                return myConn.Query<Parentesco>(sql, new { id }).ToList();
            }
        }
    }
}
