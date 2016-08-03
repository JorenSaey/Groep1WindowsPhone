using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TravelListServiceService.DataObjects;
using TravelListServiceService.Models.DAL;

namespace TravelListService.Models.DAL
{
    public class TravelListServiceInitializer : DropCreateDatabaseAlways<TravelListServiceContext>
    {
        protected override void Seed(TravelListServiceContext context)
        {
            User user = new User("joren.saey@gmail.com", "Joren", "Saey", "273c31a4d8c496ddd240c2f374c8b3a01e2fd4b2debf18e807031e43272a5afe");
            user.AddTravel("Citytrip Barcelona", "Barcelona");            
            user.Travels[0].AddCategorie("Kleding");
            user.Travels[0].Categories[0].AddItem("Jeans", 3);
            user.Travels[0].Categories[0].AddItem("Hoed", 2);

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}