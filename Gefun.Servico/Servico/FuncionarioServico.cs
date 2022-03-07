using Dapper;
using Gefun.Dominio.Classe;
using Gefun.Repositorio.Base.Repository;
using Gefun.Servico.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Gefun.Servico.Servico
{
    public class FuncionarioServico : ServicoBase<Funcionario ,FuncionarioRepositorio>
    {
        private ParentescoServico _servicoParentesco;
        private AnexoServico _anexoServico;
        private TreinamentosRealizadosServico _treinamentosRealizadosServico;

        public FuncionarioServico()
        {
            _servicoParentesco = new ParentescoServico();
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
            foreach(var item in obj.Anexos)
            {
                if (!item.Excluir)
                    _anexoServico.InserirOuAtualizar(item);
                else
                    _anexoServico.Excluir(item.Id);
            }
            obj.TreinamentosRealizados.ForEach(x => x.FuncionarioId = obj.Id);
            foreach(var item in obj.TreinamentosRealizados)
            {
                if (!item.Excluir)
                    _treinamentosRealizadosServico.InserirOuAtualizar(item);
                else
                    _treinamentosRealizadosServico.Excluir(item.Id);
            }

        }

        protected override Funcionario Obtendo(int id)
        {
            var obj = base.Obtendo(id);
            if (obj != null)
            {
                obj.Parentescos = _servicoParentesco.PorFuncionario(obj.Id);
            }

            return obj;
        }


    }
}
