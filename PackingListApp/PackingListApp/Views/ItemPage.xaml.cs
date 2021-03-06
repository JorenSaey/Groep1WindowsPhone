﻿using System;
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
using System.Windows.Controls.Primitives;
using PackingListApp.Views.PopUps;

namespace PackingListApp.Views
{
    public partial class ItemPage : PhoneApplicationPage
    {
        private Travel activeTravel;
        private TravelRepository travelRepo;
        private CategorieRepository categorieRepo;
        private ItemRepository itemRepo;
        private ObservableCollection<CategorieViewModel> categories;

        public ItemPage()
        {
            InitializeComponent();
            travelRepo = new TravelRepository();
            categorieRepo = new CategorieRepository();
            itemRepo = new ItemRepository();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            InitItems();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            this.Opacity = 0.2;
            Popup add = new Popup();
            CategoriePopup popup = new CategoriePopup(activeTravel, categories);
            popup.Width = Application.Current.Host.Content.ActualWidth - 40;
            add.Child = popup;
            add.IsOpen = true;
            add.VerticalOffset = 50;
            add.HorizontalOffset = 20;
            add.Closed += (s1, e1) =>
            {
                this.Opacity = 1;
                this.IsEnabled = true;
                NavigationService.Navigate(new Uri("/Views/ItemPage.xaml?id=" + activeTravel.Id + "&refresh=" + categories.Count, UriKind.Relative));
                NavigationService.RemoveBackEntry();
            };
        }
        private void Add_Item_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            this.Opacity = 0.2;
            Popup add = new Popup();
            CategorieViewModel cvm = (sender as MenuItem).DataContext as CategorieViewModel;
            Categorie ca = new Categorie() { Id = cvm.Id};
            ItemPopup popup = new ItemPopup(ca,cvm.Items);
            popup.Width = Application.Current.Host.Content.ActualWidth - 40;
            add.Child = popup;
            add.IsOpen = true;
            add.VerticalOffset = 50;
            add.HorizontalOffset = 20;
            add.Closed += (s1, e1) =>
            {
                this.Opacity = 1;
                this.IsEnabled = true;                
            };
        }
        private void Rename_Categorie_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            this.Opacity = 0.2;
            Popup add = new Popup();
            CategorieViewModel cvm = (sender as MenuItem).DataContext as CategorieViewModel;
            Categorie ca = new Categorie() { Id = cvm.Id };
            CategoriePopupRename popup = new CategoriePopupRename(ca,categories);
            popup.Width = Application.Current.Host.Content.ActualWidth - 40;
            add.Child = popup;
            add.IsOpen = true;
            add.VerticalOffset = 50;
            add.HorizontalOffset = 20;
            add.Closed += (s1, e1) =>
            {
                this.Opacity = 1;
                this.IsEnabled = true;
                //RefreshItems();
                
            };
            popup.TxtName.Text = cvm.Name;
        }
        private void Remove_Categorie_Click(object sender, RoutedEventArgs e)
        {
            CategorieViewModel cvm = (sender as MenuItem).DataContext as CategorieViewModel;
            categorieRepo.DeleteCategorie(cvm.Id);
            categories.Remove(cvm);
        }
        private void Remove_Item_Click(object sender, RoutedEventArgs e)
        {
            ItemViewModel ivm = (sender as MenuItem).DataContext as ItemViewModel;
            CategorieViewModel cvm = categories.Where(c => c.Id == ivm.CategorieId).FirstOrDefault();
            itemRepo.DeleteItem(ivm.Id);
            cvm.Items.Remove(ivm);
        }
        private async void Plus_One(object sender, RoutedEventArgs e)
        {
            ItemViewModel ivm = (sender as Button).DataContext as ItemViewModel;
            Item item = ivm.Item;
            await itemRepo.updateAmountNeeded(item.Id, 1);
            NavigationService.Navigate(new Uri("/Views/ItemPage.xaml?id=" + activeTravel.Id + "&refresh=" + item.Name + item.AmountCollected, UriKind.Relative));
            NavigationService.RemoveBackEntry();
        }
        
        private async void Minus_One(object sender, RoutedEventArgs e)
        {
            ItemViewModel ivm = (sender as Button).DataContext as ItemViewModel;
            Item item = ivm.Item;
            await itemRepo.updateAmountNeeded(item.Id, -1);
            NavigationService.Navigate(new Uri("/Views/ItemPage.xaml?id=" + activeTravel.Id + "&refresh=" + item.Name + item.AmountCollected, UriKind.Relative));
            NavigationService.RemoveBackEntry();
        }
        private async void InitItems()
        {
            string id = NavigationContext.QueryString["id"];
            activeTravel = await travelRepo.Find(id);
            TxtTitle.Text = activeTravel.Name;
            categories = new ObservableCollection<CategorieViewModel>(activeTravel.Categories.Select(c => new CategorieViewModel(c)).ToList());
            CategorieContainer.DataContext = categories;
        }
    }
}