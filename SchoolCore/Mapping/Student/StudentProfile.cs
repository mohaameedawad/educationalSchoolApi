using AutoMapper;
using SchoolCore.Features.Students.Queries.Dtos;
using SchoolData.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.Mapping.Student
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile() 
        {
            GetStudentListMapping();
        }
    }
}
