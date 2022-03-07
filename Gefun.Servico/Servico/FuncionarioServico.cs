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
        public Funcionario ObterCompleto(int id)
        {
            string query = @"
            SELECT * FROM Funcionario WHERE Id= @id
            SELECT * FROM Formacao WHERE FormacaoId= @id";

            var funcionario = new Funcionario();
            using(var mult = _connection.QueryMultiple(query, new { id }))
            {
                funcionario = mult.Read<Funcionario>().FirstOrDefault();
                if (funcionario != null)
                {
                    funcionario.TreinamentosRealizados = mult.Read<TreinamentosRealizados>().ToList();
                }
            }
            return funcionario;
        }


    }
}
