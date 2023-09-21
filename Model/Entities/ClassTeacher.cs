using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class ClassTeacher
    {
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public Class Class { get; set; }
        public Teacher Teacher { get; set; }
    }
}
