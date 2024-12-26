namespace InveonBootcamp.CompletionProject.Core.Dtos.Authenticate
{
    public class LoginDtoResponse
    {
        public bool AuthenticateResult { get; set; }
        public string AuthToken { get; set; } = default!;
        public DateTime AccessTokenExpireDate { get; set; }
    }
}
