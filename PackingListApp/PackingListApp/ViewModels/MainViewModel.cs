using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingListApp.Model;

namespace PackingListApp.ViewModels
{
    class MainViewModel
    {
        public todoItem todo = null;
        IEnumerable<User> user;
       public  User single = null;

        public static ObservableCollection<todoItem> ItemCollection { set; get; }
        IEnumerable<todoItem> test;

        public MainViewModel()
        {
            if (ItemCollection == null)
                ItemCollection = new ObservableCollection<todoItem>();

            getAzureData();
            getUserData();

        }

        public void loadData()
        {
        }

		public async void getAzureData()
        {
			test =await App.MobileService.GetTable<todoItem>().ToEnumerableAsync();

            todo = test.FirstOrDefault();
            
        }
        public async void getUserData()
        {
            user = await App.MobileService.GetTable<User>().ToEnumerableAsync();

            single = user.FirstOrDefault();
        }
    }
}
