using MediatR;
using SchoolCore.Bases;

namespace SchoolCore.Features.Students.Commands.Models
{
    public class EditStudentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public int DID { get; set; }
    }
}
