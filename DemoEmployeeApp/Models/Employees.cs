using System;
using System.Collections.Generic;

namespace DemoEmployeeApp.Models
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public DateTime HireDate { get; set; }
        public List<Address> Addresses = new List<Address>();
    }
}