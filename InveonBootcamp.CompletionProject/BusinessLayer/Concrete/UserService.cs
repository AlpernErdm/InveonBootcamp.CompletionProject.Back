using AutoMapper;
using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;
using InveonBootcamp.CompletionProject.Core.ExceptionHandler.ExceptionClasses;
using InveonBootcamp.CompletionProject.Core.Models;
using InveonBootcamp.CompletionProject.DataAccessLayer.Repositories;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Concrete
{
    public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : IUserService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
            {
            throw new NotFoundException("User not found");
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(email);
            if (user == null)
            {
        throw new NotFoundException("User not found");
            }
            return _mapper.Map<UserDto>(user);
        }
        public async Task<User> AuthenticateUserAsync(string email, string password)
        {
            var user = await _unitOfWork.Users.GetAsync(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            return user;
        }

        public async Task<UserDto> AddUserAsync(CreateUserDto userForCreateDto)
        {
            var user = _mapper.Map<User>(userForCreateDto);
            user.Id = Guid.NewGuid();
            await _unitOfWork.Users.AddAsync(user);
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0) 
            {
                throw new CreationFailedException("User creation failed.");
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateUserAsync(Guid id, UpdateUserDto updateUserDto)
        {
            var existingUser = await _unitOfWork.Users.GetByIdAsync(id);
            if (existingUser == null)
            {
                throw new NotFoundException("User not found");
            }
            _mapper.Map(updateUserDto, existingUser);
            _unitOfWork.Users.Update(existingUser);
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0)
            {
                throw new UpdateFailedException("User update failed.");
            }
            return _mapper.Map<UserDto>(existingUser);
        }
        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            _unitOfWork.Users.Remove(user);
            var result = await _unitOfWork.CompleteAsync();
            if (result == 0) 
            {
        throw new DeletionFailedException("User deletion failed.");
            }
        }
    }
}