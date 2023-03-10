using DemoEmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoEmployeeApp.DAL
{
    public interface IEmployeeRepository
    {
        List<Employees> GetAll();

        Employees GetById(int employeeId);

        bool Update(Employees employee);
    }
}