<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Webmaster.Master" AutoEventWireup="true" CodeBehind="CreateSession.aspx.cs" Inherits="EduTech.Pages.Sessions.CreateSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../../Styles/Selectsub.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="Form1" runat="server">
    <div class="maincont">
    <fieldset style="width:98%; font-weight:bold;">
            <legend>Create Session</legend>
            <table width="96%">
            <tr><td colspan="2"><center>
                <asp:Label ID="lblerr" runat="server" Text="" Font-Italic="True" ForeColor="#CC0000"></asp:Label></center></td></tr>
               <tr>
                <td style="width:30%;height:40px;padding-left:25px;">
                    <asp:Label ID="Label2" runat="server" Text="Session"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtses" runat="server" Width="93%" CssClass="txtbox"></asp:TextBox>
                    </td></tr>
                    <tr><td colspan="2" align="right">
                            <asp:Button ID="btncreate" runat="server" Text="Create Session"  CssClass="btn" 
                                Width="130px" onClick="btncreate_click"/></td></tr>
            </table>
         </fieldset> 
    </div>
</form>

</asp:Content>
