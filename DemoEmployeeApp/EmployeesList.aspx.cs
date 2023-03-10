using DemoEmployeeApp.DAL;
using DemoEmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoEmployeeApp
{
    public partial class Employees1 : System.Web.UI.Page
    {
        private IEmployeeRepository _employeeRepo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _employeeRepo = new EmployeeRepository();
                var employees = _employeeRepo.GetAll();

                this.gridEmployees.DataSource = GetEmployeesDT(employees);
                this.gridEmployees.AutoGenerateColumns = false;
                this.gridEmployees.DataBind();
            }
        }

        private DataTable GetEmployeesDT(List<Employees> employees)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("EmployeeId");
            dataTable.Columns.Add("FirstName");
            dataTable.Columns.Add("LastName");
            dataTable.Columns.Add("JobTitle");
            dataTable.Columns.Add("HireDate");
            dataTable.Columns.Add("Address");

            foreach (var employee in employees)
            {
                string adrs = "";

                DataRow row = dataTable.NewRow();
                row["EmployeeId"] = employee.EmployeeId;
                row["FirstName"] = employee.FirstName;
                row["LastName"] = employee.LastName;
                row["JobTitle"] = employee.JobTitle;
                row["HireDate"] = employee.HireDate.ToString("MM/dd/yyy");

                foreach (var address in employee.Addresses)
                {
                    adrs += address.Address1 + ", " + address.AddressCity + "|";
                }
                row["Address"] += adrs;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        protected void gridEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].Text = e.Row.Cells[4].Text.Replace("|", "<br/>");
        }

        protected void gridEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Details") return;
                Response.Redirect("/EmployeeDetails?EmployeeId=" + e.CommandArgument);
        }
    }
}