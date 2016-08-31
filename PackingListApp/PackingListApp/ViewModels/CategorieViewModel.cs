using PackingListApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingListApp.ViewModels
{
    public class CategorieViewModel
    {
        public ObservableCollection<ItemViewModel> Items { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public CategorieViewModel(Categorie categorie)
        {
            if (categorie.Items != null)
                Items = new ObservableCollection<ItemViewModel>(categorie.Items.Select(i => new ItemViewModel(i)).ToList());
            else
                Items = new ObservableCollection<ItemViewModel>();
            Name = categorie.Name;
            Id = categorie.Id;
        }
    }
    public class ItemViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Ratio { get; set; }
        public string CategorieId { get; set; }
        public ItemViewModel(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Ratio= item.AmountCollected+"/"+item.AmountNeeded;
            CategorieId = item.CategorieId;
        }
    }
}
