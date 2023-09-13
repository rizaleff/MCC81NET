// See https://aka.ms/new-console-template for more information
using LatihanGenericCollections;

Console.WriteLine("Hello, World!");


List<string> nama = new List<string>(); 
List<Employee> employees = new List<Employee>(); //List Object

Employee employeeRizal = new Employee();

employeeRizal.Name = "Rizal";
employeeRizal.Id = 1;
employeeRizal.Department = "IT";

employees.Add(employeeRizal); // Nambahin list


Console.WriteLine(employees.Count); // Cetak Count List

foreach (Employee employee in employees)
{
    
}
