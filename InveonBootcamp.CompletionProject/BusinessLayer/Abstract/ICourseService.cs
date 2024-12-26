using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;

namespace InveonBootcamp.CompletionProject.BusinessLayer.Abstract
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync();
        Task<CourseDto> GetCourseByIdAsync(int id);
        Task<CourseDto> AddCourseAsync(CreateCourseDto courseDto);
        Task<CourseDto> UpdateCourseAsync(int id, UpdateCourseDto updateCourseDto);
        Task DeleteCourseAsync(int id);
    }
}
