using Dapper.Contrib.Extensions;
using Gefun.Dominio.Classe.Cadastro;
using Gefun.Repositorio.Configuracao;
using System.Collections.Generic;
using System.Linq;

namespace Gefun.Repositorio.Base.Repositorio
{
    public class CidadesRepositorio : RepositorioBase<Cidade>
    {
        public List<Cidade> Todos()
        {
            using (var myConn = DbContext.ObterConexao())
            {
                myConn.Open();
                return myConn.GetAll<Cidade>().ToList();
            }
        }
    }
}
