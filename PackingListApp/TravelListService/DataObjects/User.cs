using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace TravelListServiceService.DataObjects
{
    public class User : EntityData
    {
       
        //[JsonProperty("id")]
        //public string Id { get; set; }
        [JsonProperty("email")]
        public string Email { get;  set; }
        [JsonProperty("firstName")]
        public string FirstName { get;  set; }
        [JsonProperty("lastName")]
        public string LastName { get;  set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("travels")]
        public virtual ICollection<Travel> Travels { get; set; }
        //CONSTRUCTOR
        public User() { }
        public User(string email, string firstname, string lastname,string password)
        {
            Email = email;
            FirstName = firstname;
            LastName = lastname;
            Password = password;
        }
       
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