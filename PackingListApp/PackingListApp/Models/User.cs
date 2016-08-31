

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
        public string Email { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "travels")]
        public virtual IList<Travel> Travels { get; set; }
        //CONSTRUCTOR
        public User() {}   
        
        
    }
}