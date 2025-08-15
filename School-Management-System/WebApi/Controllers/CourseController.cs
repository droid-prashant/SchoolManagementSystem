using System.Reflection.Metadata.Ecma335;
using Application.Courses.Dtos;
using Application.Courses.Interfaces;
using Application.Courses.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        // GET: api/<CourseController>
        [HttpGet]
        [Route("GetCourse")]
        public async Task<List<CourseViewModel>> Get(CancellationToken cancellationToken)
        {
            var result = await _courseService.GetCourse(cancellationToken);
            return result;
        }

        [HttpGet]
        [Route("GetCourseByClassId")]
        public async Task<List<CourseViewModel>> Get([FromQuery] string classId, CancellationToken cancellationToken)
        {
            var ClassRoomId = Guid.Parse(classId);
            var result = await _courseService.GetCourseByClassId(ClassRoomId, cancellationToken);
            return result;
        }

        // POST api/<CourseController>
        [HttpPost]
        [Route("AddCourse")]
        public async Task Post([FromBody] CourseDto courseDto, CancellationToken cancellationToken)
        {
            await _courseService.AddCourse(courseDto, cancellationToken);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
