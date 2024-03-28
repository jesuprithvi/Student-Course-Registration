<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Courses.aspx.cs" Inherits="Courses" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
Courses
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="course_back_color">
      <telerik:RadScriptManager ID="RadScriptManager2" runat="server"></telerik:RadScriptManager>
        <h1>Click your needed Course </h1>
    <div class="button">      
        <table>
         <tr>
                <td>
                    <telerik:RadButton ID="RadButton1" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px" Text="C" runat="server" OnClick="C_Button"></telerik:RadButton>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton2" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px"  Text="SQL" runat="server"></telerik:RadButton>
                 </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton3" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px"  Text="HTML" runat="server"></telerik:RadButton>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton4" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px"  Text="CSS" runat="server"></telerik:RadButton>
                 </td>
         </tr>
         <tr>                
                <td >
                    <br />
                    <br />
                    <br />
                    <telerik:RadButton ID="RadButton5" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px" Text="JavaScript" runat="server"></telerik:RadButton>
                </td>
                <td>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton6" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px" Text="NodeJS" runat="server"></telerik:RadButton>
                 </td>
                <td>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton7" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px"  Text="Xamarin" runat="server"></telerik:RadButton>
                </td>
                <td>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton8" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px"  Text="KOTLIN" runat="server"></telerik:RadButton>
                 </td>
         </tr>
         <tr>                
                <td >
                    <br />
                    <br />
                    <br />
                    <telerik:RadButton ID="RadButton9" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px" Text="ASP.NET" runat="server"></telerik:RadButton>
                </td>
                <td>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton11" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px" Text="TELERIK" runat="server"></telerik:RadButton>
                 </td>
                <td>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton12" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px"  Text="AZURE" runat="server"></telerik:RadButton>
                </td>
                <td>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton13" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px"  Text="MANGO DB" runat="server"></telerik:RadButton>
                 </td>
         </tr>
         <tr>                
                <td >
                    <br />
                    <br />
                    <br />
                    <telerik:RadButton ID="RadButton10" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px" Text="MYSQL" runat="server"></telerik:RadButton>
                </td>
                <td>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton14" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px" Text="GIT" runat="server"></telerik:RadButton>
                 </td>
                <td>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton15" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px"  Text="C++" runat="server"></telerik:RadButton>
                </td>
                <td>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="RadButton16" button-align="center" Height="35px" font-weight="bold" Font-Size="Larger" Width="150px"  Text="C#" runat="server"></telerik:RadButton>
                 </td>
         </tr>
        </table>
    </div>
  </div>
</asp:Content>
