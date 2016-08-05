using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using TravelListServiceService.DataObjects;
using TravelListServiceService.Models.DAL;

namespace TravelListServiceService.Controllers
{
    public class CategorieController : TableController<Categorie>
    {

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            TravelListServiceContext context = new TravelListServiceContext();
            DomainManager = new EntityDomainManager<Categorie>(context, Request);
        }


        // GET tables/Categorie
        [QueryableExpand("Items")]
        public IQueryable<Categorie> GetAllCategories()
        {
            return Query();
        }

        public IQueryable<Categorie> GetitemsCat(string id)
        {
            return Query().Where(c => c.TravelId == id);
        }

    }
}