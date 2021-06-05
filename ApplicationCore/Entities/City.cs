using System;
using Airlines.ApplicationCore.DTOs;

namespace Airlines.ApplicationCore.Entities
{
    public class City : BaseEntity<int>
    {
        public string Name { get; private set; }

        public City() { }
        
        public City(string name)
        {
            UpdateName(name);
        }

        public void UpdateName(string name)
        {
            if (name.Length is 0 or > 50)
                throw new ArgumentOutOfRangeException(nameof(name));
            Name = name;
        }
    }
}