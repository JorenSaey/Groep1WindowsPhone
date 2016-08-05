using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using TravelListServiceService.DataObjects;
using TravelListServiceService.Models;
using TravelListServiceService.Models.DAL;

namespace TravelListServiceService.Controllers
{
    public class TodoItemController : TableController<Item>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            TravelListServiceContext context = new TravelListServiceContext();
            DomainManager = new EntityDomainManager<Item>(context, Request);
        }

        // GET tables/TodoItem
       // [Queryable("Items")]
        public IQueryable<Item> GetAllTodoItems()
        {
            IQueryable<Item> test = Query();
            return test;
        }

     

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Item> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Item> PatchTodoItem(string id, Delta<Item> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostTodoItem(Item item)
        {
            Item current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}