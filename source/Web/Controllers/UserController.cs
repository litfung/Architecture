using Architecture.Application;
using Architecture.CrossCutting;
using Architecture.Model;
using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Architecture.Web
{
    [ApiController]
    [Route("Users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddUserModel model)
        {
            return await _userService.AddAsync(model).ResultAsync();
        }

        [EnumAuthorize(Roles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return await _userService.DeleteAsync(id).ResultAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            return await _userService.GetAsync(id).ResultAsync();
        }

        [HttpPatch("{id}/Inactivate")]
        public async Task InactivateAsync(long id)
        {
            await _userService.InactivateAsync(id);
        }

        [HttpGet("List")]
        public async Task<IActionResult> ListAsync([FromQuery]PagedListParameters parameters)
        {
            return await _userService.ListAsync(parameters).ResultAsync();
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            return await _userService.ListAsync().ResultAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(UpdateUserModel model)
        {
            return await _userService.UpdateAsync(model).ResultAsync();
        }
    }
}
