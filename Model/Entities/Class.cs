using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public ICollection<ClassTeacher> ClassTeachers { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
