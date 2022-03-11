    using Gefun.Dominio.Classe.Cadastro;
using Gefun.Repositorio.Base.Repositorio;
using Gefun.Servico.Base;
using Gefun.Servico.Interface;
using System.Collections.Generic;

namespace Gefun.Servico.Servico
{
    public class TreinamentoServico : ServicoBase<Treinamento, TreinamentoRepositorio>, ITreinamentoServico
    {        
        public List<Treinamento> Todos() => _repositorio.Todos(); 
    }
}
