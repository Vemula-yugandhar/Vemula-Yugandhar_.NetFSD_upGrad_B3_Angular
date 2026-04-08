using Dappper_Day_2_RelationShips.Models;

namespace Dappper_Day_2_RelationShips.Repostories
{
    public interface IStudentRepository
    {
        List<Student> GetStudentsWithCourse();
        List<Course> GetCoursesWithStudents();
    }
}
