namespace JayrideChallenge.Utils
{
    public sealed class ExternalServicesOptions
	{
		public LocationApi LocationApi { get; set; }
		public PassengerApi PassengerApi { get; set; }
        public ExternalServicesOptions()
        {
            LocationApi = new LocationApi();
            PassengerApi = new PassengerApi();
        }
    }
	public class LocationApi
	{
		public string Token { get; set; } = string.Empty;
        public string BaseAddress { get; set; } = string.Empty;

    }
    public class PassengerApi
	{ 
        public string BaseAddress { get; set; } = string.Empty;

    }
	
}

