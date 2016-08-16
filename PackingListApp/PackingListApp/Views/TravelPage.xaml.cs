﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.MobileServices;
using PackingListApp.Models;
using System.Windows.Input;
using System.Linq;
using System.Windows.Media.Imaging;

namespace PackingListApp.Views
{
    public partial class TravelPage : PhoneApplicationPage
    {
        private UserRepository userRepo;
        private User activeUser;

        public TravelPage()
        {
            InitializeComponent();
            userRepo = new UserRepository();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try {
                string email = NavigationContext.QueryString["email"];
                activeUser = await userRepo.Find(email);
                foreach(Travel t in activeUser.Travels)
                {              
                    //1 ListBoxItem
                    ListBoxItem item = new ListBoxItem();
                    //Properties of ListBoxItem
                    item.BorderThickness = new Thickness(0,0,0,1);
                    item.BorderBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
                    item.Padding = new Thickness(0,10,0,10);
                    item.IsSelected = false;
                    item.Hold += ListBoxItem_Hold;
                    //Content of ListBoxItem
                    Grid grid = new Grid();
                    ColumnDefinition col1 = new ColumnDefinition();
                    col1.Width = new GridLength(280);
                    ColumnDefinition col2 = new ColumnDefinition();
                    col2.Width = new GridLength(50);
                    ColumnDefinition col3 = new ColumnDefinition();
                    col3.Width = GridLength.Auto;
                    grid.ColumnDefinitions.Add(col1);
                    grid.ColumnDefinitions.Add(col2);
                    grid.ColumnDefinitions.Add(col3);
                    TextBlock name = new TextBlock();
                    name.Text = t.Name;
                    name.FontSize = 24;
                    name.VerticalAlignment = VerticalAlignment.Center;
                    TextBlock percentage = new TextBlock();
                    percentage.Text = "0%";
                    percentage.FontSize = 24;
                    percentage.HorizontalAlignment = HorizontalAlignment.Left;
                    percentage.VerticalAlignment = VerticalAlignment.Center;
                    Button button = new Button();
                    BitmapImage bitMapImage = new BitmapImage(new Uri("/Assets/Images/list.png", UriKind.Relative));
                    bitMapImage.DecodePixelWidth = 200;
                    Image image = new Image();
                    image.Source = bitMapImage;
                    image.Width = 50;
                    button.Content = image;
                    button.BorderThickness = new Thickness(0, 0, 0, 0);
                    grid.Children.Add(name);
                    Grid.SetRow(name, 0);
                    Grid.SetColumn(name, 0);
                    grid.Children.Add(percentage);
                    Grid.SetRow(percentage, 0);
                    Grid.SetColumn(percentage, 1);
                    grid.Children.Add(button);
                    Grid.SetRow(button, 0);
                    Grid.SetColumn(button, 2);
                    item.Content = grid;
                    TravelContainer.Items.Add(item);
                }
            }
            catch(MobileServiceInvalidOperationException ex)
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml",UriKind.Relative));
            }
        }
        private void ListBoxItem_Hold(object sender, GestureEventArgs a)
        {
            //test
            ListBoxItem item = (ListBoxItem)sender;
            if (item.IsSelected)
                item.IsSelected = false;
            else
                item.IsSelected = true;
            
        }
    }
}