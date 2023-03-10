using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoEmployeeApp.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int EmployeeId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}