using DemoEmployeeApp.DAL;
using DemoEmployeeApp.Models;
using DemoEmployeeApp.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoEmployeeApp
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        private IEmployeeRepository _employeeRepo;
        Employees employee = new Employees();
        AddressUC addressesControl;

        protected void Page_Init(object sender, EventArgs e)
        {
            _employeeRepo = new EmployeeRepository();

            if (Request.QueryString["EmployeeId"] != null && Request.QueryString["EmployeeId"] != string.Empty)
            {
                int employeeId = Convert.ToInt32(Request.QueryString["EmployeeId"]);

                employee = _employeeRepo.GetById(employeeId);

                txtFirstName.Text = employee.FirstName;
                txtLastName.Text = employee.LastName;
                txtJobTitle.Text = employee.JobTitle;
                txtHireDate.Text = employee.HireDate.ToString("MM/dd/yyyy");

                addressesControl = GenerateAddresses(employee.Addresses);
            }
            else
            {
                Response.Redirect("/EmployeesList");
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EmployeesList");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.JobTitle = txtJobTitle.Text;
            employee.HireDate = Convert.ToDateTime(txtHireDate.Text);
            UpdateAddresses();

            var isUpdated = _employeeRepo.Update(employee);

            if (isUpdated)
                Response.Redirect("/EmployeesList");
        }

        #region ------------ Private Methods -----------

        private AddressUC GenerateAddresses(List<Address> addresses)
        {
            if (addresses.Count > 0 && addresses != null)
            {
                AddressUC addressUC = new AddressUC(addresses);
                this.pnlAddress.Controls.Add(addressUC);

                return addressUC;
            }
            else
            {
                Label lblMessage = new Label() { Text = "No addresses provided" };
                this.pnlAddress.Controls.Add(lblMessage);
                return null;
            }
        }

        private void UpdateAddresses()
        {
            foreach (var address in employee.Addresses)
            {
                foreach (Control addressPnl in addressesControl.Controls)
                {
                    if (addressPnl.GetType() == typeof(Panel) && ((Panel)addressPnl).ID == address.AddressId.ToString())
                    {
                        var pnl = (Panel)addressPnl;

                        foreach (Control pnlCtrl in pnl.Controls)
                        {
                            if (pnlCtrl.GetType() == typeof(TextBox))
                            {
                                var textBox = (TextBox)pnlCtrl;
                                var txtPropName = textBox.ID.Split('-')[0];

                                address.GetType().GetProperty(txtPropName).SetValue(address, textBox.Text);
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}