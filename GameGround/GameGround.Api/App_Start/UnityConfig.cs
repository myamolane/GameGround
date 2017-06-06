using GameGround.Infrastructure;
using Microsoft.Practices.Unity;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System.Web.Http;
using Unity.WebApi;
using GameGround.Core;
using Utility;

namespace GameGround.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();



            var provider = LocalizedExceptionBase.LocalizedProvider = new LocalizedProvider();

            container
                .RegisterInstance(provider)
                .RegisterType<IDataContextAsync, GGContext>()
                .RegisterType<IUnitOfWorkAsync, UnitOfWork>()
                .RegisterType(typeof(IRepositoryAsync<>), typeof(Repository<>))
                .RegisterType<IPlayerService,PlayerService>()
                .RegisterType< IGameService,GameService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public static T GetService<T>()
            where T : class
        {
            var service = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(T));
            if (service is T) return service as T;
            return default(T);
        }
    }
}