<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="C.aspx.cs" Inherits="C" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
      <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
     <h1>Welcome To C Language Tutorial</h1>
    <div class="c_color">
     <div class="row">
     <div class="column" style="background-color:#aaa;">
         <h2>Syllabus</h2>
         <hr />
         <ol>
             <li>Introduction in C Language<a href="https://byjus.com/gate/introduction-to-c-programming/">Click here</a> </li>
             <li>Fundamentals in C </li>
             <li>Operators and Expressions </li>
             <li>Data types </li>
             <li>Input-Output Library Functions </li>
             <li>Control statements</li>
             <li>Function </li>
             <li>Storage class </li>
             <li>Pointer </li>
         </ol>
      </div>
     </div>
        </div>
    <div class="pdf">
        <asp:ImageButton ID="imgbutton" runat="server" ImageUrl="~/Images/Pdf_Icon.png" AlternateText="PDF" Height="60px" Width="40px" ToolTip="PDF" Visible="true" OnClick="C_img_pdf_click" />
    </div>
</asp:Content>
