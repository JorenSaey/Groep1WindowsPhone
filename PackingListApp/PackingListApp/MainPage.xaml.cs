using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PackingListApp.ViewModels;
using PackingListApp.Model;

namespace PackingListApp
{
    public partial class MainPage : PhoneApplicationPage
    {

       private String username;
        private String password;
        private MainViewModel mainViewModel;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();

            mainViewModel.getAzureData();
            mainViewModel.getUserData();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        public void Valideer_Login(object sender, RoutedEventArgs e)
        {

            mainViewModel.loadData();
            txtUsername.Text = mainViewModel.todo.Name;
            User user = mainViewModel.single;
           // username = mainViewModel.todo.Name;
            password = PwBoxPasswoord.Password;
            //valideer


        }

      
    }
}