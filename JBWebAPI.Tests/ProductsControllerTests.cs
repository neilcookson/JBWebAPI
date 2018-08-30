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

        [DataRow(866140)]
        [DataRow(868389)]
        [DataRow(884573)]
        [DataTestMethod]
        public void DeleteProduct_ReturnsTrue_MatchingId(int id)
        {
            var expectedResponse = true;
            IHttpActionResult controllerResponse = productsController.DeleteProduct(id);
            var actualResponse = controllerResponse as OkNegotiatedContentResult<bool>;

            Assert.AreEqual(expectedResponse, actualResponse.Content);
        }

        [DataRow(0)]
        [DataRow(-1)]
        [DataTestMethod]
        public void DeleteProduct_ReturnsBadRequestMessage_NoMatchingId(int id)
        {
            var expectedResponse = $"Unable to delete product with id {id}";
            IHttpActionResult controllerResponse = productsController.DeleteProduct(id);
            var actualResponse = controllerResponse as BadRequestErrorMessageResult;

            Assert.AreEqual(expectedResponse, actualResponse.Message);
        }

        [TestMethod]
        public void PostProduct_ReturnsProductDTO_ValidProduct()
        {
            var existingProducts = productsController.GetProducts() as OkNegotiatedContentResult<IEnumerable<ProductDTO>>;
            var expectedIdString = existingProducts.Content.OrderByDescending(prod => prod.Id).Last().Id;
            int expectedIdInt = Int32.Parse(expectedIdString) + 1;
            ProductDTO newProduct = new ProductDTO()
            {
                Description = "This is a brand new product",
                Brand = "Acme Inc",
                Model = "Awesome-o 9000"
            };
            var createdProductResult = productsController.PostProduct(newProduct) as CreatedNegotiatedContentResult<ProductDTO>;
            Assert.IsNotNull(createdProductResult);
            Assert.IsNotNull(createdProductResult.Content);
            Assert.AreEqual(typeof(ProductDTO), createdProductResult.Content.GetType());
            Assert.AreEqual(createdProductResult.Content.Id, expectedIdInt.ToString());
        }

        [TestMethod]
        public void PostProduct_BadRequestMessage_InvalidProduct()
        {
            var expectedErrorMsg = "Product was not valid";
            ProductDTO newProduct = new ProductDTO()
            {
                Description = "This is a brand new product",
                Model = "Awesome-o 9000"
            };
            var badRequestErrorMessageResult = productsController.PostProduct(newProduct) as BadRequestErrorMessageResult;
            Assert.IsNotNull(badRequestErrorMessageResult);
            Assert.AreEqual(expectedErrorMsg, badRequestErrorMessageResult.Message);
        }
    }
}
