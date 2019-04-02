using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity_Framework_Indication.Interfaces;
using Entity_Framework_Indication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_Indication.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _db;

        public TeacherController(ITeacherService teacherService)
        {
            _db = teacherService;
        }

        public IActionResult Index()
        {
            return View(_db.AllTeachers());
        }

        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _db.CreateTeacher(teacher);
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
        public IActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _db.EditTeacher(teacher);

                return View(teacher);
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