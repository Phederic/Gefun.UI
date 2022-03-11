using Gefun.Dominio.Classe.Cadastro;
using Gefun.Repositorio.Base.Repositorio;
using Gefun.Servico.Base;

using Gefun.Servico.Interface;
using System.Collections.Generic;

namespace Gefun.Servico.Servico
{

    public class FormacaoServico : ServicoBase<Formacao, FormacaoRepositorio>, IFormacaoServico

    {
              
        public List<Formacao> Todos() => _repositorio.Todos();

    }
}
