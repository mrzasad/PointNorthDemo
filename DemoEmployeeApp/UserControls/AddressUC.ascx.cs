using DemoEmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoEmployeeApp.UserControls
{
    public partial class AddressUC : System.Web.UI.UserControl
    {
        public List<Address> Addresses;

        public AddressUC(List<Address> addresses)
        {
            Addresses = addresses;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var counter = 1;
            foreach (var address in Addresses)
            {

                Panel pnlAddress = new Panel() { ID = address.AddressId.ToString() };
                pnlAddress.CssClass = "mb-20";
                pnlAddress.GroupingText = "Address " + counter.ToString();

                Label lblAddress1 = new Label() { Text = "Address 1" };
                pnlAddress.Controls.Add(lblAddress1);

                TextBox txtAddress1 = new TextBox() { CssClass = "form-control", Text = address.Address1, ID = "Address1-"+address.AddressId };
                pnlAddress.Controls.Add(txtAddress1);

                Label lblAddress2 = new Label() { Text = "Address 2" };
                pnlAddress.Controls.Add(lblAddress2);

                TextBox txtAddress2 = new TextBox() { CssClass = "form-control", Text = address.Address2, ID = "Address2-" + address.AddressId };
                pnlAddress.Controls.Add(txtAddress2);

                Label lblCity = new Label() { Text = "City" };
                pnlAddress.Controls.Add(lblCity);

                TextBox txtCity = new TextBox() { CssClass = "form-control", Text = address.AddressCity, ID = "AddressCity-" + address.AddressId };
                pnlAddress.Controls.Add(txtCity);

                Label lblState = new Label() { Text = "State" };
                pnlAddress.Controls.Add(lblState);

                TextBox txtState = new TextBox() { CssClass = "form-control", Text = address.AddressState, ID = "AddressState-" + address.AddressId };
                pnlAddress.Controls.Add(txtState);
                
                Label lblZip = new Label() { Text = "Zip" };
                pnlAddress.Controls.Add(lblZip);

                TextBox txtZip = new TextBox() { CssClass = "form-control", Text = address.AddressZip, ID = "AddressZip-" + address.AddressZip };
                pnlAddress.Controls.Add(txtZip);

                this.Controls.Add(pnlAddress);

                counter++;
            }
        }
    }
}