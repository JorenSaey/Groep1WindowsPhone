using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using PackingListService.DataObjects;
using PackingListService.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Linq;

namespace PackingListService
{
    public class QueryableExpandAttribute : ActionFilterAttribute
    {
        private const string ODataExpandOption = "$expand=";

        public QueryableExpandAttribute(string expand)
        {
            this.AlwaysExpand = expand;
        }

        public string AlwaysExpand { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            HttpRequestMessage request = actionContext.Request;
            string query = request.RequestUri.Query.Substring(1);
            var parts = query.Split('&').ToList();
            bool foundExpand = false;
            for (int i = 0; i < parts.Count; i++)
            {
                string segment = parts[i];
                if (segment.StartsWith(ODataExpandOption, StringComparison.Ordinal))
                {
                    foundExpand = true;
                    parts[i] += "," + this.AlwaysExpand;
                    break;
                }
            }

            if (!foundExpand)
            {
                parts.Add(ODataExpandOption + this.AlwaysExpand);
            }

            UriBuilder modifiedRequestUri = new UriBuilder(request.RequestUri);
            modifiedRequestUri.Query = string.Join("&",
                                        parts.Where(p => p.Length > 0));
            request.RequestUri = modifiedRequestUri.Uri;
            base.OnActionExecuting(actionContext);
        }
    }
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Database.SetInitializer(new MobileServiceInitializer());
        }
    }
    public class MobileServiceInitializer : DropCreateDatabaseAlways<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            try {
                User test = new User("a","ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb");
                test.AddTravel("Survivalweekend", "Zomer 2016");
                test.AddTravel("Businesstrip Marseille", "31 September 2016");
                User joren = new User("joren.saey@gmail.com", "dc00c903852bb19eb250aeba05e534a6d211629d77d055033806b783bae09937");
                joren.AddTravel("Survivalweekend", "Zomer 2016");
                joren.AddTravel("Businesstrip Marseille", "31 September 2016");
                context.Users.Add(joren);
                context.Users.Add(test);
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine(validationError.PropertyName + "\n\n" + validationError.ErrorMessage + "\n\n\n");
                    }
                }
            }
        }
    }    
}

