<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Webmaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="EduTech.Pages.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../Styles/Newuser.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="Form1" runat="server">
<div class="cont" style="margin-top:100px;">
<fieldset style="width:98%; font-weight:bold;">
            <legend>Error</legend>
 <asp:Label ID="lblerr" runat="server" Text="" ForeColor="#990000" Font-Italic="True" Font-Size="X-Large"></asp:Label>
            </fieldset>
   
</div>
</form>
</asp:Content>
