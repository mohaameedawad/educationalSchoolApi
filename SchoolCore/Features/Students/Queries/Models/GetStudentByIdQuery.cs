using MediatR;
using SchoolCore.Features.Students.Queries.Dtos;
using SchoolData.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolCore.Bases;


namespace SchoolCore.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<StudentDto>>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id )
        {
            Id = id;
        }
    }
}
