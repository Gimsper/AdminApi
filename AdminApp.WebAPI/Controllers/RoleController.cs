using AdminApp.Core.DTO.Role;
using AdminApp.Core.DTO.User;
using AdminApp.Core.Entities;
using AdminApp.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdminApp.WebAPI.Controllers
{
    public class RoleController : BaseController<Role>
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService, IMapper mapper) : base(roleService, mapper)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RoleReadDTO>))]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roleService.GetAllAsync();
            if (result.StateOperation)
            {
                var items = _mapper.Map<List<RoleReadDTO>>(result.Results);
                return Ok(items);
            }
            return Ok(result.Results);
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleReadDTO))]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _roleService.GetByIdAsync(id);
            var item = _mapper.Map<RoleReadDTO>(result.Result);
            return Ok(item);
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Add([FromBody] RoleAddDTO request)
        {
            var item = _mapper.Map<Role>(request);
            var result = await _roleService.AddAsync(item);
            return Ok(result.StateOperation);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Update([FromBody] RoleUpdateDTO request)
        {
            var item = _mapper.Map<Role>(request);
            var result = await _roleService.UpdateAsync(item);
            return Ok(result.StateOperation);
        }
    }
}
