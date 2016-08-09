
using System.Windows;
using Microsoft.Phone.Controls;
using System;
using Microsoft.WindowsAzure.MobileServices;
using PackingListApp.Models;
using System.Threading.Tasks;

namespace PackingListApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        private MobileServiceCollection<User, User> users;
        private IMobileServiceTable<User> userTable =
            App.MobileService.GetTable<User>();

        public MainPage()
        {
            InitializeComponent();
        }

        //test
        private async Task ShowUser(string email)
        {
            User user = await userTable.LookupAsync(email);
            Console.WriteLine(user.FirstName);
        }
        private async void MeldAan(object sender, RoutedEventArgs e)
        {
            //test
            await ShowUser("joren.saey@gmail.com");
            NavigationService.Navigate(new Uri("/Views/TravelPage.xaml", UriKind.Relative));
        }
    }
}