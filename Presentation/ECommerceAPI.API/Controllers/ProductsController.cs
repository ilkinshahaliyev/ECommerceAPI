using ECommerceAPI.Application.Repositories.ProductRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> Get()
        {
            await _productWriteRepository.AddAsync(new() { Name = "iPhone 14 Pro", Price = 1999, Stock = 23 });
            await _productWriteRepository.SaveAsync();

            return Ok();
        }
    }
}
