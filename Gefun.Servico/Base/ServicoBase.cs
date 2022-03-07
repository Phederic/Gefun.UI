

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
            //_repositorio = GerenciadorDependencia.ObterInstancia<TRepositorio>();
        }

        public ServicoBase(TRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
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
<<<<<<< HEAD
            //using(var myConn = new SqlConnection("Data Source=BRENDEL-PC;user id=sa;password=saroot;"))
            using (var myConn = DbContext.ObterConexao())
=======
            using(var myConn = new SqlConnection("Data Source=BRENDEL-PC;user id=sa;password=saroot;"))
>>>>>>> f9094f20e329a39ef9df2daf1b7482b87366f89c
            {
                myConn.Open();
                PreInserirEAtualizar(obj);
                obj = Inserindo(obj);
                PosInserirEAtualizar(obj);
                return obj;
            }
        }

        public T Atualizar(T obj)
        {
            using (var transacao = DbContext.ObterConexao().BeginTransaction())
            {
                PreInserirEAtualizar(obj);
                obj = Atualizando(obj);
                PosInserirEAtualizar(obj);
                transacao.Commit();
                return obj;
            }
        }

        public virtual void PreInserirEAtualizar(T obj) { }
        public virtual void PosInserirEAtualizar(T obj) { }
        public virtual void PreExcluir(int id) { }

        public void Excluir(int id)
        {
            using (var transacao = DbContext.ObterConexao().BeginTransaction())
            {
                PreExcluir(id);
                Excluindo(id);
                transacao.Commit();
            };
        }

        public T Obter(int id)
        {
            return Obtendo(id);
        }

        protected virtual T Atualizando(T obj)
        {
            return _repositorio.Atualizar(obj);
        }

        protected virtual void Excluindo(int id)
        {
            _repositorio.Excluir(id);
        }

        protected virtual T Inserindo(T obj)
        {
            return _repositorio.Inserir(obj);
        }

        protected virtual T Obtendo(int id)
        {
            return _repositorio.Obter(id);
        }
    }
}
