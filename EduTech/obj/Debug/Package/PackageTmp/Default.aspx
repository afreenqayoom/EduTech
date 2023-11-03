<%@ Page Title="Home Page" Language="C#" AutoEventWireup="false"
    CodeBehind="Default.aspx.cs" Inherits="EduTech._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>EduTech</title>
<link href="Styles/Site.css" rel="Stylesheet" type="text/css" />
<link href="Styles/Controls.css" rel="Stylesheet" type="text/css" />
</head>
<body>
<div id="container">
    <div id="header"> 
        <div class="headerimg">
        <img src="Images/Main/logo.png" alt="No logo" />
        </div>
        <div class="headertext">EduTech - S.P Model Hr. Sec. Institute</div>       
    </div>
     <form id="Form1" runat="server">
    <div id="content">
        <div class="contentbox">
       
        <fieldset style="width:500px"> 
            <legend> User Credentials </legend> 
            <table style="width:100%;">
            <tr><td colspan="2" align="center">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Main/lock.jpg" Width="80%" Height="227px"/></td></tr>
            <tr><td colspan="2" align="center">
                <asp:Label ID="lblmsg" runat="server" Text="" Font-Italic="True" 
                    ForeColor="#990000"></asp:Label><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Please Enter Username" ControlToValidate="txtuname" 
                    Font-Italic="True" ForeColor="#990000"></asp:RequiredFieldValidator><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Please Enter Password" ControlToValidate="txtpassword" 
                    Font-Italic="True" ForeColor="#990000"></asp:RequiredFieldValidator>
                    </td></tr>
            <tr>
            <td align="center" style="padding-right:10px;"><br />
            <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
            </td>
            <td><br />
            <asp:TextBox ID="txtuname" runat="server" Width="100%"></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td align="center" style="padding-right:10px;">
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            </td>
            <td>
            <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td>
             </td>
            <td align="right"><br />
            <asp:Button ID="cmdlogin" runat="server" Text="Login" CssClass="btn" 
                    onclick="cmdlogin_Click"/>
            </td>
            </tr>
            </table>
            </fieldset>
          
        </div>
    </div>
      </form>
    <div id="footer">
        <div class="copyright">
        <a href="#" target="_blank" id="copyright_link">Copyright
                    © 2015  </a>
        </div>
        <div class="footer-right">
        </div>
    </div>
</div>

</body>
</html>