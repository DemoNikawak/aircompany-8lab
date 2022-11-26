using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes { get; private set; }
        public List<Plane> SortedByMaxSpeedPlanes => Planes.OrderBy(w => w.MaxSpeed).ToList();
        public List<Plane> SortedByMaxFlightDistancePlanes => Planes.OrderBy(w => w.MaxFlightDistance).ToList();
        public List<Plane> SortedByMaxLoadCapacityPlanes => Planes.OrderBy(w => w.MaxLoadCapacity).ToList();

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            return Planes.OfType<PassengerPlane>().ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return Planes.OfType<MilitaryPlane>().ToList();
        }

        public PassengerPlane GetPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes()
                    .OrderByDescending(plane=>plane.PassengersCapacity)
                    .FirstOrDefault();             
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes()
                    .Where(plane => plane.MillitaryType == MilitaryType.Transport)
                    .ToList();
        }


        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", Planes.Select(x => x.Model)) +
                    '}';
        }
    }
}
