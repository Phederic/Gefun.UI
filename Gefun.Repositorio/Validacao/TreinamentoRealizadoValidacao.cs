using FluentValidation;
using Gefun.Dominio.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Repositorio.Validacao
{
    public class TreinamentoRealizadoValidacao : AbstractValidator<TreinamentoRealizado>
    {
        public TreinamentoRealizadoValidacao()
        {
            RuleFor(x => x.TreinamentosId).NotNull().WithMessage("Teste"); ;
            RuleFor(x => x.FuncionarioId).NotNull().WithMessage("Teste");
            
        }
    }
}
