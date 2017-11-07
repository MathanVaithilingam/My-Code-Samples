using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using VehiclesRepository.DBContext;

namespace VehiclesRepository.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<VehiclesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VehiclesDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
