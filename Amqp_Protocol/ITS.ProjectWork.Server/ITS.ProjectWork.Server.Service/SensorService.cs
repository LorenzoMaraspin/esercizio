using ITS.ProjectWork.Server.Data;
using ITS.ProjectWork.Server.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Server.Service
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _sensorRepository;
        public SensorService(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }
        public int CountAllSensors()
        {
            return _sensorRepository.Count();
        }

        public void DeleteSensor(int id)
        {
            _sensorRepository.Delete(id);
        }

        public IEnumerable<Sensor> GetAllSensors()
        {
            return _sensorRepository.GetAll();
        }

        public Sensor GetSensorById(int id)
        {
            return _sensorRepository.Get(id);
        }

        public void InsertSensor(Sensor sensor)
        {
            _sensorRepository.Insert(sensor);
        }

        public void UpdateSensor(Sensor sensor)
        {
            _sensorRepository.Update(sensor);
        }
    }
}
