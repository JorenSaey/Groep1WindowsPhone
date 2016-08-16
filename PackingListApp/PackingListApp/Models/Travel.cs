

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace PackingListApp.Models
{
    public class Travel 
    {
        //ATTRIBUTEN
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "destination")]
        public string Destination { get; set; }
        [JsonProperty(PropertyName = "categories")]
        public virtual IList<Categorie> Categories {get; private set;}
        //CONSTRUCTOR
        public Travel() { }
        public Travel(string name, string destination)
        {
            Name = name;
            Destination = destination;
            Categories = new List<Categorie>();
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