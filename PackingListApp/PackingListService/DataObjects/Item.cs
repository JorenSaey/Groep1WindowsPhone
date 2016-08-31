using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackingListService.DataObjects
{
    public class Item : EntityData
    {
        //ATTRIBUTEN
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public int AmountNeeded { get; set; }
        public int AmountCollected { get; set; }
        public string CategorieId { get; set; }
        //CONSTRUCTOR
        public Item() { }
        public Item(string id,string name, int amountNeeded)
        {
            Id = id;
            Name = name;
            AmountNeeded = amountNeeded;
            AmountCollected = 0;
        }
        //ANDERE METHODES
        public void Add()
        {
            AmountCollected++;
        }
        public void Remove()
        {
            AmountCollected--;
        }        
        public bool IsCompleted()
        {
            return AmountCollected == AmountNeeded;
        }
    }
}