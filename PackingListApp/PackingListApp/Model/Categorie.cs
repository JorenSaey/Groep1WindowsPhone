using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingListApp.Model
{
    class Categorie
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("travel")]
        public virtual Travel Travel { get; set; }
        [JsonProperty("item")]
        public virtual ICollection<Item> Items { get; set; }
        //CONSTRUCTOR
        public Categorie() { }
        public Categorie(string name)
        {
            Name = name;
             Items = new List<Item>();
        }
    }
}
