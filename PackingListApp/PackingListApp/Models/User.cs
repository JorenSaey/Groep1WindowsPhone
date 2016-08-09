

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace PackingListApp.Models
{
    public class User 
    {
        //ATTRIBUTEN
        public string Id { get; set; }
        [JsonProperty(PropertyName="email")]
        public string Email { get; private set; }
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; private set; }
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; private set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "travels")]
        public virtual IList<Travel> Travels { get; private set; }
        //CONSTRUCTOR
        public User() { }
        public User(string id,string email, string firstname, string lastname,string password)
        {
            Id = id;
            Email = email;
            FirstName = firstname;
            LastName = lastname;
            Password = password;
            Travels = new List<Travel>();
        }
        //ANDERE METHODES
        public void AddTravel(string name, string destination)
        {
            Travel travel = new Travel(name, destination);
            Travels.Add(travel);
        }
        public void RemoveTravel(string name)
        {
            Travel travel = Travels.Where(t => t.Name == name).FirstOrDefault();
            if (travel != null)
                Travels.Remove(travel);
        }
        
    }
}