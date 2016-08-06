using System;

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
            try
            {
                 await apiController.loginUser(username, password);
            }catch (ArgumentNullException e)
            {
                // foute login
            }
           if(apiController.loggedInUser != null)
            {
                //apiController.loggedInUser.Email="updatetest@gmail.com";
                //apiController.updateUser(apiController.loggedInUser);

                // ga naar homepagina
            }
           
         
        }

    }
}
