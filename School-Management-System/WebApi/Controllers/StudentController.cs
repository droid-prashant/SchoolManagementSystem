using Application.ClassRooms.Command.CreateClassRoom;
using Application.Common.Interfaces;
using Application.Students.Command.CreateStudent;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController:ApiBaseController
    {
        private readonly IApplicationDbContext _context;
        public StudentController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task Post([FromBody] CreateStudentCommand command, CancellationToken cancellationToken)
        {
            await Mediator.Send(command, cancellationToken);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
