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

        private void Registreer(object sender, RoutedEventArgs e)
        {
            try
            {
                BtnLogin.IsEnabled = false;
                new UserRepository().Register(TxtboxUsername.Text, PwBoxPassword.Password, PwBoxConfirmPassword.Password);
                TxtError.Text = "";
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            catch (ArgumentException ex)
            {
                TxtError.Text = ex.Message;
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                TxtError.Text = "Kan geen verbinding maken met de service. Controleer uw internetverbinding of probeer later opnieuw.";
            }
            finally
            {
                BtnLogin.IsEnabled = true;
            }

        }
    }
}