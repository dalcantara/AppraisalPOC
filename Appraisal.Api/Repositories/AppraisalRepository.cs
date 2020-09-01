using System.Collections.Generic;
using System.Threading.Tasks;
using Appraisal.Api.Settings;
using MongoDB.Driver;

namespace Appraisal.Api.Repositories
{
    public class AppraisalRepository : IAppraisalRepository
    {
        private IMongoCollection<Models.Appraisal> _Appraisals;

        public AppraisalRepository(IProductDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);  
            var database = client.GetDatabase(settings.DatabaseName);
            _Appraisals = database.GetCollection<Models.Appraisal>(settings.AppraisalCollectionName);
        }
        public async Task<IEnumerable<Models.Appraisal>> GetAllAsync()
        {
            var Appraisals = _Appraisals.Find(Appraisal => true).ToEnumerable();
            return await Task.FromResult(Appraisals);
        }

        public Task<Models.Appraisal> GetBySku(string sku)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Models.Appraisal> CreateAsync(Models.Appraisal newAppraisal)
        {
            await _Appraisals.InsertOneAsync(newAppraisal);
            return await Task.FromResult<Models.Appraisal>(newAppraisal);
        }
        
        public async Task<Models.Appraisal> UpdateAsync(Models.Appraisal updatedAppraisal)
        {
            var result = await _Appraisals.ReplaceOneAsync(Appraisal => Appraisal.Id == updatedAppraisal.Id, updatedAppraisal);
            if (result.ModifiedCount > 0)
            {
                return await Task.FromResult(updatedAppraisal);
            }
            return await Task.FromException<Models.Appraisal>(new KeyNotFoundException(string.Format("Appraisal: {0} was not found", updatedAppraisal.AppraisalForm.Title)));
        }
    }
}