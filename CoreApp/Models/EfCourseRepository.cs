using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace CoreApp.Models
{
    public class EfCourseRepository : ICourseRepository
    {
        private DataContext context;
        public EfCourseRepository(DataContext _context)
        {
            context = _context;
        }

        public IEnumerable<Course> Courses => context.Courses;

        IQueryable<Course> ICourseRepository.Courses => throw new NotImplementedException();

        public void CreateCourse(Course newCourse)
        {
            throw new NotImplementedException();
        }

        public void DeleteCourse(int courseid)
        {
            throw new NotImplementedException();
        }

        public Course GetById(int courseid)
        {
            return context.Courses.Find(courseid);
        }

        public IEnumerable<Course> GetCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCousesByActive(bool isActive)
        {
            //Sadece aktif olan kursları al
            // return context.Courses.Where(y=>y.IsActive == isActive).ToList();
            // tüm kursları listele
            return context.Courses.ToList();
        }

        public void UpdateCourse(Course UpdatedCourse)
        {
            var updatedcourseInfo = context.Courses.Find(UpdatedCourse.Id);
            //güncelle repository
            if (updatedcourseInfo != null)
            {
                updatedcourseInfo.Name = UpdatedCourse.Name;
                updatedcourseInfo.Description = UpdatedCourse.Description;
                updatedcourseInfo.Price = UpdatedCourse.Price;
                updatedcourseInfo.IsActive = UpdatedCourse.IsActive;

                context.SaveChanges();
            }

        }
    }
}
