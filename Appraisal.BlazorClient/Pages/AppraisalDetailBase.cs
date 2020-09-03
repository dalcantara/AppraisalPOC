// using System.Threading.Tasks;
// using Appraisal.BlazorClient.Services;
// using Microsoft.AspNetCore.Components;
//
// namespace Appraisal.BlazorClient.Pages
// {
//     public class AppraisalDetailBase:ComponentBase
//     {
//         public Appraisal.Shared.Models.Appraisal Appraisal { get; set; }
//
//         // ReSharper disable once MemberCanBePrivate.Global
//         [Inject] public IAppraisalService AppraisalService { get; set; }
//         
//         protected override async Task OnInitializedAsync()
//         {
//             Appraisal = new Appraisal.Shared.Models.Appraisal();
//         }
//     }
// }