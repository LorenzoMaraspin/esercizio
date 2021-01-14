using ITS.ProjectWork.Server.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Server.Data
{
    public interface IScooterRepository
    {
        IEnumerable<Scooter> GetAll();
        Scooter GetById(int id);

        void Insert(Scooter entity);

        void Update(Scooter entity);

        void Delete(int id);

        int Count();
    }
}
