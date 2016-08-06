using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace TravelListServiceService.DataObjects
{
    public class Travel : EntityData
    {
        //ATTRIBUTEN
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("destination")]
        public string Destination { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("categories")]
        public virtual ICollection<Categorie> Categories {get; set;}

        //CONSTRUCTOR
        public Travel() { }
        public Travel(string name, string destination)
        {
            Name = name;
            Destination = destination;
        }
        //ANDERE METHODES
        public void AddCategorie(string name)
        {
            Categorie categorie = new Categorie(name);
            Categories.Add(categorie);
        }
        public void RemoveCategorie(string name)
        {
            Categorie categorie = Categories.Where(c => c.Name == name).FirstOrDefault();
            if (categorie != null)
                Categories.Remove(categorie);
        }

    }
}