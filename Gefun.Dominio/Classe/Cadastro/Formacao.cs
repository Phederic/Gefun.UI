using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Dominio.Classe.Cadastro
{
    [Table("Formacao")]
   public class Formacao
    {
        public const int MaxDescricao = 150;
        [DisplayName("Descrição")]
        public string  Descricao { get; set; }

    }
}
