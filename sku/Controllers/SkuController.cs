using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sku.Core.DTOs.Requests;
using sku.Core.DTOs.Responses;
using sku.Core.Services;
using sku.Core.Services.Contracts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sku.Controllers
{
    [ApiController]
    [Route("/")]
    public class SkuController : Controller
    {
        private readonly ISkuService _service;

        public SkuController(ISkuService service)
        {
            _service = service;
        }


        // POST endpoint to facilitate the creation of new payloads
        [HttpPost("products")]
        public async Task<IActionResult> createAsync(IEnumerable<SkuCreateRequest> requests)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request provided");

                await _service.CreateProductsAsync(requests).ConfigureAwait(false);
            }
            catch(Exception e)
            {
                return BadRequest("Error saving Products");
            }

            return Ok("Products saved successfully");
        }

        // GET endpoint to fetch ProductsList
        [HttpGet("products")]
        public async Task<IActionResult> getAsync()
        {
            var productsList = Enumerable.Empty<SkuGetResponse>();
            try
            {
                productsList = await _service.GetProductsAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                return BadRequest("Error Fetching Products");
            }

            return Ok(productsList);
        }
    }
}

