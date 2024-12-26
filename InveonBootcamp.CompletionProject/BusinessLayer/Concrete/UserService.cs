using AutoMapper;
using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;
using InveonBootcamp.CompletionProject.Core.Models;
using InveonBootcamp.CompletionProject.DataAccessLayer.Repositories;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }
        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            var user = await _unitOfWork.Users
                .GetAsync(u => u.Username == username && u.Password == password);

            return user;
        }
        public async Task<UserDto> AddUserAsync(CreateUserDto userForCreateDto)
        {
            var user = _mapper.Map<User>(userForCreateDto);
            user.Id = Guid.NewGuid(); 
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UserDto> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            var existingUser = await _unitOfWork.Users.GetByIdAsync(id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            _mapper.Map(updateUserDto, existingUser);

            _unitOfWork.Users.Update(existingUser);
            await _unitOfWork.CompleteAsync();

            var userDto = _mapper.Map<UserDto>(existingUser);
            return userDto;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user != null)
            {
                _unitOfWork.Users.Remove(user);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
