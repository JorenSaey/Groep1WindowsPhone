

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace PackingListApp.Models
{
    public class User 
    {
        //ATTRIBUTEN
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName="email")]
        public string Email { get; private set; }
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; private set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; private set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "travels")]
        public virtual IList<Travel> Travels { get; private set; }
        //CONSTRUCTOR
        public User() {}   
        
        
    }
}