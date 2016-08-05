using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingListApp.Model
{
    class Travel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("destination")]
        public string Destination { get; set; }
        [JsonProperty("userId")]

        public string UserId { get; set; }
        [JsonProperty("categories")]
        public virtual ICollection<Categorie> Categories { get; set; }
        [JsonProperty("user")]
        public virtual User User { get; set; }

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