using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.WindowsAzure.Mobile.Service;
using PackingListService.DataObjects;
using PackingListService.Models;
using System.Web.Http.OData;
using System.Collections.Generic;
using AutoMapper;

namespace PackingListService.Controllers
{
    public class UserController : TableController<User>
    {
        private MobileServiceContext context;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<User>(context, Request, Services);
        }
        // GET tables/User        
        public IQueryable<User> GetAllUser()
        {
            return Query(); 
        }
        // GET tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        [EnableQuery(MaxExpansionDepth = 3)]
        [QueryableExpand("Travels/Categories/Items")]
        public SingleResult<User> GetUser(string id)
        {
            return Lookup(id);
        }
        public Task<User> PatchUser(string id, Delta<User> patch)
        {
            return UpdateAsync(id, patch);
        }
        public async Task<IHttpActionResult> PostUser(User item)
        {
            context.Users.Add(new User(item.Email, item.Password));
            await context.SaveChangesAsync();

            return CreatedAtRoute("Tables", new { id = item.Id }, item);
        }
        public Task DeleteUser(string id)
        {
             return DeleteAsync(id);
        }

    }
}