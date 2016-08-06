using Newtonsoft.Json;
using System.Collections.Generic;


namespace PackingListApp.Model
{
    class Categorie
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("items")]
        public virtual ICollection<Item> Items { get; set; }
        [JsonProperty("travelId")]
        public string TravelId { get; set; }
        //CONSTRUCTOR
        public Categorie() { }
        public Categorie(string name)
        {
            Name = name;
             Items = new List<Item>();
        }

 
    }
}
