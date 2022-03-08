using Gefun.Dominio.Classe.Cadastro;
using Gefun.Repositorio.Base.Repositorio;
using Gefun.Servico.Base;
<<<<<<< HEAD
<<<<<<< HEAD
using Gefun.Servico.Interface;
=======
>>>>>>> f9094f20e329a39ef9df2daf1b7482b87366f89c
=======
>>>>>>> f9094f20e329a39ef9df2daf1b7482b87366f89c
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Servico.Servico
{
<<<<<<< HEAD
<<<<<<< HEAD
    public class FormacaoServico : ServicoBase<Formacao, FormacaoRepositorio>, IFormacaoServico
=======
    public class FormacaoServico : ServicoBase<Formacao, FormacaoRepositorio>
>>>>>>> f9094f20e329a39ef9df2daf1b7482b87366f89c
=======
    public class FormacaoServico : ServicoBase<Formacao, FormacaoRepositorio>
>>>>>>> f9094f20e329a39ef9df2daf1b7482b87366f89c
    {
        public FormacaoServico()
        {
            _repositorio = new FormacaoRepositorio();
        }

        public List<Formacao> Todos()
        {
            return _repositorio.Todos();
        }
    }
}
