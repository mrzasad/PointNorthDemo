<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesList.aspx.cs" Inherits="DemoEmployeeApp.Employees1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Employees</h1>
    <div class="row">
        <asp:GridView ID="gridEmployees" runat="server" Height="213px" Width="100%" class="table table-bordered table-hover" OnRowDataBound="gridEmployees_RowDataBound" OnRowCommand="gridEmployees_RowCommand">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" >
                </asp:BoundField>
                <asp:BoundField DataField="LastName" HeaderText="Last Name" >
                </asp:BoundField>
                <asp:BoundField DataField="JobTitle" HeaderText="Job Title" >
                </asp:BoundField>
                <asp:BoundField DataField="HireDate" HeaderText="Hire Date" >
                </asp:BoundField>
                <asp:BoundField DataField="Address" HeaderText="Address" >
                </asp:BoundField>
                <asp:TemplateField ShowHeader="True" HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnDetails" runat="server" CommandName="Details"
                            Text="Details" CommandArgument='<%# Eval("EmployeeId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>
</asp:Content>
