using JBWebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace JBWebAPI.API.Models
{
    public class ProductDTO
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }

        public static explicit operator ProductDTO(Product productEntity)
        {
            return new ProductDTO()
            {
                Id = productEntity.ProductID.ToString(),
                Description = productEntity.Category,
                Model = productEntity.DisplayName,
                Brand = productEntity.Brand
            };
        }

        public static explicit operator Product(ProductDTO productDTO)
        {
            int productId;

            return new Product()
            {
                ProductID = Int32.TryParse(productDTO.Id, out productId) ? productId : 0,
                Category = productDTO.Description,
                DisplayName = productDTO.Model,
                Brand = productDTO.Brand
            };
        }
    }
}