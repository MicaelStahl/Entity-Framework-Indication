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

        Course FindCourseWithStudents(int? id);

        List<Course> FindCoursesNoTeacher();

        bool RemoveTeacherFromCourse(int? id);

        bool RemoveStudentFromCourse(int? courseId, int? studentId);

        List<Student> FindNonAssignedStudents(int? id);

        Course EditCourse(Course course);

        bool AddStudent(int? courseId, int? studentId);

        bool AddAssignment(int? id, Assignment assignment);
    }
}
