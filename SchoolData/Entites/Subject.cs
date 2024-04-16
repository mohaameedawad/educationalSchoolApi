using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolData.Entites
{
    public class Subject
    {
        public Subject()
        {
            StudentsSubject = new HashSet<StudentSubject>();
            DepartmetsSubject = new HashSet<DepartmetSubject>();
        }
        [Key]
        public int SubID { get; set; }
        [StringLength(500)]
        public string SubjectName { get; set; }
        public DateTime Period { get; set; }
        public virtual ICollection<StudentSubject> StudentsSubject { get; set; }
        public virtual ICollection<DepartmetSubject> DepartmetsSubject { get; set; }
    }
}
