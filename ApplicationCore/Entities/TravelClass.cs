using System;
using System.Collections.Generic;

namespace Airlines.ApplicationCore.Entities
{
    public class TravelClass : BaseEntity<int>
    {
        public string Name { get; private set; }
        public float ClassPrice { get; private set; }

        public IEnumerable<Plane> Planes { get; private set; }

        public TravelClass(string name, float classPrice)
        {
            UpdateName(name);
            UpdateClassPrice(classPrice);
        }
        
        public void UpdateName(string name)
        {
            if (name.Length == 0 && name.Length > 50)
                throw new ArgumentException(nameof(name));
            Name = name;
        }
        
        public void UpdateClassPrice(float price)
        {
            if (price > 1000000)
                throw new ArgumentException(nameof(price));
            ClassPrice = price;
        }
    }
}