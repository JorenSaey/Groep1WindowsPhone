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
                Travel test = new Travel("wtf", "gelukt?");
                test.UserId = t.Id;
                test.Id = Guid.NewGuid().ToString();
              foreach(Travel tr in t.Travels)
                {
                    tr.Name = "Changed";
                }
                //  t.Travels.Add(test);
                apiController.updateUser(t);

                // ga naar homepagina
            }
           
         
        }

    }
}
