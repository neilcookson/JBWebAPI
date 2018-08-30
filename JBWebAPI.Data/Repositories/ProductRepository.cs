using JBWebAPI.Data.Interfaces;
using JBWebAPI.Data.Models;
using System;
using System.Collections.Generic;
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
        List<Product> Products => availableData?.Result?.Products?.ToList();

        public ProductRepository (IDataService dataService, IConfigurationSettings configurationSettings)
        {
            _dataService = dataService;
            availableData = _dataService.LoadData<DataLoaderResult>(configurationSettings);
        }

        public Task<Product> AddOrUpdateProductAsync(Product newProduct)
        {
            var existingProduct = Products?.Where(product => product.Equals(newProduct))?.FirstOrDefault();
            if (existingProduct == null)
            {
                newProduct.ProductID = Products.OrderByDescending(prod => prod.ProductID).Last().ProductID + 1;
                Products.Add(newProduct);
            }
            Products?.Remove(existingProduct);
            Products?.Add(newProduct);
            return Task.FromResult(newProduct);
        }

        public Task<IEnumerable<Product>> FindProductsAsync(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(Products);
        }

        public Task<Product> GetProductAsync(int id)
        {
            return Task.FromResult(Products?.Where(product => product.ProductID == id)?.FirstOrDefault() ?? default(Product));
        }

        public Task<bool> RemoveProduct(Product instance)
        {
            return Task.FromResult(Products?.Remove(instance) ?? false);
        }

        public Task<bool> RemoveProduct(string id)
        {
            throw new NotImplementedException();
        }
    }
}
