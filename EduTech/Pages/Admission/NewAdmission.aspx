<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Webmaster.Master" AutoEventWireup="true" CodeBehind="NewAdmission.aspx.cs" Inherits="EduTech.Pages.Admission.NewAdmission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/Admission.css" type="text/css" rel="Stylesheet" />
 
<style type="text/css">
    #searchbox
{
    background-color: #eaf8fc;
    background-image: linear-gradient(#fff, #d4e8ec);
    border-radius: 35px;    
    border-width: 1px;
    border-style: solid;
    border-color: #c4d9df #a4c3ca #83afb7;            
    width: 468px;
    height: 40px;
    padding: 3px;
    overflow: hidden; /* Clear floats */
}
.search, 
.submit {
    float: left;
}

.search {
    padding: 5px 9px;
    height: 23px;
    width: 380px;
    border: 1px solid #a4c3ca;
    font: normal 16px 'trebuchet MS', arial, helvetica;
    background: #f1f1f1;
    border-radius: 50px 3px 3px 50px;
    box-shadow: 0 1px 3px rgba(0, 0, 0, 0.25) inset, 0 1px 0 rgba(255, 255, 255, 1);            
}

/* ----------------------- */

.submit
{       
    background-color: #6cbb6b;
    background-image: linear-gradient(#95d788, #6cbb6b);
    border-radius: 3px 50px 50px 3px;    
    border-width: 1px;
    border-style: solid;
    border-color: #7eba7c #578e57 #447d43;
    box-shadow: 0 0 1px rgba(0, 0, 0, 0.3), 
                0 1px 0 rgba(255, 255, 255, 0.3) inset;
    height: 35px;
    margin: 2px 0 0 10px;
    padding: 0;
    width: 100px;
    cursor: pointer;
    font: bold 14px Arial, Helvetica;
    color: #23441e;    
    text-shadow: 0 1px 0 rgba(255,255,255,0.5);
}

.submit:hover {       
    background-color: #95d788;
    background-image: linear-gradient(#6cbb6b, #95d788);
}   

.submit:active {       
    background: #95d788;
    outline: none;
    box-shadow: 0 1px 4px rgba(0, 0, 0, 0.5) inset;        
}

.submit::-moz-focus-inner {
       border: 0;  /* Small centering fix for Firefox */
}
.fileupload input
{
    opacity:0;
    
       
}
.fileupload span
{
    display:inline-block;
    top:0;
    left:0;
  background-color: #6cbb6b;
    background-image: linear-gradient(#95d788, #6cbb6b);
    border-radius: 10px;    
    border-width: 1px;
    border-style: solid;
    border-color: #7eba7c #578e57 #447d43;
    box-shadow: 0 0 1px rgba(0, 0, 0, 0.3), 
                0 1px 0 rgba(255, 255, 255, 0.3) inset;
    height: 35px;
    
    padding-top: 10px;
    width: 99%;
    cursor: pointer;
    font: bold 14px Arial, Helvetica;
    color: #23441e;    
    text-shadow: 0 1px 0 rgba(255,255,255,0.5);   
}
</style>
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="main">
<div class="message">
     <asp:Label ID="lblmes" runat="server" Text=""></asp:Label><br />
     </div>
    <div class="controls">
    <table width="100%">
    <tr><td style="width:55%; padding-left:20px;">
    <div id="searchbox">
    <asp:TextBox ID="txtsearch" runat="server" Width="309px" 
            style="margin-left: 14px; margin-top: 2px;" Height="24px" CssClass="search" ></asp:TextBox>
        <asp:Button ID="cmdsearch" runat="server" Text="Search" CssClass="submit" 
            onclick="cmdsearch_Click" />
</div>
        </td>
      
<td style="width:15%;">
        <asp:Button ID="btndel" runat="server" style="margin-bottom: 0px;" 
            Text="Delete" CssClass= "btn" Width="100%" onclick="btndel_Click"/></td>
        <td style="width:15%;">
            <asp:Button ID="btnnewrec" runat="server" Text="New Record" type="reset" Width="100%" 
            CssClass="btn" onclick="btnnewrec_Click"/></td>
        <td style="width:15%; padding-right:5px;"><asp:Button ID="btnsave" onclick="btnsave_Click" runat="server" Text="Save" 
             CssClass="btn"  Width="100%" /></td></tr>
            </table>
    </div>
    <div class="submain1">
        <div class="subdet">
            <div class="subdet1">
                <div class="det1">
                    <fieldset style="width:95%"> 
                     <legend> Admission Details</legend> 
                        <table style="border-style: none; border-color: inherit; border-width: 0px; width:100%; height: 202px;">
                            <tr><td style="width:35%;">
                                <asp:Label ID="Label2" runat="server" Text="Admission Number"></asp:Label></td>
                                <td style="width:65%;">
                                    <asp:TextBox ID="txtadmno" runat="server" Width="93%" CssClass="textbox"></asp:TextBox></td></tr>
                            <tr><td>
                                <asp:Label ID="Label3" runat="server" Text="Roll Number"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtrno" runat="server" Width="93%" CssClass="textbox"></asp:TextBox></td></tr>
                                    <tr><td>
                                        <asp:Label ID="Label4" runat="server" Text="11th Board Roll number"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtbrno" runat="server" Width="93%"  CssClass="textbox"></asp:TextBox></td></tr>
                                            <tr><td>
                                                <asp:Label ID="Label5" runat="server" Text="Stream"></asp:Label>
                                            </td><td>
                                                <asp:DropDownList ID="ddstream" runat="server" Width="100%" CssClass="Selectbox" 
                                                        AutoPostBack="True" onselectedindexchanged="ddstream_SelectedIndexChanged">
                                                    <asp:ListItem>SCIENCE</asp:ListItem>
                                                    <asp:ListItem>COMMERCE</asp:ListItem>
                                                    <asp:ListItem>ARTS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td></tr>
                                            <tr><td>
                                                <asp:Label ID="Label6" runat="server" Text="Stream number"></asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="ddstreamno" runat="server" Width="100%" CssClass="Selectbox">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                        </table> 
                    </fieldset>
                </div>
                <div class="det2">
                    <fieldset style="width:95%"> 
                     <legend> Fee Details</legend> 
                           <table style="border-style: none; width:100%; height: 208px;">
                            <tr><td style="width:35%";>
                                <asp:Label ID="Label7" runat="server" Text="Bank Reciept number"></asp:Label></td>
                                <td style="width:65%";>
                                    <asp:TextBox ID="txtrecieptno" runat="server" Width="93%" CssClass="textbox"></asp:TextBox ></td></tr>
                            <tr><td>
                                <asp:Label ID="Label8" runat="server" Text="Dated"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtdate" runat="server" Width="93%" CssClass="textbox"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server"  TargetControlID="txtdate"/>                                    
                                </td></tr>
                                    <tr><td>
                                        <asp:Label ID="Label9" runat="server" Text="Amount"></asp:Label></td>
                                        <td>
                                      <asp:TextBox ID="txtamt" runat="server" Width="93%" CssClass="textbox"></asp:TextBox></td></tr>
                      
                        </table> 
                     </fieldset>
                </div>
            </div>
            <div class="subdet2"><fieldset style="width:99%; height: 72px;">
            <legend>Subjects Offered</legend>
             <table style="border-style: none; width:100%; height: 54px;">
                <tr><td>
                    <asp:Label ID="Label10" runat="server" Text="I"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="II"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="III"></asp:Label></td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="IV"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="V" ></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="VI" ></asp:Label></td></tr>
                    <tr>
                    <td>
                        <asp:DropDownList ID="ddsub1" runat="server" Width="160px" CssClass="Selectbox" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </td><td>
                        <asp:DropDownList ID="ddsub2" runat="server" Width="160px" CssClass="Selectbox" 
                                AutoPostBack="True" onselectedindexchanged="ddsub2_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </td><td>
                        <asp:DropDownList ID="ddsub3" runat="server" Width="160px" CssClass="Selectbox" 
                                AutoPostBack="True" onselectedindexchanged="ddsub3_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddsub4" runat="server" Width="160px" CssClass="Selectbox" 
                            AutoPostBack="True" onselectedindexchanged="ddsub4_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddsub5" runat="server" Width="160px"  
                            CssClass="Selectbox" AutoPostBack="True" 
                            onselectedindexchanged="ddsub5_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddsub6" runat="server" Width="160px" CssClass="Selectbox" 
                            AutoPostBack="True" onselectedindexchanged="ddsub6_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td></tr>
               </table></fieldset></div>
        </div>
        <div class="subphoto">
        
          <table style="border-style:none; width:98%; height: 335px;">
        <tr><td style="height:270px;">
             <!--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>-->
            <asp:Image ID="img" runat="server" width="100%" Height="100%"/>
            <label class="fileupload"><span>Choose Photo</span>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            </label>
            </td></tr><tr><td>
            
              <!--  </ContentTemplate>
                <Triggers><asp:PostBackTrigger ControlID="btnchoose" /></Triggers>
                </asp:UpdatePanel>-->
                </td></tr>
                
                </table>
                
            </div>    
    </div>
    <div class="boarddet">
    <fieldset style="width:98%">
            <legend>Board Details</legend>
        <table style="width: 100%">
        <tr><td style="width:12%";>
            <asp:Label ID="Label16" runat="server" Text="Board Registration Number"></asp:Label></td>
            <td style="width:18%"; >
            <asp:TextBox ID="txtboardreg" runat="server" Width="233px" CssClass="textbox"></asp:TextBox></td>
            <td  style="width:12%";>
                <asp:Label ID="Label17" runat="server" Text="Board Roll number"></asp:Label></td>
                <td  style="width:18%";>
                    <asp:TextBox ID="txtboardrno" runat="server" Width="233px" CssClass="textbox"></asp:TextBox></td>
                    <td  style="width:12%";>
            <asp:Label ID="Label18" runat="server" Text="Session"></asp:Label></td>
            <td style="width:18%";>
                <asp:DropDownList ID="ddsession" runat="server"  Width="233px" 
                    CssClass="Selectbox">
                </asp:DropDownList>
            </td></tr>
        <tr>
            <td>
                <asp:Label ID="Label19" runat="server" Text="Marks"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtmarks" runat="server"  Width="233px" CssClass="textbox"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="Label20" runat="server" Text="Out of"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddoutof" runat="server"  Width="255px" 
                               CssClass="Selectbox">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label21" runat="server" Text="Result"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddresult" runat="server"  Width="233px" 
                                     CssClass="Selectbox">
                                </asp:DropDownList>
                            </td></tr>
                            <tr><td>
                                <asp:Label ID="Label22" runat="server" Text="Remarks if any"></asp:Label></td>
                                <td colspan="5">
                                    <asp:TextBox ID="txtremarks" runat="server" width="98%" height="80px"
                                        CssClass="txtbox" TextMode="MultiLine"></asp:TextBox></td></tr>
        </table>
        </fieldset> 
        
      </div>
<div class="persondet">
<fieldset style="width:98%; height: 208px;">
    <legend>Personal Details</legend>
        <table width="100%">
            <tr>
              <td style="width:17%";>
                  <asp:Label ID="Label23" runat="server" Text="Name of the Student"></asp:Label></td>
                  <td style="width:37%";>
                      <asp:TextBox ID="txtname" runat="server" Width="370px" CssClass="textbox"></asp:TextBox></td>
                  <td style="width:18%";>
                      <asp:Label ID="Label24" runat="server" Text="Fathers name"></asp:Label></td>
                      <td style="width:30%";>
                          <asp:TextBox ID="txtfather" runat="server"  Width="370px" CssClass="textbox"></asp:TextBox></td>
            </tr>
            <tr><td>
                <asp:Label ID="Label25" runat="server" Text="Mothers Name"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtmother" runat="server"  Width="370px" CssClass="textbox"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="Label26" runat="server" Text="Date of Birth"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtdob" runat="server"  Width="370px" CssClass="textbox"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"  TargetControlID="txtdob"/>
                            </td></tr>
            <tr>
            <td>
                <asp:Label ID="Label27" runat="server" Text="Permanent Address"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtperadd" runat="server"  Width="370px" CssClass="textbox"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="Label28" runat="server" Text="Correspondance Address"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtcoradd" runat="server"  Width="370px" CssClass="textbox"></asp:TextBox></td></tr>
                        <tr>
                        <td>
                            <asp:Label ID="Label29" runat="server" Text="Mobile number"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtmobno" runat="server" Width="370px" CssClass="textbox"></asp:TextBox></td>
                                <td>
                                    <asp:Label ID="Label30" runat="server" Text="Residence number (Landline)"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtresno" runat="server" Width="370px"  CssClass="textbox"></asp:TextBox></td></tr>
                                        <tr><td>
                                            <asp:Label ID="Label31" runat="server" Text="Parent/Guardian number"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtpno" runat="server" Width="370px" CssClass="textbox"></asp:TextBox></td>
                                                <td>
                                                    <asp:Label ID="Label32" runat="server" Text="Category"></asp:Label></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddcategory" runat="server" Width="392px"  CssClass="Selectbox">
                                                        </asp:DropDownList>
                                                    </td></tr>
        </table>
    <asp:Button ID="btnchoose" runat="server" style="margin-top:0px;" 
                Width="1%" Height="16px" OnClick="btnchoose_Click" />
</fieldset>
</div>

</div>
</form>
</asp:Content>
