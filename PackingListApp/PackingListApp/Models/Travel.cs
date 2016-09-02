

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace PackingListApp.Models
{
    public class Travel 
    {
        //ATTRIBUTEN
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        
        [JsonProperty(PropertyName = "categories")]
        public virtual IList<Categorie> Categories {get; set;}
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        //CONSTRUCTOR
        public Travel() {}        
        
    }
}