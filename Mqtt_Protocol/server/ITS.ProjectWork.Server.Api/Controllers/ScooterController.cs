using ITS.ProjectWork.Server.Model;
using ITS.ProjectWork.Server.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITS.ProjectWork.Server.Api.Controllers
{
    [Route("api/scooter")]
    [ApiController]
    public class ScooterController : ControllerBase
    {
        private readonly IScooterService _scooterService;
        public ScooterController(IScooterService scooterService)
        {
            _scooterService = scooterService;
        }
        // GET: api/<ScooterController>
        [HttpGet]
        public IEnumerable<Scooter> Get()
        {
            return _scooterService.GetAllScooters();
        }

        // GET api/<ScooterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _scooterService.GetScooterById(id).ToString();
        }

        // POST api/<ScooterController>
        [HttpPost]
        public void Post([FromBody] Scooter scooter)
        {
            _scooterService.InsertScooter(scooter);
        }

        // PUT api/<ScooterController>/5
        [HttpPut]
        public void Put([FromBody] Scooter scooter)
        {
            _scooterService.UpdateScooter(scooter);
        }

        // DELETE api/<ScooterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _scooterService.DeleteScooter(id);
        }
    }
}
