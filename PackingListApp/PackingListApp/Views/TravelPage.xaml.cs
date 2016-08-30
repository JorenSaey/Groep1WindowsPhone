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
using System.Collections.ObjectModel;

namespace PackingListApp.Views
{
    public partial class TravelPage : PhoneApplicationPage
    {
        private UserRepository userRepo;
        private TravelRepository travelRepo;
        private User activeUser;
        private ObservableCollection<Travel> travels;

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
            this.IsEnabled = false;
            this.Opacity = 0.2;
            Popup add = new Popup();
            Travel travel = (sender as Grid).DataContext as Travel;
            TravelPopupRename popup = new TravelPopupRename(travel);
            popup.Width = Application.Current.Host.Content.ActualWidth - 40;
            add.Child = popup;
            add.IsOpen = true;
            add.VerticalOffset = 50;
            add.HorizontalOffset = 20;
            add.Closed += (s1, e1) =>
            {
                this.Opacity = 1;
                this.IsEnabled = true;
                Travel tr =  travels.Where(t => t.Id == travel.Id).FirstOrDefault();
                travels.Remove(tr);
                tr.Name = popup.TxtName.Text;
                tr.Date = popup.txtDate.Text;
                travels.Add(tr);
            };
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
                travels.Add(new Travel() {Id=activeUser.Id+popup.TxtName.Text, Name = popup.TxtName.Text, Date = popup.txtDate.Text, UserId = activeUser.Id });
            };
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Travel travel = (Travel)TravelContainer.SelectedItem;
            travelRepo.DeleteTravel(travel.Id);
            travels.Remove(travel);
        }
        private async void InitTravels()
        {
            try
            {
                string email = NavigationContext.QueryString["email"];
                activeUser = await userRepo.Find(email);
                travels = new ObservableCollection<Travel>(activeUser.Travels);
                TravelContainer.DataContext = travels;
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        private void NavigateToItemPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/ItemPage.xaml", UriKind.Relative));
        }
    }
}