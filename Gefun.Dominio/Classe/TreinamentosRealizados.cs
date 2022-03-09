using Dapper.Contrib.Extensions;
using Gefun.Dominio.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Dominio.Classe
{
    [Table("TreinamentosRealizados")]
   public class TreinamentosRealizados : EntidadeBaseLista
    {
        [DisplayName("Funcionario")]
        public int FuncionarioId { get; set; }
        [DisplayName("Treinamento")]
        public int TreinamentosId { get; set; }

    }
}
