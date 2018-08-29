using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using JBWebAPI.API.Models;
using JBWebAPI.Data.Interfaces;

namespace JBWebAPI.API.Controllers
{
    public class ProductsController : ApiController
    {
        readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IHttpActionResult> GetProductAsync (int id)
        {
            var result = await _productRepository.GetProductAsync(id.ToString());
            var dto = (ProductDTO)result;
            if (result != null) {
                return Ok(dto);
            }
            return BadRequest($"No matching product found with id {id.ToString()}"); 
        }

        public async Task<IHttpActionResult> GetAllProductsAsync()
        {
            var result = await _productRepository.GetAllProductsAsync();
            var dtoList = result?.Select(x => (ProductDTO)x);
            if (result != null)
            {
                return Ok(dtoList);
            }
            return NotFound();
        }
    }
}
