<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LookupTypeDetails.aspx.cs" Inherits="LMSGroup2.Web.Lookups.LookupTypeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        function canSave() {
            var message = '';

            var typeName = $("#<%=txtTypeName.ClientID %>").val();
            ////////var typeNameJs = document.getElementById("<%=txtTypeName.ClientID%>").value;

            if (typeName == '')
                message += '\n\t- Type Name';

            if (message != '') {
                alert('Please provide the following details:\n' + message);
                return false;
            }
            return true;

        }
    </script>

    <!-- Title -->
    <h2>Type Details</h2>

    <!-- Search Criteria -->
    <div class="row">

        <div class="col-md-4">
            <div class="form-group">
                <label for="txtUserId">Type Id</label>
                <asp:TextBox ReadOnly="true" runat="server" ID="txtTypeId" CssClass="form-control" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtFirstName">Type Name</label>
                <asp:TextBox runat="server" ID="txtTypeName" CssClass="form-control" />
            </div>
        </div>
    </div>


    <!-- Actions -->
    <div class="row mb-15">
        <div class="col-md-12">
            <asp:Button runat="server" ID="btSave" Text="Save" CssClass="btn btn-primary" OnClick="btSave_Click" OnClientClick="javascript:return canSave()"/>
        </div>
    </div>

    <hr />
    <div class="row">
        <div class="col-md-12">
            <h3>Lookups</h3>
            <asp:Button runat="server" ID="btAddNewLookup" Text="Add New Lookup" CssClass="btn btn-success" OnClick="btAddNewLookup_Click" />

            <!-- Types List -->
            <asp:ListView ID="lvLookups" runat="server" DataKeyNames="LookUpId">
                <LayoutTemplate>
                    <table class="table table-condensed table-striped">
                        <thead>
                            <th>LookUp Id</th>
                            <th>Description</th>
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
                            <asp:Label runat="server" ID="lblUserID" Text='<%# Bind("LookUpId") %>' /></td>
                        <td><%# Eval("LookupDescription") %></td>
                        <td>
                            <asp:DynamicHyperLink runat="server" Text="View" CssClass="btn btn-info" NavigateUrl='<%# GetRouteUrl("LookupDetails", new { mode = "View", TypeId= Eval("TypeId") , Id = Eval("LookUpId") }) %>' />
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
        </div>
    </div>

</asp:Content>
