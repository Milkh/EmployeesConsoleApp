using NUnit.Framework;
using System;
using System.Collections.Generic;
using EmployeesConsoleApp;

namespace TestProjectEmployeesApp.Test
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void Employee_CreateNewEmployee_PropertiesAreCorrect()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 1,
                FirstName = "Temp",
                LastName = "Temp",
                Salary = 5000
            };

            // Act
            //---


            // Assert
            Assert.AreEqual(1, employee.Id, "ID should be correct");
            Assert.AreEqual("Temp", employee.FirstName, "First name should be correct");
            Assert.AreEqual("Temp", employee.LastName, "Last name should be correct");
            Assert.AreEqual(5000m, employee.Salary, "Salary should be correct");
            
        }
    }
}