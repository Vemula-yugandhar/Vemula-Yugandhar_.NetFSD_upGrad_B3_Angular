using Dappper_Day_2_RelationShips.Models;
using Microsoft.IdentityModel.Tokens;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Dappper_Day_2_RelationShips.Repostories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connStr;

        public StudentRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection")!;
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }

        public List<Student> GetStudentsWithCourse()
        {
            string sql = @"
        SELECT s.StudentId, s.StudentName, s.CourseId,
               c.CourseName
        FROM Student s
        INNER JOIN Course c ON s.CourseId = c.CourseId";

            using var db = GetConnection();
            return db.Query<Student>(sql).ToList();
        }
   

    public List<Course> GetCoursesWithStudents()
        {
            string sql = @"
        SELECT c.CourseId, c.CourseName,
               s.StudentId, s.StudentName, s.CourseId
        FROM Course c
        LEFT JOIN Student s ON c.CourseId = s.CourseId";

            using var db = GetConnection();

            var courseDict = new Dictionary<int, Course>();

            var result = db.Query<Course, Student, Course>(
                sql,
                (course, student) =>
                {
                    if (!courseDict.TryGetValue(course.CourseId, out var existingCourse))
                    {
                        existingCourse = course;
                        existingCourse.Students = new List<Student>();
                        courseDict.Add(existingCourse.CourseId, existingCourse);
                    }

                    if (student != null && student.StudentId != 0)
                    {
                        existingCourse.Students.Add(student);
                    }

                    return existingCourse;
                },
                splitOn: "StudentId"
            );

            return courseDict.Values.ToList();
        }
    }
}