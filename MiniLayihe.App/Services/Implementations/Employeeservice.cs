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

        public DateTime CreatedDate { get; private set; }

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
            CreatedDate = DateTime.Now;
            
            _employees.Create(employee);
            
        }

        public void Delete()
        {
            Console.WriteLine("Add id");
            int.TryParse(Console.ReadLine(), out int id);

            Employee employee = _employees.GetById(id);

            if (employee==null)
            {
                Console.WriteLine("Employee not found");
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
            int id = int.Parse(Console.ReadLine());
            Employee employee = _employees.GetById(id);

            if (employee == null)
            {
                Console.WriteLine("Employee not found");
            }
            else
            {
                Console.WriteLine("Add name");
                employee.Name = Console.ReadLine();
                Console.WriteLine("Add surname");
                employee.Surname = Console.ReadLine();
                Console.WriteLine("Add price");
                employee.Salary = double.Parse(Console.ReadLine());
                Console.WriteLine("Add position");
            }

        }
    }
}
