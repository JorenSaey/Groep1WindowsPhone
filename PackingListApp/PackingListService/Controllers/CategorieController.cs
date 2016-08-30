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
    public class CategorieController : TableController<Categorie>
    {
        private MobileServiceContext context;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Categorie>(context, Request, Services);
        }

        // GET tables/Categorie
        public IQueryable<Categorie> GetAllCategorie()
        {
            return Query(); 
        }

        // GET tables/Categorie/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Categorie> GetCategorie(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Categorie/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Categorie> PatchCategorie(string id, Delta<Categorie> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Categorie
        public async Task<IHttpActionResult> PostCategorie(Categorie item)
        {
            Travel travel = context.Travels.Where(t => t.Id == item.TravelId).FirstOrDefault();
            if (travel != null)
            {
                travel.AddCategorie(item.Name);
                await context.SaveChangesAsync();
            }
            return CreatedAtRoute("Tables", new { id = item.Id }, item);
        }

        // DELETE tables/Categorie/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCategorie(string id)
        {
             return DeleteAsync(id);
        }

    }
}