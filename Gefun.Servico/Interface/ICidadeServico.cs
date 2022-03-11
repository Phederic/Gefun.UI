using Gefun.Dominio.Classe.Cadastro;
using Gefun.Servico.Base;

using System.Collections.Generic;
namespace Gefun.Servico.Interface
{
    public interface ICidadeServico : IServico<Cidade>
    {
        List<Cidade> Todos();
    }
}
