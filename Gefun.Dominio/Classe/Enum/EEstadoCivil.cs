using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Dominio.Classe.Enum
{
   public enum EEstadoCivil
    {   [Description("Solteiro")]
        Solteiro,
        [Description("Casado")]
        Casado,
        [Description("Viúvo")]
        Viuvo,
        [Description("Separado")]
        Separado
    }
}
