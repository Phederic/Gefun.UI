using Gefun.Dominio.Classe;
using Gefun.Repositorio.Base.Repositorio;
using Gefun.Servico.Base;
using Gefun.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Servico.Servico
{
    public class AnexoServico : ServicoBase<Anexo, AnexoRepositorio>, IAnexoServico
    {
        public AnexoServico()
        {
            _repositorio = new AnexoRepositorio();
        }

        public List<Anexo> PorFuncionario(int id) => _repositorio.PorFuncionario(id);

    }
}
