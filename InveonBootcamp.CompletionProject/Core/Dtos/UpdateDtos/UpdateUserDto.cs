namespace InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos
{
    public class UpdateUserDto
    {
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
      //  public string Role { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
