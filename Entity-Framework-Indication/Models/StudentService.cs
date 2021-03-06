﻿using Entity_Framework_Indication.Interfaces;
using Entity_Framework_Indication.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Models
{
    public class StudentService : IStudentService
    {
        private readonly SchoolDbContext _db;

        public StudentService(SchoolDbContext studentDbContext)
        {
            _db = studentDbContext;
        }

        public StudentService() { }

        public List<Student> AllStudents()
        {
            return _db.Students.ToList();
        }

        public Student CreateStudent(Student student)
        {
            Student newStudent = new Student()
            {
                FirstName = student.FirstName,
                SecondName = student.SecondName,
                SchoolYear = student.SchoolYear,
                PhoneNumber = student.PhoneNumber
            };

            _db.Students.Add(newStudent);
            _db.SaveChanges();

            return newStudent;
        }

        public bool DeleteStudent(int? id)
        {
            Student student = _db.Students.SingleOrDefault(x => x.Id == id);

            if (student != null)
            {
                _db.Students.Remove(student);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Student EditStudent(Student student)
        {
            Student Original = _db.Students.SingleOrDefault(x => x.Id == student.Id);

            if (Original != null)
            {
                Original.FirstName = student.FirstName;
                Original.SecondName = student.SecondName;
                Original.PhoneNumber = student.PhoneNumber;
                Original.SchoolYear = student.SchoolYear;
                Original.StudentsCourses = student.StudentsCourses;

                _db.SaveChanges();

                return Original;
            }
            return null;
        }

        public Student FindStudent(int? id)
        {
            var students = _db.Students
                    .Include(x => x.StudentsCourses)
                    .ThenInclude(x => x.Course)
                    .ThenInclude(x => x.Assignments)
                    .Include(x => x.StudentsCourses)
                    .ThenInclude(x => x.Course)
                    .ThenInclude(x => x.Teacher)
                    .AsNoTracking()
                    .SingleOrDefault(x => x.Id == id);

            return students;
        }
    }
}
