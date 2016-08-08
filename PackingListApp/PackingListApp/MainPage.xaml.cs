
using System.Windows;
using Microsoft.Phone.Controls;
using PackingListApp.ViewModels;

namespace PackingListApp
{
    public partial class MainPage : PhoneApplicationPage
    {

       private string username;
        private string password;
        private MainViewModel mainViewModel;


        public MainPage()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();

       
        }

        public void Valideer_Login(object sender, RoutedEventArgs e)
        {      
            username = TxtboxUsername.Text;
            password = PwBoxPassword.Password;
            mainViewModel.valideer(username, password);

        }
  
    }
}