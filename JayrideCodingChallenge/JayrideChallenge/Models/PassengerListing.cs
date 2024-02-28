using System;
namespace JayrideChallenge.Models
{
	public class PassengerListing
	{
        public string From { get; set; }
        public string To { get; set; }
        public List<Listing> Listings { get; set; }
		public PassengerListing()
		{
			Listings = new List<Listing>();
		}
    }
	public class Listing
	{
		public string Name { get; set; }
		public double PricePerPassenger { get; set; }
		public int NoOfPassengers { get; set; }
		public double TotalPrice { get; set; }
        public Vehicle VehicleType { get; set; }


    }
	public class Vehicle
	{
        public string Name { get; set; }
        public int MaxPassengers { get; set; }

    }
}

