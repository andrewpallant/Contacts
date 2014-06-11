<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlPhoneNumbers.ascx.cs" Inherits="Contacts.controls.ctlPhoneNumbers" %>
<div style="height:200px;overflow:auto;">
    <asp:GridView runat="server" ID="gvPhone" BorderStyle="None" CssClass="table" style="width:400px"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" OnRowEditing="gvPhone_RowEditing" OnRowCancelingEdit="gvPhone_RowCancelingEdit" OnRowUpdating="gvPhone_RowUpdating" DataKeyNames="ContactPhoneId" OnRowDeleting="gvPhone_RowDeleting">
        <Columns>
            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Numbers" />
            <asp:CommandField ShowEditButton="True"></asp:CommandField>
            <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
        </Columns>
    </asp:GridView>
</div>
<asp:Button runat="server" ID="btnAdd" OnClick="btnAdd_Click" Text="Add Phone Number" />