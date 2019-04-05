using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Entity_Framework_Indication.Controllers;
using Entity_Framework_Indication.Models;

namespace XUnitTestEntityFrameworkIndication
{
    public class UnitTestStudent
    {
        [Fact]
        public void ZeroStudentIndexWorks()
        {
            var studentController = new StudentController(new StudentService());
        }
    }
}
