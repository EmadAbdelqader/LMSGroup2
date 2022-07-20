<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="LMSGroup2.Web.Users.UserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Title -->
    <h2>User Details</h2>

    <!-- Search Criteria -->
    <div class="row">

        <div class="col-md-4">
            <div class="form-group">
                <label for="lblUserId">User Id</label>
                <asp:label runat="server" ID="lblUserId" CssClass="form-control" />
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
    <div class="row ">
        <div class="col-md-12">
            <asp:Button runat="server" ID="btSave" Text="Save" CssClass="btn btn-danger" OnClick="btSave_Click" />
        </div>
    </div>

    <h3>Leave Applications</h3>
    <!-- Users List -->
    <asp:ListView ID="lvLeaveApplicatoins" runat="server" DataKeyNames="AppId">

        <LayoutTemplate>
            <table class="table table-condensed table-striped">
                <thead>
                    <th>LeaveApp Id</th>
                    <th>From Date</th>
                    <th>To Date</th>
                    <th>Total Days</th>
                    <th>Actions</th>
                </thead>
                <tbody>
                    <tr id="itemPlaceHolder" runat="server"></tr>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Label runat="server" ID="lblUserID" Text='<%# Bind("AppId") %>' /></td>
                <td><%# Eval("FromDate") %></td>
                <td><%# Eval("ToDate") %></td>
                <td><%# Eval("TotalDays") %></td>
                <td>
                    <asp:DynamicHyperLink runat="server" Text="View" CssClass="btn btn-info" NavigateUrl='<%# GetRouteUrl("LeaveDetails", new { mode = "View" , Id = Eval("AppId") }) %>' />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <table class="table table-condensed table-striped">
                <tr>
                    <td>No leaves available.</td>
                </tr>
            </table>
        </EmptyDataTemplate>

    </asp:ListView>

</asp:Content>
