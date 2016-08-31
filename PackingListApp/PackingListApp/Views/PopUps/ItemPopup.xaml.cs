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
using Microsoft.WindowsAzure.MobileServices;
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;
using PackingListApp.ViewModels;

namespace PackingListApp.Views.PopUps
{
    public partial class ItemPopup : PhoneApplicationPage
    {
        private ItemRepository itemRepo;
        private Categorie activeCategorie;
        private ObservableCollection<ItemViewModel> items;
        public ItemPopup(Categorie activeCategorie, ObservableCollection<ItemViewModel> items)
        {
            InitializeComponent();
            this.activeCategorie = activeCategorie;
            this.itemRepo = new ItemRepository();
            this.items = items;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                itemRepo.CreateItem(TxtName.Text,Int32.Parse(txtAmountNeeded.Text),activeCategorie.Id);
                items.Add(new ItemViewModel(new Item()
                {
                    Id = activeCategorie.Id + TxtName.Text,
                    AmountNeeded = Int32.Parse(txtAmountNeeded.Text),
                    AmountCollected = 0,
                    Name = TxtName.Text,
                    CategorieId = activeCategorie.Id
                }));
            }
            catch (MobileServiceInvalidOperationException ex)
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
