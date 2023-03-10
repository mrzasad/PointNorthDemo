using Dapper;
using DemoEmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEmployeeApp.DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private SqlConnection _db;

        public EmployeeRepository()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
        }

        public List<Employees> GetAll()
        {
            var query = "Select e.EmployeeId, e.FirstName, e.LastName, e.JobTitle, e.HireDate, a.AddressId, a.Address1, a.Address2, a.AddressCity, a.AddressState, a.AddressZip, a.EmployeeId from Employees e "
                                            + "INNER JOIN[Address] a ON e.EmployeeId = a.EmployeeId";

            var employeeDictionary = new Dictionary<int, Employees>();

            var employees = this._db.Query<Employees, Address, Employees>(query, (emp, address) =>
            {
                Employees employee;

                if (!employeeDictionary.TryGetValue(emp.EmployeeId, out employee))
                {
                    employee = emp;
                    employee.Addresses = new List<Address>();
                    employeeDictionary.Add(employee.EmployeeId, employee);
                }

                if (address.AddressId > 0) employee.Addresses.Add(address);
                return employee;
            }, splitOn: "AddressId");

            return employees.Distinct().ToList();
        }

        public Employees GetById(int employeeId)
        {
            var query = "Select e.EmployeeId, e.FirstName, e.LastName, e.JobTitle, e.HireDate, a.AddressId, a.Address1, a.Address2, a.AddressCity, a.AddressState, a.AddressZip from Employees e "
                        + "INNER JOIN [Address] a ON e.EmployeeId = a.EmployeeId Where e.EmployeeId = @EmployeeId";

            var employeeDictionary = new Dictionary<int, Employees>();

            var employeeObj = this._db.Query<Employees, Address, Employees>(query, (emp, address) =>
            {
                Employees employee;

                if (!employeeDictionary.TryGetValue(emp.EmployeeId, out employee))
                {
                    employee = emp;
                    employee.Addresses = new List<Address>();
                    employeeDictionary.Add(employee.EmployeeId, employee);
                }

                if (address.AddressId > 0) employee.Addresses.Add(address);
                return employee;
            }, new { EmployeeId = employeeId }, splitOn: "AddressId").FirstOrDefault();

            return employeeObj;
        }

        public bool Update(Employees employee)
        {
            DynamicParameters employeeParameters = new DynamicParameters();
            employeeParameters.Add("@EmployeeId", employee.EmployeeId);
            employeeParameters.Add("@FirstName", employee.FirstName);
            employeeParameters.Add("@LastName", employee.LastName);
            employeeParameters.Add("@JobTitle", employee.JobTitle);
            employeeParameters.Add("@HireDate", employee.HireDate);

            string updateEmployeeQuery = " UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, JobTitle = @JobTitle, HireDate = @HireDate WHERE EmployeeId = @EmployeeId";

            string updateAddressQuery = " UPDATE Address SET Address1 = @Address1, Address2 = @Address2, AddressCity = @AddressCity, AddressState = @AddressState, AddressZip = @AddressZip WHERE AddressId = @AddressId";

            try
            {
                this._db.Execute(updateEmployeeQuery, employeeParameters);

                foreach (var address in employee.Addresses)
                {
                    DynamicParameters addresssParameters = new DynamicParameters();
                    addresssParameters.Add("@AddressId", address.AddressId);
                    addresssParameters.Add("@Address1", address.Address1);
                    addresssParameters.Add("@Address2", address.Address2);
                    addresssParameters.Add("@AddressCity", address.AddressCity);
                    addresssParameters.Add("@AddressState", address.AddressState);
                    addresssParameters.Add("@AddressZip", address.AddressZip);

                    this._db.Execute(updateAddressQuery, addresssParameters);
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}