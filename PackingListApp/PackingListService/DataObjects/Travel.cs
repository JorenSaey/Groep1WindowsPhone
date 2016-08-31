using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PackingListService.DataObjects
{
    public class Travel : EntityData
    {
        //ATTRIBUTEN
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public virtual IList<Categorie> Categories {get; set;}
        public string UserId { get; set; }
        //CONSTRUCTOR
        public Travel() { }
        public Travel(string id, string name, string date)
        {
            Id = id;
            Name = name;
            Date = date;
            Categories = Defaults.GiveDefaultCategories(id);
        }
        //ANDERE METHODES
        public void AddCategorie(string name)
        {
            Categorie categorie = new Categorie(Id + name, name) { TravelId = this.Id};
            Categories.Add(categorie);
        }
        public void RemoveCategorie(string name)
        {
            Categorie categorie = Categories.Where(c => c.Name == name).FirstOrDefault();
            if (categorie != null)
                Categories.Remove(categorie);
        }


        private class Defaults
        {
            public static IList<Categorie> GiveDefaultCategories(string travelId)
            {
                string CAT_1 = "kleren";
                string CAT_2 = "hygiëne";
                string CAT_3 = "entertainment";

                String ITEM_1 = "kousen";
                String ITEM_2 = "t-shirt";
                String ITEM_3 = "korte broek";

                String ITEM_4 = "tandenborstel";
                String ITEM_5 = "shampoo";
                String ITEM_6 = "handdoek";

                String ITEM_7 = "telefoon";
                String ITEM_8 = "boek";
                String ITEM_9 = "gezelschapsspel";

                Categorie cat1 = new Categorie()
                    { Id = travelId + CAT_1, Name = CAT_1, TravelId = travelId };
                Categorie cat2 = new Categorie()
                    { Id = travelId + CAT_2, Name = CAT_2, TravelId = travelId };
                Categorie cat3 = new Categorie()
                    { Id = travelId + CAT_3, Name = CAT_3, TravelId = travelId };

                Item item1 = new Item()
                {
                    Id = cat1.Id + ITEM_1,
                    AmountNeeded = 1,
                    AmountCollected = 0,
                    Name = ITEM_1,
                    CategorieId = cat1.Id
                };

                Item item2 = new Item()
                {
                    Id = cat1.Id + ITEM_2,
                    AmountNeeded = 2,
                    AmountCollected = 0,
                    Name = ITEM_2,
                    CategorieId = cat1.Id
                };

                Item item3 = new Item()
                {
                    Id = cat1.Id + ITEM_3,
                    AmountNeeded = 3,
                    AmountCollected = 0,
                    Name = ITEM_3,
                    CategorieId = cat1.Id
                };

                Item item4 = new Item()
                {
                    Id = cat2.Id + ITEM_4,
                    AmountNeeded = 1,
                    AmountCollected = 0,
                    Name = ITEM_4,
                    CategorieId = cat2.Id
                };

                Item item5 = new Item()
                {
                    Id = cat2.Id + ITEM_5,
                    AmountNeeded = 2,
                    AmountCollected = 0,
                    Name = ITEM_5,
                    CategorieId = cat2.Id
                };

                Item item6 = new Item()
                {
                    Id = cat2.Id + ITEM_6,
                    AmountNeeded = 3,
                    AmountCollected = 0,
                    Name = ITEM_6,
                    CategorieId = cat2.Id
                };

                Item item7 = new Item()
                {
                    Id = cat3.Id + ITEM_7,
                    AmountNeeded = 1,
                    AmountCollected = 0,
                    Name = ITEM_1,
                    CategorieId = cat3.Id
                };

                Item item8 = new Item()
                {
                    Id = cat3.Id + ITEM_8,
                    AmountNeeded = 2,
                    AmountCollected = 0,
                    Name = ITEM_8,
                    CategorieId = cat3.Id
                };

                Item item9 = new Item()
                {
                    Id = cat3.Id + ITEM_9,
                    AmountNeeded = 3,
                    AmountCollected = 0,
                    Name = ITEM_9,
                    CategorieId = cat3.Id
                };

                cat1.Items = new List<Item>() { item1, item2, item3 };
                cat2.Items = new List<Item>() { item4, item5, item6 };
                cat3.Items = new List<Item>() { item7, item8, item9 };

                return new List<Categorie>() { cat1, cat2, cat3 };
            }
        }

    }
}