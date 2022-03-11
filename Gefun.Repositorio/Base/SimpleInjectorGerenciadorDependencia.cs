using System;
using System.Collections.Generic;
using SimpleInjector;

namespace Gefun.Repositorio.Base
{
    public class SimpleInjectorGerenciadorDependencia : IGerenciadorDependencia
    {
        private readonly Container _container;

        public SimpleInjectorGerenciadorDependencia() => _container = new Container();


        public object ObterInstancia(Type type) =>  _container.GetInstance(type);


        public TDependencia ObterInstancia<TDependencia>()
        where TDependencia : class
        {
            return _container.GetInstance<TDependencia>();
        }

        public TDependencia ObterInstanciaSeRegistrado<TDependencia>() where TDependencia : class
        {
            var x = _container.GetRegistration(typeof(TDependencia));
            if (x == null)
                return null;
            return (TDependencia)x.GetInstance();
        }

        public void Register<TDependencia, TImplementacao>()
        where TDependencia : class
        where TImplementacao : class, TDependencia
        {
            Register(typeof(TDependencia), typeof(TImplementacao));
        }

        public void Register(Type dependencia, Type implementacao) => _container.Register(dependencia, implementacao);


        public void RegistrarSingleton(Type dependencia, Type implementacao) => _container.Register(dependencia, implementacao, Lifestyle.Singleton);


        public void RegisterSingleton<TDependencia, TImplementacao>()
        where TDependencia : class
        where TImplementacao : class, TDependencia
        {
            _container.Register<TDependencia, TImplementacao>(Lifestyle.Singleton);
        }

        public void RegistrarSingleton<TDependencia>(TDependencia objeto)
        where TDependencia : class
        {
            _container.RegisterInstance(objeto);
        }

        public IEnumerable<object> ObterInstancias(Type type) => _container.GetAllInstances(type);


        public void Verify() => _container.Verify();


        public void RegisterDecorator<TService, TDecorator>()
        where TService : class
        where TDecorator : class, TService
        {
            _container.RegisterDecorator<TService, TDecorator>();
        }

        public void RegisterDecoratorSingleton<TService, TDecorator>()
        where TService : class
        where TDecorator : class, TService
        {
            _container.RegisterDecorator<TService, TDecorator>(Lifestyle.Singleton);
        }

        public void RegisterSingleton<T>(Func<T> funcCreator) where T : class => _container.Register(funcCreator, Lifestyle.Singleton);


        public void Register<T>(Func<T> funcCreator) where T : class => _container.Register(funcCreator, Lifestyle.Transient);

    }
}
