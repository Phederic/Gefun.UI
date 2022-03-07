using Gefun.Dominio.Base;

namespace Gefun.Repositorio.Base
{
    public interface IRepositorio
    {
    }

    public interface IRepositorio<T> : IRepositorio where T : EntidadeBase
    {
        T Inserir(T obj);
        T Atualizar(T obj);
        T Obter(int id);
        void Excluir(int id);
    }
}