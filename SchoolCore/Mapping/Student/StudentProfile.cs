using AutoMapper;

namespace SchoolCore.Mapping.Student
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            AddStudentMapping();
            EditStudentMapping();
        }
    }
}
