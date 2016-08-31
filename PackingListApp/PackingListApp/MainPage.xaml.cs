
using System.Windows;
using Microsoft.Phone.Controls;
using System;
using Microsoft.WindowsAzure.MobileServices;
using PackingListApp.Models;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PackingListApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        private UserRepository userRepo;

        public MainPage()
        {
            InitializeComponent();
            userRepo = new UserRepository();
            TxtEmail.Text = "a";
            PswPassword.Password = "a";         
        }
        
        private async void MeldAan(object sender, RoutedEventArgs e)
        {
            try {
                BtnLogin.IsEnabled = false;
                //returnt null als de aameldgegevens incorrect zijn
                User user = await userRepo.ValidateSignIn(TxtEmail.Text, PswPassword.Password);
                if (user != null)
                {
                    TxtError.Text = "";
                    NavigationService.Navigate(new Uri("/Views/TravelPage.xaml?email="+user.Email, UriKind.Relative));
                }
                else
                    TxtError.Text = "Aanmeldgegevens incorrect";
            }
            catch (ArgumentException ex)
            {
                TxtError.Text = ex.Message;
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                TxtError.Text = "Kan geen verbinding maken met de service";
            }     
            finally
            {
                BtnLogin.IsEnabled = true;
            }      
            
        }
    }
}