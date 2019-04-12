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
        bool AddStudent(int? courseId, int? studentId);

        bool AddAssignment(int? id, Assignment assignment);

        List<Course> AllCourses();

        Course CreateCourse(Course course);

        Course EditCourse(Course course);

        Course FindCourse(int? id);

        Course FindCourseWithStudents(int? id);

        List<Course> FindCoursesNoTeacher();

        List<Student> FindNonAssignedStudents(int? id);

        bool RemoveCourse(int? id);

        bool RemoveTeacherFromCourse(int? id);

        bool RemoveStudentFromCourse(int? courseId, int? studentId);
    }
}
