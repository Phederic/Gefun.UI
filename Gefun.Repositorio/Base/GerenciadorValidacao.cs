using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Gefun.Repositorio.Base
{
    public static class GerenciadorValidacao<TEntidade>
        where TEntidade : class
    {
        public static IList<AplicacaoExceptionDetalhes> Validar(TEntidade entidade) => GerenciadorValidacao.Validar(entidade);


        public static void AssertValidacao(TEntidade entidade) => GerenciadorValidacao.AssertValidacao(entidade);

    }

    public static class GerenciadorValidacao
    {
        public static IList<AplicacaoExceptionDetalhes> Validar<TEntidade>(TEntidade entidade) where TEntidade : class
        {
            var validacao = ObterValidador<TEntidade>();

            if (validacao == null)
                return new List<AplicacaoExceptionDetalhes>();

            var resultado = validacao.Validate(entidade);

            if (resultado.IsValid)
                return new List<AplicacaoExceptionDetalhes>();

            return resultado.Errors.Select(x => new AplicacaoExceptionDetalhes(x.ErrorMessage, x.PropertyName)).ToList();
        }

        public static void AssertValidacao<TEntidade>(TEntidade entidade) where TEntidade : class
        {
            var resultados = Validar(entidade);
            if (resultados != null && resultados.Count() > 0)
                throw new AplicacaoException(resultados);             
        }

        public static IValidator<TEntidade> ObterValidador<TEntidade>() where TEntidade : class => GerenciadorDependencia.ObterInstanciaSeRegistrado<IValidator<TEntidade>>();

    }
}
