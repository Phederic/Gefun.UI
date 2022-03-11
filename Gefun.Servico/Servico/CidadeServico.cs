using Gefun.Dominio.Classe.Cadastro;
using Gefun.Repositorio.Base.Repositorio;
using Gefun.Servico.Base;
using Gefun.Servico.Interface;
using System.Collections.Generic;

namespace Gefun.Servico.Servico
{
    public class CidadeServico : ServicoBase<Cidade, CidadesRepositorio> , ICidadeServico
    {
        public List<Cidade> Todos() => _repositorio.Todos();
        
    }
}
