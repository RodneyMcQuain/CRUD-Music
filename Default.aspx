<%@ Page Language="C#" Title="Login" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="musicP.Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />

    <div class="center-container login-register-container">

        <div class="login-register-sub-container">
            <h1 class="login-register">Login</h1>
        </div>

        <div class="login-register-sub-container">
            <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control input-lg" placeholder="Username" />
        </div>

        <div class="login-register-sub-container">
            <asp:TextBox ID="tbPassword" TextMode="Password" runat="server" CssClass="form-control input-lg" placeholder="Password" />
        </div>

        <div class="login-register-sub-container">
            <asp:Button ID="btLogin" runat="server" CssClass="btn btn-lg" Text="Login" OnClick="btLogin_Click" />
        </div>

        <div class="login-register-sub-container">
            <asp:LinkButton ID="btRegister" runat="server" OnClick="btRegister_Click">Register</asp:LinkButton>
        </div>

    </div>
</asp:Content>
