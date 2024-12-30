namespace InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos
{
    public class CreateUserDto
    {   
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}
