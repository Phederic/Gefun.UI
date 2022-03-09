using Gefun.Dominio.Classe.Cadastro;
using Gefun.Repositorio.Base.Repositorio;
using Gefun.Servico.Base;
using Gefun.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Servico.Servico
{
    public class CidadeServico : ServicoBase<Cidades, CidadesRepositorio> , ICidadeServico
    {
        public CidadeServico()
        {
            _repositorio = new CidadesRepositorio();
        }

        public List<Cidades> Todos() => _repositorio.Todos();
        

        
    }
}
