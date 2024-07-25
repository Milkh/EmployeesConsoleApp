using Xunit;
using System.Collections.Generic;
using System;
using EmployeesConsoleApp;

namespace EmployeesConsoleAppX.test
{
    public class EmployeeManagerTests
    {
        [Fact]
        public void AddEmployee_ValidParameters_EmployeeAdded()
        {
            // Arrange
            var employees = new List<Employee>();
            var parameters = new[] { "FirstName=John", "LastName=Doe", "Salary=5000" };

            // Act
            EmployeeManager.AddEmployee(employees, parameters);

            // Assert
            Assert.Single(employees, "Employee should be added to the list");
            Assert.Equal("John", employees[0].FirstName, "First name should be correct");
            Assert.Equal("Doe", employees[0].LastName, "Last name should be correct");
            Assert.Equal(5000m, employees[0].Salary, "Salary should be correct");
        }
    }
}