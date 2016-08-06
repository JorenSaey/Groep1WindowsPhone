using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelListServiceService.DataObjects
{
    public class Categorie : EntityData
    {
        //ATTRIBUTEN
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name{ get; set; }
        [JsonProperty("travelId")]
        public string TravelId { get; set; }
        // public virtual Travel Travel { get; set; }
        [JsonProperty("items")]
        public virtual ICollection<Item> Items { get;  set; }
        //CONSTRUCTOR
        public Categorie() { }
        public Categorie(string name)
        {
            Name = name;
          //  Items = new List<Item>();
        }
        ////ANDERE METHODES
        //public void AddItem(string name, int amountNeeded)
        //{
        //    Item item = new Item(name, amountNeeded);
        //    Items.Add(item);
        //}
        //public void RemoveItem(string name)
        //{
        //    Item item = Items.Where(i => i.Name == name).FirstOrDefault();
        //    if (item != null)
        //        Items.Remove(item);
        //}
        ////TODO: COMPOSITE PATTERN

    }
}