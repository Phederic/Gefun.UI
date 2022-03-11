using Gefun.Dominio.Classe;
using Gefun.Servico.Base;
using System.Collections.Generic;

namespace Gefun.Servico.Interface
{
    public interface ITreinamentoRealizadoServico : IServico<TreinamentoRealizado>
    {
        List<TreinamentoRealizado> PorFuncionario(int id);
    }
}
