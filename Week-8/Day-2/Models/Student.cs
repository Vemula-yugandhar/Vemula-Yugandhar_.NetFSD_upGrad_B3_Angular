namespace Dappper_Day_2_RelationShips.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public int CourseId { get; set; }

        // Navigation
        public string CourseName { get; set; }
    }
}
