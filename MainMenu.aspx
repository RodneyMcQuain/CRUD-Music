<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="musicP._Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.0/css/all.css">
    <link href="stylesheet.css" rel="stylesheet" />
    
    <script type="text/javascript">
        liHome.classList.toggle("active");
    </script>

    <div style="background-image: url('assets/images/vinyl.jpg'); background-repeat: no-repeat; background-size: 100%; padding: 0px; height: 275px;">
         <div class="text-center" style="padding: 1%;">
            <h1 style="position: absolute; color: #f2f2f2; top: 200px; left: 44%; margin-top: 50px; font-size: 40px;">CRUD Music</h1>
        </div>
    </div>

    <div class="center-container">

        <div class="general-contianer">
            <asp:TextBox ID="tbArtist" runat="server" CssClass="form-control input-lg main-menu-artist-album" placeholder="Artist"></asp:TextBox>
            <asp:TextBox ID="tbAlbum" runat="server" CssClass="form-control input-lg main-menu-artist-album" placeholder="Album"></asp:TextBox>
            <asp:LinkButton ID="addButton" runat="server" CssClass="btn btn-lg" OnClick="addButton_Click">
                <span aria-hidden="true" class="fa fa-plus"></span>
            </asp:LinkButton>
        </div>

        <div class="container" style="margin-top: 10px; width: 500px; height: 250px; overflow-y: scroll; overflow-x: hidden;">
            <asp:GridView ID="musicGrid" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-stripped music-grid-header"
                HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" 
                ForeColor="Black" GridLines="Horizontal" Width="500px" OnSelectedIndexChanging="GridView1_SelectedIndexChanged" AllowSorting="True" DataKeyNames="musicID">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="artist" HeaderText="artist" SortExpression="artist" />
                    <asp:BoundField DataField="album" HeaderText="album" SortExpression="album" />
                </Columns>
                <RowStyle Height="50px"/>
                <AlternatingRowStyle Height="50px"/>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" Height="20px" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MusicConnectionString %>" SelectCommand="SELECT musicID, artist, album FROM music WHERE userID = @userID">
                <SelectParameters>
                    <asp:SessionParameter Name="userID" SessionField="userID" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>

        <div class="container text-center" style="padding-top: 10px">
            <asp:Label ID="lblRandomMusic" style="text-align: center; font-size: 20px;" runat="server">Take a listen to: </asp:Label>
            <asp:LinkButton ID="btRandomMusic" style="font-size: 20px; color: #000000" runat="server" OnClick="btRandomMusic_Click"></asp:LinkButton>
            <asp:Label ID="lblRandomMusicID" style="display: none" runat="server" ></asp:Label>
        </div>

    </div>
</asp:Content>
