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
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public virtual IList<Travel> Travels { get; set; }
        //CONSTRUCTOR
        public User() { }
        public User(string email, string firstname, string lastname,string password)
        {
            Id = email;
            Email = email;
            FirstName = firstname;
            LastName = lastname;
            Password = password;
            Travels = new List<Travel>();
        }
        //ANDERE METHODES
        public void AddTravel(string name,string date)
        {
            Travel travel = new Travel(Id+name,name,date);
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