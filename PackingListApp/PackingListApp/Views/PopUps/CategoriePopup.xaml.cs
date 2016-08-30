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

namespace PackingListApp.Views.PopUps
{
    public partial class CategoriePopup : PhoneApplicationPage
    {
        private CategorieRepository categorieRepo;
        private Travel activeTravel;
        public CategoriePopup(Travel activeTravel)
        {
            InitializeComponent();
            this.activeTravel = activeTravel;
            this.categorieRepo = new CategorieRepository();
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                categorieRepo.CreateCategorie(TxtName.Text, activeTravel.Id);
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
