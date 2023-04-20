
using MiniLayihe.App.Services.Implementations;
using MiniLayihe.App.Services.Interfaces;
using MiniLayihe.Core.Models;
using System.Linq.Expressions;


IEmployeeservice employeeservice = new Employeeservice();
Console.WriteLine("0. Close");
Console.WriteLine("1. Create employee");
Console.WriteLine("2. Delete employee");
Console.WriteLine("3. Show employee");
Console.WriteLine("4. Get by id employee");
Console.WriteLine("5. Update employee");


string command = Console.ReadLine();

while (command!="0")
{

    switch (command)
    {
        case "1":
            employeeservice.Create();
            break;
        case "2":
            employeeservice.Delete();
            break;
        case "3":
            employeeservice.GetAll();
            break;
        case "4":
            employeeservice.GetById();
            break;
        case "5":
            employeeservice.Update();
            break;
        default:
            Console.WriteLine("Get valid option");
            break;
    }

    command = Console.ReadLine();
    Console.WriteLine("0. Close");
    Console.WriteLine("1. Create employee");
    Console.WriteLine("2. Delete employee");
    Console.WriteLine("3. Show employee");
    Console.WriteLine("4. Get by id employee");
    Console.WriteLine("5. Update employee");


}