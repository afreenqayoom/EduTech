<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Webmaster.Master" AutoEventWireup="true" CodeBehind="Newuser.aspx.cs" Inherits="EduTech.Pages.Newuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Newuser.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
<div class="cont" style="margin-top:100px;">
        <fieldset style="width:98%; font-weight:bold;">
            <legend>New User</legend>
             <table width="96%">
            <tr><td colspan="2">
               <center> <asp:Label ID="lblerr" runat="server" ForeColor="#CC0000"></asp:Label>
                   <asp:CompareValidator ID="CompareValidator1" runat="server" 
                       ControlToCompare="txtrpass" ControlToValidate="txtpass" 
                       ErrorMessage="Password &amp; Retype Password should match" ForeColor="#990000"></asp:CompareValidator>
                </center></td></tr>
                           <tr>
                <td style="height:40px; padding-left:22px;">
                   
                    <asp:Label ID="Label4" runat="server" Text="Account Type"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddaccount" runat="server" Width="525px" cssclass="Selectbox"
                        AutoPostBack="True">
                        <asp:ListItem>User</asp:ListItem>
                        <asp:ListItem>Administrator</asp:ListItem>
                        </asp:DropDownList>
                      </td></tr>
            <tr><td style="width:30%; height:40px; padding-left:25px;">
                <asp:Label ID="Label1" runat="server" Text="Username" ForeColor="Black"></asp:Label></td><td style="width:70%";>
                    <asp:TextBox ID="txtuname" runat="server" Width="500px" CssClass="textbox"></asp:TextBox>
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
                            <asp:Button ID="btncreate" runat="server" Text="Create"  CssClass="btn" 
                                Width="130px" onclick="btncreate_Click"/></td></tr>
            </table>
            </fieldset>
            </div>
            <div class="cont" style="margin-top:10px; margin-bottom:10px;">
            <fieldset style="width:98%; font-weight:bold;">
            <legend>User Rights</legend>
                <asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="Leaf">
                <Nodes>
                <asp:TreeNode Text="EDUTECH">
                <asp:TreeNode Text="Admission" Expanded="False">
                <asp:TreeNode Text="New Admission"></asp:TreeNode>
                <asp:TreeNode Text="Enrollment Sheet"></asp:TreeNode>
                <asp:TreeNode Text="Admission cum Examination Card"></asp:TreeNode>
                <asp:TreeNode Text="Identity Card"></asp:TreeNode>
                <asp:TreeNode Text="Sports Form"></asp:TreeNode>
                <asp:TreeNode Text="Library Form"></asp:TreeNode>
                <asp:TreeNode Text="Admission Register"></asp:TreeNode>
                <asp:TreeNode Text="Subject-wise Details"></asp:TreeNode>
                <asp:TreeNode Text="Attendance Sheet"></asp:TreeNode>
                <asp:TreeNode Text="Micropack"></asp:TreeNode>
                <asp:TreeNode Text="Certificates" Expanded="False">
                    <asp:TreeNode Text="Bonafide Certificate"></asp:TreeNode>
                    <asp:TreeNode Text="Discharge Certificate"></asp:TreeNode>
                </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Examination" Expanded="False" >
                <asp:TreeNode Text="View Marks Details" Expanded="False"></asp:TreeNode>
                <asp:TreeNode Text="Exam Marks Details" Expanded="False">
                <asp:TreeNode Text="U1" Expanded="False"></asp:TreeNode>
                <asp:TreeNode Text="U2" Expanded="False"></asp:TreeNode>
                <asp:TreeNode Text="T1" Expanded="False"></asp:TreeNode>
                <asp:TreeNode Text="T2" Expanded="False"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Examination Evaluation" Expanded="False"></asp:TreeNode>
                <asp:TreeNode Text="Report Card"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Session" Expanded="False">
                <asp:TreeNode Text="Change Session"></asp:TreeNode>
                <asp:TreeNode Text="Create Session"></asp:TreeNode>
                </asp:TreeNode>
                </asp:TreeNode>
                </Nodes>
                </asp:TreeView>
            </fieldset>
            </div>
</form>
</asp:Content>
