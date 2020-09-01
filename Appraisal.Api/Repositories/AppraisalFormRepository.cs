using System.Collections.Generic;
using System.Threading.Tasks;
using Appraisal.Api.Models;
using Appraisal.Api.Settings;
using MongoDB.Driver;

namespace Appraisal.Api.Repositories
{
    public class AppraisalFormRepository : IAppraisalFormRepository
    {
        private IMongoCollection<AppraisalForm> _AppraisalForms;

        public AppraisalFormRepository(IProductDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);  
            var database = client.GetDatabase(settings.DatabaseName);
            _AppraisalForms = database.GetCollection<AppraisalForm>(settings.AppraisalFormCollectionName);
        }
        public async Task<IEnumerable<AppraisalForm>> GetAllAsync()
        {
            var AppraisalForms = _AppraisalForms.Find(AppraisalForm => true).ToEnumerable();
            return await Task.FromResult(AppraisalForms);
        }

        public Task<AppraisalForm> GetBySku(string sku)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AppraisalForm> CreateAsync(AppraisalForm newAppraisalForm)
        {
            await _AppraisalForms.InsertOneAsync(newAppraisalForm);
            return await Task.FromResult<AppraisalForm>(newAppraisalForm);
        }
        
        public async Task<AppraisalForm> UpdateAsync(AppraisalForm updatedAppraisalForm)
        {
            var result = await _AppraisalForms.ReplaceOneAsync(appraisalForm => appraisalForm.Id == updatedAppraisalForm.Id, updatedAppraisalForm);
            if (result.ModifiedCount > 0)
            {
                return await Task.FromResult(updatedAppraisalForm);
            }
            return await Task.FromException<AppraisalForm>(new KeyNotFoundException(string.Format("AppraisalForm: {0} was not found", updatedAppraisalForm.Title)));
        }
    }
}