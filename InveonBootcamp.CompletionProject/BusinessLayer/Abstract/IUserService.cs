using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;
using InveonBootcamp.CompletionProject.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Abstract
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<UserDto> AddUserAsync(CreateUserDto userForCreateDto);
        Task<UserDto> UpdateUserAsync(int id, UpdateUserDto updateUserDto);
        Task DeleteUserAsync(Guid id);
        Task<User> AuthenticateUserAsync(string username, string password); 
    }
}
