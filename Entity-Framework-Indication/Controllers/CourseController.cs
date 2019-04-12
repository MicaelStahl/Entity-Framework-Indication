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
        public IActionResult AddStudentsComplete(int? studentId)
        {
            if (studentId != null || studentId != 0)
            {
                var courseId = HttpContext.Session.GetInt32("_AddStudents");

                _courseDB.AddStudent(courseId, studentId);

                var studentList = _courseDB.FindNonAssignedStudents(courseId);

                return View(studentList);
            }
            return View();
        }

        // The other Actions for adding teacher to course are in TeacherController.
        // Simply to annoy Ulf.
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

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateAssignment(int? courseId)
        {
            var course = _courseDB.FindCourse(courseId);
            Assignment assignment = new Assignment() { Course = course };

            return View(assignment);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateAssignment(int? courseId, Assignment assignment)
        {
            if (courseId != null || courseId != 0 || ModelState.IsValid)
            {
                var boolean = _courseDB.AddAssignment(courseId, assignment);

                if (boolean)
                {
                    return RedirectToAction(nameof(Details), "Course", new { courseId });
                }
                return BadRequest();
            }
            return BadRequest();
        }

        [AutoValidateAntiforgeryToken]
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
                var course = _courseDB.FindCourseWithStudents((int)id);

                return View(course);
            }
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Course course, List<Assignment> assignments)
        {
            if (ModelState.IsValid)
            {
                // Testing to see if I can send a list through a view. Might not be possible
                // but it's good practice. if I succeed, it'll look pretty dope.
                course.Assignments = assignments;
                var newCourse = _courseDB.EditCourse(course, assignments);

                return RedirectToAction(nameof(Details), "Course", newCourse);
            }
            return NotFound();
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditAssignment(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }
            var course = _courseDB.FindCourseWithStudents(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course.Assignments);

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]  
        public IActionResult EditAssignment(Assignment assignment)
        {
            // Friendly reminder for myself:
            // Create a NEW METHOD to edit the assignment and add it into the correct course.
            // this might be done by using a Session, but prolly with using include in the GET
            // and then send both the values up.
            // Goodnight :)

            //var newAssignment = _courseDB.EditAssignment()

            return BadRequest();
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

                if (course != null)
                {
                    return View(course);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult RemoveStudentComplete(int? courseId, int? studentId)
        {
            if (studentId == null || studentId == 0 || courseId == null || courseId == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var boolean = _courseDB.RemoveStudentFromCourse(courseId, studentId);

            if (boolean)
            {
                return RedirectToAction(nameof(Details), "Course", new { courseId });
            }
            return RedirectToAction(nameof(Index));
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