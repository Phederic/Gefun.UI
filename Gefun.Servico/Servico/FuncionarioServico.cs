using Dapper;
using Gefun.Dominio.Base;
using Gefun.Dominio.Classe;
using Gefun.Repositorio.Base.Repository;
using Gefun.Servico.Base;
using Gefun.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Gefun.Servico.Servico
{
    public class FuncionarioServico : ServicoBase<Funcionario, FuncionarioRepositorio>, IFuncionarioServico
    {
        private ParentescoServico _servicoParentesco;
        private AnexoServico _anexoServico;
        private TreinamentosRealizadosServico _treinamentosRealizadosServico;

        public FuncionarioServico()
        {
            _repositorio = new FuncionarioRepositorio();
            _servicoParentesco = new ParentescoServico();
            _treinamentosRealizadosServico = new TreinamentosRealizadosServico();
            _anexoServico = new AnexoServico();
        }

        public List<Funcionario> Todos()
        {
            return _repositorio.Todos();
        }

        public override void PosInserirEAtualizar(Funcionario obj)
        {
            obj.Parentescos.ForEach(x => x.FuncionarioId = obj.Id);
            foreach (var item in obj.Parentescos)
            {
                if (!item.Excluir)
                    _servicoParentesco.InserirOuAtualizar(item);
                else
                    _servicoParentesco.Excluir(item.Id);
            }

            obj.Anexos.ForEach(x => x.FuncionarioId = obj.Id);
            foreach (var item in obj.Anexos)
            {
                if (!item.Excluir)
                    _anexoServico.InserirOuAtualizar(item);
                else
                    _anexoServico.Excluir(item.Id);
            }
            obj.TreinamentosRealizados.ForEach(x => x.FuncionarioId = obj.Id);
            foreach (var item in obj.TreinamentosRealizados)
            {
                if (!item.Excluir)
                    _treinamentosRealizadosServico.InserirOuAtualizar(item);
                else
                    _treinamentosRealizadosServico.Excluir(item.Id);
            }

        }
        public override void PreExcluir(int id)
        {
            var obj = Obter(id);
            foreach (var item in obj.Parentescos)
                _servicoParentesco.Excluir(item.Id);

            foreach (var item in obj.Anexos)
                _anexoServico.Excluir(item.Id);

            foreach (var item in obj.TreinamentosRealizados)
                _treinamentosRealizadosServico.Excluir(item.Id);
        }

        protected override Funcionario Obtendo(int id)
        {
            var obj = base.Obtendo(id);
            if (obj != null)
            {
                obj.Parentescos = _servicoParentesco.PorFuncionario(obj.Id);
                obj.TreinamentosRealizados = _treinamentosRealizadosServico.PorFuncionario(obj.Id);
                obj.Anexos = _anexoServico.PorFuncionario(obj.Id);
            }

            return obj;
        }

        public Funcionario ObterCompleto(int id)
        {
            string query = @"
            SELECT * FROM Funcionario WHERE Id= @id;
            SELECT * FROM Parentesco WHERE Id= @id;
            SELECT * FROM TreinamentosRealizados WHERE Id=@id;
            ";

            var funcionario = new Funcionario();
            using (var mult = _connection.QueryMultiple(query, new { id }))
            {
                funcionario = mult.Read<Funcionario>().FirstOrDefault();
                if (funcionario != null)
                {
                    funcionario.TreinamentosRealizados = mult.Read<TreinamentosRealizados>().ToList();
                    funcionario.Parentescos = mult.Read<Parentesco>().ToList();

                }
            }
            return funcionario;
        }



    }
}

