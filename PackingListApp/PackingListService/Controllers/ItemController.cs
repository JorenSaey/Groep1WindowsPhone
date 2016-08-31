using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using PackingListService.DataObjects;
using PackingListService.Models;

namespace PackingListService.Controllers
{
    public class ItemController : TableController<Item>
    {
        private MobileServiceContext context;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Item>(context, Request, Services);
        }

        // GET tables/Item
        public IQueryable<Item> GetAllItem()
        {
            return Query(); 
        }

        // GET tables/Item/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Item> GetItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Item/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Item> PatchItem(string id, Delta<Item> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Item
        public async Task<IHttpActionResult> PostItem(Item item)
        {
            Categorie categorie = context.Categories.Where(c => c.Id == item.CategorieId).FirstOrDefault();
            if (categorie != null)
            {
                categorie.AddItem(item.Name,item.AmountNeeded);
                await context.SaveChangesAsync();
            }
            return CreatedAtRoute("Tables", new { id = item.Id }, item);
        }

        // DELETE tables/Item/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteItem(string id)
        {
             return DeleteAsync(id);
        }

    }
}