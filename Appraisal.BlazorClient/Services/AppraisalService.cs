using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Appraisal.BlazorClient.Services
{
    public class AppraisalService : IAppraisalService
    {
        private readonly HttpClient _httpClient;

        public AppraisalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Appraisal.Shared.Models.Appraisal[]> GetAll()
        {
            return await _httpClient.GetJsonAsync<Appraisal.Shared.Models.Appraisal[]>("sample-data/appraisal.json");
        }
    }
}