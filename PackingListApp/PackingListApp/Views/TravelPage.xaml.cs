using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.MobileServices;
using PackingListApp.Models;
using System.Windows.Input;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;
using PackingListApp.Views.PopUps;
using System.Collections.Generic;

namespace PackingListApp.Views
{
    public partial class TravelPage : PhoneApplicationPage
    {
        private UserRepository userRepo;
        private TravelRepository travelRepo;
        private User activeUser;
        private IList<Travel> travels;

        public TravelPage()
        {
            InitializeComponent();
            userRepo = new UserRepository();
            travelRepo = new TravelRepository();         
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
             InitTravels();
        }
        private void BtnGoToItemPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/ItemPage.xaml", UriKind.Relative));
        }
        private void ListBoxItem_Hold(object sender, GestureEventArgs a)
        {
            //Venster om naam te wijzigen of te verwijderen
                        
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            this.Opacity = 0.2;
            Popup add = new Popup();
            TravelPopup popup = new TravelPopup(activeUser); 
            popup.Width = Application.Current.Host.Content.ActualWidth-40;
            add.Child = popup;
            add.IsOpen = true;
            add.VerticalOffset = 50;
            add.HorizontalOffset = 20;
            add.Closed += (s1, e1) =>
            {
                this.Opacity = 1;
                this.IsEnabled = true;
                RefreshTravels();
            };
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Travel travel = (Travel)TravelContainer.SelectedItem;
            travelRepo.DeleteTravel(travel.Id);            
            RefreshTravels();
        }
        private async void InitTravels()
        {
            try
            {
                string email = NavigationContext.QueryString["email"];
                activeUser = await userRepo.Find(email);
                travels = activeUser.Travels;
                TravelContainer.DataContext = travels;
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }
        private async void RefreshTravels()
        {
            try {
                activeUser = await userRepo.Find(activeUser.Id);
                travels = activeUser.Travels;
                TravelContainer.DataContext = travels;
            }
            catch(MobileServiceInvalidOperationException ex)
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }
    }
}