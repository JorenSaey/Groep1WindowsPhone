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
using System.Collections.ObjectModel;

namespace PackingListApp.Views.PopUps
{
    public partial class TravelPopup : PhoneApplicationPage
    {
        private ObservableCollection<Travel> travels;
        private TravelRepository travelRepo;
        private User activeUser;
        public TravelPopup(User activeUser, ObservableCollection<Travel> travels)
        {
            InitializeComponent();
            this.activeUser = activeUser;
            this.travelRepo = new TravelRepository();
            this.travels = travels;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxtName.Text == "" || txtDate.Text == "")
                {
                    TxtError.Text = "Beide velden moeten ingevuld zijn!";
                }
                else
                {
                    travelRepo.CreateTravel(TxtName.Text, txtDate.Text, activeUser.Id);
                    travels.Add(new Travel() { Id = activeUser.Id + TxtName.Text, Name = TxtName.Text, Date = txtDate.Text, UserId = activeUser.Id });
                    ClosePopup();
                }
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                
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