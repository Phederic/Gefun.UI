using Dapper.Contrib.Extensions;
using Gefun.Dominio.Base;
using Gefun.Repositorio.Configuracao;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            try
            {
                _connection.Delete<T>(obj);
            }
            catch 
            {
                MessageBox.Show("Não é possivel deletar, pois existe um funcionaro relacionado a ele.", "ATENÇÃO");
            }
        }

        public T Obter(int id) => _connection.Get<T>(id);
        }       
    
    }

