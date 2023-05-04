using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public void UpdateCourse(Course UpdatedCourse, Course originalCourse = null)
        {
            if (originalCourse == null)
            {
                originalCourse = context.Courses.Find(UpdatedCourse.Id);

            }
            else
            {
                context.Courses.Attach(originalCourse);
            }
            //güncelle repository

            originalCourse.Name = UpdatedCourse.Name;
            originalCourse.Description = UpdatedCourse.Description;
            originalCourse.Price = UpdatedCourse.Price;
            originalCourse.IsActive = UpdatedCourse.IsActive;

            EntityEntry entry = context.Entry(originalCourse);

            //modified,Unchanged,Added,Deleted,Detached
            Console.WriteLine($"Entity State : {entry.State}");
            foreach (var property in new string[] { "Name", "Description", "Price", "IsActive" })
            {
                Console.WriteLine($"{property} - old : {entry.OriginalValues[property]} new {entry.CurrentValues[property]}");
            }
            context.SaveChanges();

        }
    }
}

