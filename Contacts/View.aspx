<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Contacts.View" %>
<%@ Register assembly="Contacts" namespace="Contacts.controls" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-2">
    </div>
    <div class="col-lg-5">
        <h2>Contact
        </h2>
        <h4 runat="server" id="subtitle">Details</h4>
        <hr />
        <dl class="dl-horizontal">
            <cc1:ReadOnlyFormControl ID="rofcName" LabelText="Name" runat="server"></cc1:ReadOnlyFormControl>
            <cc1:ReadOnlyFormControl ID="rofcAddress" LabelText="Address" runat="server"></cc1:ReadOnlyFormControl>
            <cc1:ReadOnlyFormControl ID="rofcCity" LabelText="City" runat="server"></cc1:ReadOnlyFormControl>
            <cc1:ReadOnlyFormControl ID="rofcState" LabelText="State" runat="server"></cc1:ReadOnlyFormControl>
            <cc1:ReadOnlyFormControl ID="rofcZip" LabelText="ZIP" runat="server"></cc1:ReadOnlyFormControl>
            <cc1:ReadOnlyFormControl ID="rofcEmail" LabelText="Email" runat="server"></cc1:ReadOnlyFormControl>
            <cc1:ReadOnlyFormControl ID="rofcTwitter" LabelText="Twitter" runat="server"></cc1:ReadOnlyFormControl>

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
