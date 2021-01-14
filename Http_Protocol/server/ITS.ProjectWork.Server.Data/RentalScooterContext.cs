using ITS.ProjectWork.Server.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.ProjectWork.Server.Data
{
    public class RentalScooterContext : DbContext
    {
        public RentalScooterContext(DbContextOptions<RentalScooterContext> options) : base(options)
        {

        }
        public DbSet<Scooter> Scooter { get; set; }
        public DbSet<Sensor> Sensor { get; set; }
    }
}
