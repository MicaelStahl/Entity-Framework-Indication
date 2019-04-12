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

                _db.Assignments.Add(assignment);

                _db.SaveChanges();

                return true;
            }
            return false;
        }

        public List<Course> AllCourses()
        {
            return _db.Courses
                .Include(x => x.StudentsCourses)
                .ThenInclude(x=>x.Student)
                .Include(x=>x.Teacher)
                .Include(x=>x.Assignments)
                .ToList();
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

                _db.SaveChanges();

                return true;
            }
            return false;
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
                StudentsCourses = course.StudentsCourses,
                Teacher = course.Teacher,
                Assignments = course.Assignments
            };
            _db.Courses.Add(newCourse);
            _db.SaveChanges();

            return newCourse;
        }

        public Course EditCourse(Course course)
        {
            var original = _db.Courses
                .Include(x=>x.StudentsCourses)
                .ThenInclude(x=>x.Student)
                .Include(x=>x.Teacher)
                .Include(x=>x.Assignments)
                .SingleOrDefault(x => x.Id == course.Id);
            if (original != null)
            {
                original.Title = course.Title;
                original.Subject = course.Subject;
                original.StudentsCourses = course.StudentsCourses;
                original.Teacher = course.Teacher;
                original.Assignments = course.Assignments;

                _db.SaveChanges();

                return original;
            }
            return course;
        }

        public Course FindCourse(int? id)
        {
            return _db.Courses.SingleOrDefault(x => x.Id == id);
        }

        public List<Course> FindCoursesNoTeacher()
        {
            List<Course> courses = new List<Course>();

            var course = _db.Courses
                .Include(x => x.Teacher)
                .ToList();

            foreach (var item in course)
            {
                if (item.Teacher == null)
                {
                    courses.Add(item);
                }
            }
            return courses;
        }

        public Course FindCourseWithStudents(int? id)
        {
            if (id == null || id == 0)
            {
                return null;
            }
            var courses = _db.Courses
                .Include(x => x.StudentsCourses)
                .ThenInclude(x => x.Student)
                .Include(x => x.Teacher)
                .Include(x => x.Assignments)
                .ThenInclude(x=>x.Course)
                .SingleOrDefault(x => x.Id == id);

            return courses;
        }

        public List<Student> FindNonAssignedStudents(int? id)
        {
            if (id == 0 || id == null)
            {
                return null;
            }
            var courses = _db.Courses.SingleOrDefault(x => x.Id == id);

            var students = _db.Students
                .Include(x => x.StudentsCourses)
                .ThenInclude(x => x.Course)
                .ToList();

            List<Student> removeStudents = new List<Student>();

            foreach (var item in students)
            {
                foreach (var value in item.StudentsCourses)
                {
                    if (value.CourseId == courses.Id)
                    {
                        removeStudents.Add(item);
                        break;
                    }
                }
            }
            foreach (var item in removeStudents)
            {
                students.Remove(item);
            }
            return students;
        }

        public bool RemoveCourse(int? id)
        {
            var course = _db.Courses.SingleOrDefault(x => x.Id == id);

            if (course == null)
            {
                return false;
            }
            _db.Courses.Remove(course);
            _db.SaveChanges();

            return true;
        }

        public bool RemoveStudentFromCourse(int? courseId, int? studentId)
        {
            if (courseId == null || courseId == 0 || studentId == null || studentId == 0)
            {
                return false;
            }

            var course = _db.Courses
                .Include(x => x.StudentsCourses)
                .ThenInclude(x => x.Student)
                .SingleOrDefault(x => x.Id == courseId);

            foreach (var item in course.StudentsCourses)
            {
                if (item.StudentId == studentId)
                {
                    course.StudentsCourses.Remove(item);

                    _db.SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public bool RemoveTeacherFromCourse(int? id)
        {
            if (id == null || id == 0)
            {
                return false;
            }
            var course = _db.Courses
                .Include(x => x.Teacher)
                .SingleOrDefault(x => x.Id == id);

            if (course == null)
            {
                return false;
            }

            if (course.Teacher != null)
            {
                course.Teacher = null;

                _db.SaveChanges();

                return true;
            }
            return false;
        }
    }
}