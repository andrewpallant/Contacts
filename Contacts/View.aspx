<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Contacts.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-2">
    </div>
    <div class="col-lg-5">
        <h2>Contact</h2>
        <h4 runat="server" id="subtitle">Details</h4>
        <hr />
        <dl class="dl-horizontal">
            <dt>Name</dt>
            <dd>
                <asp:Label runat="server" ID="txtName"></asp:Label>
            </dd>

            <dt>Address</dt>
            <dd>
                <asp:Label runat="server" ID="txtAddress"></asp:Label>
            </dd>

            <dt>City</dt>
            <dd>
                <asp:Label runat="server" ID="txtCity"></asp:Label>
            </dd>

            <dt>State</dt>
            <dd>
                <asp:Label runat="server" ID="txtState"></asp:Label>
            </dd>

            <dt>Zip</dt>
            <dd>
                <asp:Label runat="server" ID="txtZip"></asp:Label>
            </dd>

            <dt>Email</dt>
            <dd>
                <asp:Label runat="server" ID="txtEmail"></asp:Label>
            </dd>

            <dt>Twitter</dt>
            <dd>
                <asp:Label runat="server" ID="txtTwitter"></asp:Label>
            </dd>

            <div class="col-md-offset-2 col-md-10">
                <br />
                <asp:Button runat="server" ID="btnDelete" Text="Delete" class="btn btn-default" OnClick="btnDelete_Click" />
                <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" OnClick="lnkEdit_Click"></asp:LinkButton>
                | <a href="Default.aspx">Back To List</a>
            </div>
        </dl>
    </div>
    <div class="col-lg-5">
    </div>
</asp:Content>
