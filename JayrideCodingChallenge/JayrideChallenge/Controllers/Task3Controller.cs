    using JayrideChallenge.Services;
    using Microsoft.AspNetCore.Mvc;

    namespace JayrideChallenge.Controllers
    {
        [Route("Listings")]
        [ApiController]
        public class Task3Controller : ControllerBase
        {
            private readonly PassengerService _passengerService;
            public Task3Controller(PassengerService passengerService)
            {
                _passengerService = passengerService;
            }

            /// <summary>
            /// Gets listings with total price of for given number of passengers
            /// </summary>
            /// <param name="noOfPassengers"></param>
            /// <returns></returns>
            [HttpGet("{noOfPassengers}", Name = "GetListing")]
            public async Task<ActionResult> GetListing(int noOfPassengers)
            {
                if (noOfPassengers <= 0)
                    return BadRequest("Invalid input");
                 var result = await _passengerService.GetPassengerListingPrices(noOfPassengers);
                 if (result is not null && result.Listings is not null && result.Listings.Any() is true)
                 {
                     return Ok(result);
                 }
                 else
                         return NotFound("Listings not found!"); 

                /*
                 *** This below code can be run without adding explicit properties TotalPrice, NoOfPassenngers to Listing class ***
             
               var data = await _passengerService.GetPassengerListingData();
                var result = new
                {
                    From = data.From,
                    To = data.To,
                    Listings = data.Listings.Where(p => passengers <= p.VehicleType.MaxPassengers).Select(p =>
              new
              {
                  Name = p.Name,
                  PricePerPassenger = p.PricePerPassenger,
                  TotalPrice = passengers * p.PricePerPassenger,
                  VehicleType = p.VehicleType

              }).OrderBy(t => t.TotalPrice)
                };
                return Ok(result);
                */


        }
       
        }
    }
