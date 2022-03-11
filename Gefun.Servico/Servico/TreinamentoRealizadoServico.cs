using Gefun.Dominio.Classe;
using Gefun.Repositorio.Base.Repository;
using Gefun.Servico.Base;
using Gefun.Servico.Interface;
using System.Collections.Generic;

namespace Gefun.Servico.Servico
{
    public class TreinamentoRealizadoServico : ServicoBase<TreinamentoRealizado, TreinamentosRealizadosRepositorio>, ITreinamentoRealizadoServico
    {
        public List<TreinamentoRealizado> PorFuncionario(int id) => _repositorio.PorFuncionario(id);

    }
}
