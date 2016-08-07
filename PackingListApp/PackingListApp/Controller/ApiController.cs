using Microsoft.WindowsAzure.MobileServices;
using PackingListApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PackingListApp.Controller
{
    class ApiController
    {
        
       private IMobileServiceTable<User> userTable;
        private IMobileServiceClient client;
        public User loggedInUser;

        public ApiController()
        {
            client = App.MobileService;
            userTable = client.GetTable<User>();

        }

        public async void updateUser(User u)
        {

           // u.Travels = null;
           foreach(Travel tr in u.Travels)
            {
                tr.Id = Guid.NewGuid().ToString();
                foreach(Categorie c in tr.Categories)
                {
                    c.TravelId = tr.Id;
                    c.Id = Guid.NewGuid().ToString(); 
                    foreach(Item i in c.Items)
                    {
                        i.CategorieId = c.Id;
                        i.Id = Guid.NewGuid().ToString();
                    }
                }
            }
            await userTable.DeleteAsync(loggedInUser);
            await userTable.InsertAsync(u);
            await userTable.RefreshAsync(u);
            loggedInUser = u;

        }
        public async void insertUser(User user)
        {
           
            await userTable.InsertAsync(user);
           
            
        }
        public async void deleteUser(User user)
        {
            await userTable.DeleteAsync(user);
        }

        public async System.Threading.Tasks.Task<User> loginUser(string email, string password)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("email", email);
            parameters.Add("password", password);
           IEnumerable<User> user = await userTable.WithParameters(parameters).ToEnumerableAsync();
            loggedInUser = user.FirstOrDefault();
            return loggedInUser ;



        }
    }
}
