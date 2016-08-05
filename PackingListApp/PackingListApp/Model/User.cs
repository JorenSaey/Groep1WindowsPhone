using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingListApp.Model
{
    class User
    {

        public string Email { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
     //   public virtual IList<Travel> Travels { get; set; }
        //CONSTRUCTOR
        public User() { }
        public User(string email, string firstname, string lastname, string password)
        {
            Email = email;
            FirstName = firstname;
            LastName = lastname;
            Password = password;
          //  Travels = new List<Travel>();
        }
    }
}
