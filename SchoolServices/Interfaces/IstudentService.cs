using SchoolData.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolServices.Interfaces
{
    public interface IstudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdAsync(int id);


    }
}
