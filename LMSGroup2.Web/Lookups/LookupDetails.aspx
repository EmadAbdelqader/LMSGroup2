<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LookupDetails.aspx.cs" Inherits="LMSGroup2.Web.Lookups.LookupDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lookup</h2>

    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtTypeId">Type Id</label>
                <asp:TextBox ReadOnly="true" runat="server" ID="txtTypeId" CssClass="form-control" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtLookupId">LookupId</label>
                <asp:TextBox runat="server" ReadOnly="true" ID="txtLookupId" CssClass="form-control" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtDescription">Description</label>
                <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:Button CssClass="btn btn-danger" runat="server" ID="btSave" Text="Save" OnClick="btSave_Click" />
        </div>
    </div>
</asp:Content>
