﻿namespace SchoolCore.Features.Students.Queries.Dtos
{
    public class GetStudentPaginatedListResponse
    {
        public int StudID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? DepartmentName { get; set; }
    }
}
