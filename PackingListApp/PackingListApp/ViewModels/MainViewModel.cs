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
        public static ObservableCollection<todoItem> ItemCollection { set; get; }

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
			IEnumerable<todoItem> test =await App.MobileService.GetTable<todoItem>().ToEnumerableAsync();

         
        }
    }
}
