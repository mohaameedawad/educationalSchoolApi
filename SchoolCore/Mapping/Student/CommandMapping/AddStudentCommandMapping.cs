using SchoolCore.Features.Students.Commands.Models;
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
        public void AddStudentMapping()
        {
            CreateMap<AddStudentCommand , SchoolData.Entites.Student>();
        }
    }
}
