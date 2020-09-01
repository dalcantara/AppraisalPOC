using System.Collections.Generic;
using System.Threading.Tasks;
using Appraisal.Api.Models;
using Appraisal.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Appraisal.Api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            ;
        }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product NewProduct)
        {
            var createdProduct = await _productRepository.CreateAsync(NewProduct);
            return Ok(createdProduct);
        }
        
        // POST api/values
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product UpdatedProduct)
        {
            
            try
            {
                var updated = await _productRepository.UpdateAsync(UpdatedProduct);
                return Ok(updated);
            }
            catch (KeyNotFoundException) {
                return NotFound(new EmptyResult());
            }
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var users =  await _productRepository.GetAllAsync();
            return await Task.FromResult(users);
        }
    }
}