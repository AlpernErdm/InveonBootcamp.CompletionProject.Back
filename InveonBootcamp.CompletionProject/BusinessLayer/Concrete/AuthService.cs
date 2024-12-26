using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.Core.Dtos.Authenticate;
using InveonBootcamp.CompletionProject.Core.Dtos.JwtAuth;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<(bool IsAuthenticated, string Token, DateTime ExpiryDate)> LoginUserAsync(LoginDtoRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException("Username and Password cannot be empty");
            }

            var user = await _userService.AuthenticateUserAsync(request.Username, request.Password);

            if (user != null)
            {
                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { Username = request.Username });
                return (true, generatedTokenInformation.Token, generatedTokenInformation.TokenExpireDate);
            }

            return (false, null, DateTime.MinValue);
        }
    }
}
