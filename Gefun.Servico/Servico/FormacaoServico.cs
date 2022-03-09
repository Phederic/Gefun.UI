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

    public class FormacaoServico : ServicoBase<Formacao, FormacaoRepositorio>, IFormacaoServico

    {
        public FormacaoServico()
        {
            _repositorio = new FormacaoRepositorio();
        }

        public List<Formacao> Todos() => _repositorio.Todos();
        
    }
}
