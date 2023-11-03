<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Webmaster.Master" AutoEventWireup="true" CodeBehind="Changepass.aspx.cs" Inherits="EduTech.Changepass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Newuser.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
<div class="cont" style="margin-top:100px;">
        <fieldset style="width:98%; font-weight:bold;">
            <legend>Change Password</legend>
             <table width="96%">
            <tr><td colspan="2">
               <center> <asp:Label ID="lblerr" runat="server" ForeColor="#CC0000"></asp:Label>
                   <asp:CompareValidator ID="CompareValidator1" runat="server" 
                       ControlToCompare="txtrpass" ControlToValidate="txtpass" 
                       ErrorMessage="Password &amp; Retype Password should match" ForeColor="#990000"></asp:CompareValidator>
                </center></td></tr>
                        
            <tr><td style="width:30%; height:40px; padding-left:25px;">
                <asp:Label ID="Label1" runat="server" Text="Old Password" ForeColor="Black"></asp:Label></td><td style="width:70%";>
                    <asp:TextBox ID="txtold" runat="server" Width="500px" CssClass="textbox"></asp:TextBox>
                </td></tr>
                <tr>
                <td style="height:40px; padding-left:22px;">
                   
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtpass" runat="server" Width="500px" CssClass="textbox" TextMode="Password"></asp:TextBox></td></tr>

                         <tr>
                <td style="height:40px; padding-left:22px;">
                   
                    <asp:Label ID="Label3" runat="server" Text=" Retype Password"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtrpass" runat="server" Width="500px" CssClass="textbox" TextMode="Password"></asp:TextBox></td></tr>
              


                        <tr><td colspan="2" align="right">
                            <asp:Button ID="btnchange" runat="server" Text="Change Password"  CssClass="btn" 
                                Width="130px" onclick="btnchange_Click"/></td></tr>
            </table>
            </fieldset>
            </div>
            </form>
</asp:Content>
