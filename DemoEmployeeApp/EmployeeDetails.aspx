<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="DemoEmployeeApp.EmployeeDetails" %>

<asp:Content ID="EmployeeContent" ContentPlaceHolderID="MainContent" runat="server">
    </br>
    <div class="row">
        <div class="col-sm-6">
            <asp:Panel ID="pnlPersonal" runat="server" GroupingText="Personal Information">
                <div class="form-group">
                    <label>First Name:</label>
                    <asp:TextBox ID="txtFirstName" runat="server" class="form-control"></asp:TextBox>
                <div class="form-group">
                    <label>Last Name:</label>
                    <asp:TextBox ID="txtLastName" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Job Title:</label>
                    <asp:TextBox ID="txtJobTitle" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Hired Date:</label>
                    <asp:TextBox ID="txtHireDate" runat="server" class="form-control"></asp:TextBox>
                </div>
            </asp:Panel>
        </div>
        <div class="col-sm-6">
            <asp:Panel ID="pnlAddress" runat="server" >
            </asp:Panel>
        </div>
    </div>
    <div class="row">
        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success btn-md pull-right mr-15" OnClick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-default btn-md pull-right mr-5" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
