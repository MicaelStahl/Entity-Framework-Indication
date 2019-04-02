using Entity_Framework_Indication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Interfaces
{
    public interface IAssignmentService
    {
        Assignment CreateAssignment(string title, string description, string subject, DateTime dueToDate, string grades);

        List<Assignment> AllAssignments();

        Assignment FindAssignment(int id);

        bool RemoveAssignment(int id);

        bool UpdateGrades(int id, string grades);

        bool EditAssignment(Assignment assignment);


    }
}
