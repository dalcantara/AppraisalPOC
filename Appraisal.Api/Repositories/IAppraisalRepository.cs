using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appraisal.Api.Repositories
{
    public interface IAppraisalRepository
    {
        Task<IEnumerable<Models.Appraisal>> GetAllAsync();
        Task<Models.Appraisal> CreateAsync(Models.Appraisal newAppraisal);
        Task<Models.Appraisal> UpdateAsync(Models.Appraisal updatedAppraisal);
    }
}