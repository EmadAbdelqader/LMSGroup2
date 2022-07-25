<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LookupTypesList.aspx.cs" Inherits="LMSGroup2.Web.Lookups.LookupTypesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Title -->
    <h2>Types List</h2>
    <hr />
    <!-- Search Criteria -->
    <div class="row">

        <div class="col-md-4">
            <div class="form-group">
                <label for="txtUserId">Type Id</label>
                <asp:TextBox runat="server" ID="txtTypeId" CssClass="form-control" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtFirstName">Type Name</label>
                <asp:TextBox runat="server" ID="txtTypeName" CssClass="form-control" />
            </div>
        </div>
    </div>

    <hr />

    <!-- Actions -->
    <div class="row text-center mb-15">
        <div class="col-md-12">
            <asp:Button runat="server" ID="btSearch" Text="Search" CssClass="btn btn-danger" OnClick="btSearch_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:Button runat="server" ID="btAddNewType" Text="Add New Type" CssClass="btn btn-success" OnClick="btAddNewType_Click" />
        </div>
    </div>

    

    <!-- Types List -->
    <asp:ListView ID="lvLookupTypes" runat="server" DataKeyNames="TypeId">

        <LayoutTemplate>
            <table class="table table-condensed table-striped">
                <thead>
                    <th>Type Id</th>
                    <th>Type Name</th>
                    <th>Actions</th>
                </thead>
                <tbody>
                    <tr id="itemPlaceHolder" runat="server"></tr>
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Label runat="server" ID="lblUserID" Text='<%# Bind("TypeId") %>' /></td>
                <td><%# Eval("TypeName") %></td>
                <td>
                    <asp:DynamicHyperLink runat="server" Text="View" CssClass="btn btn-info" NavigateUrl='<%# GetRouteUrl("LookupTypeDetails", new { mode = "View" , Id = Eval("TypeId") }) %>' />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <table class="table table-condensed table-striped">
                <tr>
                    <td>No types available.</td>
                </tr>
            </table>
        </EmptyDataTemplate>

    </asp:ListView>


</asp:Content>
