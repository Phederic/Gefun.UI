using Gefun.Dominio.Base;
using Gefun.Servico.Base;
using System.Collections.Generic;

namespace Gefun.Servico.Interface
{
    public interface IParentescoServico : IServico<Parentesco>
    {
        List<Parentesco> PorFuncionario(int id);
    }
}
