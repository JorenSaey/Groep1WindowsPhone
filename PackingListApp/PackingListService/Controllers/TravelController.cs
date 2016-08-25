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
    public class TravelController : TableController<Travel>
    {
        private MobileServiceContext context;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Travel>(context, Request, Services);
        }

        // GET tables/Travel
        public IQueryable<Travel> GetAllTravel()
        {
            return Query(); 
        }

        // GET tables/Travel/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Travel> GetTravel(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Travel/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Travel> PatchTravel(string id, Delta<Travel> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Travel
        public async Task<IHttpActionResult> PostTravel(Travel item)
        {
            User user = context.Users.Where(u => u.Id == item.UserId).FirstOrDefault();
            if (user != null)
            {
                user.AddTravel(item.Name,item.Date);
                await context.SaveChangesAsync();
            }
            return CreatedAtRoute("Tables", new { id = item.Id }, item);
        }
        
        public Task DeleteTravel(string id)
        {
             return DeleteAsync(id);
        }

    }
}