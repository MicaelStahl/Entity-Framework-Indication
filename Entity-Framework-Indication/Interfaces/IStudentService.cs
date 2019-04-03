using Entity_Framework_Indication.Models;
using Entity_Framework_Indication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Interfaces
{
    public interface IStudentService
    {
        Student CreateStudent(Student student);

        List<Student> AllStudents();

        Student FindStudent(int? id);

        Student EditStudent(Student student);

        bool DeleteStudent(int? id);

        //List<StudentsCourses> UpdateCourse(int? id, Course course);
    }
}
