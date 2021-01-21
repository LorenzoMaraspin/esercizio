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
    public class ScooterRepository : IScooterRepository
    {
        private readonly string _connectionString;
        public ScooterRepository()
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
                connection.Delete(new Scooter
                {
                    ScooterId = id
                });

                //var category = connection.Get<Category>(id);
                //connection.Delete(category);
            }
        }

        public Scooter Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<Scooter>(id);
            }
        }

        public IEnumerable<Scooter> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Scooter>();
            }
        }

        public void Insert(Scooter entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Insert(entity);
            }
        }

        public void Update(Scooter entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Update(entity);
            }
        }
    }
}
