using SchoolData.Entites;

namespace SchoolServices.Interfaces
{
    public interface IstudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<Student> GetByIdWithoutInclude(int id);

        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(string name, int Id);

        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);




    }
}
