using System.Collections.Generic;

namespace CoreApp.Models
{
    public interface ICourseRepository
    {
     
        IQueryable<Course> Courses { get; }

        Course GetById(int id);
        IEnumerable<Course> GetCourses();
        IEnumerable<Course> GetCousesByActive(bool isActive);
        void CreateCourse(Course newCourse);
        void UpdateCourse(Course UpdatedCourse);
        void DeleteCourse(int courseid);
        
    }
}
