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

        public static ObservableCollection<todoItem> ItemCollection { set; get; }
        IEnumerable<todoItem> test;

        public MainViewModel()
        {
            if (ItemCollection == null)
                ItemCollection = new ObservableCollection<todoItem>();
        }

        public void loadData()
        {

        }

		public async void getAzureData()
        {
			test =await App.MobileService.GetTable<todoItem>().ToEnumerableAsync();

            todo = test.FirstOrDefault();
            
        }
    }
}
