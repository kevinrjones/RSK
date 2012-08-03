using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using SignalR;
using TheatreBooking.Hubs;
using TheatreBooking.Infrastructure;
using IDependencyResolver = SignalR.IDependencyResolver;

namespace TheatreBooking
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IUnityContainer container = GetUnityContainer();
            IDependencyResolver dependencyResolver = new UnityDependencyResolver(container);

            GlobalHost.DependencyResolver = dependencyResolver;
            RouteTable.Routes.MapHubs();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private IUnityContainer GetUnityContainer()
        {
            IUnityContainer container = new UnityContainer();
            RegisterServices(container);
            return container;
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<ITestService, TestService>()
                .RegisterType<TheatreBookingHub>()
                ;
        }
    }

    public interface ITestService
    {
        void Foo();
    }

    public class TestService : ITestService
    {
        public void Foo()
        {
            
        }
    }
}