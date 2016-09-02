

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
        
        public string Percent
        {
            get
            {
                int totalCollected = 0, totalNeeded = 0;
                foreach (Categorie cat in Categories) {
                    foreach (Item item in cat.Items)
                    {
                        totalCollected += item.AmountCollected;
                        totalNeeded += item.AmountNeeded;
                    }
                }
                return (totalCollected*100) / (totalNeeded) + "%";
            }
            set
            {
            }
        }

        public string Color
        {
            get
            {
                return Percent.Equals("100%") ? "LightGreen" : "White";
            }
        }
        //CONSTRUCTOR
        public Travel() {}        
        
    }
}