//File Name : VehiclesDataRepository.cs
//Author    : Mathan Vaithilingam
//Description : Vehicles data repository

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesRepository.DBContext;

namespace VehiclesRepository.DataRepository
{
    /// <summary>
    /// Vehicles CRUD operations
    /// </summary>
    public class VehiclesDataRepository : IVehiclesDataRepository, IDisposable
    {
        private VehiclesDbContext vehiclesDbEntities = new VehiclesDbContext();


        /// <summary>
        /// Get All Vehicles
        /// </summary>
        /// <returns></returns>
        public IList<Vehicle> GetAllVehicles()
        {
            IList<Vehicle> vehicles;
            using (VehiclesDbContext vehiclesDbEntities = new VehiclesDbContext())
            {
                vehicles = vehiclesDbEntities.Vehicles.ToList();
            }
            return vehicles;
        }

        /// <summary>
        /// Get Vehicle by ID  (Throw exception if vehicle id is not available in data storage)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Vehicle GetVehicleById(int id)
        {
            return vehiclesDbEntities.Vehicles.Single(v => v.Id == id);
        }


        /// <summary>
        /// Get All Vehicles by Filer Attribute value
        /// </summary>
        /// <param name="filterAttribute"></param>
        /// <param name="filterAttributeValue"></param>
        /// <returns></returns>
        public IList<Vehicle> GetAllVehiclesByFilters(string filterAttribute, string filterAttributeValue)
        {
            IList<Vehicle> vehicles = null;

            if (filterAttribute.Equals("vid"))
            {
                int id = Convert.ToInt32(filterAttributeValue);
                vehicles = vehiclesDbEntities.Vehicles.Where(x => x.Id == id).ToList();
            }
            else if (filterAttribute.Equals("year"))
            {
                int year = Convert.ToInt32(filterAttributeValue);
                vehicles = vehiclesDbEntities.Vehicles.Where(x => x.Year == year).ToList();
            }
            else if (filterAttribute.Equals("make"))
            {
                vehicles = vehiclesDbEntities.Vehicles.Where(x => x.Make.Equals(filterAttributeValue)).ToList();
            }
            else if (filterAttribute.Equals("vmodel"))
            {
                vehicles = vehiclesDbEntities.Vehicles.Where(x => x.VModel.Equals(filterAttributeValue)).ToList();
            }
            else
            {
                vehicles = vehiclesDbEntities.Vehicles.ToList();
            }
            return vehicles;
        }

        /// <summary>
        /// Add new Vehicle (Id=0 and RowVersion=null )
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<int> AddVehicleAsync(Vehicle vehicle)
        {
            vehicle = vehiclesDbEntities.Vehicles.Add(vehicle);
            return await vehiclesDbEntities.SaveChangesAsync();
        }

        public int AddVehicle(Vehicle vehicle)
        {
            vehicle = vehiclesDbEntities.Vehicles.Add(vehicle);
            return vehiclesDbEntities.SaveChanges();
        }

        /// <summary>
        /// Update existing Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public async Task<int> UpdateVehicleAsync(Vehicle vehicle)
        {
            vehicle = vehiclesDbEntities.Vehicles.Attach(vehicle);
            vehiclesDbEntities.Entry(vehicle).State = System.Data.Entity.EntityState.Modified;
            return await vehiclesDbEntities.SaveChangesAsync();
        }


        /// <summary>
        /// Delete Vehicle by ID (Throw exception if vehicle id is not available in data storage)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteVehicleAsync(int id)
        {
            var vehicle = vehiclesDbEntities.Vehicles.Single(v => v.Id == id);
            vehiclesDbEntities.Vehicles.Remove(vehicle);
            return await vehiclesDbEntities.SaveChangesAsync();
        }

        /// <summary>
        /// Clear DbEntities memory allocation
        /// </summary>
        /// <param name="disposing"></param>
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (vehiclesDbEntities != null)
                {
                    vehiclesDbEntities.Dispose();
                    vehiclesDbEntities = null;
                }
            }
        }


        /// <summary>
        /// Dispose DbEntities - IDisposable member
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
