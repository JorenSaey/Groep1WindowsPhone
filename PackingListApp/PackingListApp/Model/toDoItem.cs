using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingListApp.Model
{
    class todoItem : INotifyPropertyChanged
    {
        //ATTRIBUTEN
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public int AmountNeeded { get; set; }
        public int AmountCollected { get; set; }
        //CONSTRUCTOR
        public todoItem() { }
        public todoItem(string name, int amountNeeded)
        {
            Name = name;
            AmountNeeded = amountNeeded;
            AmountCollected = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}