using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity_Framework_Indication.Interfaces;
using Entity_Framework_Indication.Models;
using Entity_Framework_Indication.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_Indication.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _db;
        private const string SessionKeyAddTeachers = "_AddTeachers";

        public TeacherController(ITeacherService teacherService)
        {
            _db = teacherService;
        }

        public IActionResult Index()
        {
            HttpContext.Session.Remove("_AddTeachers");
            return View(_db.AllTeachers());
        }

        public IActionResult AddTeacher(int? id)
        {
            if (id != null || id != 0)
            {
                HttpContext.Session.SetInt32("_AddTeachers", (int)id);

                var teachers = _db.AllTeachers();

                return View(teachers);
            }
            return BadRequest();
        }
        public IActionResult AddTeacherComplete(int? id)
        {
            if (id != null || id != 0)
            {
                var courseId = HttpContext.Session.GetInt32("_AddTeachers");

                _db.AddCourseToTeacher(courseId, id);

                return RedirectToAction(nameof(Index), "Course");
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("FirstName, SecondName, Specification, PhoneNumber")]Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _db.CreateTeacher(teacher);

                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        public IActionResult Details(int? id)
        {
            if (id != null || id != 0)
            {
                var teacher = _db.FindTeacherWithEverything((int)id);

                return View(teacher);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var teacher = _db.FindTeacher((int)id);

                return View(teacher);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit([Bind("Id,FirstName,SecondName,Specification,PhoneNumber")]Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var newTeacher = _db.EditTeacher(teacher);

                return RedirectToAction(nameof(Details), "Teacher", teacher);
            }
            return View();
        }

        public IActionResult Remove(int? id)
        {
            if (id != null)
            {
                _db.RemoveTeacher((int)id);
            }
            return View();
        }
    }
}