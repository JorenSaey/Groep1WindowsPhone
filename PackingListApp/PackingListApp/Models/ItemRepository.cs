using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingListApp.Models
{
    public class ItemRepository
    {
        private static MobileServiceCollection<Item, Item> items;
        private static IMobileServiceTable<Item> itemTable =
            App.MobileService.GetTable<Item>();

        public async void CreateItem(string name, int amountNeeded, string categorieId)
        {
            Item item = new Item(name,amountNeeded) { CategorieId = categorieId };
            await itemTable.InsertAsync(item);
        }
        //public async void DeleteTravel(string id)
        //{
        //    Travel travel = await Find(id);
        //    await travelTable.DeleteAsync(travel);
        //}
        //public async Task<Travel> Find(string id)
        //{
        //    Travel travel = await travelTable.LookupAsync(id);
        //    return travel;
        //}
        //public async void UpdateTravel(string id, string name, string date)
        //{
        //    Travel travel = await Find(id);
        //    await travelTable.DeleteAsync(travel);
        //    CreateTravel(name, date, travel.UserId);
        //}
    }
}
