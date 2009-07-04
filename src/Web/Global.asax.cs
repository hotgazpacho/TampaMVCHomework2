using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Homework2.Models;

using MvcContrib.Unity;
using Microsoft.Practices.Unity;
using Homework2.Controllers;

namespace Homework2
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication, IUnityContainerAccessor
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            InitializeContainer();
            RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders[typeof (Customer)] = new EntityModelBinder();
        }

        private static UnityContainer _container;

        #region IUnityContainerAccessor Members

        public IUnityContainer Container
        {
            get { return _container; }
        }

        #endregion

        /// <summary>
        /// Instantiate the container and add all Controllers that derive from 
        /// UnityController to the container.  Also associate the Controller 
        /// with the UnityContainer ControllerFactory.
        /// </summary>
        protected virtual void InitializeContainer()
        {
            if (_container == null)
            {
                _container = new UnityContainer();
                _container.RegisterType(typeof(IRepository<Customer>), typeof(CustomerActiveRecordRepository));
                ControllerBuilder.Current.SetControllerFactory(typeof(MvcContrib.Unity.UnityControllerFactory));

                //Type[] assemblyTypes = typeof(CustomersController).Assembly.GetTypes();
                //foreach (Type type in assemblyTypes)
                //{
                //    if (typeof(IController).IsAssignableFrom(type))
                //    {
                //        _container.RegisterType(type, type);
                //    }
                //}
            }
        }
    }
}