using ITS.ProjectWork.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.ProjectWork.Server.Data
{
    public class ScooterRepository : IScooterRepository
    {
        private readonly RentalScooterContext _rentalScooterContext;
        public ScooterRepository(RentalScooterContext rentalScooterContext)
        {
            _rentalScooterContext = rentalScooterContext;
        }
        public int Count()
        {
            return _rentalScooterContext.Scooter.Count();
        }

        public void Delete(int id)
        {
            var scooter = new Scooter
            {
                ScooterId = id
            };
            _rentalScooterContext.Entry(scooter).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public IEnumerable<Scooter> GetAll()
        {
            return _rentalScooterContext.Scooter.ToArray();
        }

        public Scooter GetById(int id)
        {
            return _rentalScooterContext.Scooter.FirstOrDefault(s => s.ScooterId == id);
        }

        public void Insert(Scooter entity)
        {
            _rentalScooterContext.Scooter.Add(entity);
            _rentalScooterContext.SaveChanges();
        }

        public void Update(Scooter entity)
        {
            _rentalScooterContext.Update(entity);
            _rentalScooterContext.SaveChanges();
        }
    }
}
