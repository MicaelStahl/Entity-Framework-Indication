using Entity_Framework_Indication.Models;
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

        Student FindStudent(int id);

        bool EditStudent(Student student);

        bool DeleteStudent(int id);
    }
}
