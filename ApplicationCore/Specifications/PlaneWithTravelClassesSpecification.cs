using System;
using System.Linq;
using Airlines.ApplicationCore.Entities;
using Ardalis.Specification;

namespace Airlines.ApplicationCore.Specifications
{
    public sealed class PlaneWithTravelClassesSpecification : Specification<Plane>
    {
        public PlaneWithTravelClassesSpecification(int planeId) : base()
        {
            Query
                .Where(o => o.Id == planeId)
                .Include(o => o.TravelClasses);
        }
        
        public PlaneWithTravelClassesSpecification() : base()
        {
            Query
                .Include(o => o.TravelClasses);
        }
    }
}