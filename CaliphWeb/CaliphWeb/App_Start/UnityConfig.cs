using BeyondCode.Core.Helper;
using BeyondCode.Helper;
using BeyondCode.Services;
using BeyondCode.Services.Helper;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BeyondCode
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IRestHelper, HttpClientHelper>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IMasterDataService, MasterDataService>();
            container.RegisterType<ICaliphAPIHelper, CaliphAPIHelper>();
            container.RegisterType<IOne2OneApiHelper, One2OneApiHelper>();
        }
    }
}