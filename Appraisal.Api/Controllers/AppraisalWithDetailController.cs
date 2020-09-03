using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appraisal.Api.Repositories;
using Appraisal.Shared.Models;
using Microsoft.AspNetCore.Mvc;
namespace Appraisal.Api.Controllers
{
    [Route("api/AppraisalWithDetail")]
    [ApiController]
    public class AppraisalWithDetailsController : ControllerBase
    {
        private readonly IAppraisalRepository _appraisalRepository;

        public AppraisalWithDetailsController(IAppraisalRepository appraisalRepository)
        {
            _appraisalRepository = appraisalRepository;
            ;
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Shared.Models.AppraisalWithDetail newAppraisal)
        {
            // var createdAppraisal = await _appraisalRepository.CreateAsync(newAppraisal);
            return Ok();
        }
        
        // [HttpPut]
        // public async Task<IActionResult> Put([FromBody] Shared.Models.AppraisalWithDetail updatedAppraisal)
        // {
        //     
        //     try
        //     {
        //         updatedAppraisal.AppraisalFormAnswers.AppraisedDateTime = DateTime.Now;
        //         var updated = await _appraisalRepository.UpdateAsync(updatedAppraisal);
        //         return Ok(updated);
        //     }
        //     catch (KeyNotFoundException) {
        //         return NotFound(new EmptyResult());
        //     }
        // }
        [HttpGet]
        public async Task<IEnumerable<Shared.Models.AppraisalWithDetail>> GetAllAsync()
        {
            var appraisals =  await _appraisalRepository.GetAllAsync();
            var appraisal = appraisals.First();
            var answers = appraisal.AppraisalFormAnswers;
            var detail = appraisal.AppraisalFormAnswers.Take(1);
            var appraisalWithDetail = new AppraisalWithDetail(appraisal);

            var appraisalsWithDetail = new List<Shared.Models.AppraisalWithDetail>() {appraisalWithDetail};
            
            return await Task.FromResult(appraisalsWithDetail);
        }
        
    }
}