using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelListServiceService.DataObjects
{
    public class Travel : EntityData
    {
        //ATTRIBUTEN
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public virtual ICollection<Categorie> Categories {get; set;}

        public virtual User User { get; set; }
        //CONSTRUCTOR
        public Travel() { }
        public Travel(string name, string destination)
        {
            Name = name;
            Destination = destination;
           // Categories = new List<Categorie>();
        }
        //ANDERE METHODES
        //public void AddCategorie(string name)
        //{
        //    Categorie categorie = new Categorie(name);
        //    Categories.Add(categorie);
        //}
        //public void RemoveCategorie(string name)
        //{
        //    Categorie categorie = Categories.Where(c => c.Name == name).FirstOrDefault();
        //    if (categorie != null)
        //        Categories.Remove(categorie);
        //}
        
    }
}