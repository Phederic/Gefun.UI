
using Gefun.Dominio.Base;

namespace Gefun.Servico.Base
{
    public interface IServico
    {

    }

    public interface IServico<T> : IServico where T : EntidadeBase
    {
        T Obter(int id);
        T InserirOuAtualizar(T obj);
        T Inserir(T obj);
        T Atualizar(T obj);
        void Excluir(int id);
    }
}
