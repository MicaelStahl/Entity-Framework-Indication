using Entity_Framework_Indication.Interfaces;
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

        public Assignment CreateAssignment(string title, string description, string subject, DateTime dueToDate, string grades)
        {
            if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(subject) ||
                dueToDate != null ||
                string.IsNullOrWhiteSpace(grades))
            {
                return null;
            }
            Assignment assignment = new Assignment()
            { Title = title, Description = description, Subject = subject, DueToDate = dueToDate, Grades = grades };

            _db.Assignments.Add(assignment);
            _db.SaveChanges();

            return assignment;
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
                orig.Grades = assignment.Grades;

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

        public bool UpdateGrades(int id, string grades)
        {
            var newGrades = _db.Assignments.SingleOrDefault(x => x.Id == id);

            if (newGrades != null)
            {
                newGrades.Grades = grades;
                _db.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
