<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SQLConnectionWebApp.Models.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--<asp:SqlDataSource ID="data" runat="server" ConnectionString="<%$ ConnectionStrings:c432018fa01dillnConnectionString %>" 
        SelectCommand="SELECT password FROM Users WHERE username=@username" ></asp:SqlDataSource>-->
    <div id="loginControls" runat="server">
        <asp:Label ID="usernameLbl" Text="Username:" runat="server"></asp:Label><br />
        <asp:TextBox ID="username" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="passwordLbl" Text="Password:" runat="server"></asp:Label><br />
        <asp:TextBox ID="password" runat="server" TextMode="Password" AutoPostBack="true" OnTextChanged="submit_Click"></asp:TextBox>
        <br />
        <asp:Button ID="submit" runat="server" Text="Log In" OnClick="submit_Click" />
        <asp:Label ID="lblErrorMessage" runat="server" Visible="false" Text=""></asp:Label>
    </div>
    <div id="loggedInControls" runat="server" visible="false">
        <asp:Label ID="successLbl" runat="server" Text="You have successfully logged in, " ></asp:Label>
    </div>

</asp:Content>
