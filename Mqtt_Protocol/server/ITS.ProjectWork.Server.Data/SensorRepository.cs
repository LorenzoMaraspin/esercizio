using ITS.ProjectWork.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.ProjectWork.Server.Data
{
    public class SensorRepository : ISensorRepository
    {
        private readonly RentalScooterContext _rental;
        public SensorRepository(RentalScooterContext rental)
        {
            _rental = rental;
        }
        public int Count()
        {
            return _rental.Sensor.Count();
        }

        public void Delete(int id)
        {
            var sensor = new Sensor
            {
                SensorId = id
            };
            _rental.Entry(sensor).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public IEnumerable<Sensor> GetAll()
        {
            return _rental.Sensor.ToArray();
        }

        public Sensor GetById(int id)
        {
            return _rental.Sensor.FirstOrDefault(s => s.SensorId == id);
        }

        public void Insert(Sensor entity)
        {
            _rental.Sensor.Add(entity);
            _rental.SaveChanges();
        }

        public void Update(Sensor entity)
        {
            _rental.Update(entity);
            _rental.SaveChanges();
        }
    }
}
