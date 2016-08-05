using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingListApp.Model
{
    class User
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("travels")]
        public virtual ICollection<Travel> Travels { get; set; }
        //CONSTRUCTOR
        public User() { }
        public User(string email, string firstname, string lastname, string password)
        {
            Email = email;
            FirstName = firstname;
            LastName = lastname;
            Password = password;
              Travels = new List<Travel>();
        }
    }
}
