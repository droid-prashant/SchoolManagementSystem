using Application.ClassRooms.Command.CreateClassRoom;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ApiBaseController
    {
        private readonly IApplicationDbContext _context;
        public ClassRoomController(IApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ClassRoomController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClassRoomController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClassRoomController>
        [HttpPost]
        public async Task Post([FromBody] CreateClassRoomCommand command, CancellationToken cancellationToken)
        {
            await Mediator.Send(command, cancellationToken);
        }

        // PUT api/<ClassRoomController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClassRoomController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
