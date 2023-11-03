<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Webmaster.Master" AutoEventWireup="true" CodeBehind="MarksEntry.aspx.cs" Inherits="EduTech.Pages.Examination.MarksEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../../Styles/MarksEntry.css" type="text/css" rel="Stylesheet" />
    <style type="text/css">
        .style1
        {
            width: 11%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server">
    <div class="maincont">
        <fieldset style="width:98%; font-weight:bold;">
        <legend>Marks Entry</legend>
          
           <table width="100%">
             <tr><td width="14%">
                 <asp:Label ID="Label1" runat="server" Text="Exam"></asp:Label></td>
                 <td width="50%">
                     <asp:Label ID="lblexam" runat="server" ForeColor="#23441E"></asp:Label></td>
                     <td align="center" class="style1">
                         <asp:Label ID="Label2" runat="server" Text="Subject"></asp:Label></td>
                         <td width="30%">
                             <asp:Label ID="lblsubject" runat="server" ForeColor="#23441E"></asp:Label></td></tr>
                             <tr><td colspan="4"> <center><asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label></center></td></tr>
                             </table>
                             <table width="100%"style="margin-top:10px;"><tr>
                            
                            
                                <td align="right" width="300px">
                                
                                <asp:Label ID="Label3" runat="server" Text="Roll Number"></asp:Label></td>
                                <td align="left" width="310px">
                                <asp:TextBox ID="txtsearch" runat="server" Width="309px" 
            style="margin-left: 14px;" Height="24px" CssClass="txtbox" ></asp:TextBox></td><td>
        <asp:Button ID="cmdsearch" runat="server" Text="Search" CssClass="submit" onclick="cmdsearch_Click"/></td>
                           
                             </tr></table>
                             <table style="margin-top:10px;">
                             <tr><td width="150px" align="center">
                                 <asp:Label ID="Label4" runat="server" Text="Name"></asp:Label></td>
                                 <td width="300px">
                                     <asp:TextBox ID="txtname" runat="server" Width="250px" 
            style="margin-left: 14px; margin-top: 2px; float:left;" Height="20px" CssClass="txtbox" Enabled="False"></asp:TextBox></td>
            <td width="150px" align="center">
                <asp:Label ID="Label5" runat="server" Text="Stream"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtstream" runat="server" Width="250px" 
            style="margin-left: 14px; margin-top: 2px;" Height="20px" CssClass="txtbox" Enabled="False"></asp:TextBox></td></tr>
            <tr><td  width="150px" align="center">
                <asp:Label ID="Label6" runat="server" Text="Theory"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txttheory" runat="server" Width="250px" 
            style="margin-left: 14px; margin-top: 2px;" Height="20px" CssClass="txtbox" 
                        AutoPostBack="True" ontextchanged="txttheory_TextChanged">0</asp:TextBox></td>
            <td  width="150px" align="center">
                <asp:Label ID="Label7" runat="server" Text="Outof"></asp:Label></td><td>
                    <asp:TextBox ID="txtto" runat="server" Width="250px" 
            style="margin-left: 14px; margin-top: 2px;" Height="20px" CssClass="txtbox" 
                        Enabled="False">0</asp:TextBox></td></tr>
            <tr>
            <td width="150px" align="center">
                <asp:Label ID="Label8" runat="server" Text="Practical"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtprac" runat="server" Width="250px" 
            style="margin-left: 14px; margin-top: 2px;" Height="20px" CssClass="txtbox" 
                        ontextchanged="txtprac_TextChanged">0</asp:TextBox></td>
            <td width="150px" align="center">
                <asp:Label ID="Label9" runat="server" Text="Outof"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtpo" runat="server"  Width="250px" 
            style="margin-left: 14px; margin-top: 2px;" Height="20px" CssClass="txtbox" 
                        Enabled="False">0</asp:TextBox></td></tr>
            <tr><td colspan="4">
              <center><asp:Button ID="btnsave" runat="server" Text="Save" CssClass="submit" 
                      Enabled="False" onclick="btnsave_Click" />
                  <asp:Button ID="btncancel" runat="server"
                          Text="Cancel" CssClass="submit" onclick="btncancel_Click" /></center></td>
              </tr></table>
        </fieldset>
    </div>
</form>
</asp:Content>
