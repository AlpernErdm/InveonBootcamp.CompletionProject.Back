using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.BusinessLayer.Concrete;
using InveonBootcamp.CompletionProject.Core.Dtos.Authenticate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.CompletionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("LoginUser")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUser(LoginDtoRequest request)
        {
            var (isAuthenticated, token, expiryDate) = await _authService.LoginUserAsync(request);

            if (isAuthenticated)
            {
                var response = new LoginDtoResponse
                {
                    AuthenticateResult = true,
                    AuthToken = token,
                    AccessTokenExpireDate = expiryDate
                };

                return Ok(response);
            }
            else
            {
                return Unauthorized("Invalid username or password");
            }
        }
    }
    }
