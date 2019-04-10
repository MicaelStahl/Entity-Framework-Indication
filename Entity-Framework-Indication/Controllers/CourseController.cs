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

        private const string SessionKeyAddStudents = "_AddStudents";

        public CourseController(ICourseService courseService, IAssignmentService assignmentService)
        {
            _courseDB = courseService;
            _assignmentDB = assignmentService;
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult Index()
        {
            HttpContext.Session.Remove("_AllStudents");
            return View(_courseDB.AllCourses());
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
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
        [AutoValidateAntiforgeryToken]
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
        [AutoValidateAntiforgeryToken]
        public IActionResult AddStudents(int? id)
        {
            if (id != null)
            {
                HttpContext.Session.SetInt32("_AddStudents", (int)id);

                var studentCourses = _courseDB.FindNonAssignedStudents(id);

                if (studentCourses == null)
                {
                    return BadRequest();
                }
                return View(studentCourses);
            }
            return NotFound();
        }
        [HttpPost, ActionName("AddStudents")]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddStudentsComplete(int? id)
        {
            if (id != null || id == 0)
            {
                var courseId = HttpContext.Session.GetInt32("_Testing");

                _courseDB.AddStudent(courseId, id);

                var studentList = _courseDB.FindNonAssignedStudents(courseId);

                return View(studentList);
            }

            return View();
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddTeacher()
        {
            var course = _courseDB.FindCourseNoTeacher();

            return View(course);
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseDB.CreateCourse(course);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var course = _courseDB.FindCourseWithStudents(id);

                return View(course);
            }
            return View();
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
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
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit([Bind("Id, Title, Subject")]Course course)
        {
            if (ModelState.IsValid)
            {
                var newCourse = _courseDB.EditCourse(course);

                return RedirectToAction(nameof(Details), "Course", newCourse);
            }
            return NotFound();
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult Remove(int? id)
        {
            if (id != null)
            {
                _courseDB.RemoveCourse((int)id);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}