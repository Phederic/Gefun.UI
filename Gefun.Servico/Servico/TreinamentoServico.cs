using Gefun.Dominio.Classe.Cadastro;
using Gefun.Repositorio.Base.Repositorio;
using Gefun.Servico.Base;
using Gefun.Servico.Interface;
using System.Collections.Generic;

namespace Gefun.Servico.Servico
{
    public class TreinamentoServico : ServicoBase<Treinamentos, TreinamentoRepositorio>, ITreinametosServico
    {
        public TreinamentoServico()
        {
            _repositorio = new TreinamentoRepositorio();
        }

        public List<Treinamentos> Todos()
        {
            return _repositorio.Todos();
        }
    }
}
