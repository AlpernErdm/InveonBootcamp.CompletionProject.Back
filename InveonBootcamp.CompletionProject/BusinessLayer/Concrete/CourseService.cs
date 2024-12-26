﻿using AutoMapper;
using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;
using InveonBootcamp.CompletionProject.Core.Models;
using InveonBootcamp.CompletionProject.DataAccessLayer.Repositories;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Concrete
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<CourseDto> GetCourseByIdAsync(int id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<CourseDto> AddCourseAsync(CreateCourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.CompleteAsync();

            var courseDtos = _mapper.Map<CourseDto>(course); 
            return courseDtos;
        }

        public async Task<CourseDto> UpdateCourseAsync(int id, UpdateCourseDto updateCourseDto)
        {
            var existingCourse = await _unitOfWork.Courses.GetByIdAsync(id);
            if (existingCourse == null)
            {
                throw new Exception("Course not found");
            }

            _mapper.Map(updateCourseDto, existingCourse);

            _unitOfWork.Courses.Update(existingCourse);
            await _unitOfWork.CompleteAsync();

            var courseDto = _mapper.Map<CourseDto>(existingCourse);
            return courseDto;
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course != null)
            {
                _unitOfWork.Courses.Remove(course);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}