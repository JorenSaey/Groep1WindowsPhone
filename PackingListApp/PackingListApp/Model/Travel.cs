using Newtonsoft.Json;
using System.Collections.Generic;


namespace PackingListApp.Model
{
    class Travel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("destination")]
        public string Destination { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("categories")]
        public virtual ICollection<Categorie> Categories { get; set; }

        //CONSTRUCTOR
        public Travel() { }
        public Travel(string name, string destination)
        {
            Name = name;
            Destination = destination;
             Categories = new List<Categorie>();
        }
    }
}