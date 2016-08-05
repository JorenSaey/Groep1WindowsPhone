using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using TravelListServiceService.DataObjects;
using TravelListServiceService.Models.DAL;

namespace TravelListServiceService.Controllers
{
    public class UserController : TableController<User>
    {
      

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            TravelListServiceContext context = new TravelListServiceContext();
            DomainManager = new EntityDomainManager<User>(context, Request);
        }
        [QueryableExpand("Travels")]
        public IQueryable<User> GetAllUsers()
        {

            IQueryable<User> test = Query();
            
            return Query();
        }
        [QueryableExpand("Travels")]
        public User GetUsers(string id)
        {
            //IQueryable<User> test = Query();
            // User temp = Query().Where(c => c.Id == id).FirstOrDefault();
            // return Query().Where(c => c.Id == id);
            User temp = Query().Where(c => c.Email == "anton@gmail.com").FirstOrDefault();
            return temp;
        }
        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}