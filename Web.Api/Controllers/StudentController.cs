using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.GetStudentQueri;
using Application.Commands.Students.Create;
using Application.Commands.Students.Delete;
using Application.Commands.Students.Update;
using MediatR;
using Notes.WebApi.Controllers;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : BaseController
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetStudentInfo(int userId)
        {
            var query = new GetStudentInfoQuery(userId);
            var studentInfo = await _mediator.Send(query);

            if (studentInfo == null)
            {
                return NotFound();
            }

            return Ok(studentInfo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetStudentInfo), new { userId = command.UserId }, result);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateStudent(int userId, [FromBody] UpdateStudentCommand command)
        {
            if (userId != command.UserId)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteStudent(int userId)
        {
            var command = new DeleteStudentCommand(userId);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
