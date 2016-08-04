using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using TravelListServiceService.DataObjects;
using TravelListServiceService.Models;
using Owin;
using TravelListServiceService.Models.DAL;

namespace TravelListServiceService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new TravelListServiceInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<TravelListServiceContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class TravelListServiceInitializer : CreateDatabaseIfNotExists<TravelListServiceContext>
    {
        protected override void Seed(TravelListServiceContext context)
        {
            List<Item> todoItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Name = "First item", AmountCollected = 1,AmountNeeded=2 },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Second item", AmountCollected = 2, AmountNeeded =3 },
            };

            foreach (Item todoItem in todoItems)
            {
                context.Set<Item>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

