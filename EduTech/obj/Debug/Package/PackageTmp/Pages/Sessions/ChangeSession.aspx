<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Webmaster.Master" AutoEventWireup="true" CodeBehind="ChangeSession.aspx.cs" Inherits="EduTech.Pages.Sessions.ChangeSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../../Styles/Selectsub.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="Form1" runat="server">
    <div class="maincont">
    <fieldset style="width:98%; font-weight:bold;">
            <legend>Select Session</legend>
            <table width="96%">
              <tr><td colspan="2"><center>
                <asp:Label ID="lblerr" runat="server" Text="" Font-Italic="True" ForeColor="#CC0000"></asp:Label></center></td></tr>
               <tr>
                <td style="width:30%;height:40px;padding-left:25px;">
                    <asp:Label ID="Label2" runat="server" Text="Session"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddsession" runat="server"  Width="405px" cssclass="Selectbox"
                        AutoPostBack="True">
                        </asp:DropDownList>
                    </td></tr>
                    <tr><td colspan="2" align="right">
                            <asp:Button ID="btnok" runat="server" Text="Change Session"  CssClass="btn" 
                                Width="130px" OnClick="btnok_Click"/></td></tr>
            </table>
         </fieldset> 
    </div>
</form>
</asp:Content>
