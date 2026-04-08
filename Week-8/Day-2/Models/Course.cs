namespace Dappper_Day_2_RelationShips.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        // One-to-Many
        public List<Student> Students { get; set; } = new();
    }
}
