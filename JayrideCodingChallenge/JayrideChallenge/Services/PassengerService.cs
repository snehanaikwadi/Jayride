using JayrideChallenge.Models;

namespace JayrideChallenge.Services
{
    public class PassengerService
    {
        private readonly HttpClient _client;

        public PassengerService(HttpClient client)
        {
            _client = client;
        }
        public async Task<PassengerListing> GetPassengerListingPrices(int passengers)
        {
            try
            {
                var data = await _client.GetFromJsonAsync<PassengerListing>("");
                if (data is not null && data.Listings?.Any() is true)
                {
                    return new PassengerListing()
                    {
                        From = data.From,
                        To = data.To,
                        Listings = data.Listings.Where(p => passengers <= p.VehicleType.MaxPassengers)
                        .Select(n => new Listing
                        {
                            Name = n.Name,
                            PricePerPassenger = n.PricePerPassenger,
                            NoOfPassengers = passengers,
                            TotalPrice = Math.Round((double)passengers * n.PricePerPassenger, 2),
                            VehicleType = n.VehicleType
                        }).OrderBy(x => x.TotalPrice).ToList()
                    };
                }
                return new PassengerListing();
            }
            catch(Exception ex)
            {
                throw new Exception("Error in Passenger Service. Details: " + ex.Message + ex.StackTrace);
            }


        }
        public async Task<PassengerListing> GetPassengerListingData()
        {
            var data = await _client.GetFromJsonAsync<PassengerListing>("");
            return data;
        }
    }
}

