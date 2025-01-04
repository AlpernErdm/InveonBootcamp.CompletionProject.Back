using InveonBootcamp.CompletionProject.BusinessLayer.Abstract;
using InveonBootcamp.CompletionProject.Core.Dtos;
using InveonBootcamp.CompletionProject.Core.Dtos.CreateDtos;
using InveonBootcamp.CompletionProject.Core.Dtos.UpdateDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.CompletionProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CourseDto>> Create(CreateCourseDto courseDto)
        {
            var courseDtos = await _courseService.AddCourseAsync(courseDto);
            return CreatedAtAction(nameof(GetCourse), new { id = courseDtos.Id }, courseDto);
        }

        [HttpPut("{id}")]
      //  [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCourse(int id, UpdateCourseDto updateCourseDto)
        {
            var courseDto = await _courseService.UpdateCourseAsync(id, updateCourseDto);
            return Ok(courseDto);
        }

        [HttpDelete("{id}")]
      //  [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return NoContent();
        }
    }
}
