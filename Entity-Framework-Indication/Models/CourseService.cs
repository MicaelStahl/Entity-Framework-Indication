using Entity_Framework_Indication.Interfaces;
using Entity_Framework_Indication.ViewModels;
using Microsoft.EntityFrameworkCore;
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

        public bool AddAssignment(int? id, Assignment assignment)
        {
            if (id != null || assignment != null)
            {
                var course = _db.Courses.SingleOrDefault(x => x.Id == id);
                course.Assignments.Add(assignment);

                _db.SaveChanges();

                return true;
            }
            return false;
        }

        public bool AddStudent(StudentsCourses student)
        {
            if (student != null)
            {

                _db.Sc.Add(student);
                _db.SaveChanges();

                return true;
            }


            return false;
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

            Course newCourse = new Course()
            {
                Title = course.Title,
                Subject = course.Subject,
                Grades = course.Grades,
                StudentsCourses = course.StudentsCourses,
                Teacher = course.Teacher,
                Assignments = course.Assignments,
            };
            //StudentsCourses nC = new StudentsCourses();

            //nC.Course.Title = newCourse.Title;
            //nC.Course.Subject = newCourse.Subject;
            //nC.Course.Grades = newCourse.Grades;
            //nC.Course.StudentsCourses = newCourse.StudentsCourses;
            //nC.Course.Assignments = newCourse.Assignments;
            //nC.Course.Teacher = newCourse.Teacher;

            //_db.Sc.Add(nC);
            _db.Courses.Add(newCourse);
            _db.SaveChanges();

            return newCourse;
        }

        public bool EditCourse(Course course)
        {
            var original = _db.Courses.SingleOrDefault(x => x.Id == course.Id);
            if (original != null)
            {
                original.Title = course.Title;
                original.Subject = course.Subject;
                original.Grades = course.Grades;
                original.StudentsCourses = course.StudentsCourses;
                original.Teacher = course.Teacher;
                original.Assignments = course.Assignments;

                _db.SaveChanges();

                return true;
            }
            return false;
        }

        public Course FindCourse(int? id)
        {
            if (id != null)
            {

                return _db.Courses.SingleOrDefault(x => x.Id == id);
            }
            return null;
        }

        public bool RemoveCourse(int? id)
        {
            if (id != null)
            {
                var course = _db.Courses.SingleOrDefault(x => x.Id == id);

                if (course != null)
                {
                    _db.Courses.Remove(course);
                    _db.SaveChanges();

                    return true;
                }
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
