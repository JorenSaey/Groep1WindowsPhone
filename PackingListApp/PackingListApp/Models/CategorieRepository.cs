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

        public async Task CreateCategorie(string name, string travelId)
        {
            Categorie categorie = new Categorie() { Name = name,  TravelId = travelId };
            await categorieTable.InsertAsync(categorie);
        }
        public async void DeleteCategorie(string id)
        {
            Categorie categorie = await Find(id);
            await categorieTable.DeleteAsync(categorie);
        }
        public async Task<Categorie> Find(string id)
        {
            Categorie categorie = await categorieTable.LookupAsync(id);
            return categorie;
        }
        public async void UpdateCategorie(string id, string name)
        {
            Categorie categorie = await Find(id);
            categorie.Items = null;
            categorie.Name = name;
            await categorieTable.UpdateAsync(categorie);
        }
    }
}
