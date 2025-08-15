using Application.ClassRooms.Command.CreateClassRoom;
using Application.ClassRooms.Interfaces;
using Application.ClassRooms.VieModels;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ApiBaseController
    {
        private readonly IClassRoomService _classRoom;
        public ClassRoomController(IClassRoomService classRoom)
        {
            _classRoom = classRoom;
        }

        [HttpGet]
        [Route("GetClassRoom")]
        public async Task<List<ClassRoomViewModel>> Get(CancellationToken cancellationToken)
        {
            var result = await _classRoom.GetClassRoomList(cancellationToken);
            return result;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task Post([FromBody] CreateClassRoomCommand command, CancellationToken cancellationToken)
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
