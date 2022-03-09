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
    public class TreinamentoRepositorio : RepositorioBase<Treinamentos>
    {
        public List<Treinamentos> Todos()
        {
            using(var myConn = DbContext.ObterConexao())
            {
                myConn.Open();
                return myConn.GetAll<Treinamentos>().ToList();
            }
        }
    }
}
