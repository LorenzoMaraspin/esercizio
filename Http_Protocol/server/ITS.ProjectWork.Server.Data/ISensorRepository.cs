using ITS.ProjectWork.Server.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Server.Data
{
    public interface ISensorRepository
    {
        IEnumerable<Sensor> GetAll();
        Sensor GetById(int id);

        void Insert(Sensor entity);

        void Update(Sensor entity);

        void Delete(int id);

        int Count();
    }
}
