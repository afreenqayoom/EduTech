<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Webmaster.Master" AutoEventWireup="true" CodeBehind="Printpreview.aspx.cs" Inherits="EduTech.Pages.Printpreview" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/Viewreport.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainreport">
<form runat="server">    
    <center>
        <asp:Label ID="lblmes" runat="server"></asp:Label>
    <CR:CrystalReportViewer ID="CrystalReportViewer" runat="server" 
        AutoDataBind="true" ToolPanelView="None"  Width="350px" Height="50px"/></center> 
    </form>
        </div>
</asp:Content>
