<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="musicP.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        liAbout.classList.toggle("active");
    </script>

    <h2><%: Title %>.</h2>
    <p>A simple CRUD app where a user can create, select, update, and delete artist and album records.</p>
</asp:Content>
