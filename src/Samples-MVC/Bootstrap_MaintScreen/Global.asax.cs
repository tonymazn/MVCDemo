using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net.Config;
using Repository;

namespace DemoProduct
{
    public class MvcApplication : System.Web.HttpApplication
    {

//        protected SessionHelper _sessionHelper = null;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            XmlConfigurator.Configure();
        }

//        protected void Application_BeginRequest(object sender, EventArgs e)
//        {
//            _sessionHelper = new SessionHelper();
//            _sessionHelper.OpenSession();
//        }
//
//        protected void Application_EndRequest(object sender, EventArgs e)
//        {
//            _sessionHelper = new SessionHelper();
//            _sessionHelper.CloseSession();
//        }
    }
}
