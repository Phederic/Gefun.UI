using FluentValidation;
using Gefun.Dominio.Classe.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Repositorio.Validacao
{
    public class CidadeValidacao : AbstractValidator<Cidade>
    {
        public CidadeValidacao()
        {
            RuleFor(x => x.Descricao).MaximumLength(Cidade.MaxDescricao);
        }
    }
}
