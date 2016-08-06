using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingListApp.Model;
using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;
using PackingListApp.Controller;

namespace PackingListApp.ViewModels
{
    class MainViewModel
    {
        ApiController apiController;


        public MainViewModel()
        {
            apiController = new ApiController();
        }

        public async void valideer(string username,string password)
        {
            await apiController.loginUser(username, password);
            String test = "test";
        }

    }
}
