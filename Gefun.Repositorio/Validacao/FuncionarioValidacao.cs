using FluentValidation;
using FluentValidation.Validators;
using Gefun.Dominio.Classe;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Repositorio.Validacao
{
    public class FuncionarioValidacao : AbstractValidator<Funcionario>
    {
        public FuncionarioValidacao()
        {
            RuleFor(x => x.CPF).NotNull();
            RuleFor(x => x.CPF).NotEmpty();
            RuleFor(x => x.Nome).MaximumLength(Funcionario.NomeTamanhoMax);
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.Nome).NotNull();
           
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email invalido");
            RuleFor(X => X.Observacao).MaximumLength(Funcionario.ObservacaoTamanhoMax);
            RuleFor(x => x.TreinamentosRealizados.Count).NotEqual(0).WithMessage("Nenhum treinamento informado");
            RuleFor(x => x.DataNascimento.Ticks).GreaterThanOrEqualTo(SqlDateTime.MinValue.Value.Ticks).WithMessage("Data invalida");
            RuleFor(x => x.DataNascimento.Ticks).LessThanOrEqualTo(SqlDateTime.MaxValue.Value.Ticks).WithMessage("Data invalida");




        }
    }
}
