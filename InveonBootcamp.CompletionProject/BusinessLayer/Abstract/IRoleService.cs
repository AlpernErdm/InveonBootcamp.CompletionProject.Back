using InveonBootcamp.CompletionProject.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Abstract
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> AddUserToRoleAsync(User user, string roleName);
    }

   
    }
