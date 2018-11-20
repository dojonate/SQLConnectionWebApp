<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SQLConnectionWebApp.Models.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--<asp:SqlDataSource ID="data" runat="server" ConnectionString="<%$ ConnectionStrings:c432018fa01dillnConnectionString %>" 
        SelectCommand="SELECT password FROM Users WHERE username=@username" ></asp:SqlDataSource>-->

    <asp:Label ID="usernameLbl" Text="Username:" runat="server"></asp:Label><br />
    <asp:TextBox ID="username" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="passwordLbl" Text="Password:" runat="server"></asp:Label><br />
    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Button ID="submit" runat="server" 

</asp:Content>
