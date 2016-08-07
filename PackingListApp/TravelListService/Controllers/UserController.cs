using Microsoft.Azure.Mobile.Server;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
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

        public Task<User> PatchUser(string id, Delta<User> patch)
        {
            return UpdateAsync(id, patch);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}