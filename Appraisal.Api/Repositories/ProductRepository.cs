using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;
using Appraisal.Api.Models;
using Appraisal.Api.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Appraisal.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IMongoCollection<Product> _products;
        private readonly IMongoDatabase _database;

        public ProductRepository(IProductDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
            _products = _database.GetCollection<Product>(settings.ProductCollectionName);
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            // var products = _database.GetCollection<Product>("books");
            // var appraisalForms = _database.GetCollection<AppraisalForm>("publishers");
            //
            // var mergedProducts = from product in products.AsQueryable()
            //     join appraisalForm in appraisalForms.AsQueryable() on
            //         product.AppraisalFormId equals appraisalForm.Id
            //     select product;
            //
            //return await Task.FromResult(mergedProducts.ToEnumerable());
            var products = _products.Find(product => true).ToEnumerable();
            return await Task.FromResult(products);
        }

        public Task<Product> GetBySku(string sku)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Product> CreateAsync(Product newProduct)
        {
            await _products.InsertOneAsync(newProduct);
            return await Task.FromResult<Product>(newProduct);
        }

         public async Task<Product> UpdateAsync(Product updatedProduct)
        {
            var result = await _products.ReplaceOneAsync(product => product.Id == updatedProduct.Id, updatedProduct);
            if (result.ModifiedCount > 0)
            {
                return await Task.FromResult(updatedProduct);
            }
            return await Task.FromException<Product>(new KeyNotFoundException(string.Format("Product: {0} was not found", updatedProduct.Title)));
        }
    }
}