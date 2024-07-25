using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EmployeesConsoleApp
{
    static class EmployeeManager
    {
        public static List<Employee> LoadEmployees()
        {
            if (File.Exists("employees.json"))
            {
                string json = File.ReadAllText("employees.json");
                if (!string.IsNullOrEmpty(json))
                {
                    return JsonConvert.DeserializeObject<List<Employee>>(json);
                }
            }
            return new List<Employee>();
        }

        public static void SaveEmployees(List<Employee> employees)
        {
            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            File.WriteAllText("employees.json", json);
        }

        public static void AddEmployee(List<Employee> employees, string[] parameters)
        {
            string firstName = GetParameterValue(parameters, "FirstName");
            string lastName = GetParameterValue(parameters, "LastName");
            string salaryStr = GetParameterValue(parameters, "Salary");

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(salaryStr))
            {
                Console.WriteLine("Please provide all required parameters.");
                return;
            }

            decimal salary = decimal.Parse(salaryStr);

            var employee = new Employee
            {
                Id = employees.Count > 0 ? employees[employees.Count - 1].Id + 1 : 1,
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };
            employees.Add(employee);
            Console.WriteLine($"Employee added with ID: {employee.Id}");
        }

        public static void UpdateEmployee(List<Employee> employees, string[] parameters)
        {
            int id = int.Parse(GetParameterValue(parameters, "Id"));
            var employee = employees.Find(e => e.Id == id);
            if (employee != null)
            {
                string newFirstName = GetParameterValue(parameters, "FirstName", employee.FirstName);
                string newLastName = GetParameterValue(parameters, "LastName", employee.LastName);
                string newSalaryStr = GetParameterValue(parameters, "Salary", employee.Salary.ToString());

                if (string.IsNullOrEmpty(newFirstName) || string.IsNullOrEmpty(newLastName) || string.IsNullOrEmpty(newSalaryStr))
                {
                    Console.WriteLine("Please provide all required parameters.");
                    return;
                }

                decimal newSalary = decimal.Parse(newSalaryStr);
                employee.FirstName = newFirstName;
                employee.LastName = newLastName;
                employee.Salary = newSalary;
                Console.WriteLine($"Employee with ID {id} updated.");
            }
            else
            {
                Console.WriteLine($"Employee with ID {id} not found.(404)");
            }
        }

        public static void GetEmployee(List<Employee> employees, string[] parameters)
        {
            int id = int.Parse(GetParameterValue(parameters, "Id"));
            var employee = employees.Find(e => e.Id == id);
            if (employee != null)
            {
                Console.WriteLine($"Id = {employee.Id}, FirstName = {employee.FirstName}, LastName = {employee.LastName}, Salary = {employee.Salary}");
            }
            else
            {
                Console.WriteLine($"Employee with ID {id} not found.(404)");
            }
        }

        public static void DeleteEmployee(List<Employee> employees, string[] parameters)
        {
            int id = int.Parse(GetParameterValue(parameters, "Id"));
            var employee = employees.Find(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine($"Employee with ID {id} deleted.");
            }
            else
            {
                Console.WriteLine($"Employee with ID {id} not found.(404)");
            }
        }

        public static void GetAllEmployees(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"Id = {employee.Id}, FirstName = {employee.FirstName}, LastName = {employee.LastName}, Salary = {employee.Salary}");
            }
        }

        private static string GetParameterValue(string[] parameters, string parameterName, string defaultValue = null)
        {
            foreach (var parameter in parameters)
            {
                if (parameter.StartsWith($"{parameterName}:"))
                {
                    return parameter.Substring(parameterName.Length + 1);
                }
            }
            return defaultValue;
        }
    }
}
        
