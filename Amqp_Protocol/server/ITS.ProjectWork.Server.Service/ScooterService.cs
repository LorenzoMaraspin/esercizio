using ITS.ProjectWork.Server.Data;
using ITS.ProjectWork.Server.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Server.Service
{
    public class ScooterService : IScooterService
    {
        private readonly IScooterRepository _scooterRepository;
        public ScooterService(IScooterRepository scooterRepository)
        {
            _scooterRepository = scooterRepository;
        }
        public int MyProperty { get; set; }

        public int CountAllScooters()
        {
            return _scooterRepository.Count();
        }

        public void DeleteScooter(int id)
        {
            _scooterRepository.Delete(id);
        }

        public IEnumerable<Scooter> GetAllScooters()
        {
            return _scooterRepository.GetAll();
        }

        public Scooter GetScooterById(int id)
        {
            return _scooterRepository.Get(id);
        }

        public void InsertScooter(Scooter scooter)
        {
            _scooterRepository.Insert(scooter);
        }

        public void UpdateScooter(Scooter scooter)
        {
            _scooterRepository.Update(scooter);
        }
    }
}
