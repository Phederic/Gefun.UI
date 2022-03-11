using Gefun.Dominio.Classe.Cadastro;
using Gefun.Servico.Base;
using System.Collections.Generic;

namespace Gefun.Servico.Interface
{
    public interface ITreinamentoServico : IServico<Treinamento>
    {
        List<Treinamento> Todos();
    }
}
