using Microsoft.EntityFrameworkCore;
using School_Infrastructure.Interfaces;
using SchoolData.Entites;
using SchoolServices.Interfaces;

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

        public async Task<string> AddAsync(Student student)
        {
            var studentResult = await _StudentRepository.GetTableNoTracking()
                                                    .Where(x => x.Name == student.Name)
                                                    .FirstOrDefaultAsync();
            if (studentResult != null) return "Sorry Student exits";

            await _StudentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameExist(string name)
        {
            var student = _StudentRepository.GetTableNoTracking().Where(x => x.Name == name).FirstOrDefault();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int Id)
        {
            var student = await _StudentRepository.GetTableNoTracking().Where(x => x.Name == name).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<string> EditAsync(Student student)
        {
            await _StudentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _StudentRepository.BeginTransaction();
            try
            {
                await _StudentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";

            }
        }

        public async Task<Student> GetByIdWithoutInclude(int id)
        {
            var student = await _StudentRepository.GetTableNoTracking()
                                                  .Where(x => x.StudID == id)
                                                  .FirstOrDefaultAsync();

            return student;
        }
        #endregion

    }
}
