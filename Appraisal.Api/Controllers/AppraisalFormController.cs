using System.Collections.Generic;
using System.Threading.Tasks;
using Appraisal.Api.Models;
using Appraisal.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Appraisal.Api.Controllers
{
    [Route("api/AppraisalForm")]
    [ApiController]
    public class AppraisalFormController : ControllerBase
    {
        private readonly IAppraisalFormRepository _appraisalFormRepository;

        public AppraisalFormController(IAppraisalFormRepository appraisalFormRepository)
        {
            _appraisalFormRepository = appraisalFormRepository;
            ;
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AppraisalForm newAppraisalForm)
        {
            var createdAppraisalForm = await _appraisalFormRepository.CreateAsync(newAppraisalForm);
            return Ok(createdAppraisalForm);
        }
        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AppraisalForm updatedAppraisalForm)
        {
            
            try
            {
                var updated = await _appraisalFormRepository.UpdateAsync(updatedAppraisalForm);
                return Ok(updated);
            }
            catch (KeyNotFoundException) {
                return NotFound(new EmptyResult());
            }
        }
        [HttpGet]
        public async Task<IEnumerable<AppraisalForm>> GetAllAsync()
        {
            var users =  await _appraisalFormRepository.GetAllAsync();
            return await Task.FromResult(users);
        }
    }
}