using System;
using System.Collections.Generic;
using System.Linq;

namespace Gefun.Repositorio.Base
{
    public class AplicacaoException : Exception
    {
        private List<AplicacaoExceptionDetalhes> _detalhes;
        
        public override string Message
        {
            get
            {
                return ToString();
            }
        }

        public IEnumerable<AplicacaoExceptionDetalhes> Detalhes { get => _detalhes; set => _detalhes = value.ToList(); }
        public bool TemErros => _detalhes.Count > 0;

        public AplicacaoException() => _detalhes = new List<AplicacaoExceptionDetalhes>();


        public AplicacaoException(IEnumerable<AplicacaoExceptionDetalhes> detalhes) => _detalhes = detalhes.ToList();


        public AplicacaoException(params AplicacaoExceptionDetalhes[] detalhes) => _detalhes = detalhes.ToList();


        public AplicacaoException(AplicacaoExceptionDetalhes detalhe) => _detalhes = new List<AplicacaoExceptionDetalhes> { detalhe };


        public AplicacaoException(params string[] mensagem)
        {
            var detalhes = new List<AplicacaoExceptionDetalhes>();
            foreach (var item in mensagem)
            {
                if (!string.IsNullOrWhiteSpace(item))
                    detalhes.Add(new AplicacaoExceptionDetalhes(item));
            }
            _detalhes = detalhes;
        }

        public string ToString(string separador) => string.Join(separador, Detalhes.Select(x => x.Mensagem));


        public override string ToString() =>  ToString("\r\n");


        public AplicacaoException AddPrefixoMensagens(string prefixo)
        {
            foreach (var item in Detalhes)
            {
                item.Mensagem = prefixo + ": " + item.Mensagem;
            }
            return this;
        }

        public AplicacaoException AddDetalhe(params AplicacaoExceptionDetalhes[] detalhes)
        {
            _detalhes.AddRange(detalhes);
            return this;
        }

        public AplicacaoException AddDetalhe(params string[] detalhes)
        {
            _detalhes.AddRange(detalhes.Select(x => new AplicacaoExceptionDetalhes(x)));
            return this;
        }

        public void LancarExcecaoSeTiverErros()
        {
            if (TemErros)
                throw this;
        }
    }
}
