using ITS.ProjectWork.Server.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Server.Service
{
    public interface ISensorService
    {
        IEnumerable<Sensor> GetAllSensors();
        void InsertSensor(Sensor sensor);
        int CountAllSensors();
        void DeleteSensor(int id);
        Sensor GetSensorById(int id);
        void UpdateSensor(Sensor sensor);
    }
}
