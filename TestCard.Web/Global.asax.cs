using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestCard.Web.Security;

namespace TestCard.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinderConfig.RegisterModelBinders(ModelBinders.Binders);
            AutoMapperConfiguration.Configure();
        }

        protected void Application_PostRequestHandlerExecute(object sender, EventArgs args)
        {
            //AppAuth.LogSession();
        } 

        protected void Session_OnEnd(Object sender, EventArgs e)
        {
            AppAuth.LogSessionEnd(Session);
        }
    }
}