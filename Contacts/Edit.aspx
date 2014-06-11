<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Contacts.Edit" %>
<%@ Register assembly="Contacts" namespace="Contacts.controls" tagprefix="cc1" %>

<%@ Register src="controls/ctlPhoneNumbers.ascx" tagname="ctlPhoneNumbers" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-2">
        </div>
        <div class="col-lg-8">
            <h2>Contact</h2>
            <h4>Edit</h4>
            <hr />
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="row">
        <div class="col-lg-2">
        </div>
        <div class="col-lg-5">
            <div class="form-horizontal">
                <cc1:FormControl runat="server" RowClass="form-group" ID="txtName" LabelClass="control-label" Col1Class="col-md-2" LabelText="Name" Col2Class="col-md-10" InputClass="form-control" />

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

                
            </div>
        </div>

        <div class="col-lg-5">
            <uc1:ctlPhoneNumbers ID="ctlPhoneNumbers1" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-5">
            <div class="col-md-offset-2 col-md-10">
                <br /><br />
                <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Save" class="btn btn-default" />
                    | <a href="Default.aspx">Back To List</a>
            </div>
        </div>
        <div class="col-lg-5">
        </div>
    </div>
</asp:Content>
