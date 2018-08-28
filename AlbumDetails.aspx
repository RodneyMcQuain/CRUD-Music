<%@ Page Title="Album Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlbumDetails.aspx.cs" Inherits="musicP.AlbumDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.0/css/all.css">
        <link href="stylesheet.css" rel="stylesheet" />

        <div class="container text-center" style="margin-bottom: 50px;">
            <asp:Label ID="lblArtistAlbumAlbumDetails" runat="server" style="font-family: Verdana; font-weight: bold; font-size: 50px;"></asp:Label>
        </div>

        <div class="center-container">

            <div class="general-contianer">
                <asp:TextBox ID="tbArtistAlbumDetails" CssClass="form-control input-lg album-details-artist-album" runat="server" placeholder="Artist"></asp:TextBox>
                <asp:TextBox ID="tbAlbumAlbumDetails" CssClass="form-control input-lg album-details-artist-album" runat="server" placeholder="Album"></asp:TextBox>
            </div>

            <div class="general-contianer">
                <asp:TextBox ID="tbYear" CssClass="form-control input-lg album-details-artist-album" runat="server" placeholder="Year"></asp:TextBox>
                <asp:TextBox ID="tbGenre" CssClass="form-control input-lg album-details-artist-album" runat="server" placeholder="Genre"></asp:TextBox>
            </div>

            <div class="general-contianer">
                <asp:LinkButton ID="btUpdate" runat="server" CssClass="btn btn-lg" text="Update" OnClick="btUpdate_Click">
                    <span aria-hidden="true" class="fa fa-sync-alt"></span> Update
                </asp:LinkButton>

                <asp:LinkButton ID="btDelete" runat="server" CssClass="btn btn-lg" text="Delete" OnClick="btDelete_Click">
                    <span aria-hidden="true" class="fa fa-trash"></span> Delete
                </asp:LinkButton>
            </div>

        </div>
</asp:Content>

