using System.Collections.Generic;

namespace Airlines.ApplicationCore.Entities
{
    public class Plane : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int TotalSeats { get; set; }
        
        private readonly List<TravelClass> _travelClasses = new List<TravelClass>();
        public IReadOnlyCollection<TravelClass> TravelClasses => _travelClasses.AsReadOnly();

        public Plane(string name, string model, int totalSeats)
        {
            Name = name;
            Model = model;
            TotalSeats = totalSeats;
        }

        public void AddTravelClass(TravelClass travelClass)
        {
            _travelClasses.Add(travelClass);
        }
        
        public void RemoveTravelClass(TravelClass travelClass)
        {
            _travelClasses.Remove(travelClass);
        }
    }
}