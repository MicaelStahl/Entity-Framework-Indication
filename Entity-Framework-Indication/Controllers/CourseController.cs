using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity_Framework_Indication.Interfaces;
using Entity_Framework_Indication.Models;
using Entity_Framework_Indication.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Indication.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseDB;
        private readonly IAssignmentService _assignmentDB;
        private readonly SchoolDbContext _dbContext;

        private const string SessionKeyTesting = "_Testing";

        public CourseController(ICourseService courseService, IAssignmentService assignmentService,
            SchoolDbContext dbContext)
        {
            _courseDB = courseService;
            _assignmentDB = assignmentService;
            _dbContext = dbContext;
        }

        // Remember to add PartialViews etc to make everything actually function. This is just 
        // the blueprint atm. It's bound to change.
        public IActionResult Index()
        {
            HttpContext.Session.Remove("_Testing");
            return View(_courseDB.AllCourses());
        }

        [HttpGet]
        public IActionResult AddAssignment(int? id)
        {
            if (id != null)
            {
                var course = _courseDB.FindCourse(id);
                if (course == null)
                {
                    return NotFound();
                }
                return View(course);
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddAssignment(int? id, Assignment assignment)
        {
            if (id != null || ModelState.IsValid)
            {
                _courseDB.AddAssignment(id, assignment);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddStudents(int? id)
        {
            if (id != null)
            {
                HttpContext.Session.SetInt32("_Testing", (int)id);
                //var student = _dbContext.Sc.Include(x => x.StudentId).ToList();
                var course = _courseDB.FindCourse(id);
                //var newStudents = _dbContext.Students.Include(x => x.StudentsCourses).ToList();

                //_dbContext.Sc.Include(x => x.Course == course).Include(y => y.Student);
                return View(_dbContext);
            }
            return BadRequest();
        }
        [HttpPost, ActionName("AddStudents")]
        public IActionResult AddStudentsComplete(int? id)
        {
            if (id != null || id == 0)
            {
                var course = HttpContext.Session.GetInt32("_Testing");

                _courseDB.AddStudent(course, id);

                //return View(_courseDB.AddStudent(course, id));
                return View(_dbContext);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseDB.CreateCourse(course);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var course = _courseDB.FindCourse(id);

                return View(course);
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

                return RedirectToAction(nameof(Index));
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