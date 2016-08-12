using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.MobileServices;
using PackingListApp.Models;


namespace PackingListApp.Views
{
    public partial class TravelPage : PhoneApplicationPage
    {
        private static MobileServiceCollection<User, User> users;
        private static IMobileServiceTable<User> userTable =
            App.MobileService.GetTable<User>();

        private User activeUser;

        public TravelPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try {
                string email = NavigationContext.QueryString["email"];
                activeUser = await userTable.LookupAsync(email);
                foreach(Travel t in activeUser.Travels)
                {              
                    //1 ListBoxItem
                    ListBoxItem item = new ListBoxItem();
                    //Properties of ListBoxItem
                    item.BorderThickness = new Thickness(0,0,0,1);
                    item.BorderBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
                    item.Padding = new Thickness(0,10,0,10);
                    //Content of ListBoxItem
                    Grid grid = new Grid();
                    ColumnDefinition col1 = new ColumnDefinition();
                    col1.Width = new GridLength(300);
                    ColumnDefinition col2 = new ColumnDefinition();
                    col2.Width = GridLength.Auto; 
                    grid.ColumnDefinitions.Add(col1);
                    grid.ColumnDefinitions.Add(col2);
                    TextBlock name = new TextBlock();
                    name.Text = t.Name;
                    name.FontSize = 24;
                    TextBlock percentage = new TextBlock();
                    //todo
                    percentage.Text = "0%";
                    percentage.FontSize = 24;
                    percentage.HorizontalAlignment = HorizontalAlignment.Left;
                    grid.Children.Add(name);
                    Grid.SetRow(name, 0);
                    Grid.SetColumn(name, 0);
                    grid.Children.Add(percentage);
                    Grid.SetRow(percentage, 0);
                    Grid.SetColumn(percentage, 1);
                    item.Content = grid;
                    TravelContainer.Items.Add(item);
                }
            }
            catch(MobileServiceInvalidOperationException ex)
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml",UriKind.Relative));
            }
        }

        
    }
}