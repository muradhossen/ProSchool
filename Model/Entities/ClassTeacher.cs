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
