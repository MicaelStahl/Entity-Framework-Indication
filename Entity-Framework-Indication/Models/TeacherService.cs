using Entity_Framework_Indication.Interfaces;
using Entity_Framework_Indication.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Models
{
    public class TeacherService : ITeacherService
    {
        private readonly SchoolDbContext _db;

        public TeacherService(SchoolDbContext teacherDbContext)
        {
            _db = teacherDbContext;
        }

        public List<Teacher> AllTeachers()
        {
            return _db.Teachers.ToList();
        }

        public Teacher CreateTeacher(Teacher teacher)
        {
            if (string.IsNullOrWhiteSpace(teacher.FirstName) ||
                string.IsNullOrWhiteSpace(teacher.SecondName) ||
                string.IsNullOrWhiteSpace(teacher.PhoneNumber) ||
                string.IsNullOrWhiteSpace(teacher.Specification))
            {
                return null;
            }

            Teacher newTeacher = new Teacher()
            {
                FirstName = teacher.FirstName,
                SecondName = teacher.SecondName,
                PhoneNumber = teacher.PhoneNumber,
                Specification = teacher.Specification,
            };
            _db.Teachers.Add(newTeacher);
            _db.SaveChanges();

            return newTeacher;
        }

        public Teacher EditTeacher(Teacher teacher)
        {
            var original = _db.Teachers.SingleOrDefault(x => x.Id == teacher.Id);

            if (original != null || teacher != null)
            {
                original.FirstName = teacher.FirstName;
                original.SecondName = teacher.SecondName;
                original.PhoneNumber = teacher.PhoneNumber;
                original.Specification = teacher.Specification;

                _db.SaveChanges();

                return original;
            }
            return teacher;
        }

        public bool AddCourseToTeacher(int? courseId, int? teacherId)
        {
            var course = _db.Courses.SingleOrDefault(x => x.Id == courseId);
            var teacher = _db.Teachers.SingleOrDefault(x => x.Id == teacherId);

            if (course == null || teacher == null)
            {
                return false;
            }

            course.Teacher = teacher;
            _db.SaveChanges();

            return true;
        }

        public List<Teacher> FindTeacherWithEverything(int id)
        {
            var teachers = _db.Teachers
                .Where(x => x.Id == id)
                .Include(x => x.Courses)
                .ThenInclude(x => x.StudentsCourses)
                .ThenInclude(x => x.Course)
                .ThenInclude(x => x.Assignments)
                .Include(x => x.Courses)
                .ThenInclude(x => x.StudentsCourses)
                .ThenInclude(x => x.Student)
                .AsNoTracking()
                .ToList();

            return teachers;
        }

        public Teacher FindTeacher(int id)
        {
            return _db.Teachers.SingleOrDefault(x => x.Id == id);
        }

        public bool RemoveTeacher(int id)
        {
            var teacher = _db.Teachers.SingleOrDefault(x => x.Id == id);

            if (teacher != null)
            {
                _db.Teachers.Remove(teacher);
                _db.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
