using App.Domain.Core.Cars.Entity;
using App.Domain.Core.Log.Entity;
using App.Domain.Core.Operators.Entity;
using App.Domain.Core.Request.Entity;
using App.Infrastructure.Db.SqlServer.Ef.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Db.SqlServer.Ef
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<InspectionRequest> InspectionRequests { get; set; }
        public DbSet<InspectionLog> InspectionLogs { get; set; }
        public DbSet<Operator> Operators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new InspectionRequestConfiguration());

            modelBuilder.Entity<CarModel>().HasData(
                new CarModel { Id = 1, Name = "پژو 207" },
                new CarModel { Id = 2, Name = "رانا" },
                new CarModel { Id = 3, Name = "سمند" },
                new CarModel { Id = 4, Name = "کوییک" },
                new CarModel { Id = 5, Name = "تیبا" }
            );

            modelBuilder.Entity<Operator>().HasData(
                new Operator
                {
                    Id = 1,
                    Username = "admin",
                    Password = "1234"
                }
            );
        }


    }
}
