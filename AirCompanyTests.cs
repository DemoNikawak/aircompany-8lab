using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        [Test]
        public void AllTransportPlanesTest()
        {
            Airport airport = new Airport(MockDataStore.GetPlanes());

            List<MilitaryPlane> transportMilitaryPlanes = airport.GetTransportMilitaryPlanes().ToList();

            var allPlanesAreTransport = transportMilitaryPlanes
                                    .All(plane => plane.MillitaryType == MilitaryType.Transport);

            Assert.IsTrue(allPlanesAreTransport);
        }

        [Test]
        public void MaxPassengersCapacityPlaneTest()
        {
            Airport airport = new Airport(MockDataStore.GetPlanes());

            var expectedPlane = MockDataStore.PlaneWithMaxPassengerCapacity;

            var actualPlane = airport.GetPlaneWithMaxPassengersCapacity();

            Assert.AreEqual(expectedPlane, actualPlane);

        }

        [Test]
        public void MaxLoadCapacityOrderingTest()
        {
            var airport = new Airport(MockDataStore.GetPlanes());

            var sortedPlanes = airport.SortedByMaxLoadCapacityPlanes;

            var firstPlaneCapacity = sortedPlanes[0].MaxLoadCapacity;
            var lastPlaneCapacity = sortedPlanes[sortedPlanes.Count - 1].MaxLoadCapacity;

            Assert.Greater(lastPlaneCapacity, firstPlaneCapacity);
        }
    }
}
