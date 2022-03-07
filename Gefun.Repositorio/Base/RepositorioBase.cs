using Dapper.Contrib.Extensions;
using Gefun.Repositorio.Configuracao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Repositorio.Base
{
    public class RepositorioBase<T> where T : class
    {
        public SqlConnection _connection = DbContext.ObterConexao();

        public T Obter(int id)
            => _connection.Get<T>(id);

        public int Inserir(T classe)
            => (int)_connection.Insert<T>(classe);

        public void Atualizar(T classe)
            => _connection.Update<T>(classe);

        public bool Delete(int id)
        {
            var T = _connection.Get<T>(id);
            if (T is null)
                return false;
            _connection.Delete(T);
            return true;
        }

        public void Delete(T classe)
            => _connection.Delete<T>(classe);

        public void InserirOuDeletar(T classe)
        {        
                if (classe == null)
                    _connection.Insert<T>(classe);
                else
                    _connection.Update<T>(classe);
        }

        public IEnumerable<T> Todos()
            => _connection.GetAll<T>();

        /// <summary>
        /// T Obter(id);
        /// T Inserir(T)
        /// T Atualizar(T)
        /// T InserirOuAtualizar(T)
        /// List<T> Todos()
        /// Excluir(id)
        /// </summary>
        /// <param name=""></param>
    }
}
