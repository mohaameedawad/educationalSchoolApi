using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.BaseController;
using SchoolCore.Features.Students.Commands.Models;
using SchoolCore.Features.Students.Queries.Models;
using SchoolData.AppMetaData;

namespace SchoolApi.Controllers
{
    //[Route("api/[controller]")]
    [Area("Admin")]
    [ApiController]
    public class StudentsController : AppController
    {
        public StudentsController(IMediator mediator) : base(mediator)
        {
        }


        #region Handle EndPoints
        [HttpGet(Router.studentRouting.List)]
        public async Task<IActionResult> GetStudentsList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }

        [HttpGet(Router.studentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }

        [HttpPost(Router.studentRouting.CreateStudent)]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentCommand student)
        {
            var response = await _mediator.Send(student);

            return NewResult(response);
        }

        [HttpPut(Router.studentRouting.EditStudent)]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand student)
        {
            var response = await _mediator.Send(student);

            return NewResult(response);
        }

        [HttpDelete(Router.studentRouting.DeleteStudent)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }
        #endregion
    }
}
