using Gefun.Dominio.Classe;
using Gefun.Servico.Base;
using System.Collections.Generic;

namespace Gefun.Servico.Interface
{
    public interface IAnexoServico : IServico<Anexo>
    {
        List<Anexo> PorFuncionario(int id);
        List<Anexo> Todos();
    }
}
