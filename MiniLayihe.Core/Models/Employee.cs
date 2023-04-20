using MiniLayihe.Core.Enums;
using MiniLayihe.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MiniLayihe.Core.Models
{
    public class Employee:BaseModel
    {
        private static int _id;
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Salary { get; set; }
        public Position Position { get; set; }
        public Employee()
        {
            _id++;
            Id = _id;

        }

        public override string ToString()
        {
            return $"  {Id}  {Name}  {Surname}  {Salary}  {Position} {CreatedDate}  ";
        }
    }
}
