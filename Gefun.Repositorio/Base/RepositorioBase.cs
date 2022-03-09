using Dapper.Contrib.Extensions;
using Gefun.Dominio.Base;
using Gefun.Repositorio.Configuracao;
using System.Data.SqlClient;

namespace Gefun.Repositorio.Base
{
    public class RepositorioBase<T> : IRepositorio<T> where T : EntidadeBase
    {
        public SqlConnection _connection = DbContext.ObterConexao();

        T IRepositorio<T>.Inserir(T obj)
        {
            var id = (int)_connection.Insert<T>(obj);
            obj.Id = id;
            return obj;
        }

        T IRepositorio<T>.Atualizar(T obj)
        {
            _connection.Update<T>(obj);            
            return obj;
        }

        public void Excluir(int id)
        {
            var obj = Obter(id);
            _connection.Delete<T>(obj);
        }

        public T Obter(int id)
        {
            return _connection.Get<T>(id);
        }       
    }
}
