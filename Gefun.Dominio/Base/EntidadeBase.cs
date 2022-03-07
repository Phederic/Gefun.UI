using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Dominio.Base
{
   public class EntidadeBase
    {
        public int Id { get; set; }
        [Computed]
        [DisplayName("Está salvo")]
        public bool EstaSalvo { get => Id > 0; }
    }
}
