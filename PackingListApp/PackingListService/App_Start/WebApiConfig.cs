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

namespace PackingListService
{
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
                context.Users.Add(new User("joren.saey@gmail.com", "joren", "saey", "dc00c903852bb19eb250aeba05e534a6d211629d77d055033806b783bae09937"));
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

    //public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    //{
    //    protected override void Seed(MobileServiceContext context)
    //    {
    //        List<TodoItem> todoItems = new List<TodoItem>
    //        {
    //            new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
    //            new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
    //        };

    //        foreach (TodoItem todoItem in todoItems)
    //        {
    //            context.Set<TodoItem>().Add(todoItem);
    //        }

    //        base.Seed(context);
    //    }
    //}
}

