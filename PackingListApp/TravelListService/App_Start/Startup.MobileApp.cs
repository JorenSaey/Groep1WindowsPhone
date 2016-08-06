using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using TravelListServiceService.DataObjects;
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
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

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



            Categorie categorie1 = new Categorie { Id = Guid.NewGuid().ToString(), Name = "Documenten" };
            categorie1.Items = new List<Item>{ new Item { Id = Guid.NewGuid().ToString(), Name = "Ticket", AmountCollected = 1, AmountNeeded = 2 }
        };
            Categorie categorie2 = new Categorie { Id = Guid.NewGuid().ToString(), Name = "Eten" };
            categorie2.Items = new List<Item>{ new Item { Id = Guid.NewGuid().ToString(), Name = "Appels", AmountCollected = 1, AmountNeeded = 2 }
        };


            User user1 = new User { Id = Guid.NewGuid().ToString(), Email = "testAccount@gmail.com", FirstName = "test", LastName = "acc", Password = "pw" };

            Travel travel1 = new Travel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Belgium",
                Destination = "Brussels"
            };

            travel1.Categories = new List<Categorie> { categorie1, categorie2 };
            user1.Travels = new List<Travel> { travel1 };



            Categorie categorie3 = new Categorie { Id = Guid.NewGuid().ToString(), Name = "Kleren" };
            categorie3.Items = new List<Item>{ new Item { Id = Guid.NewGuid().ToString(), Name = "Jas", AmountCollected = 1, AmountNeeded = 2 }
        };
            Categorie categorie4 = new Categorie { Id = Guid.NewGuid().ToString(), Name = "Medicatie" };
            categorie4.Items = new List<Item>{ new Item { Id = Guid.NewGuid().ToString(), Name = "Zonnecreme", AmountCollected = 1, AmountNeeded = 2 }
        };


            User user2 = new User { Id = Guid.NewGuid().ToString(), Email = "anton@gmail.com", FirstName = "anton", LastName = "rooseleer", Password = "pw" };

            Travel travel2 = new Travel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Brazillie",
                Destination = "Rio"
            };

            travel2.Categories = new List<Categorie> { categorie3, categorie4 };
            user2.Travels = new List<Travel> { travel2 };

         



            context.Users.Add(user1);
            context.Users.Add(user2);
            context.SaveChanges();
      

            base.Seed(context);
        }
    }
}

