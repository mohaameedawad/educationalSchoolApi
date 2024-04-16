using Microsoft.EntityFrameworkCore;
using School_Infrastructure.Bases;
using School_Infrastructure.Context;
using School_Infrastructure.Interfaces;
using SchoolData.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Properties
        //private readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
            //_dbContext = dbContext;
        }
        #endregion

        #region Handle EndPoints
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _dbContext.Students.Include(x => x.Department).ToListAsync();
        }

        #endregion

    }
}
