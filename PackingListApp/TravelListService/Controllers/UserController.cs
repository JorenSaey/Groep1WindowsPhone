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
        public async Task<IQueryable<User>>GetAllUsers()
        {

            IQueryable<User> test = Query();
            //test//
            //User temp = new User("Test", "travel", "acount", "hier");
            //temp.Id = Guid.NewGuid().ToString();
            //Travel travel1 = new Travel
            //{
            //    Id = "Customtest",
            //    Name = "Belgium",
            //    Destination = "Brussels"
            //};
            //travel1.UserId = temp.Id;
            //temp.Travels = new List<Travel> { travel1 };
            //await InsertAsync(temp);
            //test

            return Query();
        }
       // [QueryableExpand("Travels")]
        public User GetUsers(string email,string password)
        {
           
            User temp = Query().Where(c => c.Email == email && c.Password == password ).FirstOrDefault();
            return temp;
        }
    
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> PostTodoItem([FromBody]User user)
        {
   
            User current = await InsertAsync(user);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }


      
        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}