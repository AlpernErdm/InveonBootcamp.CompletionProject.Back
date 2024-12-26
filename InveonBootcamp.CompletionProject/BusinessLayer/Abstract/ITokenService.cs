using InveonBootcamp.CompletionProject.Core.Dtos.JwtAuth;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Abstract
{
    public interface ITokenService
    {
        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
    }
}
