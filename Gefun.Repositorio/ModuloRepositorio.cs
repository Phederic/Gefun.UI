using FluentValidation;
using Gefun.Repositorio.Base;
using Gefun.Repositorio.Base.Repositorio;
using Gefun.Repositorio.Validacao;
using System.Linq;

namespace Gefun.Repositorio
{
    public class ModuloRepositorio : ModuloDependencia
    {
        static ModuloRepositorio()
        {           
        }

        public ModuloRepositorio()
        {
            RegistrarValidations();
            RegistrarRepositorios();            
        }

        /// <summary>
        /// Registra todas as classes que herdam de <see cref="IRepositorio"/>
        /// </summary>
        private void RegistrarRepositorios()
        {
            var repositoryAssembly = typeof(TreinamentoRepositorio).Assembly;
            var typesRepositorio = repositoryAssembly.GetExportedTypes()
            .Where(type => type.GetInterfaces().Any(x => x == typeof(IRepositorio)) && type.IsClass && !type.IsAbstract);

            foreach (var typeRepositorio in typesRepositorio)            
                RegistrarSingleton(typeRepositorio, typeRepositorio);            
        }

        public void RegistrarValidations()
        {
            //Carregar validadores do FluentValidation
            AssemblyScanner.FindValidatorsInAssembly(typeof(TreinamentoValidacao).Assembly)
            .Where(v => v.InterfaceType.FullName != null)
            .ToList()
            .ForEach(v => RegistrarSingleton(v.InterfaceType, v.ValidatorType));

            //ValidatorOptions.LanguageManager = new CustomLanguageManager
            //{
            //    Culture = new CultureInfo("pt")
            //};
        }
    }
}
