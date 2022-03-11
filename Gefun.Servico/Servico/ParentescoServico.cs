using Gefun.Dominio.Base;
using Gefun.Repositorio.Base.Repository;
using Gefun.Servico.Base;
using Gefun.Servico.Interface;
using System.Collections.Generic;
namespace Gefun.Servico.Servico
{
    public class ParentescoServico : ServicoBase<Parentesco, ParentescoRepositorio>, IParentescoServico
    {
        public List<Parentesco> PorFuncionario(int id) => _repositorio.PorFuncionario(id);
    }
}
