using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniLayihe.App.Services.Interfaces
{
    internal interface IEmployeeservice
    {
        public void Create();
        public void Delete();
        public void Update();
        public void GetById();
        public void GetAll();
    }
}
