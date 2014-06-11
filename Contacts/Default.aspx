<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Contacts.Default" %>
<%@ Register assembly="Contacts" namespace="Contacts.controls" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-8">
            <h2>WebForm Demo</h2>
            <ul>
                <li>Use Custom WebControls as Plug-ins</li>
                <li>Use Custom WebControls to Render Repeatable Structure</li>
                <li>Create Database Objects</li>
                <li>Structure to Support Bootstrap</li>
                <li>Demonstrate Rich ToolBox Controls</li>
                <li>Demonstrate Rapid Development</li>
            </ul>
        </div>
        <div class="col-lg-2"></div>
    </div>

    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-8">
            <hr />
        </div>
        <div class="col-lg-2"></div>
    </div>

    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-2"><img src="images/face.png" /></div>
        <div class="col-lg-6">
            <dl class="dl-horizontal">
                <dt>Slide Share</dt><dd><a href="http://www.slideshare.net/apallant">http://www.slideshare.net/apallant</a></dd>
                <dt>GitHub</dt><dd><a href="https://github.com/andrewpallant/Contacts">https://github.com/andrewpallant/Contacts</a></dd>
                <dt>LinkedIn</dt><dd><a href="http://ca.linkedin.com/in/andrewpallant/">http//ca.linkedin.com/in/andrewpallant/</a></dd>
                <dt>Twitter</dt><dd><a href="https://twitter.com/LdnDeveloper">https://twitter.com/LdnDeveloper</a></dd>
                <dt>Web URL</dt><dd><a href="http://www.LdnDeveloper.com">http://www.LdnDeveloper.com</a></dd>
            </dl>
        </div>
        <div class="col-lg-2"></div>
    </div>
    
</asp:Content>
