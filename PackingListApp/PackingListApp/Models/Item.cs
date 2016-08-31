

using Newtonsoft.Json;

namespace PackingListApp.Models
{
    public class Item 
    {
        //ATTRIBUTEN
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "amountNeeded")]
        public int AmountNeeded { get; set; }
        [JsonProperty(PropertyName = "amountCollected")]
        public int AmountCollected { get; set; }
        [JsonProperty(PropertyName="categorieId")]
        public string CategorieId { get; set; }
        //CONSTRUCTOR
        public Item() { }
        public Item(string name, int amountNeeded)
        {
            Name = name;
            AmountNeeded = amountNeeded;
            AmountCollected = 0;
        }
        //ANDERE METHODES
        public void Add()
        {
            if (AmountCollected < AmountNeeded)
                AmountCollected++;
        }
        public void Remove()
        {
            if (AmountCollected > 0)
                AmountCollected--;
        }        
        public bool IsCompleted()
        {
            return AmountCollected == AmountNeeded;
        }
    }
}