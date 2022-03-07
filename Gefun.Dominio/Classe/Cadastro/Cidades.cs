using Dapper.Contrib.Extensions;
using Gefun.Dominio.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Dominio.Classe.Cadastro
{
        [Table("Cidades")]
      public class Cidades : EntidadeBase
    {
        public const int MaxDescricao = 150;
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
