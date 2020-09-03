using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appraisal.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace Appraisal.Api.Controllers
{
    [Route("api/Appraisal")]
    [ApiController]
    public class AppraisalController : ControllerBase
    {
        private readonly IAppraisalRepository _appraisalRepository;

        public AppraisalController(IAppraisalRepository appraisalRepository)
        {
            _appraisalRepository = appraisalRepository;
            ;
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Shared.Models.Appraisal newAppraisal)
        {
            var createdAppraisal = await _appraisalRepository.CreateAsync(newAppraisal);
            return Ok(createdAppraisal);
        }
        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Shared.Models.Appraisal updatedAppraisal)
        {
            
            try
            {
                
                updatedAppraisal.AppraisalFormAnswers.First().AppraisedDateTime = DateTime.Now;
                var updated = await _appraisalRepository.UpdateAsync(updatedAppraisal);
                return Ok(updated);
            }
            catch (KeyNotFoundException) {
                return NotFound(new EmptyResult());
            }
        }
        [HttpGet]
        public async Task<IEnumerable<Shared.Models.Appraisal>> GetAllAsync()
        {
            var appraisals =  await _appraisalRepository.GetAllAsync();
            return await Task.FromResult(appraisals);
        }
        
    }

    public class Models
    {
    }
}