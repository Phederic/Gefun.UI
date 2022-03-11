using Gefun.Dominio.Classe;
using Gefun.Servico.Base;

using System.Collections.Generic;
namespace Gefun.Servico.Interface
{
    public interface IFuncionarioServico : IServico<Funcionario>
    {
        List<Funcionario> Todos();

    }
}
