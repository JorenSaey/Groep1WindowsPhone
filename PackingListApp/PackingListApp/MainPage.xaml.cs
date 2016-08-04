using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PackingListApp.Resources;

namespace PackingListApp
{
    public partial class MainPage : PhoneApplicationPage
    {

       private String username;
        private String password;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        public void Valideer_Login(object sender, RoutedEventArgs e)
        {

            username = TxtboxUsername.Text;
            password = PwBoxPasswoord.Password;
            //valideer


        }

      
    }
}