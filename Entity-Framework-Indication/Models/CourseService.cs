using Entity_Framework_Indication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Models
{
    public class CourseService : ICourseService
    {
        private readonly SchoolDbContext _db;

        public CourseService(SchoolDbContext CourseDbContext)
        {
            _db = CourseDbContext;
        }

        public List<Course> AllCourses()
        {
            return _db.Courses.ToList();
        }

        public Course CreateCourse(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.Title) ||
                string.IsNullOrWhiteSpace(course.Subject))
            {
                return null;
            }

            Course newCourse = new Course() { Title = course.Title, Subject = course.Subject, Grades = course.Grades };

            _db.Courses.Add(newCourse);
            _db.SaveChanges();

            return course;
        }

        public bool EditCourse(Course course)
        {
            var original = _db.Courses.SingleOrDefault(x => x.Id == course.Id);
            if (original != null)
            {
                original.Title = course.Title;
                original.Subject = course.Subject;
                original.Grades = course.Grades;
                original.Students = course.Students;
                original.Teacher = course.Teacher;
                original.Assignments = course.Assignments;

                _db.SaveChanges();

                return true;
            }
            return false;
        }

        public Course FindCourse(int id)
        {
            return _db.Courses.SingleOrDefault(x => x.Id == id);
        }

        public bool RemoveCourse(int id)
        {
            var course = _db.Courses.SingleOrDefault(x => x.Id == id);

            if (course != null)
            {
                _db.Courses.Remove(course);
                _db.SaveChanges();

                return true;
            }
            return false;
        }

        //public bool UpdateGrades(int id, string grade)
        //{
        //    var newGrade = _db.Courses.SingleOrDefault(x => x.Id == id);

        //    if (newGrade != null)
        //    {
        //        newGrade.Grades = grade;
        //        _db.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}
    }
}
