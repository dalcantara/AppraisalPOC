using System.Collections.Generic;
using System.Threading.Tasks;
using Appraisal.BlazorClient.Services;
using Microsoft.AspNetCore.Components;


namespace Appraisal.BlazorClient.Pages
{
    public partial class AppraisalListBase:ComponentBase
    {
        public Appraisal.Shared.Models.Appraisal[] Appraisals { get; set; }

        // ReSharper disable once MemberCanBePrivate.Global
        [Inject] public IAppraisalService AppraisalService { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            Appraisals = await AppraisalService.GetAll();
        }
    }
}