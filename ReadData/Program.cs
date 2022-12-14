using System;

namespace ReadData
{
    class Program
    {
        static void Main(string[] args)
        {
            var empRepos = new EmployeeRepository();
            var employeeList = empRepos.GetEmployee();
            var EmployeeById3 = empRepos.GetEmployeeByID(3);
            var EmployeeById5 = empRepos.GetEmployeeByID(5);
            Console.WriteLine("\nEmployee Data from SQL :-\n");
            foreach (var emp in employeeList)
            {
                Console.WriteLine($"{emp.EmpId} ---- {emp.EmpName} ---- {emp.EmpAge}");              
            }
            Console.WriteLine($"\nThe 3rd Employee is : {EmployeeById3.EmpId} ---- {EmployeeById3.EmpName} ---- {EmployeeById3.EmpAge}");
            Console.WriteLine($"\nThe 3rd Employee is : {EmployeeById5.EmpId} ---- {EmployeeById5.EmpName} ---- {EmployeeById5.EmpAge}");


            Console.ReadKey();
        }
    }
}
