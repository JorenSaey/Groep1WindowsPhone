using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackingListService.DataObjects
{
    public class User : EntityData
    {
        //ATTRIBUTEN
        //public Guid Id { get; set; } bestaat al
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; set; }
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