using JBWebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBWebAPI.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(string id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> FindProductsAsync(Func<Product, bool> predicate);
        Task<bool> AddOrUpdateProductAsync(Product instance);
        Task<bool> RemoveProduct(Product instance);
        Task<bool> RemoveProduct(string id);
    }
}
