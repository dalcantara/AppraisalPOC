using System.Collections.Generic;
using System.Threading.Tasks;
using Appraisal.Api.Settings;
using MongoDB.Driver;

namespace Appraisal.Api.Repositories
{
    public class AppraisalRepository : IAppraisalRepository
    {
        private IMongoCollection<Shared.Models.Appraisal> _Appraisals;
        private IMongoCollection<Shared.Models.AppraisalFormAnswers> _appraisalHistory;

        public AppraisalRepository(IProductDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);  
            var database = client.GetDatabase(settings.DatabaseName);
            _Appraisals = database.GetCollection<Shared.Models.Appraisal>(settings.AppraisalCollectionName);
            _appraisalHistory = database.GetCollection<Shared.Models.AppraisalFormAnswers>("AppraisalHistory");
        }
        public async Task<IEnumerable<Shared.Models.Appraisal>> GetAllAsync()
        {
            var appraisals = _Appraisals.Find(appraisal => true).ToEnumerable();
            return await Task.FromResult(appraisals);
        }

        public Task<Shared.Models.Appraisal> GetBySku(string sku)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Shared.Models.Appraisal> CreateAsync(Shared.Models.Appraisal newAppraisal)
        {
            await _Appraisals.InsertOneAsync(newAppraisal);
            return await Task.FromResult<Shared.Models.Appraisal>(newAppraisal);
        }

        public async Task<Shared.Models.Appraisal> UpdateAsync(Shared.Models.Appraisal updatedAppraisal)
        {
            var result = await _Appraisals.ReplaceOneAsync(Appraisal => Appraisal.Id == updatedAppraisal.Id, updatedAppraisal);
            if (result.ModifiedCount > 0)
            {
                return await Task.FromResult(updatedAppraisal);
            }
            return await Task.FromException<Shared.Models.Appraisal>(new KeyNotFoundException(string.Format("Appraisal: {0} was not found", updatedAppraisal.AppraisalForm.Title)));
        }

        public async Task<Shared.Models.Appraisal> CreateWithHistoryAsync(Shared.Models.Appraisal newAppraisal)
        {
            await _Appraisals.InsertOneAsync(newAppraisal);
            //await _appraisalHistory.InsertOneAsync(newAppraisal.AppraisalFormAnswers);
            return await Task.FromResult<Shared.Models.Appraisal>(newAppraisal);
        }
        public async Task<Shared.Models.Appraisal> UpdateWithHistoryAsync(Shared.Models.Appraisal updatedAppraisal)
        {
            var result = await _Appraisals.ReplaceOneAsync(Appraisal => Appraisal.Id == updatedAppraisal.Id, updatedAppraisal);
            if (result.ModifiedCount > 0)
            {
                return await Task.FromResult(updatedAppraisal);
            }
            return await Task.FromException<Shared.Models.Appraisal>(new KeyNotFoundException(string.Format("Appraisal: {0} was not found", updatedAppraisal.AppraisalForm.Title)));
        }
        public async Task<Shared.Models.Appraisal> GetAllWithHistoryAsync(Shared.Models.Appraisal newAppraisal)
        {
            await _Appraisals.InsertOneAsync(newAppraisal);
            return await Task.FromResult<Shared.Models.Appraisal>(newAppraisal);
        }
    }
}