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
        public Guid Id { get; set; }
        [JsonProperty("nalme")]
        public string Name { get; set; }
        [JsonProperty("amountNeeded")]
        public int AmountNeeded { get; set; }
        [JsonProperty("amountCollected")]
        public int AmountCollected { get; set; }
        [JsonProperty("categorie")]
        public virtual Categorie Categorie { get; set; }
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
