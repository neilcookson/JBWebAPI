using JBWebAPI.Data.Interfaces;
using JBWebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JBWebAPI.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly IDataService _dataService;
        readonly DataLoaderResult availableData;
        List<Product> Products { get; set; }

        public ProductRepository (IDataService dataService, IConfigurationSettings configurationSettings)
        {
            _dataService = dataService;
            availableData = _dataService.LoadData<DataLoaderResult>(configurationSettings);
            Products = new List<Product>(availableData?.Result?.Products);
        }

        public Task<Product> AddProductAsync(Product newProduct)
        {
            var existingProduct = Products?.Where(product => product.ProductID == newProduct.ProductID)?.FirstOrDefault();
            if (existingProduct == null)
            {
                newProduct.ProductID = Products.OrderByDescending(prod => prod.ProductID).Last().ProductID + 1;
                Products.Add(newProduct);
                return Task.FromResult(newProduct);
            }
            return Task.FromResult(default(Product));
        }

        public Task<Product> UpdateProductAsync(Product newProduct)
        {
            var existingProduct = Products?.Where(product => product.ProductID == newProduct.ProductID)?.FirstOrDefault();
            if (existingProduct == null)
            {
                return Task.FromResult(default(Product));
            }
            var removeResult = Products?.Remove(existingProduct);
            if(removeResult ?? false)
            {
                Products?.Add(newProduct);
                var insertedProduct = Products?.Where(prod => prod.ProductID == newProduct.ProductID)?.FirstOrDefault();
                return Task.FromResult(insertedProduct ?? default(Product));
            }
            return Task.FromResult(default(Product));
        }

        public Task<IEnumerable<Product>> FindProductsAsync(Func<Product, bool> predicate)
        {
            var result = Products.Where(predicate);
            return Task.FromResult(result);
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(Products);
        }

        public Task<Product> GetProductAsync(int id)
        {
            return Task.FromResult(Products?.Where(product => product.ProductID == id)?.FirstOrDefault() ?? default(Product));
        }

        public Task<bool> RemoveProductAsync(Product instance)
        {
            return Task.FromResult(Products?.Remove(instance) ?? false);
        }
    }
}
