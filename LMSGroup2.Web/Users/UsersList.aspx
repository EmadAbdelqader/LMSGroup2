<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="LMSGroup2.Web.Users.UsersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Title -->
    <h2>Users List</h2>

    <!-- Search Criteria -->
    <div class="row">

        <div class="col-md-4">
            <div class="form-group">
                <label for="txtUserId">User Id</label>
                <asp:TextBox runat="server" ID="txtUserId" CssClass="form-control" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtFirstName">First Name</label>
                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtLastName">Last Name</label>
                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />
            </div>
        </div>

    </div>


    <!-- Actions -->
    <div class="row text-center">
        <div class="col-md-12">
            <asp:Button runat="server" ID="btSearch" Text="Search" CssClass="btn btn-primary" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:Button runat="server" ID="btAddNewUser" Text="Add New" CssClass="btn btn-success" OnClick="btAddNewUser_Click" />
        </div>
    </div>

    

    <!-- Users List -->
    <asp:ListView ID="lvUsers" runat="server" DataKeyNames="UserId">

        <LayoutTemplate>
            <table class="table table-condensed table-striped">
                <thead>
                    <th>User Id</th>
                    <th>First Name</th>
                    <th>Middle Name</th>
                    <th>Last Name</th>
                    <th>Email</th>
                    <th>Username</th>
                    <th>User Level</th>
                    <th>Actions</th>
                </thead>
                <tbody>
                    <tr id="itemPlaceHolder" runat="server"></tr>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Label runat="server" ID="lblUserID" Text='<%# Bind("UserId") %>' /></td>
                <td><%# Eval("FirstName") %></td>
                <td><%# Eval("MiddleName") %></td>
                <td><%# Eval("LastName") %></td>
                <td><%# Eval("Email") %></td>
                <td><%# Eval("Username") %></td>
                <td><%# Eval("UserLevel") %></td>
                <td>
                    <asp:DynamicHyperLink runat="server" Text="View" CssClass="btn btn-info" NavigateUrl='<%# GetRouteUrl("UserDetails", new { mode = "View" , Id = Eval("UserId") }) %>' />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>No users available.</td>
                </tr>
            </table>
        </EmptyDataTemplate>

    </asp:ListView>

</asp:Content>
