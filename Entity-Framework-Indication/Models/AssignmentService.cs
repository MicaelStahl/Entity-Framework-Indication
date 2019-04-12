using Entity_Framework_Indication.Interfaces;
using Entity_Framework_Indication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Models
{
    public class AssignmentService : IAssignmentService
    {
        private readonly SchoolDbContext _db;

        public AssignmentService(SchoolDbContext AssignmentDbContext)
        {
            _db = AssignmentDbContext;
        }

        public List<Assignment> AllAssignments()
        {
            return _db.Assignments.ToList();
        }

        public Assignment CreateAssignment(Assignment assignment)
        {
            if (string.IsNullOrWhiteSpace(assignment.Title) ||
                string.IsNullOrWhiteSpace(assignment.Subject) ||
                assignment.DueToDate != null)
            {
                return null;
            }
            Assignment newAssignment = new Assignment()
            {
                Title = assignment.Title,
                Description = assignment.Description,
                Subject = assignment.Subject,
                DueToDate = assignment.DueToDate
            };

            _db.Assignments.Add(newAssignment);
            _db.SaveChanges();

            return newAssignment;
        }

        public bool EditAssignment(Assignment assignment)
        {
            var orig = _db.Assignments.SingleOrDefault(x => x.Id == assignment.Id);

            if (orig != null)
            {
                orig.Title = assignment.Title;
                orig.Description = assignment.Description;
                orig.Subject = assignment.Subject;
                orig.DueToDate = assignment.DueToDate;

                _db.SaveChanges();

                return true;
            }
            return false;
        }

        public Assignment FindAssignment(int id)
        {
            return _db.Assignments.SingleOrDefault(x => x.Id == id);
        }

        public bool RemoveAssignment(int id)
        {
            var assignment = _db.Assignments.SingleOrDefault(x => x.Id == id);

            if (assignment != null)
            {
                _db.Assignments.Remove(assignment);

                return true;
            }
            return false;
        }
    }
}
