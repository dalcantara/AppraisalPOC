using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appraisal.Api.Repositories
{
    public interface IAppraisalRepository
    {
        Task<IEnumerable<Shared.Models.Appraisal>> GetAllAsync();
        Task<Shared.Models.Appraisal> CreateAsync(Shared.Models.Appraisal newAppraisal);
        Task<Shared.Models.Appraisal> UpdateAsync(Shared.Models.Appraisal updatedAppraisal);
        Task<Shared.Models.Appraisal> CreateWithHistoryAsync(Shared.Models.Appraisal newAppraisal);
        Task<Shared.Models.Appraisal> UpdateWithHistoryAsync(Shared.Models.Appraisal updatedAppraisal);
        Task<Shared.Models.Appraisal> GetAllWithHistoryAsync(Shared.Models.Appraisal newAppraisal);
    }
}