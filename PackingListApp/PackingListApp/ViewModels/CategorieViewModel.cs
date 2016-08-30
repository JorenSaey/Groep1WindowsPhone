using PackingListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingListApp.ViewModels
{
    public class CategorieViewModel
    {
        public IList<ItemViewModel> Items { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public CategorieViewModel(Categorie categorie)
        {
            Items = categorie.Items.Select(i => new ItemViewModel(i)).ToList();
            Name = categorie.Name;
            Id = categorie.Id;
        }
    }
    public class ItemViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Ratio { get; set; }
        public ItemViewModel(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Ratio= item.AmountCollected+"/"+item.AmountNeeded;
        }
    }
}
