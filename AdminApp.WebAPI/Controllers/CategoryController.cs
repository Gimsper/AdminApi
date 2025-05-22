using AdminApp.Core.DTO.Category;
using AdminApp.Core.DTO.Item;
using AdminApp.Core.Entities;
using AdminApp.Services.Interfaces;
using AdminApp.WebAPI.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;


namespace AdminApp.Web.Controllers
{
    public class CategoryController : BaseController<Category>
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService, IMapper mapper) : base(categoryService, mapper)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CategoryReadDTO>))]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
            if (result.StateOperation)
            {
                var items = _mapper.Map<List<CategoryReadDTO>>(result.Results);
                return Ok(items);
            }
            return Ok(result.Results);
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryReadDTO))]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            var item = _mapper.Map<CategoryReadDTO>(result.Result);
            return Ok(item);
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Add([FromBody] CategoryAddDTO request)
        {
            var item = _mapper.Map<Category>(request);
            var result = await _categoryService.AddAsync(item);
            return Ok(result.StateOperation);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateDTO request)
        {
            var item = _mapper.Map<Category>(request);
            var result = await _categoryService.UpdateAsync(item);
            return Ok(result.StateOperation);
        }
    }
}
