using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity_Framework_Indication.Interfaces;
using Entity_Framework_Indication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_Indication.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseDB;
        private readonly IAssignmentService _assignmentDB;

        public CourseController(ICourseService courseService, IAssignmentService assignmentService)
        {
            _courseDB = courseService;
            _assignmentDB = assignmentService;
        }

        // Remember to add PartialViews etc to make everything actually function. This is just 
        // the blueprint atm. It's bound to change.
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseDB.CreateCourse(course);

                return View(_courseDB.AllCourses());
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var course = _courseDB.FindCourse((int)id);

                return View(course);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                var newCourse = _courseDB.EditCourse(course);

                return View(newCourse);
            }
            return View();
        }

        public IActionResult Remove(int? id)
        {
            if (id != null)
            {
                _courseDB.RemoveCourse((int)id);
            }
            return View();
        }

        //public IActionResult UpdateGrades(int id, string grades)
        //{
        //    if (grades != null)
        //    {
        //        _courseDB.UpdateGrades(id, grades);
        //    }
        //    return View();
        //}
    }
}