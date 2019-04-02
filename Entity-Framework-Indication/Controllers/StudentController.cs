using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity_Framework_Indication.Interfaces;
using Entity_Framework_Indication.Models;
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
            return View();
        }

        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.CreateStudent(student);

                return View(_db.AllStudents());
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var student = _db.FindStudent((int)id);

                return View(_db.AllStudents());
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.EditStudent(student);

                return View(_db.AllStudents());
            }
            return View();
        }

        public IActionResult Remove(int? id)
        {
            if (id != null)
            {
                _db.DeleteStudent((int)id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}