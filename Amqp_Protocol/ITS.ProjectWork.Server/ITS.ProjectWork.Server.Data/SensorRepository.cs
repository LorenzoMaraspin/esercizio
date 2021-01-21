using Dapper;
using Dapper.Contrib.Extensions;
using ITS.ProjectWork.Server.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ITS.ProjectWork.Server.Data
{
    public class SensorRepository : ISensorRepository
    {
        private readonly string _connectionString;
        public SensorRepository()
        {
            this._connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        public int Count()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string query = "select Count(*) from Scooter";
                return connection.ExecuteScalar<int>(query);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Delete(new Sensor
                {
                    SensorId = id
                });

                //var category = connection.Get<Category>(id);
                //connection.Delete(category);
            }
        }

        public Sensor Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<Sensor>(id);
            }
        }

        public IEnumerable<Sensor> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Sensor>();
            }
        }

        public void Insert(Sensor entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Insert(entity);
            }
        }

        public void Update(Sensor entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Update(entity);
            }
        }
    }
}
