using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingListApp.Models
{
    public class CategorieRepository
    {
        private static MobileServiceCollection<Categorie, Categorie> categories;
        private static IMobileServiceTable<Categorie> categorieTable =
            App.MobileService.GetTable<Categorie>();

        public async void CreateCategorie(string name, string travelId)
        {
            Categorie categorie = new Categorie() { Name = name,  TravelId = travelId };
            await categorieTable.InsertAsync(categorie);
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
