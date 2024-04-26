using SchoolCore.Features.Students.Commands.Models;

namespace SchoolCore.Mapping.Student
{
    public partial class StudentProfile
    {
        public void EditStudentMapping()
        {
            CreateMap<EditStudentCommand, SchoolData.Entites.Student>().
              ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.Id));
        }
    }
}
