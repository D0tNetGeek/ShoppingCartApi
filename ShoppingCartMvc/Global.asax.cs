﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ShoppingCartMvc.Unity;

namespace ShoppingCartMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Initialize IoC container/Unity
            Bootstrapper.Initialise();
            //Register our custom controller factory
            ControllerBuilder.Current.SetControllerFactory(typeof(ControllerFactory));
        }
    }
}
