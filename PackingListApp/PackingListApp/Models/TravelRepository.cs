using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingListApp.Models
{
    public class TravelRepository
    {
        private static MobileServiceCollection<Travel, Travel> travels;
        private static IMobileServiceTable<Travel> travelTable =
            App.MobileService.GetTable<Travel>();

        public async void CreateTravel(string name, string date, string userId)
        {
            Travel travel = new Travel() { Name = name, Date = date,UserId = userId};
            await travelTable.InsertAsync(travel);
        }
        public async void DeleteTravel(string id)
        {
            Travel travel = await Find(id);
            await travelTable.DeleteAsync(travel);
        }
        public async Task<Travel> Find(string id)
        {
            Travel travel = await travelTable.LookupAsync(id);
            return travel;
        }
        public async void UpdateTravel(string id,string name, string date)
        {
            Travel travel = await Find(id);
            await travelTable.DeleteAsync(travel);
            CreateTravel(name, date, travel.UserId);
        }
    }
}
