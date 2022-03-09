using Gefun.Dominio.Classe;
using Gefun.Repositorio.Base.Repository;
using Gefun.Servico.Base;
using Gefun.Servico.Interface;
using System.Collections.Generic;

namespace Gefun.Servico.Servico
{
    public class TreinamentosRealizadosServico : ServicoBase<TreinamentosRealizados, TreinamentosRealizadosRepositorio>, ITreinamentosRealizadosServico
    {
        public TreinamentosRealizadosServico()
        {
            _repositorio = new TreinamentosRealizadosRepositorio();
        }

        public List<TreinamentosRealizados> PorFuncionario(int id) => _repositorio.PorFuncionario(id);
        
            
        

    }
}
