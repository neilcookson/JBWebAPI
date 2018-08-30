﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using JBWebAPI.API.Models;
using JBWebAPI.Data.Interfaces;
using JBWebAPI.Data.Models;

namespace JBWebAPI.API.Controllers
{
    public class ProductsController : ApiController
    {
        readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
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

        public IHttpActionResult DeleteProduct(int id)
        {
            var result = _productRepository.GetProductAsync(id).GetAwaiter().GetResult();
            if (result is Product productToDelete)
            {
                var deleteSuccesful = _productRepository.RemoveProduct(productToDelete).GetAwaiter().GetResult();
                if (deleteSuccesful)
                {
                    return Ok(true);
                }
            }
            return BadRequest($"Unable to delete product with id {id}");
        }
        
        public IHttpActionResult PostProduct(ProductDTO productDTO)
        {
            var entity = (Product)productDTO;
            if (entity != null && entity.IsValid)
            {
                var createResult = _productRepository.AddOrUpdateProductAsync(entity).GetAwaiter().GetResult();
                var newProductAsDTO = (ProductDTO)createResult;
                return Created($"api/products/{newProductAsDTO.Id}", newProductAsDTO);
            }
            return BadRequest("Product was not valid");
        }
    }
}
