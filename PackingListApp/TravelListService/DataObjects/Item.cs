using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelListServiceService.DataObjects
{
    public class Item : EntityData
    {
        //ATTRIBUTEN
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("amountNeeded")]
        public int AmountNeeded { get; set; }
        [JsonProperty("amountCollected")]
        public int AmountCollected { get; set; }
        [JsonProperty("categorieId")]
        public string CategorieId { get; set; }
       // public virtual Categorie Categorie { get; set; }
        //CONSTRUCTOR
        public Item() { }
        public Item(string name, int amountNeeded)
        {
            Name = name;
            AmountNeeded = amountNeeded;
            AmountCollected = 0;
        }
        //ANDERE METHODES
        public void Add()
        {
            AmountCollected++;
        }
        public void Remove()
        {
            AmountCollected--;
        }        
        public bool IsCompleted()
        {
            return AmountCollected == AmountNeeded;
        }
    }
}