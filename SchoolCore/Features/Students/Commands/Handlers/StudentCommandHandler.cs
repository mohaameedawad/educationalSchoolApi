using AutoMapper;
using MediatR;

using SchoolCore.Bases;
using SchoolCore.Features.Students.Commands.Models;
using SchoolCore.Features.Students.Queries.Dtos;
using SchoolCore.Features.Students.Queries.Models;
using SchoolCore.Wrappers;
using SchoolData.Entites;

using SchoolServices.Interfaces;

namespace SchoolCore.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                        IRequestHandler<AddStudentCommand, SchoolCore.Bases.Response<string>>,
                                        IRequestHandler<EditStudentCommand, SchoolCore.Bases.Response<string>>,
                                        IRequestHandler<DeleteStudentCommand, SchoolCore.Bases.Response<string>>,
                                        IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>



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

            if (result == "Success") return Success<string>("Added Successfully");
            else return BadRequest<string>();


        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);

            if (student == null) return NotFound<string>("Student Not Found");

            var studentMapper = _mapper.Map<Student>(request);

            var result = await _studentService.EditAsync(studentMapper);

            if (result == "Success") return Success($"Edited Successfully {studentMapper.StudID}");

            else return BadRequest<string>();


        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetByIdWithoutInclude(request.Id);

            if (student == null) return NotFound<string>("Student Not Found");

            var result = await _studentService.DeleteAsync(student);

            if (result == "Success") return Deleted<string>($"Deleted Successfully");

            else return BadRequest<string>();

        }

        public Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
