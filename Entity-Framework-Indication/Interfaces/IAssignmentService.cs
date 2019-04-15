using Entity_Framework_Indication.Models;
using Entity_Framework_Indication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Interfaces
{
    public interface IAssignmentService
    {
        Assignment CreateAssignment(Assignment assignment);

        List<Assignment> AllAssignments();

        Assignment FindAssignment(int id);

        bool RemoveAssignment(int? courseId, int? assignmentId);

        bool EditAssignment(Assignment assignment);
    }
}
