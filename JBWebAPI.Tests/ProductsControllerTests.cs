using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using JBWebAPI.API.Controllers;
using JBWebAPI.Data;
using JBWebAPI.Data.Models;
using JBWebAPI.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ProductsControllerTests
    {
        ProductsController productsController = new ProductsController(new ProductRepository(new TestDataLoader(), new TestConfigurationSettings()));

        [DataRow(1)]
        [DataTestMethod]
        public void GeProduct_ReturnsProduct_MatchingId(int id)
        {
            
        }

        [DataRow(999)]
        [DataTestMethod]
        public void GetProduct_ReturnsBadRequest_NoMatchingId(int id)
        {
           
        }

        [TestMethod]
        public void GetAllProducts_ReturnsAllProducts()
        {
            var expectedCount = 99;
            IHttpActionResult controllerResponse = productsController.GetAllProductsAsync().GetAwaiter().GetResult();
            var actualResponse = controllerResponse as OkNegotiatedContentResult<IEnumerable<Product>>;

            Assert.IsNotNull(actualResponse);
            Assert.IsNotNull(actualResponse.Content);
            Assert.AreEqual(expectedCount, actualResponse.Content.Count());
        }
    }
}
