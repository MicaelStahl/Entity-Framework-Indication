using Entity_Framework_Indication.Interfaces;
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
            if (string.IsNullOrWhiteSpace(teacher.FirstName)
                || string.IsNullOrWhiteSpace(teacher.SecondName)
                || string.IsNullOrWhiteSpace(teacher.PhoneNumber)
                || string.IsNullOrWhiteSpace(teacher.TeachingSubject))
            {
                return null;
            }

            Teacher newTeacher = new Teacher()
            {
                FirstName = teacher.FirstName,
                SecondName = teacher.SecondName,
                PhoneNumber = teacher.PhoneNumber,
                TeachingSubject = teacher.TeachingSubject
            };

            _db.Teachers.Add(newTeacher);
            _db.SaveChanges();

            return newTeacher;
        }

        public bool EditTeacher(Teacher teacher)
        {
            var original = _db.Teachers.SingleOrDefault(x => x.Id == teacher.Id);

            if (original != null)
            {
                original.FirstName = teacher.FirstName;
                original.SecondName = teacher.SecondName;
                original.PhoneNumber = teacher.PhoneNumber;
                original.TeachingSubject = teacher.TeachingSubject;
                original.Courses = teacher.Courses;

                _db.SaveChanges();

                return true;
            }
            return false;
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
