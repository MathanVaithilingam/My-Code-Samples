using System.Collections.Generic;
using VehiclesRepository.DBContext;
using VehiclesWebApp.Models;

namespace VechicleWebApp.Helpers
{
    /// <summary>
    /// Helper to map between ViewModel to Entity
    /// </summary>
    public static class MappingHelper
    {
        /// <summary>
        /// Map from Vehicle Entity to ViewModel
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public static VehicleModel ConvertToVehicleViewModel(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return null;
            }

            return new VehicleModel()
            {
                Id = vehicle.Id,
                Year = vehicle.Year,
                Make = vehicle.Make,
                VModel = vehicle.VModel,
                RowVersion = vehicle.RowVersion
            };
        }

        /// <summary>
        /// Map from Vehicle ViewModel to Entity
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public static Vehicle ConvertToVehicleEntity(VehicleModel vehicle)
        {
            if(vehicle == null)
            {
                return null;
            }

            return new Vehicle()
            {
                Id = vehicle.Id,
                Year = vehicle.Year,
                Make = vehicle.Make,
                VModel = vehicle.VModel,
                RowVersion = vehicle.RowVersion
            };
        }

        /// <summary>
        /// Map from Vehicle entity collection to viewModel Collection
        /// </summary>
        /// <param name="vehicles"></param>
        /// <returns></returns>
        public static IList<VehicleModel> ConvertToVehicleViewModelCollection(IList<Vehicle> vehicles)
        {

            if (vehicles == null)
            {
                return null;
            }

            IList<VehicleModel> vehicleModels = new List<VehicleModel>();
            foreach (Vehicle vehicle in vehicles)
            {
                vehicleModels.Add(new VehicleModel()
                {
                    Id = vehicle.Id,
                    Year = vehicle.Year,
                    Make = vehicle.Make,
                    VModel = vehicle.VModel,
                    RowVersion = vehicle.RowVersion
                });
            }
            return vehicleModels;
        }

        /// <summary>
        /// Map from Vehicle ViewModel collection to Entity collection
        /// </summary>
        /// <param name="vehicleModels"></param>
        /// <returns></returns>
        public static IList<Vehicle> ConvertToVehicleEntityCollection(IList<VehicleModel> vehicleModels)
        {
            if (vehicleModels == null)
            {
                return null;
            }

            IList<Vehicle> vehicles = new List<Vehicle>();
            foreach (VehicleModel vehicleModel in vehicleModels)
            {
                vehicles.Add(new Vehicle()
                {
                    Id = vehicleModel.Id,
                    Year = vehicleModel.Year,
                    Make = vehicleModel.Make,
                    VModel = vehicleModel.VModel,
                    RowVersion = vehicleModel.RowVersion
                });
            }
            return vehicles;
        }

    }
}