using Dapper.Contrib.Extensions;
using System.ComponentModel;

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
