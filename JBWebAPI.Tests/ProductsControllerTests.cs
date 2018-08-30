using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using JBWebAPI.API.Controllers;
using JBWebAPI.API.Models;
using JBWebAPI.Data;
using JBWebAPI.Data.Models;
using JBWebAPI.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ProductsControllerTests
    {
        ProductsController productsController = new ProductsController(new ProductRepository(new TestDataService(), new TestConfigurationSettings()));

        [DataRow(866140)]
        [DataRow(868389)]
        [DataRow(884573)]
        [DataTestMethod]
        public void GeProduct_ReturnsProduct_MatchingId(int id)
        {
            IHttpActionResult controllerResponse = productsController.GetProduct(id);
            var actualResponse = controllerResponse as OkNegotiatedContentResult<ProductDTO>;

            Assert.IsNotNull(actualResponse);
            Assert.IsNotNull(actualResponse.Content);
            Assert.AreEqual(typeof(ProductDTO), actualResponse.Content.GetType());
        }

        [DataRow(0)]
        [DataRow(-1)]
        [DataTestMethod]
        public void GetProduct_ReturnsBadRequestMessage_NoMatchingId(int id)
        {
            IHttpActionResult controllerResponse = productsController.GetProduct(id);
            var expectedMessage = $"No matching product found with id {id}";
            var actualResponse = controllerResponse as BadRequestErrorMessageResult;

            Assert.IsNotNull(actualResponse);
            Assert.AreEqual(expectedMessage, actualResponse.Message);
        }

        [TestMethod]
        public void GetAllProducts_ReturnsAllProducts()
        {
            var expectedCount = 99;
            IHttpActionResult controllerResponse = productsController.GetProducts();
            var actualResponse = controllerResponse as OkNegotiatedContentResult<IEnumerable<ProductDTO>>;

            Assert.IsNotNull(actualResponse);
            Assert.IsNotNull(actualResponse.Content);
            Assert.AreEqual(expectedCount, actualResponse.Content.Count());
        }
    }
}
