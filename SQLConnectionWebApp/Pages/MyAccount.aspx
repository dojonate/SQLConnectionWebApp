<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="SQLConnectionWebApp.Models.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="loggedOut" runat="server" visible="false">
        <asp:Label runat="server" ID="logInFirstLbl" Text="Please log in first!" ></asp:Label><br />
        <asp:Label runat="server" ID="RedirectLbl" Text="You will be redirected to the login page in 10 seconds..."></asp:Label>
    </div>
    <div id="loggedIn" runat="server" visible="false">
        <asp:Label runat="server" ID="usernameLbl" Text="Username: "></asp:Label>
        <asp:Label runat="server" ID="usernamePrintLbl" Text=""></asp:Label><br /><br />
        <div id="changePassword">
            <asp:Label runat="server" ID="changePasswordLbl" Text="Change Password: " Font-Bold="true"></asp:Label><br />
            <asp:Label runat="server" ID="oldPasswordLbl" Text="Old Password: "></asp:Label><br />
            <asp:TextBox runat="server" ID="oldPassword" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator runat="server" 
                ID="oldPasswordValidator" ControlToValidate="oldPassword" Text="Old password required"></asp:RequiredFieldValidator><br />
            <asp:Label runat="server" ID="newPasswordLbl" Text="New Password (if changing): "></asp:Label><br />
            <asp:TextBox runat="server" ID="newPassword" TextMode="Password"></asp:TextBox><asp:CustomValidator runat="server" ID="newPasswordChecker" 
                ControlToValidate="newPassword" OnServerValidate="newPasswordChecker_ServerValidate" Text="*"></asp:CustomValidator><br />
            <asp:Label runat="server" ID="confirmPasswordLbl" Text="Confirm Password (if changing): "></asp:Label><br />
            <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator runat="server" ID="confirmPasswordValidator" ControlToCompare="newPassword" 
                ControlToValidate="confirmPassword" Text="Password must match!" ></asp:CompareValidator><br />
        </div>
        <br />
        <asp:Label runat="server" ID="lastNameLbl" Text="Last Name:"></asp:Label><br />
        <asp:TextBox runat="server" ID="lastName" ></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="lastNameValidator" 
            ControlToValidate="lastName" Text="Last Name Required!" CssClass="validator"></asp:RequiredFieldValidator><br />
        <asp:Label runat="server" ID="firstNameLbl" Text="First Name:"></asp:Label><br />
        <asp:TextBox runat="server" ID="firstName" ></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="firstNameValidator" 
            ControlToValidate="lastName" Text="First Name Required!" CssClass="validator"></asp:RequiredFieldValidator><br />
        <asp:Label runat="server" ID="addressLbl" Text="Address: "></asp:Label><br />
        <asp:TextBox runat="server" ID="address" ></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="addressValidator" 
            ControlToValidate="lastName" Text="Address Required!" CssClass="validator"></asp:RequiredFieldValidator><br />
        <asp:Label runat="server" ID="phoneNumberLbl" Text="Phone Number:"></asp:Label><br />
        <asp:TextBox runat="server" ID="phoneNumber" TextMode="Phone"></asp:TextBox>
        <asp:RegularExpressionValidator runat="server" ID="phoneNumberRegexValidator" ControlToValidate="phoneNumber" 
            ValidationExpression="\(?\d{3}\)?-? *\d{3}-? *-?\d{4}" Text="Must be 10 digit phone number"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator runat="server" ID="phoneNumberValidator" 
            ControlToValidate="phoneNumber" Text="Phone Required!" CssClass="validator"></asp:RequiredFieldValidator><br />
        <asp:Label runat="server" ID="birthDateLbl" Text="Birth Date:"></asp:Label><br />
        <asp:TextBox runat="server" ID="birthDate" TextMode="Date"></asp:TextBox><br />
        <br />
        <asp:Button runat="server" ID="saveUpdates" Text="Update" OnClick="saveUpdates_Click" />
    </div>
</asp:Content>
