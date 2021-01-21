using System;
using System.Collections.Generic;
using System.Text;
using ITS.ProjectWork.Server.Data;
using ITS.ProjectWork.Server.Model;

namespace ITS.ProjectWork.Server.Service
{
    public interface IScooterService
    {
        IEnumerable<Scooter> GetAllScooters();
        void InsertScooter(Scooter scooter);
        int CountAllScooters();
        void DeleteScooter(int id);
        Scooter GetScooterById(int id);
        void UpdateScooter(Scooter scooter);
    }
}
