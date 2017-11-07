//File Name : IVehiclesDataRepository.cs
//Author    : Mathan Vaithilingam
//Description : Vehicles data repository

using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclesRepository.DBContext;

namespace VehiclesRepository.DataRepository
{
    /// <summary>
    /// Vehicles Data Repository interface
    /// </summary>
    public interface IVehiclesDataRepository
    {
        IList<Vehicle> GetAllVehicles();
        Vehicle GetVehicleById(int id);
        IList<Vehicle> GetAllVehiclesByFilters(string filterAttribute, string filterAttributeValue);
        Task<int> AddVehicleAsync(Vehicle vehicle);
        int AddVehicle(Vehicle vehicle);
        Task<int> UpdateVehicleAsync(Vehicle vehicle);
        Task<int> DeleteVehicleAsync(int id);
    }
}
