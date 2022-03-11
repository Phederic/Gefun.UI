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
    [Table("Anexo")]
    public class Anexo : EntidadeBaseLista
    {
        [DisplayName("Funcionario")]
        public int FuncionarioId { get; set; }
        [DisplayName("Arquivo")]
        public byte[] Arquivo{ get; set; }
        [DisplayName("Nome do Arquivo")]
        public string NomeArquivo { get; set; }
    }
}
