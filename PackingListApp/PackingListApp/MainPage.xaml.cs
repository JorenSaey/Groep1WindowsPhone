
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

        public MainPage()
        {
            InitializeComponent();           
        }
        
        private async void MeldAan(object sender, RoutedEventArgs e)
        {
            try {
                bool valid = await AccountValidator.ValidateSignIn(TxtEmail.Text, PswPassword.Password);
                if (valid)
                    NavigationService.Navigate(new Uri("/Views/TravelPage.xaml", UriKind.Relative));
                else
                    TxtError.Text = "Aanmeldgegevens incorrect";
            }
            catch(MobileServiceInvalidOperationException ex)
            {
                TxtError.Text = "Kan geen verbinding maken met de service";
            }           
            
        }
    }
}