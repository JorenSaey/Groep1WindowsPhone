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
    public class UserController : TableController<User>
    {
      

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            TravelListServiceContext context = new TravelListServiceContext();
            DomainManager = new EntityDomainManager<User>(context, Request);
        }
        public IQueryable<User> GetAllTodoItems()
        {
           
            
            return Query();
        }
    }
}