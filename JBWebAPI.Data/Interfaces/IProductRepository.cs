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
        Task<Product> GetProductAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> FindProductsAsync(Func<Product, bool> predicate);
        Task<Product> AddOrUpdateProductAsync(Product instance);
        Task<bool> RemoveProductAsync(Product instance);
    }
}
