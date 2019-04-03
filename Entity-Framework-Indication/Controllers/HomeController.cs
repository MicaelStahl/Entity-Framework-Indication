using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity_Framework_Indication.Interfaces;
using Entity_Framework_Indication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_Indication.Controllers
{
    public class HomeController : Controller
    {
        StudentService studentService = new StudentService();

        private readonly IStudentService _studentDb;
        private readonly ITeacherService _teacherDb;
        private readonly ICourseService _courseDb;
        private readonly IAssignmentService _assignmentDb;

        public HomeController(
            IStudentService studentService, ITeacherService teacherService,
            ICourseService courseService, IAssignmentService assignmentService)
        {
            _studentDb = studentService;
            _teacherDb = teacherService;
            _courseDb = courseService;
            _assignmentDb = assignmentService;
        }

        public IActionResult Index()
        {
            return View(_studentDb.AllStudents());
        }
    }
}