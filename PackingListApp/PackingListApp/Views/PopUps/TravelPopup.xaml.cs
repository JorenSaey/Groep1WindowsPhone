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
        private TravelRepository travelRepo;
        private User activeUser;
        public TravelPopup(User activeUser)
        {
            InitializeComponent();
            this.activeUser = activeUser;
            this.travelRepo = new TravelRepository();
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                travelRepo.CreateTravel(TxtName.Text, txtDate.Text, activeUser.Id);
            }
            catch(MobileServiceInvalidOperationException ex)
            {
                
            }
            finally
            {
                ClosePopup();
            }
                         
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