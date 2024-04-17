using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SchoolCore.Features.Students.Commands.Models;
using SchoolCore.Features.Students.Queries.Models;
using SchoolData.AppMetaData;
using SchoolData.Entites;

namespace SchoolApi.Controllers
{
    //[Route("api/[controller]")]
    [Area("Admin")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        #region Properities
        private readonly IMediator _mediator;

        #endregion

        #region Constructors
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

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
            return Ok(response);
        }
        
        [HttpPost(Router.studentRouting.CreateStudent)]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentCommand student)
        {
            var response = await _mediator.Send(student);

            return Ok();
        }
        #endregion
    }
}
