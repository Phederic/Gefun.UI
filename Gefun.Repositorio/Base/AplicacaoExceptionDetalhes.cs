namespace Gefun.Repositorio.Base
{
    public class AplicacaoExceptionDetalhes
    {
        public string Mensagem { get; set; }
        public string Propriedade { get; set; }

        public AplicacaoExceptionDetalhes(string mensagem, string propriedade)
        {
            Mensagem = mensagem;
            Propriedade = propriedade;
        }

        public AplicacaoExceptionDetalhes(string mensagem) => Mensagem = mensagem;


        protected AplicacaoExceptionDetalhes()
        {
        }
    }
}
