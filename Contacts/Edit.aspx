<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Contacts.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-2">
    </div>
    <div class="col-lg-5">
        <h2>Contact</h2>
        <h4>Edit</h4>
        <hr />
        <div class="form-horizontal">
            <div class="form-group">
                <span class="control-label col-md-2">Name</span>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <span class="control-label col-md-2">Address</span>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <span class="control-label col-md-2">City</span>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtCity" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <span class="control-label col-md-2">State</span>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtState" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <span class="control-label col-md-2">Zip</span>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtZip" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <span class="control-label col-md-2">Email</span>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <span class="control-label col-md-2">Twitter</span>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtTwitter" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Save" class="btn btn-default" />
                 | <a href="Default.aspx">Back To List</a>
            </div>
        </div>
    </div>
    <div class="col-lg-5">
    </div>
</asp:Content>
