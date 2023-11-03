<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Webmaster.Master" AutoEventWireup="true" CodeBehind="ViewSubdet.aspx.cs" Inherits="EduTech.Pages.ViewSubdet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../../Styles/ViewSubdet.css"type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server">
<div class="container">
     <fieldset style="width:98%; font-weight:bold;">
            <legend>Subjectwise Details</legend>
            <table width="96%">
           
                <tr>
                <td style="width:30%;height:40px;padding-left:25px;">
                    <asp:Label ID="Label2" runat="server" Text="Subject"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddsubjects" runat="server"  Width="405px" cssclass="Selectbox"
                        AutoPostBack="True">
                        </asp:DropDownList>
                    </td></tr>
                     <tr>
                <td style="height:40px; padding-left:22px;">
                    <asp:CheckBox ID="chkrno" runat="server" AutoPostBack="True" />
                    <asp:Label ID="Label3" runat="server" Text="Roll Number"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtrollno" runat="server" Width="380px" CssClass="textbox"></asp:TextBox></td></tr>
                        <tr><td colspan="2" align="right">
                            <asp:Button ID="btnview" runat="server" Text="View"  CssClass="btn" 
                                Width="130px" onclick="btnview_Click"/></td></tr>
            </table>
            </fieldset> 
</div>
</form>
</asp:Content>
