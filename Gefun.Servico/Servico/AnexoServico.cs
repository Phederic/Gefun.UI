using Gefun.Dominio.Classe;
using Gefun.Repositorio.Base.Repositorio;
using Gefun.Servico.Base;
using Gefun.Servico.Interface;
using System.Collections.Generic;

namespace Gefun.Servico.Servico
{
    public class AnexoServico : ServicoBase<Anexo, AnexoRepositorio>, IAnexoServico
    {
       
        public List<Anexo> PorFuncionario(int id) => _repositorio.PorFuncionario(id);

        public List<Anexo> Todos() => _repositorio.Todos();

    }
}
