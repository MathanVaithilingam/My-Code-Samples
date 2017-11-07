using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VehiclesRepository.DataRepository;
using VehiclesWebApp.Api;
using System.Net.Http;
using VehiclesWebApp.Models;
using System.Web.Http;
using System.Net;
using System.Collections.Generic;
using VehiclesRepository.DBContext;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace VechicleWebApp.Tests.Api
{
    [TestClass]
    public class VehiclesControllerTest
    {
        Mock<IVehiclesDataRepository> mockRepository = null;
        VehiclesController apiController = null;

        const string ApiBaseUrl = "http://localhost:62007/";

        /// <summary>
        /// Initialize for every Test
        /// </summary>
        [TestInitialize]
        public void VehicleControllerTestInitialize()
        {
            mockRepository = new Mock<IVehiclesDataRepository>();
            //mockRepository.Setup(r => r.GetAllVehicles()).Returns(new List<Vehicle>() { new Vehicle() { Id = 1, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null }, new Vehicle() { Id = 2, Year = 2010, Make = "Ford", VModel = "Explorer", RowVersion = null } });
            apiController = new VehiclesController(mockRepository.Object);

            apiController.Request = new HttpRequestMessage();
            apiController.Configuration = new HttpConfiguration();
        }

        /// <summary>
        /// Cleanup after every test
        /// </summary>
        [TestCleanup]
        public void VehicleControllerTestCleanup()
        {
            mockRepository = null;
            apiController = null;
        }

       /// <summary>
       /// GetAllVehicles API Test
       /// </summary>
        [TestMethod]
        public void GetAllVehiclesTest()
        {
            
            //apiController = new VehiclesController(mockRepository.Object);

            //apiController.Request = new HttpRequestMessage();
            //apiController.Configuration = new HttpConfiguration();

            mockRepository.Setup(r => r.GetAllVehicles()).Returns(new List<Vehicle>() { new Vehicle() { Id = 1, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null }, new Vehicle() { Id = 2, Year = 2010, Make = "Ford", VModel = "Explorer", RowVersion = null } });


            apiController.Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(ApiBaseUrl + "api/Vehicles")
                };

            var response = apiController.GetAllVehicles();

            IList<VehicleModel> vehicleResult = JsonConvert.DeserializeObject<List<VehicleModel>>(response.Content.ReadAsStringAsync().Result);

            Assert.IsNotNull(response);
            Assert.AreEqual<HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(vehicleResult);
            Assert.IsTrue(vehicleResult.Count == 2);
        }

        /// <summary>
        /// GetVehicleById API Test
        /// </summary>
        [TestMethod]
        public void GetAllVehicleByIdTest()
        {
            mockRepository.Setup(r => r.GetVehicleById(1)).Returns(new Vehicle() { Id = 1, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null });

            var response = apiController.GetVehicleById(1);

            VehicleModel vehicleResult = null;
            response.TryGetContentValue<VehicleModel>(out vehicleResult);

            Assert.IsNotNull(response);
            Assert.AreEqual<HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(vehicleResult);
            Assert.IsTrue(vehicleResult.Id == 1);

        }

        /// <summary>
        /// GetAllVehiclesByFilter API Test
        /// </summary>
        [TestMethod]
        public void GetAllVehiclesByFilterTest()
        {
            mockRepository.Setup(r => r.GetAllVehiclesByFilters("year", "2010")).Returns(new List<Vehicle>() { new Vehicle() { Id = 1, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null }, new Vehicle() { Id = 2, Year = 2010, Make = "Ford", VModel = "Explorer", RowVersion = null } });

            var response = apiController.GetAllVehiclesByFilter("year","2010");

            IList<VehicleModel> vehicleResult = null;
            response.TryGetContentValue<IList<VehicleModel>>(out vehicleResult);

            Assert.IsNotNull(response);
            Assert.AreEqual<HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(vehicleResult);
            Assert.IsTrue(vehicleResult.Count == 2);

        }

        /// <summary>
        /// AddVehicle API Test
        /// </summary>
        [TestMethod]
        public void AddVehicleTest()
        {
            var vehicle = new Vehicle() { Id = 0, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null };
            mockRepository.Setup(r => r.AddVehicleAsync(vehicle)).Returns(Task.FromResult(1));

            //apiController.Request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri(ApiBaseUrl + "api/Vehicles")
            //};
            
            var response = apiController.AddVehicle(new VehicleModel() { Id = 0, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null }).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual<HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);

        }

        /// <summary>
        /// UpdateVehicle API Test
        /// </summary>
        [TestMethod]
        public void UpdateVehicleTest()
        {
            var vehicle = new Vehicle() { Id = 1, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null };
            mockRepository.Setup(r => r.UpdateVehicleAsync(vehicle)).Returns(Task.FromResult(1));

            var response = apiController.UpdateVehicle(new VehicleModel() { Id = 1, Year = 1997, Make = "TestMake", VModel = "TestModel", }).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual<HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);

        }

        /// <summary>
        /// DeleteVehicle API Test
        /// </summary>
        [TestMethod]
        public void DeleteVehicleTest()
        {
            var vehicle = new Vehicle() { Id = 1, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null };
            mockRepository.Setup(r => r.UpdateVehicleAsync(vehicle)).Returns(Task.FromResult(1));

            mockRepository.Setup(r => r.DeleteVehicleAsync(1)).Returns(Task.FromResult(1));

            var response = apiController.DeleteVehicle(2).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual<HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
