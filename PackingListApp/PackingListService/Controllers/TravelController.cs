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
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
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
            Travel current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Travel/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTravel(string id)
        {
             return DeleteAsync(id);
        }

    }
}