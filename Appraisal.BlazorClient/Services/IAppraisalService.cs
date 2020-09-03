using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appraisal.BlazorClient.Services
{
    public interface IAppraisalService
    {
        Task<Appraisal.Shared.Models.Appraisal[]> GetAll();
    }
}