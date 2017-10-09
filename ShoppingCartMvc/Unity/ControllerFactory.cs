using System;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;

namespace ShoppingCartMvc.Unity
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                if (controllerType == null)
                    throw new ArgumentNullException("controllerType");

                if (!typeof(IController).IsAssignableFrom(controllerType))
                    throw new ArgumentException(string.Format(
                            "Type requested is not a controller: {0}",
                            controllerType.Name),
                        "controllerType");

                return MvcUnityContainer.Container.Resolve(controllerType) as IController;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }

    public static class MvcUnityContainer
    {
        public static UnityContainer Container { get; set; }
    }
}