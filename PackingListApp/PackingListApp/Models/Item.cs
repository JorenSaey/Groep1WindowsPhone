

using Newtonsoft.Json;

namespace PackingListApp.Models
{
    public class Item 
    {
        //ATTRIBUTEN
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "amountNeeded")]
        public int AmountNeeded { get; set; }
        [JsonProperty(PropertyName = "amountCollected")]
        public int AmountCollected { get; set; }
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