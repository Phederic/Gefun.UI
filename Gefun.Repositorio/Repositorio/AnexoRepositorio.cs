using Dapper;
using Dapper.Contrib.Extensions;
using Gefun.Dominio.Classe;
using Gefun.Repositorio.Configuracao;
using System.Collections.Generic;
using System.Linq;

namespace Gefun.Repositorio.Base.Repositorio
{
    public class AnexoRepositorio : RepositorioBase<Anexo>
    {
        public List<Anexo> PorFuncionario(int id)
        {
            using(var myConn = DbContext.ObterConexao())
            {
                myConn.Open();
                string sql = "SELECT * FROM Anexo WHERE FuncionarioId = @Id";
                return myConn.Query<Anexo>(sql, new { id }).ToList();
            }
        }

        public List<Anexo> Todos()
        {
            using (var myConn = DbContext.ObterConexao())
            {
                myConn.Open();
                return myConn.GetAll<Anexo>().ToList();
            }
        }
    }
}
