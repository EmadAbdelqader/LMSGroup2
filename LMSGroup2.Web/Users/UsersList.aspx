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
            <asp:Button runat="server" ID="btSearch" Text="Search" CssClass="btn btn-primary" OnClick="btSearch_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:Button runat="server" ID="btAddNewUser" Text="Add New" CssClass="btn btn-success" OnClick="btAddNewUser_Click" />
        </div>
    </div>


<%--    <asp:UpdatePanel runat="server" ID="upUsers">
        <ContentTemplate>--%>
            <!-- Users List -->
            <asp:ListView ID="lvUsers" runat="server" DataKeyNames="UserId" OnItemCommand="lvUsers_ItemCommand" OnItemDeleting="lvUsers_ItemDeleting">

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
                            <th>Created On</th>
                            <th>Actions</th>
                        </thead>
                        <tbody>
                            <tr id="itemPlaceHolder" runat="server"></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblUserID" Text='<%# Bind("UserId") %>' /></td>
                        <td><%# Eval("FirstName") %></td>
                        <td><%# Eval("MiddleName") %></td>
                        <td><%# Eval("LastName") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("Username") %></td>
                        <td><%# Eval("UserLevel") %></td>
                        <td><%# Eval("CreatedOn") %></td>
                        <td>
                            <asp:DynamicHyperLink runat="server" Text="View" CssClass="btn btn-info" NavigateUrl='<%# GetRouteUrl("UserDetails", new { mode = "View" , Id = Eval("UserId") }) %>' />
                            <asp:LinkButton runat="server" Text="View" CssClass="btn btn-danger" CommandName="View" CommandArgument='<%# Eval("UserId") %>' />
                            <asp:LinkButton ID="btDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="Delete" CommandArgument='<%# Eval("UserId") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table class="table table-condensed table-striped">
                        <tr>
                            <td>No users available.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>

            </asp:ListView>
<%--        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btSearch" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>--%>


</asp:Content>
