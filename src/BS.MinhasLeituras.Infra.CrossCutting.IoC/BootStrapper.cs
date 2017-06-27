using BS.MinhasLeituras.Domain.Interfaces.Repository;
using BS.MinhasLeituras.Domain.Interfaces.Services;
using BS.MinhasLeituras.Domain.Services;
using BS.MinhasLeituras.Infra.Data.Context;
using BS.MinhasLeituras.Infra.Data.Interfaces;
using BS.MinhasLeituras.Infra.Data.Repository;
using BS.MinhasLeituras.Infra.Data.UoW;
using BS.MinhasLeituras.Application;
using BS.MinhasLeituras.Application.Interfaces;
using SimpleInjector;

namespace BS.MInhasLeituras.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        //Container classe principal do simple Injector
        public static void RegisterServices(Container container)
        {

            //Registrando as dependências, referencia aonde esta injetando com interface
            //APP
            container.Register<ILeituraAppService, LeituraAppService>(Lifestyle.Scoped);

            //Domain
            container.Register<ILeituraService, LeituraService>(Lifestyle.Scoped);

            //Infra
            container.Register<ILeituraRepository, LeituraRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfwork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<MinhasLeiturasContext>(Lifestyle.Scoped);
            //container.Register(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
