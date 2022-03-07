using Dapper.Contrib.Extensions;
using Gefun.Dominio.Classe.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Dominio.Base
{
    [Table("Parentesco")]
   public class Parentesco : EntidadeBaseLista
    {
        [DisplayName("Funcionario")]
        public int FuncionarioId { get; set; }
        [DisplayName("Grau de parentesco")]
        public ETipoParentesco Tipo { get; set; }
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("Cidade")]
        public int CidadeId { get; set; }

    }
}
