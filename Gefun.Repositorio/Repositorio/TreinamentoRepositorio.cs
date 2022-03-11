using Dapper.Contrib.Extensions;
using Gefun.Dominio.Classe.Cadastro;
using Gefun.Repositorio.Configuracao;
using System.Collections.Generic;
using System.Linq;

namespace Gefun.Repositorio.Base.Repositorio
{
    public class TreinamentoRepositorio : RepositorioBase<Treinamento>
    {
        public List<Treinamento> Todos()
        {
            using(var myConn = DbContext.ObterConexao())
            {
                myConn.Open();
                return myConn.GetAll<Treinamento>().ToList();
            }
        }
    }
}
