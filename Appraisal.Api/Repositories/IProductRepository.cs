using System.Collections.Generic;
using System.Threading.Tasks;
using Appraisal.Shared.Models;


namespace Appraisal.Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetBySku(string sku);
        Task<Product> CreateAsync(Product newProduct);
        Task<Product> UpdateAsync(Product updatedProduct);
    }
}