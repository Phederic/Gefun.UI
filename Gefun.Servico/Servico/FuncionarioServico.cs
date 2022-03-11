using Gefun.Dominio.Classe;
using Gefun.Repositorio.Base;
using Gefun.Repositorio.Base.Repository;
using Gefun.Servico.Base;
using Gefun.Servico.Interface;
using System.Collections.Generic;
namespace Gefun.Servico.Servico
{
    public class FuncionarioServico : ServicoBase<Funcionario, FuncionarioRepositorio>, IFuncionarioServico
    {
        private IParentescoServico _servicoParentesco = GerenciadorDependencia.ObterInstancia<IParentescoServico>();
        private IAnexoServico _anexoServico = GerenciadorDependencia.ObterInstancia<IAnexoServico>();
        private ITreinamentoRealizadoServico _treinamentosRealizadosServico = GerenciadorDependencia.ObterInstancia<ITreinamentoRealizadoServico>();

        public List<Funcionario> Todos() => _repositorio.Todos();

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




    }
}

