//File Name : VehiclesController.cs
//Author    : Mathan Vaithilingam
//Description : Vehicles Web API


using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VechicleWebApp.Filters;
using VehiclesRepository.DataRepository;
using VehiclesWebApp.Models;
using VechicleWebApp.Helpers;
using System.Threading.Tasks;

namespace VehiclesWebApp.Api
{
    /// <summary>
    /// Vehicles Web API
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/[Controller]")]
    public class VehiclesController : ApiController
    {
        #region Private Members

        IVehiclesDataRepository vehiclesDataRepository = null;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vehicleDataRepository"></param>
        public VehiclesController(IVehiclesDataRepository vehicleDataRepository)
        {
            this.vehiclesDataRepository = vehicleDataRepository;
        }

        #region WebAPI operations

        /// <summary>
        /// Get All Vehicles
        /// GET /api/Vehicles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(VehicleModel))]
        public HttpResponseMessage GetAllVehicles()
        {
            IList<VehicleModel> vehicles = MappingHelper.ConvertToVehicleViewModelCollection(vehiclesDataRepository.GetAllVehicles());
            return Request.CreateResponse<IList<VehicleModel>>(HttpStatusCode.OK, vehicles);
        }

        /// <summary>
        /// Get Vehicle by Id
        /// GET /api/Vehicles/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(VehicleModel))]
        // GET api/<controller>/5
        public HttpResponseMessage GetVehicleById(int id)
        {
            VehicleModel vehicleModel = MappingHelper.ConvertToVehicleViewModel(vehiclesDataRepository.GetVehicleById(id));
            return Request.CreateResponse<VehicleModel>(HttpStatusCode.OK, vehicleModel);
        }

        /// <summary>
        /// Get Vehicles by Filter attribute
        /// GET /api/Vehicles/Filter/year/2012
        /// </summary>
        /// <param name="filterAttribute"></param>
        /// <param name="filterAttributeValue"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Filter")]
        [ResponseType(typeof(VehicleModel))]
        // GET api/<controller>/5
        public HttpResponseMessage GetAllVehiclesByFilter(string filterAttribute, string filterAttributeValue)
        {
            IList<VehicleModel> vehicles = MappingHelper.ConvertToVehicleViewModelCollection(vehiclesDataRepository.GetAllVehiclesByFilters(filterAttribute, filterAttributeValue));
            return Request.CreateResponse<IList<VehicleModel>>(HttpStatusCode.OK, vehicles);
        }

        /// <summary>
        /// Add Vehicle (Id=0 and RowVersion=null)
        /// POST /api/Vehicles  ; with post data -  VehicleModel
        /// </summary>
        /// <param name="vehicleModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModelActionFilterAttribute]
        //[ResponseType(typeof(VehicleEntity))]
        public async Task<HttpResponseMessage> AddVehicle([FromBody]VehicleModel vehicleModel)
        {
            int responseCode = await vehiclesDataRepository.AddVehicleAsync(MappingHelper.ConvertToVehicleEntity(vehicleModel));
            return Request.CreateResponse<int>(HttpStatusCode.OK, responseCode);
        }

        /// <summary>
        /// Update Vehicle   (RowVersion value should be same to avoid concurrency error)
        /// PUT /api/Vehicles ; with data - VehicleModel
        /// </summary>
        /// <param name="vehicleModel"></param>
        /// <returns></returns>
        [HttpPut]
        [ValidateModelActionFilterAttribute]
        // PUT api/<controller>/5
        public async Task<HttpResponseMessage> UpdateVehicle([FromBody]VehicleModel vehicleModel)
        {
            int responseCode = await vehiclesDataRepository.UpdateVehicleAsync(MappingHelper.ConvertToVehicleEntity(vehicleModel));
            return Request.CreateResponse(HttpStatusCode.OK, responseCode);
        }

        /// <summary>
        /// Delete Vehicle by ID
        /// DELETE api/Vehicles/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        // DELETE api/<controller>/5
        public async Task<HttpResponseMessage> DeleteVehicle(int id)
        {
            int responseCode = await vehiclesDataRepository.DeleteVehicleAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, responseCode);

        }

        #endregion
    }
}