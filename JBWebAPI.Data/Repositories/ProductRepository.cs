﻿using JBWebAPI.Data.Interfaces;
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

        public ProductRepository (IDataService dataService, IConfigurationSettings configurationSettings)
        {
            _dataService = dataService;
            availableData = _dataService.LoadDataAsync<DataLoaderResult>(configurationSettings).GetAwaiter().GetResult();
        }

        public Task<bool> AddOrUpdateProductAsync(Product instance)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> FindProductsAsync(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return Task.FromResult(availableData?.Result?.Products);
        }

        public Task<Product> GetProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveProduct(Product instance)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveProduct(string id)
        {
            throw new NotImplementedException();
        }
    }
}
