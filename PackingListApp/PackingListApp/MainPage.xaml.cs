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

       private string username;
        private string password;
        private MainViewModel mainViewModel;


        public MainPage()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();

       
        }

        public void Valideer_Login(object sender, RoutedEventArgs e)
        {

            //    txtUsername.Text = mainViewModel.todo.Name;

            // username = mainViewModel.todo.Name;
            username = TxtboxUsername.Text;
            password = PwBoxPasswoord.Password;
            mainViewModel.valideer(username, password);
            //valideer


        }

      
    }
}