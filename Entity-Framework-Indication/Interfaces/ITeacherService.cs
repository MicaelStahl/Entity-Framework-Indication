using Entity_Framework_Indication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Interfaces
{
    public interface ITeacherService
    {
        // Add more values to CreateTeacher later. Bound to be more than just name.
        Teacher CreateTeacher(Teacher teacher);

        List<Teacher> AllTeachers();

        Teacher FindTeacher(int id);

        bool EditTeacher(Teacher teacher);

        bool RemoveTeacher(int id);

    }
}
