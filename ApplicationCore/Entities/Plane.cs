using System;
using System.Collections.Generic;

namespace Airlines.ApplicationCore.Entities
{
    public class Plane : BaseEntity<int>
    {
        public string Name { get; private set; }
        public string Model { get; private set; }
        public int TotalSeats { get; private set; }

        private readonly List<TravelClass> _travelClasses = new List<TravelClass>();
        public IReadOnlyCollection<TravelClass> TravelClasses => _travelClasses.AsReadOnly();

        public Plane()
        {
        }
        
        public Plane(string name, string model, int totalSeats)
        {
            UpdateName(name);
            UpdateModel(model);
            UpdateTotalSeats(totalSeats);
        }
        
        public void UpdateName(string name)
        {
            if (name.Length < 1 && name.Length > 50)
                throw new ArgumentException(nameof(name));
            Name = name;
        }
        
        public void UpdateModel(string model)
        {
            if (model.Length == 0 && model.Length > 50)
                throw new ArgumentException(nameof(model));
            Model = model;
        }
        
        public void UpdateTotalSeats(int seats)
        {
            if (seats == 0)
                throw new ArgumentNullException(nameof(seats));
            TotalSeats = seats;
        }

        public void AddTravelClass(TravelClass travelClass)
        {
            _travelClasses.Add(travelClass);
        }
        
        public void RemoveTravelClass(TravelClass travelClass)
        {
            if (!_travelClasses.Contains(travelClass))
                throw new ArgumentException();
            _travelClasses.Remove(travelClass);
        }
    }
}