using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackingListService.DataObjects
{
    public class Categorie : EntityData
    {
        //ATTRIBUTEN
        //public Guid Id { get; set; }
        public string Name{ get; set; }
        public virtual IList<Item> Items { get; set; }
        public string TravelId { get; set; }
        //CONSTRUCTOR
        public Categorie() { }
        public Categorie(string id,string name)
        {
            Id = id;
            Name = name;
            Items = new List<Item>();
        }
        //ANDERE METHODES
        public void AddItem(string name, int amountNeeded)
        {
            Item item = new Item(Id + name, name, amountNeeded) { CategorieId = this.Id};
            Items.Add(item);
        }
        public void RemoveItem(string name)
        {
            Item item = Items.Where(i => i.Name == name).FirstOrDefault();
            if (item != null)
                Items.Remove(item);
        }
        //TODO: COMPOSITE PATTERN

    }
}