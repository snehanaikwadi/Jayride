using System.Net;
using JayrideChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace JayrideChallenge.Controllers
{
    [Route("/location")]
    [ApiController]
    public class Task2Controller : ControllerBase
    {
        private readonly LocationService _locationService;
        public Task2Controller(LocationService locationService)
        {
            _locationService = locationService;
        }
        

        /// <summary>
        /// Get city location by IP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns>Location details if IP is valid</returns>
        [HttpGet("{ip}", Name = "GetLocation")]
        public async Task<ActionResult> GetLocation(string ip)
        {
            if (!IPAddress.TryParse(ip, out _))
                return BadRequest("Invalid IP");
            var result = await _locationService.GetLocation(ip);
            if (result is not null && result.city is not null)
                return Ok(result);
            else
                return NotFound("City location details not found for this IP");
        }

        
    }
}
