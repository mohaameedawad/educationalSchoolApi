using AutoMapper;
using MediatR;
using SchoolCore.Features.Students.Queries.Dtos;
using SchoolCore.Features.Students.Queries.Models;
using SchoolData.Entites;
using SchoolServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolCore.Bases;

namespace SchoolCore.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
                                       IRequestHandler<GetStudentListQuery, Response<List<StudentDto>>>,
                                       IRequestHandler<GetStudentByIdQuery, Response<StudentDto>>
    {
        
        #region Properties
        private readonly IstudentService _studentService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public StudentQueryHandler(IstudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handel EndPoints
        public async Task<Response<List<StudentDto>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var result = await _studentService.GetStudentsListAsync();

            var mappedResult = _mapper.Map<List<StudentDto>>(result);
            return Success(mappedResult);
        
        }

        public async Task<Response<StudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);

            if (student == null) return NotFound<StudentDto>("Object Not Found");

            var result = _mapper.Map<StudentDto>(student);
            return Success(result);
        }
        #endregion

    }
}
