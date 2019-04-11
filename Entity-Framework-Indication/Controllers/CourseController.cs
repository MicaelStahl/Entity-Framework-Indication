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
        private const string SessionKeyRemoveStudent = "_RemoveStudent";

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
                var courseId = HttpContext.Session.GetInt32("_AddStudents");

                _courseDB.AddStudent(courseId, id);

                var studentList = _courseDB.FindNonAssignedStudents(courseId);

                return View(studentList);
            }

            return View();
        }

        // the other Actions for adding teacher to course are in TeacherController.
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddTeacher()
        {
            var course = _courseDB.FindCoursesNoTeacher();

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

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var course = _courseDB.FindCourseWithStudents(id);

                return View(course);
            }
            return RedirectToAction(nameof(Index));
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

        [AutoValidateAntiforgeryToken]
        public IActionResult RemoveStudent(int? id)
        {
            if (id != null || id != 0)
            {
                var course = _courseDB.FindCourseWithStudents(id);
                HttpContext.Session.SetInt32("_RemoveStudent", (int)id);

                if (course != null)
                {
                    return View(course);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult RemoveStudentComplete(int? studentId)
        {
            if (studentId == null || studentId == 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var courseId = HttpContext.Session.GetInt32("_RemoveStudent");
            if (courseId == null || courseId == 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var boolean = _courseDB.RemoveStudentFromCourse(courseId, studentId);

            if (boolean == false)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Details), "Course", new { courseId });
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult RemoveTeacher(int? id)
        {
            if (id != null || id != 0)
            {
                var boolean = _courseDB.RemoveTeacherFromCourse(id);

                if (boolean)
                {
                    return RedirectToAction(nameof(Details), "Course", new { id });
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}