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

    public class TravelListServiceInitializer : DropCreateDatabaseAlways<TravelListServiceContext>
    {
        protected override void Seed(TravelListServiceContext context)
        {



            User user1 = new User { Id = Guid.NewGuid().ToString(), Email = "anton.rooseleer@gmail.com", FirstName = "anton", LastName = "rooseleer", Password = "pw" };
            User user2 = new User { Id = Guid.NewGuid().ToString(), Email = "test@gmail.com", FirstName = "test", LastName = "account", Password = "pw" };



            Travel travel1 = new Travel { Id = Guid.NewGuid().ToString(), Name = "Belgium", Destination = "Brussels" };
            Travel travel2 = new Travel { Id = Guid.NewGuid().ToString(), Name = "UK", Destination = "London" };





            Categorie categorie1 = new Categorie { Id = Guid.NewGuid().ToString(), Name = "Documenten" };

            Categorie categorie2 = new Categorie { Id = Guid.NewGuid().ToString(), Name = "Kleren" };

            Item item1 =
                new Item { Id = Guid.NewGuid().ToString(), Name = "First item", AmountCollected = 1, AmountNeeded = 2 };

            Item item2 = new Item { Id = Guid.NewGuid().ToString(), Name = "First item", AmountCollected = 1, AmountNeeded = 2 };

            categorie1.Items.Add(item1);
            categorie2.Items.Add(item2);
            travel1.Categories.Add(categorie1);
            travel2.Categories.Add(categorie2);
            user1.Travels.Add(travel1);
            user2.Travels.Add(travel2);
            List<User> users = new List<User>
            {

            };
            users.Add(user1);
            users.Add(user2);
                


            List<Item> todoItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Name = "Anton", AmountCollected = 1,AmountNeeded=2 },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Second item", AmountCollected = 2, AmountNeeded =3 },
            };

            for (int i = 0; i < 2; i++)
        

            foreach (Item todoItem in todoItems)
            {
                context.Set<Item>().Add(todoItem);
            }

            foreach(User u in users)
            {
                context.Set<User>().Add(u);
            }
           
            base.Seed(context);
        }
    }
}

