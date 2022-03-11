using Gefun.Repositorio.Base;
using Gefun.Servico.Base;
using Gefun.Servico.Servico;
using System;
using System.Linq;

namespace Gefun.Servico
{
    public class ModuloServicos : ModuloDependencia
    {
        public ModuloServicos()
        {
            RegistrarServicosAutomaticamente();
        }

        private void RegistrarServicosAutomaticamente()
        {
            var repositoryAssembly = typeof(TreinamentoServico).Assembly; 
            var registrations = repositoryAssembly.GetTypes()
            .Where(type => type.IsClass && type.GetInterfaces().Contains(typeof(IServico)))
            .Select(type => new
            {
                Interfaces = type.GetInterfaces()
                .Where(a => a.Name != typeof(IServico<>).Name && a.Name != typeof(IServico).Name && !a.IsGenericType)
                .ToArray(),
                Implementacao = type
            }); foreach (var reg in registrations)
            {
                var nome = reg.Implementacao.Name; 
                var interfaces = reg.Interfaces;
                if (interfaces.Length > 1)
                {
                    interfaces =
                    reg.Interfaces.Where(x => !reg.Implementacao.BaseType.GetInterfaces().Any(y => y.Name == x.Name)).ToArray(); if (interfaces.Length > 1)
                    {
                        throw new Exception($"Algo errado na interface da implementação de '{reg.Implementacao.Name}'." +
                        $"\r\nInterfaces encontradas:\r\n" +
                        $"{string.Join("\r\n", reg.Interfaces.Select(x => x.Name))}");
                    }
                }
                if (!reg.Implementacao.IsInterface && !reg.Implementacao.IsAbstract)
                    RegistrarSingleton(interfaces[0], reg.Implementacao);
            }
        }
    }


}
