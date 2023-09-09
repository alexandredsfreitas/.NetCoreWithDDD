using NCwDDD.Application.Interfaces;
using NCwDDD.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace NCwDDD.Services.API.Controllers
{
	public class CategoryController : APIController
	{
        private readonly ICategoryAppService _categoryAppService;

		public CategoryController(ICategoryAppService categoryAppService)
		{
			_categoryAppService = categoryAppService;
		}

        [HttpGet("category")]
        public async Task<IEnumerable<CategoryViewModel>> Get()
        {
            return await _categoryAppService.GetAll();
        }

        [HttpGet("category/{id:guid}")]
        public async Task<CategoryViewModel> Get(Guid id)
        {
            return await _categoryAppService.GetById(id);
        }

        [HttpPost("category")]
        public async Task<IActionResult> Post([FromBody] CategoryViewModel categoryViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _categoryAppService.Register(categoryViewModel));
        }

        [HttpPut("category")]
        public async Task<IActionResult> Put([FromBody] CategoryViewModel categoryViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _categoryAppService.Update(categoryViewModel));
        }

        [HttpDelete("category")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _categoryAppService.Remove(id));
        }
    }
}

