using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PackingListApp.Models;
using System.Collections.ObjectModel;
using PackingListApp.ViewModels;

namespace PackingListApp.Views
{
    public partial class ItemPage : PhoneApplicationPage
    {
        private Travel activeTravel;
        private TravelRepository travelRepo;
        private ObservableCollection<CategorieViewModel> categories;
        public ItemPage()
        {
            InitializeComponent();
            travelRepo = new TravelRepository();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            InitItems();
        }
        private async void InitItems()
        {
            string id = NavigationContext.QueryString["id"];
            activeTravel = await travelRepo.Find(id);
            categories = new ObservableCollection<CategorieViewModel>(activeTravel.Categories.Select(c => new CategorieViewModel(c)).ToList());
            ItemContainer.DataContext = categories;
        }
    }
}