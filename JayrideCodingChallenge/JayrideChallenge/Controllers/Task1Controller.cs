using JayrideChallenge.Models;
using JayrideChallenge.Utils;
using Microsoft.AspNetCore.Mvc;

namespace JayrideChallenge.Controllers
{
    [Route("/candidate")]
    [ApiController]
    public class Task1Controller : ControllerBase
    {
        private List<Person> candidates;
        public Task1Controller()
        {
            candidates = JsonHelper.GetJsonData();
            /*candidates = new List<Person>();
            candidates.Add(new Person() { Name = "test", Phone = "test" });
            candidates.Add(new Person() { Name = "test1", Phone = "test1Phone" });
            candidates.Add(new Person() { Name = "test2", Phone = "test2Phone" });
            candidates.Add(new Person() { Name = "test3", Phone = "test2Phone" });*/
        }

        /// <summary>
        /// Lists all candidates 
        /// </summary>
        /// <returns>List of Person</returns>
        [HttpGet]
       
        public IEnumerable<Person> Get()
        {
            return candidates;
        }

        /// <summary>
        /// Gets candidate by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}", Name = "Get")]
        
        public ActionResult Get(string name)
        {
            
            if (candidates.Exists(p => p.Name.ToLower() == name.Trim().ToLower()))
                return Ok(candidates.Single(p => p.Name.ToLower() == name.Trim().ToLower()));
            else
                return NotFound("Candidate not found");
        }

        
    }
}
