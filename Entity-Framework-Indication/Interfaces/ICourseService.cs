using Entity_Framework_Indication.Models;
using Entity_Framework_Indication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Interfaces
{
    public interface ICourseService
    {
        Course CreateCourse(Course course);

        List<Course> AllCourses();

        Course FindCourse(int? id);

        bool RemoveCourse(int? id);

        bool EditCourse(Course course);

        bool AddStudent(int? courseId, int? studentId);

        //bool UpdateGrades(int id, string grade);

        bool AddAssignment(int? id, Assignment assignment);
    }
}
