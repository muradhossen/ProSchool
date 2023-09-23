namespace Model.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public ICollection<ClassTeacher> ClassTeachers { get; set; }
    }
}
