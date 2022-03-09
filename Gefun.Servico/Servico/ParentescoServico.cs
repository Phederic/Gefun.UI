using Gefun.Dominio.Base;
using Gefun.Repositorio.Base.Repository;
using Gefun.Servico.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Gefun.Servico.Servico
{
    public class ParentescoServico : ServicoBase<Parentesco, ParentescoRepositorio>
    {
        public ParentescoServico()
        {
            _repositorio = new ParentescoRepositorio();
        }
        public List<Parentesco> PorFuncionario(int id) => _repositorio.PorFuncionario(id);
      
    }
}
