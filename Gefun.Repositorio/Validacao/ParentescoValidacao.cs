using FluentValidation;
using Gefun.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Repositorio.Validacao
{
    public class ParentescoValidacao : AbstractValidator<Parentesco>
    {
        public ParentescoValidacao()
        {
            RuleFor(x => x.Nome).MaximumLength(Parentesco.NomeTamanhoMax);
            RuleFor(x => x.Tipo).NotNull();

        }
    }
}
