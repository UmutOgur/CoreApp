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
        public IActionResult Index(string Name = null, decimal? Price = null, string IsActive = null)
        {
            //Filtreleme alını için
            Console.Clear();
            var Courses = repository.GetCoursesByFilter(Name,Price,IsActive);
            ViewBag.Name= Name;
            ViewBag.Price= Price;
            ViewBag.IsActive = IsActive=="on"? true : false;
            return View(Courses); 
        }
        public IActionResult Edit(int id)
        {
            ViewBag.ActionMode = "Edit";
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
            repository.DeleteCourse(id);
            return RedirectToAction("Index");
        }
        
        public  IActionResult Create()
        {
            ViewBag.ActionMode = "Create";
            return View("Edit", new Course());
        }
        [HttpPost]
        public IActionResult Create(Course newCourse)
        {
           int id= repository.CreateCourse(newCourse);
            Console.WriteLine("Id :{0}",id);
            return RedirectToAction(nameof(Index));
        }
    }
}
