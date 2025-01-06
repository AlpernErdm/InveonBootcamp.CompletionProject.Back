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
    public class CourseService(IUnitOfWork unitOfWork, IMapper mapper) : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<CourseDto> GetCourseByIdAsync(int id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);

            if (course == null)
            {
                throw new CourseNotFoundException(id);
            }

            return _mapper.Map<CourseDto>(course);
        }

        public async Task<CourseDto> AddCourseAsync(CreateCourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _unitOfWork.Courses.AddAsync(course);
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0)
            {
                throw new CreationFailedException("Course creation failed.");
            }

            var courseDtos = _mapper.Map<CourseDto>(course);
            return courseDtos;
        }

        public async Task<CourseDto> UpdateCourseAsync(int id, UpdateCourseDto updateCourseDto)
        {
            var existingCourse = await _unitOfWork.Courses.GetByIdAsync(id);
            if (existingCourse == null)
            {
                throw new CourseNotFoundException(id);
            }

            _mapper.Map(updateCourseDto, existingCourse);

            _unitOfWork.Courses.Update(existingCourse);
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0) 
            {
                throw new UpdateFailedException("Course update failed.");
            }

            var courseDto = _mapper.Map<CourseDto>(existingCourse);
            return courseDto;
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);

            if (course == null)
            {
                throw new CourseNotFoundException(id);
            }

            _unitOfWork.Courses.Remove(course);
            var result = await _unitOfWork.CompleteAsync();

            if (result == 0)
            {
                throw new DeletionFailedException("Course deletion failed.");
            }
        }
    }
}