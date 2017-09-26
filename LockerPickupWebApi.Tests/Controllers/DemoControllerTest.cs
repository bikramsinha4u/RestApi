using LockerPickupDAL.Models;
using LockerPickupDAL.Services;
using LockerPickupWebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace LockerPickupWebApi.Tests.Controllers
{
    [TestClass]
    public class DemoControllerTest
    {
        DemoController controller;
        List<OrdersData> expectedResult;

        [TestInitialize]
        public void Setup()
        {
            LockerPickupWebApi.Tests.App_Start.AutoMapperConfig.Configure();
            this.expectedResult = new List<OrdersData>{
                new OrdersData() { Id = 1, Name = "Bk" },
                new OrdersData() { Id = 2, Name = "Sk" },
                new OrdersData() { Id = 3, Name = "Pk" }
                //new OrdersData() { Id = 4, Name = "Gk" },
                //new OrdersData() { Id = 5, Name = "Dk" },
            };
            var messagingService = new Mock<IDemoService>();
            messagingService.Setup(x => x.GetOrders()).Returns(expectedResult);
            controller = new DemoController(messagingService.Object);

            controller.Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/LockerPickupWebApi/api/demo/orders") };
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.MapHttpAttributeRoutes();
            controller.Configuration.EnsureInitialized();
        }

        [TestMethod]
        public void GetAllOrders_ShouldReturnAllOrders()
        {
            // Arrange            


            // Act
            var result = controller.Get() as System.Web.Http.Results.OkNegotiatedContentResult<System.Linq.IQueryable<object>>;

            // Assert
            Assert.IsNotNull(result);   
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var expectedJson = serializer.Serialize(expectedResult);
            var actualJson = serializer.Serialize(result.Content);
            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}
