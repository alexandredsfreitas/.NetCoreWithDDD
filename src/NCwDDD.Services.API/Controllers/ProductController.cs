using NCwDDD.Application.Interfaces;
using NCwDDD.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace NCwDDD.Services.API.Controllers
{
    public class ProductController : APIController
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet("product")]
        public async Task<IEnumerable<ProductViewModel>> Get()
        {
            return await _productAppService.GetAll();
        }

        [HttpGet("product/{id:guid}")]
        public async Task<ProductViewModel> Get(Guid id)
        {
            return await _productAppService.GetById(id);
        }

        [HttpPost("product")]
        public async Task<IActionResult> Post([FromBody] ProductViewModel productViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _productAppService.Register(productViewModel));
        }

        [HttpPut("product")]
        public async Task<IActionResult> Put([FromBody] ProductViewModel productViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _productAppService.Update(productViewModel));
        }

        [HttpDelete("product")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _productAppService.Remove(id));
        }
    }
}

