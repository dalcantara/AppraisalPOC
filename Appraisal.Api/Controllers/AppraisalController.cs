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
        public async Task<IActionResult> Post([FromBody] Models.Appraisal newAppraisal)
        {
            var createdAppraisal = await _appraisalRepository.CreateAsync(newAppraisal);
            return Ok(createdAppraisal);
        }
        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Models.Appraisal updatedAppraisal)
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
        public async Task<IEnumerable<Models.Appraisal>> GetAllAsync()
        {
            var users =  await _appraisalRepository.GetAllAsync();
            return await Task.FromResult(users);
        }
    }
}