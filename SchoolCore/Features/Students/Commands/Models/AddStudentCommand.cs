﻿using MediatR;

namespace SchoolCore.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Bases.Response<string>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DID { get; set; }
    }
}
