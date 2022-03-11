using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Repositorio.Base
{
    public static class GerenciadorDependencia
    {
        internal static IGerenciadorDependencia Atual;

        public static void RegistrarGerenciador(IGerenciadorDependencia gerenciador) => Atual = gerenciador;


        public static void RegistrarModulos(IEnumerable<ModuloDependencia> modulos)
        {
            //TODO: Excluir esse método.
            //Não exclui por falta de tempo
        }

        public static object ObterInstancia(Type dependencia)
        {
#if DEBUG
            AssertGerenciadorRegistrador();
#endif
            return Atual.ObterInstancia(dependencia);
        }

        public static TDependencia ObterInstancia<TDependencia>() where TDependencia : class
        {
#if DEBUG
            AssertGerenciadorRegistrador();
#endif
            return Atual.ObterInstancia<TDependencia>();
        }
        
        public static TDependencia ObterInstanciaSeRegistrado<TDependencia>() where TDependencia : class
        {
#if DEBUG
            AssertGerenciadorRegistrador();
#endif
            return Atual.ObterInstanciaSeRegistrado<TDependencia>();
        }

#if DEBUG
        private static void AssertGerenciadorRegistrador()
        {
            if (Atual == null)
            {
                throw new InvalidOperationException("Gerenciador nao registrado");
            }
        }

        public static void Verify() =>  Atual.Verify();

#endif
    }
}
