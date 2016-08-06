using Microsoft.WindowsAzure.MobileServices;
using PackingListApp.Model;
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

            u.Travels = null;
            await userTable.UpdateAsync(u);

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
