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

        public bool FindCourseWithStudents(int? id)
        {
            if (id == 0 || id == null)
            {
                return false;
            }

            //Do a Include here for the _db.Sc to add students/Courses :)

            return false;
        }

        public bool AddStudent(int? courseId, int? studentId)
        {
            if (courseId != null || studentId != null)
            {
                if (courseId == 0 || studentId == 0)
                {
                    return false;
                }

                var course = _db.Courses.SingleOrDefault(x => x.Id == courseId);
                var student = _db.Students.SingleOrDefault(x => x.Id == studentId);

                StudentsCourses sc = new StudentsCourses
                {
                    CourseId = course.Id,
                    Course = course,
                    StudentId = student.Id,
                    Student = student
                };

                _db.Sc.Add(sc);
                course.StudentsCourses.Add(sc);

                //_db.Sc.Include(x => x.Student == student)
                //        .Include(x => x.Course == course);

                _db.SaveChanges();
                //var newTemp = _db.Sc.Include("Course").ToList();

                //var temp = _db.Sc.Include(x => x.Student == student)
                //          .Include(y => y.Course == course).ToList();

                return true;
            }
            return false;
        }

        public List<Course> AllCourses()
        {
            return _db.Courses.Include(x => x.StudentsCourses).ToList();
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
                //Grades = course.Grades,
                StudentsCourses = course.StudentsCourses,
                Teacher = course.Teacher,
                Assignments = course.Assignments,
            };

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
                //original.Grades = course.Grades;
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
