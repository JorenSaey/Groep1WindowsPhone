using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Controls.Primitives;
using PackingListApp.Models;
using Microsoft.WindowsAzure.MobileServices;

namespace PackingListApp.Views.PopUps
{
    public partial class TravelPopup : PhoneApplicationPage
    {
        private UserRepository userRepo;
        private User activeUser;
        public TravelPopup(UserRepository userRepo, User user)
        {
            InitializeComponent();
            this.userRepo = userRepo;
            this.activeUser = user;
        }
        private async void Ok_Click(object sender, RoutedEventArgs e)
        {            
             activeUser.AddTravel(TxtName.Text, txtDate.Text);
             await userRepo.Update(activeUser);
             ClosePopup();            
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ClosePopup();
        }
        private void ClosePopup()
        {
            Popup popup = this.Parent as Popup;
            popup.IsOpen = false;
        }
    }
}