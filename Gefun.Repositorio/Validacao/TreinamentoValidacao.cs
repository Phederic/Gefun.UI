using FluentValidation;
using Gefun.Dominio.Classe.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Repositorio.Validacao
{
    public class TreinamentoValidacao : AbstractValidator<Treinamento>
    {
        public TreinamentoValidacao()
        {
            RuleFor(x => x.Descricao).MaximumLength(Treinamento.MaxDescricao);
        }
    }
}
