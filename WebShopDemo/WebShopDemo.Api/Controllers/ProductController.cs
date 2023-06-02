using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Api.Controllers
{
    /// <summary>
    /// Web shop products
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_productService"></param>
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, 
            StatusCode = StatusCodes.Status200OK, 
            Type = typeof(IEnumerable<ProductViewModel>))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productService.GetAllAsync());
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="model">Product view model</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200,
            StatusCode = StatusCodes.Status200OK,
            Type = typeof(ProductViewModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await productService.AddProductAsync(model);

            return Ok();
        }

       
    }
}
