﻿using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;
using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.CompletionProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> RegisterUser(CreateUserDto createUserDto)
        {
            var userDto = await _userService.AddUserAsync(createUserDto);
            return CreatedAtAction(nameof(GetUser), new { id = userDto.Id }, userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var userDto = await _userService.UpdateUserAsync(id, updateUserDto);
            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUserByEmail(string email)
        {
            var orders = await _userService.GetUserByEmail(email); 
            return Ok(orders);
        }

    }
}
