using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity_Framework_Indication.Interfaces;
using Entity_Framework_Indication.Models;
using Entity_Framework_Indication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_Indication.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _db;

        public StudentController(IStudentService studentService)
        {
            _db = studentService;
        }

        public IActionResult Index()
        {
            return View(_db.AllStudents());
        }

        public IActionResult Create([Bind("FirstName, SecondName, SchoolYear, PhoneNumber")]Student student)
        {
            if (ModelState.IsValid)
            {
                _db.CreateStudent(student);

                return RedirectToAction(nameof(Index), "Student");
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var student = _db.FindStudent(id);

                return View(student);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var student = _db.FindStudent(id);

                return View(student);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit([Bind("FirstName, SecondName, SchoolYear, PhoneNumber")]Student student)
        {
            if (ModelState.IsValid)
            {
                var newStudent = _db.EditStudent(student);

                return RedirectToAction(nameof(Details), "Student", newStudent);
            }
            return View();
        }

        public IActionResult Remove(int? id)
        {
            if (id != null)
            {
                _db.DeleteStudent(id);
            }
            return RedirectToAction(nameof(Index), "Student");
        }
    }
}