using InveonBootcamp.CompletionProject.Core.Dtos.Authenticate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Abstract
{

    public interface IAuthService
    {
        public Task<(bool IsAuthenticated, string Token, DateTime ExpiryDate)> LoginUserAsync(LoginDtoRequest request);
    }
}
