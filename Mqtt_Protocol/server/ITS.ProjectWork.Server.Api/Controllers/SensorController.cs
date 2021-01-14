using ITS.ProjectWork.Server.Service;
using ITS.ProjectWork.Server.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITS.ProjectWork.Server.Api.Controllers
{
    [Route("api/sensor")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ISensorService _sensorService;
        public SensorController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }
        // GET: api/<SensorController>
        [HttpGet]
        public IEnumerable<Sensor> Get()
        {
            return _sensorService.GetAllSensors();
        }

        // GET api/<SensorController>/5
        [HttpGet("{id}")]
        public Sensor Get(int id)
        {
            return _sensorService.GetSensorById(id);
        }

        // POST api/<SensorController>
        [HttpPost]
        public void Post([FromBody] Sensor sensor)
        {
            _sensorService.InsertSensor(sensor);
        }

        // PUT api/<SensorController>/5
        [HttpPut]
        public void Put([FromBody] Sensor sensor)
        {
            _sensorService.UpdateSensor(sensor);
        }

        // DELETE api/<SensorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _sensorService.DeleteSensor(id);
        }
    }
}
