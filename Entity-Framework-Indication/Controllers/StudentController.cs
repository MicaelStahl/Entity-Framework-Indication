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
        private readonly SchoolDbContext _dbContext;

        public StudentController(IStudentService studentService, SchoolDbContext dbContext)
        {
            _db = studentService;
            _dbContext = dbContext;
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

                return RedirectToAction(nameof(Index), "Home");
                //return View(_db.AllStudents());
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
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var newStudent = _db.EditStudent(student);

                return RedirectToAction(nameof(Details), "Student", student);
            }
            return View();
        }

        public IActionResult Remove(int? id)
        {
            if (id != null)
            {
                _db.DeleteStudent(id);
            }
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}