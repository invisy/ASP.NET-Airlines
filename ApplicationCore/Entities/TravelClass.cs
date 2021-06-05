using System;
using System.Collections.Generic;

namespace Airlines.ApplicationCore.Entities
{
    public class TravelClass : BaseEntity<int>
    {
        public string Name { get; private set; }
        public float ClassPrice { get; private set; }

        public IEnumerable<Plane> Planes { get; private set; }

        public TravelClass() {}
        public TravelClass(string name, float classPrice)
        {
            UpdateName(name);
            UpdateClassPrice(classPrice);
        }
        
        public void UpdateName(string name)
        {
            if (name.Length is 0 or > 50)
                throw new ArgumentOutOfRangeException(nameof(name));
            Name = name;
        }
        
        public void UpdateClassPrice(float price)
        {
            if (price is > 1000000 or < 0)
                throw new ArgumentOutOfRangeException(nameof(price));
            ClassPrice = price;
        }
    }
}