using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

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
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            //container
            //  .RegisteType()

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