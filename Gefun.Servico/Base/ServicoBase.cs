

using Gefun.Dominio.Base;
using Gefun.Repositorio.Base;
using Gefun.Repositorio.Configuracao;
using System.Data.SqlClient;

namespace Gefun.Servico.Base
{
    public abstract class ServicoBase : IServico
    {
        public SqlConnection _connection = DbContext.ObterConexao();
    }

    public abstract class ServicoBase<TRepositorio> : ServicoBase, IServico
        where TRepositorio : class, IRepositorio
    {
        protected TRepositorio _repositorio;

        public ServicoBase()
        {
            _repositorio = GerenciadorDependencia.ObterInstancia<TRepositorio>();
        }

        public ServicoBase(TRepositorio repositorio) => _repositorio = repositorio;

    }

    public abstract class ServicoBase<T, TRepositorio> : ServicoBase<TRepositorio>, IServico<T>
        where T : EntidadeBase
        where TRepositorio : class, IRepositorio<T>
    {
        public ServicoBase() : base()
        {

        }

        public ServicoBase(TRepositorio repositorio) : base(repositorio)
        {
        }

        public T InserirOuAtualizar(T obj)
        {
            if (obj.EstaSalvo)
                return Atualizar(obj);
            else
                return Inserir(obj);
        }

        public T Inserir(T obj)
        {

            using (var myConn = DbContext.ObterConexao())

            {
                myConn.Open();
                Validar(obj);
                PreInserirEAtualizar(obj);
                obj = Inserindo(obj);
                PosInserirEAtualizar(obj);
                return obj;
            }
        }

        public T Atualizar(T obj)
        {
            using (var myConn = DbContext.ObterConexao())
            {
                myConn.Open();
                Validar(obj);
                PreInserirEAtualizar(obj);
                obj = Atualizando(obj);
                PosInserirEAtualizar(obj);                
                return obj;
            }
        }

        protected virtual void Validar(T entidade)
        {
            GerenciadorValidacao<T>.AssertValidacao(entidade);
        }

        public virtual void PreInserirEAtualizar(T obj) { }
        public virtual void PosInserirEAtualizar(T obj) { }
        public virtual void PreExcluir(int id) { }

        public void Excluir(int id)
        {
            using (var myConn = DbContext.ObterConexao())            
            {
                myConn.Open();
                PreExcluir(id);
                Excluindo(id);                
            };
        }

        public T Obter(int id) => Obtendo(id);


        protected virtual T Atualizando(T obj) => _repositorio.Atualizar(obj);


        protected virtual void Excluindo(int id) => _repositorio.Excluir(id);


        protected virtual T Inserindo(T obj) => _repositorio.Inserir(obj);


        protected virtual T Obtendo(int id) =>  _repositorio.Obter(id);

    }
}
