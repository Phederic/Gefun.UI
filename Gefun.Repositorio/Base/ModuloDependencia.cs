using System;

namespace Gefun.Repositorio.Base
{
    public abstract class ModuloDependencia
    {
        protected readonly IGerenciadorDependencia Container; public ModuloDependencia() => Container = GerenciadorDependencia.Atual;

        protected void RegistrarSingleton<TDependencia, TImplementacao>()
      where TDependencia : class
      where TImplementacao : class, TDependencia
        {
            Container.RegisterSingleton<TDependencia, TImplementacao>();
        }
        protected void RegistrarSingleton(Type dependencia, Type implementacao) => Container.RegistrarSingleton(dependencia, implementacao);

        protected void Registrar<TDependencia, TImplementacao>()
      where TDependencia : class
      where TImplementacao : class, TDependencia
        {
            Container.Register(typeof(TDependencia), typeof(TImplementacao));
        }
        protected void Registrar(Type dependencia, Type implementacao) => Container.Register(dependencia, implementacao);

        protected void RegistrarTransient<T>(Func<T> funcCreator) where T : class => Container.Register<T>(funcCreator);

        protected void RegistrarSingleton<T>(Func<T> funcCreator) where T : class => Container.RegisterSingleton<T>(funcCreator);


        public void Validar() => Container.Verify();

    }
}
