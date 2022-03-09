using Dapper;
using Gefun.Dominio.Classe;
using Gefun.Repositorio.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Repositorio.Base.Repository
{
    public class TreinamentosRealizadosRepositorio : RepositorioBase<TreinamentosRealizados>
    {
        public List<TreinamentosRealizados> PorFuncionario(int id)
        {
            using ( var myConn= DbContext.ObterConexao())
            {
                myConn.Open();
                string sql = "SELECT * FROM TreinamentosRealizados WHERE FuncionarioId = @Id";
                return myConn.Query<TreinamentosRealizados>(sql, new { id }).ToList();
            }
        }




    }
}
