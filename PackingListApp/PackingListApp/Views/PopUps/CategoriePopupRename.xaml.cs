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
using Microsoft.WindowsAzure.MobileServices;
using System.Windows.Controls.Primitives;

namespace PackingListApp.Views.PopUps
{
    public partial class CategoriePopupRename : PhoneApplicationPage
    {
        private CategorieRepository categorieRepo;
        private Categorie activeCategorie;
        private ObservableCollection<CategorieViewModel> categories;
        public CategoriePopupRename(Categorie activeCategorie, ObservableCollection<CategorieViewModel> categories)
        {
            InitializeComponent();
            this.activeCategorie = activeCategorie;
            this.categorieRepo = new CategorieRepository();
            this.categories = categories;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                categorieRepo.UpdateCategorie(activeCategorie.Id, TxtName.Text);
                CategorieViewModel cat = categories.Where(c => c.Id == activeCategorie.Id).FirstOrDefault();
                int loc = categories.IndexOf(cat);
                cat.Name = TxtName.Text;
                categories[loc] = cat;
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
