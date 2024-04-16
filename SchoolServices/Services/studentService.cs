using Microsoft.EntityFrameworkCore;
using School_Infrastructure.Interfaces;
using SchoolData.Entites;
using SchoolServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolServices.Services
{
    public class studentService : IstudentService
    {
        #region Properties
        private readonly IStudentRepository _StudentRepository;

        #endregion
        
        #region Constructor
        public studentService(IStudentRepository studentRepository)
        {
            _StudentRepository = studentRepository;
        }
        #endregion

        #region handle EndPoints
        public Task<List<Student>> GetStudentsListAsync()
        {
            return _StudentRepository.GetStudentsListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            // var student = await _StudentRepository.GetByIdAsync(id);
            var student = await _StudentRepository.GetTableNoTracking()
                                                  .Include(x => x.Department)
                                                  .Where(x => x.StudID == id)
                                                  .FirstOrDefaultAsync();

            return student;
        }
        #endregion

    }
}
