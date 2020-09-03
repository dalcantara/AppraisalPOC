using System.Collections.Generic;
using System.Threading.Tasks;
using Appraisal.BlazorClient.Services;
using Microsoft.AspNetCore.Components;

namespace Appraisal.BlazorClient.Pages
{
    public partial class AppraisalList:ComponentBase
    {
        // ReSharper disable once MemberCanBePrivate.Global
        [Inject] public IAppraisalService Service { get; set; }

        public AppraisalList(IAppraisalService appraisalService)
        {
            Service = appraisalService;
        }

        public Task<List<Appraisal.Shared.Models.Appraisal>> GetAll()
        {
            return Service.GetAll();
        }
    }
}