using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingListApp.Model
{

    class Item
    {
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
        
        //CONSTRUCTOR
        public Item() { }
        public Item(string name, int amountNeeded)
        {
            Name = name;
            AmountNeeded = amountNeeded;
            AmountCollected = 0;
        }
    }
}