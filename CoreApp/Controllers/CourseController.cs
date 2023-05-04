using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CoreApp.Controllers
{
    public class CourseController : Controller
    {
        
               

        private ICourseRepository repository;
        public CourseController(ICourseRepository _repository) 
        { 
            repository = _repository;
            
        }
        public IActionResult Index()
        {
            

            var Courses = repository.GetCousesByActive(true);
            ViewBag.CourseCount = Courses.Count();// toplamını al
            return View(Courses); 
        }
        public IActionResult Edit(int id)
        {
            return View(repository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Course entity, Course original)
        {
            //Güncelle
            repository.UpdateCourse(entity);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
