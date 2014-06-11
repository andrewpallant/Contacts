<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ContactListing.aspx.cs" Inherits="Contacts.ContactListing" %>
<%@ Register assembly="Contacts" namespace="Contacts.controls" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="/js/jquery.tablesorter.js"></script> 
    <script>
        $(document).ready(function () {
            $("[id$='gvMain']").tablesorter();
        }
        );
    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-2">
        </div>
        <div class="col-lg-8">
            <a href="Edit.aspx">Create New</a>

            <asp:GridView runat="server" ID="gvMain" AutoGenerateColumns="false" BorderStyle="None" CssClass="table" OnRowCommand="gvMain_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" />
                    <asp:BoundField DataField="State" HeaderText="State" />
                    <asp:BoundField DataField="Zip" HeaderText="Zip" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Twitter" HeaderText="Twitter" />
                    <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" Text="Edit" CommandName="Edit" CommandArgument=<%#DataBinder.Eval(Container.DataItem, "ContactID")%>></asp:LinkButton>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                                <asp:LinkButton runat="server" Text="Details" CommandName="Details" CommandArgument=<%#DataBinder.Eval(Container.DataItem, "ContactID")%>></asp:LinkButton>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                                <asp:LinkButton runat="server" Text="Delete" CommandName="Delete" CommandArgument=<%#DataBinder.Eval(Container.DataItem, "ContactID")%>></asp:LinkButton>
                            </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-8">
            <cc1:RandomQuotes runat="server" Visible="true" ID="RandomQuotes1" CssClass="shadow randomQuote" />
        </div>
        <div class="col-lg-2"></div>
    </div>

</asp:Content>
