using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace LMSGroup2.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterRoutes()
        {
            RouteTable.Routes.Add("UserDetails", new Route("Users/{mode}/{Id}", new PageRouteHandler("~/Users/UserDetails.aspx")));
            RouteTable.Routes.Add("LeaveDetails", new Route("LeaveApplications/{mode}/{Id}", new PageRouteHandler("~/LeaveApplications/LeaveDetails.aspx")));

        }
    }
}