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
using Microsoft.WindowsAzure.MobileServices;
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;

namespace PackingListApp.Views.PopUps
{
    public partial class TravelPopupRename : PhoneApplicationPage
    {
        private TravelRepository travelRepo;
        private Travel activeTravel;
        private ObservableCollection<Travel> travels;
        public TravelPopupRename(Travel activeTravel, ObservableCollection<Travel> travels)
        {
            InitializeComponent();
            this.activeTravel = activeTravel;
            this.travelRepo = new TravelRepository();
            this.travels = travels;
        }
        private async void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await travelRepo.UpdateTravel(activeTravel.Id, TxtName.Text, txtDate.Text);
                Travel tr = travels.Where(t => t.Id == activeTravel.Id).FirstOrDefault();
                int loc = travels.IndexOf(tr);
                tr.Categories = activeTravel.Categories;
                tr.Name = TxtName.Text;
                tr.Date = txtDate.Text;
                travels[loc] = tr;
                ClosePopup();
            }
            catch (MobileServiceInvalidOperationException ex)
            {

            }
            finally
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