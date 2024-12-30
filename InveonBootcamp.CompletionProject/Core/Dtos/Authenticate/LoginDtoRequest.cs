namespace InveonBootcamp.CompletionProject.Core.Dtos.Authenticate
{
    public class LoginDtoRequest
    {
        public string Email { get; set; } = default!;//username?
        public string Password { get; set; } = default!;
    }
}
