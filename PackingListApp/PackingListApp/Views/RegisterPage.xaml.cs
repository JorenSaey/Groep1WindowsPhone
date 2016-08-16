using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PackingListApp.Models;

namespace PackingListApp.Views
{
    public partial class RegisterPage : PhoneApplicationPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        //private async void Registreer(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        BtnLogin.IsEnabled = false;
        //        if (PwBoxPassword.Password == PwBoxConfirmPassword.Password)
        //        {
        //            bool valid = await AccountValidator.ValidateSignIn(TxtboxUsername.Text, PwBoxPassword.Password);
        //            if (valid)
        //            {
        //                TxtError.Text = "";
        //                NavigationService.Navigate(new Uri("/Views/TravelPage.xaml", UriKind.Relative));
        //            }
        //            else
        //                TxtError.Text = "Aanmeldgegevens incorrect";
        //        }
        //        else
        //        {
        //            TxtError.Text = "Wachtwoorden komen niet overeen";
        //        }
                
        //    }
        //    catch (MobileServiceInvalidOperationException ex)
        //    {
        //        TxtError.Text = "Kan geen verbinding maken met de service. Controleer uw internetverbinding of probeer later opnieuw.";
        //    }
        //    finally
        //    {
        //        BtnLogin.IsEnabled = true;
        //    }

        //}
    }
}