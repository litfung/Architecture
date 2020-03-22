using Architecture.Application;
using Architecture.Model;
using DotNetCore.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Architecture.Web
{
    [ApiController]
    [Route("Auths")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignInAsync(SignInModel model)
        {
            return await _authService.SignInAsync(model).ResultAsync();
        }
    }
}
