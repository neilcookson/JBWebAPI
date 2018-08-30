using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using JBWebAPI.API.Helpers;
using JBWebAPI.API.Models;
using JBWebAPI.Data.Interfaces;
using JBWebAPI.Data.Models;

namespace JBWebAPI.API.Controllers
{
    public class ProductsController : ApiController
    {
        readonly IProductRepository _productRepository;
        readonly IFilterParser<Product> _filterParser;

        public ProductsController(IProductRepository productRepository, IFilterParser<Product> filterParser)
        {
            _productRepository = productRepository;
            _filterParser = filterParser;
        }

        public IHttpActionResult GetProduct (int id)
        {
            var result = _productRepository.GetProductAsync(id).GetAwaiter().GetResult();

            if (result != null) {
                var dto = (ProductDTO)result;
                return Ok(dto);
            }
            return BadRequest($"No matching product found with id {id}"); 
        }

        public IHttpActionResult GetProducts()
        {
            var result = _productRepository.GetAllProductsAsync().GetAwaiter().GetResult();
            var dtoList = result?.Select(x => (ProductDTO)x);
            if (result != null)
            {
                return Ok(dtoList);
            }
            return NotFound();
        }

        public IHttpActionResult GetProducts([FromUri]string fc)
        {
            var predicate = _filterParser.GetFilter(fc);
            var searchResult = _productRepository.FindProductsAsync(predicate).GetAwaiter().GetResult();
            if (searchResult?.Any() ?? false)
            {
                var convertedResult = searchResult.Select(prod => (ProductDTO)prod);
                return Ok(convertedResult);
            }
            return BadRequest("No products matching the filter were found");
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            var result = _productRepository.GetProductAsync(id).GetAwaiter().GetResult();
            if (result is Product productToDelete)
            {
                var deleteSuccesful = _productRepository.RemoveProductAsync(productToDelete).GetAwaiter().GetResult();
                if (deleteSuccesful)
                {
                    return Ok(true);
                }
            }
            return BadRequest($"Unable to delete product with id {id}");
        }
        
        public IHttpActionResult PostProduct([FromBody]ProductDTO productDTO)
        {
            var entity = (Product)productDTO;
            if (entity != null && entity.IsValid)
            {
                var createResult = _productRepository.AddProductAsync(entity).GetAwaiter().GetResult();
                var newProductAsDTO = (ProductDTO)createResult;
                return Created($"api/products/{newProductAsDTO.Id}", newProductAsDTO);
            }
            return BadRequest("Product was not valid");
        }

        public IHttpActionResult PutProduct([FromBody]ProductDTO productDTO)
        {
            var entity = (Product)productDTO;
            if (entity != null && entity.IsValid)
            {
                var putResult = _productRepository.UpdateProductAsync(entity).GetAwaiter().GetResult();
                if (putResult != null)
                {
                    var newProductAsDTO = (ProductDTO)putResult;
                    if (newProductAsDTO != null)
                    {
                        return Ok(newProductAsDTO);
                    }
                }
            }
            return BadRequest("No matching product was found to update");
        }
    }
}
