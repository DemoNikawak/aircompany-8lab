using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;

namespace Aircompany
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Airport airport = new Airport(MockDataStore.GetPlanes());
            Airport militaryAirport = new Airport(airport.GetMilitaryPlanes());
            Airport passengerAirport = new Airport(airport.GetPassengersPlanes());

            Console.WriteLine(militaryAirport.SortedByMaxFlightDistancePlanes.FirstOrDefault());
            Console.WriteLine(passengerAirport.SortedByMaxSpeedPlanes.FirstOrDefault());
            Console.WriteLine(passengerAirport.GetPlaneWithMaxPassengersCapacity());           
        }
    }
}
