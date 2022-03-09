using Dapper.Contrib.Extensions;
using Gefun.Dominio.Classe.Cadastro;
using Gefun.Repositorio.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Repositorio.Base.Repositorio
{
    public class CidadesRepositorio : RepositorioBase<Cidades>
    {
        public List<Cidades> Todos()
        {
            using (var myConn = DbContext.ObterConexao())
            {
                myConn.Open();
                return myConn.GetAll<Cidades>().ToList();
            }
        }
    }
}
