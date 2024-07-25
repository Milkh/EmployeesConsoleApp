using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EmployeesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = EmployeeManager.LoadEmployees();

            bool running = true;
            while (running)
            {
                Console.WriteLine("Enter a command (add, update, get, delete, getall, exit):");
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "add":
                        AddEmployee(employees);
                        EmployeeManager.SaveEmployees(employees);
                        break;
                    case "update":
                        UpdateEmployee(employees);
                        EmployeeManager.SaveEmployees(employees);
                        break;
                    case "get":
                        GetEmployee(employees);
                        break;
                    case "delete":
                        DeleteEmployee(employees);
                        EmployeeManager.SaveEmployees(employees);
                        break;
                    case "getall":
                        EmployeeManager.GetAllEmployees(employees);
                        break;
                    case "exit":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            }
        }
        
        private static void AddEmployee(List<Employee> employees)
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter salary: ");
            string salaryStr = Console.ReadLine();
            EmployeeManager.AddEmployee(employees, new[] { $"FirstName:{firstName}", $"LastName:{lastName}", $"Salary:{salaryStr}" });
        }

        private static void UpdateEmployee(List<Employee> employees)
        {
            Console.Write("Enter employee ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter new first name (or press Enter to keep the same): ");
            string newFirstName = Console.ReadLine();
            Console.Write("Enter new last name (or press Enter to keep the same): ");
            string newLastName = Console.ReadLine();
            Console.Write("Enter new salary (or press Enter to keep the same): ");
            string newSalaryStr = Console.ReadLine();

            EmployeeManager.UpdateEmployee(employees, new[] { $"Id:{id}", $"FirstName:{newFirstName}", $"LastName:{newLastName}", $"Salary:{newSalaryStr}" });
        }

        private static void GetEmployee(List<Employee> employees)
        {
            Console.Write("Enter employee ID: ");
            int id = int.Parse(Console.ReadLine());
            EmployeeManager.GetEmployee(employees, new[] { $"Id:{id}" });
        }

        private static void DeleteEmployee(List<Employee> employees)
        {
            Console.Write("Enter employee ID: ");
            int id = int.Parse(Console.ReadLine());
            EmployeeManager.DeleteEmployee(employees, new[] { $"Id:{id}" });
        }
      
    }
}
