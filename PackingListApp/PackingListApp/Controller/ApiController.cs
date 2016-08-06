using Microsoft.WindowsAzure.MobileServices;
using PackingListApp.Model;
using System;
using System.Collections.Generic;

namespace PackingListApp.Controller
{
    class ApiController
    {
        
       private IMobileServiceTable<User> userTable;
        private IMobileServiceClient client;

        public ApiController()
        {
            client = App.MobileService;
            userTable = client.GetTable<User>();



        }

        public async void insertUser(User user)
        {

    
     
            await userTable.InsertAsync(user);
            
        }
        public async void deleteUser(User user)
        {
            await userTable.DeleteAsync(user);
        }

        public async void loginUser(string email,string password)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("email", email);
            var user = await userTable.WithParameters(parameters).ToCollectionAsync();

        }
    }
}
