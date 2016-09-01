
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace PackingListApp.Models
{
    public class Categorie
    {
        //ATTRIBUTEN
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name{ get; set; }
        [JsonProperty(PropertyName = "items")]
        public virtual IList<Item> Items { get; set; }
        [JsonProperty(PropertyName = "travelId")]
        public string TravelId { get; set; }
        //CONSTRUCTOR
        public Categorie() { }

    }
}