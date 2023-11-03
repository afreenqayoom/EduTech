<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Webmaster.Master" AutoEventWireup="true" CodeBehind="Viewreport.aspx.cs" Inherits="EduTech.Pages.Admission.Viewreport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/Viewreport.css"type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div class="mainsearch">
        <fieldset style="width:98%; font-weight:bold;">
            <legend>Search</legend>
            <table width="96%">
            <tr><td colspan="2">
               <center> <asp:Label ID="lblerr" runat="server" ForeColor="#CC0000"></asp:Label></center></td></tr>
            <tr><td style="width:30%; height:40px; padding-left:25px;">
                <asp:Label ID="Label1" runat="server" Text="Stream" ForeColor="Black"></asp:Label></td><td style="width:70%";>
                    <asp:DropDownList ID="ddstream" runat="server" Width="405px" cssclass="Selectbox"
                        AutoPostBack="True">
                        <asp:ListItem>Science</asp:ListItem>
                        <asp:ListItem>Commerce</asp:ListItem>
                        <asp:ListItem>Arts</asp:ListItem>
                    </asp:DropDownList>
                </td></tr>
                <tr>
                <td style="height:40px; padding-left:22px;">
                    <asp:CheckBox ID="chkrno" runat="server" AutoPostBack="True" />
                    <asp:Label ID="Label2" runat="server" Text="Roll Number"></asp:Label></td>
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
