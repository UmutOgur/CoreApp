using Microsoft.EntityFrameworkCore;

namespace CoreApp.Models
{
    public static class SeedDatabase
    {
       public static void seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count()==0)
            {
                if (context is DataContext)
                {
                    DataContext _context = context as DataContext;

                    if (_context.Courses.Count()==0)
                    {
                        _context.Courses.AddRange(Courses);
                    }

                    if (_context.Instructors.Count() == 0)
                    {
                        _context.Instructors.AddRange(Instructors);
                    }
                    context.SaveChanges();
                }
            }
        }

        private static Course[] Courses = {
        new Course(){Name = "Html" ,Price = 10,Description="about Html",IsActive = true},
        new Course(){Name = "JavaScript" ,Price = 100,Description="about java",IsActive = true},
        new Course(){Name = "C" ,Price = 50,Description="about C",IsActive = true}
        };

        private static Instructor[]  Instructors = {
        new Instructor(){Name = "Umut",City="Bitlis"},
        new Instructor(){Name = "Burhan",City="Bitlis"},
        new Instructor(){Name = "Orhan",City="Bitlis"}
        };
    }
}
