using System.Web.Mvc;
using Domain.Core.ExternalModules.Concrete;
using Domain.Core.ExternalModules.Contracts;
using Domain.Core.Repository;
using Domain.Core.Services.Concrete;
using Domain.Core.Services.Contracts;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using NLog;
using ShoppingCartMvc.Controllers;
using BusinessLogicDbContext = Domain.Core.Repository.BusinessLogicDbContext;

namespace ShoppingCartMvc.Unity
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<ISmtpSender, DefaultSmtpSender>();
            container.RegisterType<ICourierSender, DefaultCourierSender>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IShoppingCartService, ShoppingCartService>();
            container.RegisterType<IBusinessLogicRepository, EntityFrameworkRepository<BusinessLogicDbContext>>();
            container.RegisterType<AccountController>(new InjectionConstructor(new ResolvedParameter<ICustomerService>(), new ResolvedParameter<IShoppingCartService>()));
            MvcUnityContainer.Container = container;
            return container;
        }
    }
}