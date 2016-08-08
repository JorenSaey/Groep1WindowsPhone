using System;

using PackingListApp.Controller;
using PackingListApp.Model;

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
            try
            {
                 await apiController.loginUser(username, password);
            }catch (ArgumentNullException e)
            {
                // foute login
            }
           if(apiController.loggedInUser != null)
            {

                User t = apiController.loggedInUser;
                t.Email = "anton.rooseleer@gmail.com";
                apiController.updateUser(t);
                // ga naar homepagina
            }
           
         
        }

    }
}
