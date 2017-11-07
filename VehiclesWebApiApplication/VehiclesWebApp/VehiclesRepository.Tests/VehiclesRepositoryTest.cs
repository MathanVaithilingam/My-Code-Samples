using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclesRepository.DataRepository;
using VehiclesRepository.DBContext;

namespace VehiclesRepository.Tests
{
    [TestClass]
    public class VehiclesRepositoryTest
    {
        Mock<IVehiclesDataRepository> mockRepository = null;
        

        /// <summary>
        /// Initialize for every Test
        /// </summary>
        [TestInitialize]
        public void VehicleRepositoryTestInitialize()
        {
            mockRepository = new Mock<IVehiclesDataRepository>();
            
        }

        /// <summary>
        /// Cleanup after every test
        /// </summary>
        [TestCleanup]
        public void VehicleRepositoryTestCleanup()
        {
            mockRepository = null;
        }

        [TestMethod]
        public void GetAllVehiclesTest()
        {
            mockRepository.Setup(r => r.GetAllVehicles()).Returns(new List<Vehicle>() { new Vehicle() { Id = 1, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null }, new Vehicle() { Id = 2, Year = 2010, Make = "Ford", VModel = "Explorer", RowVersion = null } });

            var response = mockRepository.Object.GetAllVehicles();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count > 0);
        }

        [TestMethod]
        public void GetVehicleByIdTest()
        {

            mockRepository.Setup(r => r.GetVehicleById(1)).Returns(new Vehicle() { Id = 1, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null });
            var response = mockRepository.Object.GetVehicleById(1);

            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Id);
        }

        [TestMethod]
        public void GetAllVehiclesByFiltersTest()
        {
            mockRepository.Setup(r => r.GetAllVehiclesByFilters("year", "2010")).Returns(new List<Vehicle>() { new Vehicle() { Id = 1, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null }, new Vehicle() { Id = 2, Year = 2010, Make = "Ford", VModel = "Explorer", RowVersion = null } });
            var response = mockRepository.Object.GetAllVehiclesByFilters("year","2010");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count == 2);
        }

        [TestMethod]
        public void AddVehicleTest()
        {
            var vehicle = new Vehicle() { Id = 0, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null };
            mockRepository.Setup(r => r.AddVehicleAsync(vehicle)).Returns(Task.FromResult(1));
            var response = mockRepository.Object.AddVehicleAsync(vehicle).Result;
            mockRepository.Verify(r => r.AddVehicleAsync(vehicle), Times.Once());

            Assert.IsNotNull(response);
            Assert.IsTrue(response > 0);
        }

        [TestMethod]
        public void UpdateVehicleTest()
        {
            var vehicle = new Vehicle() { Id = 1, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null };
            mockRepository.Setup(r => r.UpdateVehicleAsync(vehicle)).Returns(Task.FromResult(1));
            var response = mockRepository.Object.UpdateVehicleAsync(vehicle).Result;
            mockRepository.Verify(r => r.UpdateVehicleAsync(vehicle), Times.Once());

            Assert.IsNotNull(response);
            Assert.IsTrue(response > 0);
        }

        [TestMethod]
        public void DeleteVehicleTest()
        {
            var vehicle = new Vehicle() { Id = 1, Year = 2010, Make = "Toyota", VModel = "Camry", RowVersion = null };
            mockRepository.Setup(r => r.UpdateVehicleAsync(vehicle)).Returns(Task.FromResult(1));

            mockRepository.Setup(r => r.DeleteVehicleAsync(1)).Returns(Task.FromResult(1));
            var response = mockRepository.Object.DeleteVehicleAsync(1).Result;

            mockRepository.Setup(r => r.GetVehicleById(1));
            var deletedVehicle = mockRepository.Object.GetVehicleById(1);

            mockRepository.Verify(r => r.DeleteVehicleAsync(1), Times.Once());
            

            Assert.IsNotNull(response);
            Assert.IsTrue(response > 0);
            Assert.IsNull(deletedVehicle);
        }
    }
}
