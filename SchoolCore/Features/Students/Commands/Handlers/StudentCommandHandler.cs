using AutoMapper;

using Azure;
using MediatR;

using SchoolCore.Bases;
using SchoolCore.Features.Students.Commands.Models;

using SchoolData.Entites;

using SchoolServices.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                        IRequestHandler<AddStudentCommand, SchoolCore.Bases.Response<string>>
    {
        #region Properties
        private readonly IstudentService _studentService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public StudentCommandHandler(IstudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion
        #region Handle EndPoints

        public async Task<SchoolCore.Bases.Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(student);

            if(result == "Sorry Student exits") return UnProcessableEntity<string>("Sorry Student Exists");
            else if (result == "Success") return Success<string>("Added Successfully");
            else return BadRequest<string>();


        }
        #endregion
    }
}
