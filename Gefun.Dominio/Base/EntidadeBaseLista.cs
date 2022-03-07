using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Dominio.Base
{
    public class EntidadeBaseLista : EntidadeBase
    {
        [Computed]
        public bool Excluir { get; set; }
    }
}
