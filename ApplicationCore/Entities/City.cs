using System;
using Airlines.ApplicationCore.DTOs;

namespace Airlines.ApplicationCore.Entities
{
    public class City : BaseEntity<int>
    {
        public string Name { get; private set; }
        
        public City(string name)
        {
            UpdateName(name);
        }

        public void UpdateName(string name)
        {
            if (name.Length == 0 && name.Length > 50)
                throw new ArgumentException(nameof(name));
            Name = name;
        }
    }
}