using System.Collections.Generic;
using System.Data.Entity;

namespace VehiclesRepository.DBContext
{
    public class VehiclesDbContext : DbContext
    {
        // Your context has been configured to use a 'VehiclesDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'VehiclesRepository.DbContext.VehiclesDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'VehiclesDbContext' 
        // connection string in the application configuration file.
        public VehiclesDbContext()
            : base("name=VehiclesDbContext")
        {
            Database.SetInitializer(new VehiclesDBInitializer());
            // Database.SetInitializer<VehiclesDbContext>(new DropCreateDatabaseIfModelChanges<VehiclesDbContext>());
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<VehiclesDbContext, Configuration>("VehiclesDbContext"));
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// Initialize VehicleDBContext
    /// </summary>
    public class VehiclesDBInitializer : CreateDatabaseIfNotExists<VehiclesDbContext>
    {
        //Initialize the database with default data
        protected override void Seed(VehiclesDbContext context)
        {
            //Add Vehicles
            IList<Vehicle> defaultVehicles = new List<Vehicle>();

            defaultVehicles.Add(new Vehicle() { Id = 0, Make = "Nissan", VModel = "Altima", Year = 2012 });
            defaultVehicles.Add(new Vehicle() { Id = 0, Make = "Toyota", VModel = "Camry", Year = 2008 });
            defaultVehicles.Add(new Vehicle() { Id = 0, Make = "Ford", VModel = "Explorer", Year = 2000 });
            defaultVehicles.Add(new Vehicle() { Id = 0, Make = "GMC", VModel = "Acadia", Year = 2010 });

            foreach (Vehicle vehicle in defaultVehicles)
            {
                context.Vehicles.Add(vehicle);
            }

            //Add Users
            IList<User> defaultUsers = new List<User>();

            defaultUsers.Add(new User() { FirstName = "Admin", LastName = "Admin", UserId = "admin", Password = "password" });
            defaultUsers.Add(new User() { FirstName = "NormalUser", LastName = "NormalUser", UserId = "normaluser", Password = "password" });

            foreach (User user in defaultUsers)
            {
                context.Users.Add(user);
            }

            base.Seed(context);
        }
    }
}