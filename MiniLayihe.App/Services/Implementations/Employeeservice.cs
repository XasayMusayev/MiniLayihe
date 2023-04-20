using MiniLayihe.App.Services.Interfaces;
using MiniLayihe.Core.Enums;
using MiniLayihe.Core.Models;
using MiniLayihe.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniLayihe.App.Services.Implementations
{
    internal class Employeeservice : IEmployeeservice
    {
        private readonly EmployeeRepository _employees=new EmployeeRepository();



        public void Create()
        {
            Employee employee = new Employee();

            Console.WriteLine("Add name");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Add name*");
                name = Console.ReadLine();
            }
            employee.Name = name;

            Console.WriteLine("Add surname");
            string surname = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(surname))
            {
                Console.WriteLine("Add surname*");
                surname = Console.ReadLine();
            }
            employee.Surname = surname;
            Console.WriteLine("Add price");
            double.TryParse(Console.ReadLine(),out double salary);
            while (salary <=0)
            {
                Console.WriteLine("Salary not true");
                Console.WriteLine("Add price*");
                double.TryParse(Console.ReadLine(), out  salary);
            }
            
             employee.Salary = salary;
            Again:
            Console.WriteLine("-Add position-");
            Console.WriteLine("1. "+Position.Backend);
            Console.WriteLine("2. "+Position.Frontend);
            Console.WriteLine("3. "+Position.Fullstack);

            string result = Console.ReadLine();
            Position position;

            switch (result)
            {
                case "1":
                    position = Position.Backend;
                    break;
                case "2":
                    position = Position.Frontend;
                    break;
                case "3":
                    position = Position.Fullstack;
                    break;
                    default:
                    Console.WriteLine("Add valid option*");
                    goto Again;
                    
            }
            employee.Position = position;
            employee.CreatedDate = DateTime.Now;

            
            _employees.Create(employee);
            Console.WriteLine("Employee yaradildi");
            
        }

        public void Delete()
        {
            Console.WriteLine("Add id");
            int.TryParse(Console.ReadLine(), out int id);

            Employee employee = _employees.GetById(id);

            if (employee==null)
            {
                Console.WriteLine("Employee not found");
                int.TryParse(Console.ReadLine(), out  id);
            }
            else
            {
                _employees.Delete(employee);
            }
        }

        public void GetAll()
        {
            List<Employee> employees = _employees.GetAll();
            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }
        }

        public void GetById()
        {
            Console.WriteLine("Add id");
            int.TryParse(Console.ReadLine(),out int id);
            Employee employee = _employees.GetById(id);

            if (employee == null)
            {
                Console.WriteLine("Employee not found");
            }
            else
            {
                Console.WriteLine(employee);
            }



        }

        public void Update()
        {
            Console.WriteLine("Add id");
            int.TryParse(Console.ReadLine(), out int id);
            Employee employee = _employees.GetById(id);

            if (_employees.GetAll().Count() > 0)
            {
                if (employee == null)
                {
                    Console.WriteLine("Employee not found");
                    Console.WriteLine("Add id*");
                    int.TryParse(Console.ReadLine(), out id);
                }

                else
                {
                    Console.WriteLine("Add name");
                    string name = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Add name*");
                        name = Console.ReadLine();
                    }
                    employee.Name = name;
                    Console.WriteLine("Add surname");
                    string surname = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(surname))
                    {
                        Console.WriteLine("Add surname*");
                        surname = Console.ReadLine();
                    }
                    employee.Surname = surname;
                    Console.WriteLine("Add price");

                    double.TryParse(Console.ReadLine(), out double salary);
                    while (salary <= 0)
                    {
                        Console.WriteLine("Salary not true");
                        Console.WriteLine("Add price*");
                        double.TryParse(Console.ReadLine(), out salary);
                    }

                    employee.Salary = salary;
                    Console.WriteLine("Add position");
                newAgain:
                    Console.WriteLine("-Add position-");
                    Console.WriteLine("1. " + Position.Backend);
                    Console.WriteLine("2. " + Position.Frontend);
                    Console.WriteLine("3. " + Position.Fullstack);

                    string result = Console.ReadLine();
                    Position position;

                    switch (result)
                    {
                        case "1":
                            position = Position.Backend;
                            break;
                        case "2":
                            position = Position.Frontend;
                            break;
                        case "3":
                            position = Position.Fullstack;
                            break;
                        default:
                            Console.WriteLine("Add valid option*");
                            goto newAgain;

                    }
                    Console.WriteLine("Employee updated");
                    employee.Position = position;
                }
            }
            else
            {
               
                Console.WriteLine("Employye is epmty");
            }

        }
    }
}
