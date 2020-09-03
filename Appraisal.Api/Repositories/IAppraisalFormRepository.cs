using System.Collections.Generic;
using System.Threading.Tasks;
using Appraisal.Shared.Models;


namespace Appraisal.Api.Repositories
{
    public interface IAppraisalFormRepository
    {
        
        Task<IEnumerable<AppraisalForm>> GetAllAsync();
        Task<AppraisalForm> CreateAsync(AppraisalForm newAppraisalForm);
        Task<AppraisalForm> UpdateAsync(AppraisalForm updatedAppraisalForm);
    }
}
