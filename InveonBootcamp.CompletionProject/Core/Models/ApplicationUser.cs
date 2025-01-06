using Microsoft.AspNetCore.Identity;

namespace InveonBootcamp.CompletionProject.Core.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; } = default!;
    }
}
