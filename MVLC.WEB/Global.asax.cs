using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MVLC.WEB.App_Start;
using System.Web.Configuration;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace MVLC.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private string GetEnvironmentType(string ConnStringName)
        {
            string EnvironmentType = "DEV";

            if (ConnStringName.Contains("Prod"))
            {
                EnvironmentType = "Production";
            }
            else if (ConnStringName.Contains("UAT"))
            {
                EnvironmentType = "UAT";
            }
            return EnvironmentType;
        }

        private void SetEnvironmentInfo()
        {
            string ConnStringName = WebConfigurationManager.AppSettings["ConnectionStringName"];
            string EFConnectionString = ConfigurationManager.ConnectionStrings[ConnStringName].ConnectionString;

            EntityConnectionStringBuilder efBuilder = new EntityConnectionStringBuilder(EFConnectionString);
            string ConnectionString = efBuilder.ProviderConnectionString;

            SqlConnectionStringBuilder strBuilder = new SqlConnectionStringBuilder(ConnectionString);

            string EnvironmentType = GetEnvironmentType(ConnStringName);
            string DataSource = strBuilder.DataSource;
            string DB = strBuilder.InitialCatalog;

            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["EnvironmentType"] = EnvironmentType;
            System.Web.HttpContext.Current.Application["DataSource"] = DataSource;
            System.Web.HttpContext.Current.Application["DB"] = DB;
            System.Web.HttpContext.Current.Application.UnLock();

        }

        protected void Application_Start()
        {


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new AltRazorEngine());

            SetEnvironmentInfo();


        }
    }
}
