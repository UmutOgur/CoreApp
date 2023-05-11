using System.Collections.Generic;

namespace CoreApp.Models
{
    public interface ICourseRepository
    {
     
        IQueryable<Course> Courses { get; }

        Course GetById(int id);
        IEnumerable<Course> GetCourses();
        IEnumerable<Course> GetCousesByActive(bool isActive);
        IEnumerable<Course> GetCoursesByFilter(string Name = null, decimal? Price = null, string IsActive = null);
        int CreateCourse(Course newCourse);
        void UpdateCourse(Course UpdatedCourse, Course originalCourse = null);
        void DeleteCourse(int courseid);
        
    }
}
