using SchoolCore.Features.Students.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.Mapping.Student
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping() 
        {
            CreateMap<SchoolData.Entites.Student, StudentDto>().
               ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
        }
    }
}
