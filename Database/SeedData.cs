using Model.Entities;

namespace Database
{
    public class SeedData
    { 
        internal static List<Class> GetClassesSeedData()
        {
            return new List<Class>
                {
                     new Class { ClassId = 1, ClassName = "Mathematics" },
                     new Class { ClassId = 2, ClassName = "Science" },
                     new Class { ClassId = 3, ClassName = "History" },
                     new Class { ClassId = 4, ClassName = "English" },
                     new Class { ClassId = 5, ClassName = "Physics" },
                     new Class { ClassId = 6, ClassName = "Biology" },
                     new Class { ClassId = 7, ClassName = "Chemistry" },
                     new Class { ClassId = 8, ClassName = "Geography" },
                     new Class { ClassId = 9, ClassName = "Art" },
                     new Class { ClassId = 10, ClassName = "Music" }
                };
        }
        internal static List<Student> GetStudentsSeedData()
        {
            return new List<Student>
            {
                new Student { StudentId = 1, StudentName = "John", ClassId = 1 },
                new Student { StudentId = 2, StudentName = "Alice", ClassId = 1 },
                new Student { StudentId = 3, StudentName = "Bob", ClassId = 2 },
                new Student { StudentId = 4, StudentName = "Eve", ClassId = 2 },
                new Student { StudentId = 5, StudentName = "Mike", ClassId = 3 },
                new Student { StudentId = 6, StudentName = "Sarah", ClassId = 3 },
                new Student { StudentId = 7, StudentName = "David", ClassId = 4 },
                new Student { StudentId = 8, StudentName = "Emily", ClassId = 4 },
                new Student { StudentId = 9, StudentName = "Chris", ClassId = 5 },
                new Student { StudentId = 10, StudentName = "Sophia", ClassId = 5 }
            };
        }

        internal static List<Teacher> GetTeachersSeedData()
        {
            return new List<Teacher>
            {
                new Teacher { TeacherId = 1 , TeacherName  = "Murad Hossen"},
                new Teacher { TeacherId = 2 , TeacherName  = "Hamidur Rahman"},
                new Teacher { TeacherId = 3 , TeacherName  = "Rajib Sarkar"},
                new Teacher { TeacherId = 4 , TeacherName  = "Mominul Islam"},
                new Teacher { TeacherId = 5 , TeacherName  = "Hasan Showrav"}             
            };
        }
        internal static List<ClassTeacher> GetClassTeachersSeedData()
        {
            return new List<ClassTeacher>
            {
                new ClassTeacher { ClassId = 1, TeacherId = 1 },
                new ClassTeacher { ClassId = 2, TeacherId = 2 },
                new ClassTeacher { ClassId = 3, TeacherId = 3 },
                new ClassTeacher { ClassId = 4, TeacherId = 4 },
                new ClassTeacher { ClassId = 5, TeacherId = 5 },
                new ClassTeacher { ClassId = 6, TeacherId = 1 },
                new ClassTeacher { ClassId = 7, TeacherId = 2 },
                new ClassTeacher { ClassId = 8, TeacherId = 3 },
                new ClassTeacher { ClassId = 9, TeacherId = 4 },
                new ClassTeacher { ClassId = 10, TeacherId = 5 }
            };
        }

    }
}