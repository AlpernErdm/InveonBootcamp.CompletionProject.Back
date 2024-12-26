namespace InveonBootcamp.CompletionProject.Core.Dtos.JwtAuth
{
    public class GenerateTokenResponse
    {
        public string Token { get; set; } = default!;
        public DateTime TokenExpireDate { get; set; }
    }
}
