using Dapper;
using Gefun.Dominio.Classe;
using Gefun.Repositorio.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
