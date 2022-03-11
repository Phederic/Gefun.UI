using System;
using System.Collections.Generic;

namespace Gefun.Repositorio.Base
{
    public interface IGerenciadorDependencia
    {
        void Register<TDependencia, TImplementacao>()
        where TDependencia : class
        where TImplementacao : class, TDependencia;
        void RegistrarSingleton(Type dependencia, Type implementacao);
        void RegisterSingleton<TDependencia, TImplementacao>()
        where TDependencia : class
        where TImplementacao : class, TDependencia;
        void Register(Type dependencia, Type implementacao);
        void RegisterSingleton<T>(Func<T> funcCreator) where T : class;
        void Register<T>(Func<T> funcCreator) where T : class;
        object ObterInstancia(Type type);
        void RegisterDecorator<TService, TDecorator>()
        where TService : class
        where TDecorator : class, TService;
        void RegisterDecoratorSingleton<TService, TDecorator>()
        where TService : class
        where TDecorator : class, TService;
        TDependencia ObterInstancia<TDependencia>() where TDependencia : class;
        TDependencia ObterInstanciaSeRegistrado<TDependencia>() where TDependencia : class;
        IEnumerable<object> ObterInstancias(Type type);
        void Verify();
    }
}
