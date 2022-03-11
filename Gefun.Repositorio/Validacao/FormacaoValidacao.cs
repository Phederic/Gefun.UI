using FluentValidation;
using Gefun.Dominio.Classe.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Repositorio.Validacao
{
   public class FormacaoValidacao : AbstractValidator<Formacao>
    {
        public FormacaoValidacao()
        {
            RuleFor(x => x.Descricao).MaximumLength(Formacao.MaxDescricao);
        }
    }
}
