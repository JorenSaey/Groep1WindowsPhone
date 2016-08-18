using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PackingListService.DataObjects
{
    public class Travel : EntityData
    {
        //ATTRIBUTEN
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public virtual IList<Categorie> Categories {get; set;}
        public string UserId { get; set; }
        //CONSTRUCTOR
        public Travel() { }
        public Travel(string id, string name, string date)
        {
            Id = id;
            Name = name;
            Date = date;
            Categories = new List<Categorie>();
        }
        //ANDERE METHODES
        public void AddCategorie(string name)
        {
            Categorie categorie = new Categorie(Id+name,name);
            Categories.Add(categorie);
        }
        public void RemoveCategorie(string name)
        {
            Categorie categorie = Categories.Where(c => c.Name == name).FirstOrDefault();
            if (categorie != null)
                Categories.Remove(categorie);
        }
        
    }
}