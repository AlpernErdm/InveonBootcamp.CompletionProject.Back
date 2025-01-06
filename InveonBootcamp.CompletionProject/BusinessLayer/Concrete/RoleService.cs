using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Concrete
{
    public class RoleService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRoleService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                return roleResult.Succeeded;
            }
            return false;
        }

        public async Task<bool> AddUserToRoleAsync(User user, string roleName)
        {
            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }
    }
}