using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.Core.Dtos.Authenticate;
using InveonBootcamp.CompletionProject.Core.Dtos.JwtAuth;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Concrete
{
    public class AuthService(IUserService userService, ITokenService tokenService) : IAuthService
    {
        private readonly IUserService _userService = userService;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<(bool IsAuthenticated, string Token, DateTime ExpiryDate)> LoginUserAsync(LoginDtoRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException("Email and Password cannot be empty");
            }
            var user = await _userService.AuthenticateUserAsync(request.Email, request.Password);

            if (user != null)
            {
                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest
                {
                    Email = request.Email,
                    UserId = user.Id
                });
                return (true, generatedTokenInformation.Token, generatedTokenInformation.TokenExpireDate);
            }

            return (false, null, DateTime.MinValue);
        }
    }
}