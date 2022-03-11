using Dapper.Contrib.Extensions;
using Gefun.Dominio.Classe;
using Gefun.Repositorio.Configuracao;
using System.Collections.Generic;
using System.Linq;

namespace Gefun.Repositorio.Base.Repository
{
    public class FuncionarioRepositorio : RepositorioBase<Funcionario>
    {
        public List<Funcionario> Todos()
        {
            using (var myConn = DbContext.ObterConexao())
            {
                myConn.Open();
                return myConn.GetAll<Funcionario>().ToList();
            }
        }        


        
    }
}
