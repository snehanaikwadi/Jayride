using System;
using JayrideChallenge.Models;

namespace JayrideChallenge.Services
{
	public class LocationService
	{
        private readonly HttpClient _client;

        public LocationService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Location?> GetLocation(string ip)
        {
            try
            {
                var location = await _client
                .GetFromJsonAsync<Location>($"/{ip}");
                return location;
            }
            catch(Exception ex)
            {
                throw new Exception("Error calling external api. Details: "+ ex.Message + ex.StackTrace);
            }
        }
    }
}

