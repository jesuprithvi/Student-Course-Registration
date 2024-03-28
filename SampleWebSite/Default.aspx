<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
    Students Course 
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
       <link href="Styles/TelerikStyles.css" rel="stylesheet" type="text/css" />
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">


    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function panelRequestStarted(ajaxPanel, eventArgs) {
                if (eventArgs.get_eventTarget().indexOf("img_Pdf") != -1 || eventArgs.get_eventTarget().indexOf("img_excel") != -1)

                    eventArgs.set_enableAjax(false);
            }
        </script>

    </telerik:RadCodeBlock>


    <telerik:RadAjaxLoadingPanel ID="radajaxloadingpanel_gif" runat="server" HorizontalAlign="Center"
        Transparency="10" Skin="">
        <asp:Panel ID="panel_gif_loading" runat="server" CssClass="pUpdPListClass">
            <asp:Image ID="loading_gif_img" runat="server" ImageUrl="~/Images/ProgressCircle.gif"
                CssClass="pnlimageformat" />
        </asp:Panel>
    </telerik:RadAjaxLoadingPanel>


    <telerik:RadAjaxPanel ID="RadAjaxPanel_1" runat="server" ClientEvents-OnRequestStart="panelRequestStarted">


        <telerik:RadNotification RenderMode="Lightweight" ID="RadNotifySuccessfully" runat="server" VisibleOnPageLoad="false" Position="Center"
            Width="500" Height="100" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true" Skin="WebBlue" Visible="false" Style="z-index: 100000">
        </telerik:RadNotification>
        
        
        <%--<div>
            <asp:Panel ID="Delete_Panel"  CssClass="popup_wrapper cartageposearchmaxhghtPopup" runat="server" Visible="false" Height="100px" Width="400px">
                <asp:Label ID="Delete_Confirmation" runat="server" Text="Are You Sure To Delete This Data"></asp:Label>
                <br />
                <br/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Ok_Button" Text="Ok" runat="server" OnClick="OK_Button_Clicked"/>
            <asp:Button ID="Cancel_Button" Text="Cancel" runat="server" OnClick="Cancel_Button_Clicked"/>
        </asp:Panel>
        </div>--%>
        
          <div>
            <asp:Panel runat="server" ID="Delete_Panel" Visible="false" CssClass="popup_new">
                <div class="popup_form2">
                    <h1 class="pagetitle newpgtitle">
                        <asp:Label ID="Label1" runat="server">Delete Student Data</asp:Label>
                    </h1>
                    <div class="panel_color2">
                    
                          
                   <asp:Label ID="Delete_Confirmation" runat="server" Text="Are You Sure To Delete This Data?" CssClass="pb-15 inline-block"></asp:Label>
                      <table class="tbl-basic centerised">
                          <tr>
                            <td>
                              <asp:Button ID="Ok_Button" Text="Ok" runat="server" OnClick="Student_Detail_OK_Button_Clicked" />
                            </td>
                            <td>
                               <asp:Button ID="Cancel_Button" Text="Cancel" runat="server" OnClick="Student_Detail_Cancel_Button_Clicked" />
                            </td>
                           </tr>
                        </table>
                        </div>
                    </div>
                     </asp:Panel>
                    </div>

        <div>
            <asp:Panel runat="server" ID="Course_Delete_Panel" Visible="false" CssClass="popup_new">
                <div class="popup_form2">
                    <h1 class="pagetitle newpgtitle">
                        <asp:Label ID="Label2" runat="server">Delete Selected Courses</asp:Label>
                    </h1>
                    <div class="panel_color2">
                    
                          
                   <asp:Label ID="Label3" runat="server" Text="Are You Sure To Delete This Courses?" CssClass="pb-15 inline-block"></asp:Label>
                      <table class="tbl-basic centerised">
                          <tr>
                            <td>
                              <asp:Button ID="Button1" Text="Ok" runat="server" OnClick="Course_OK_Button_Clicked" />
                            </td>
                            <td>
                               <asp:Button ID="Button2" Text="Cancel" runat="server" OnClick="Course_Cancel_Button_Clicked" />
                            </td>
                           </tr>
                        </table>
                        </div>
                    </div>
                     </asp:Panel>
                    </div>
        <%--<telerik:RadWindowManager ID="RadWindowManager1" Visible="false" Height="100px" runat="server">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server" Behaviors="Close" VisibleOnPageLoad="false">
                    <ContentTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Are you sure you want to delete the selected items?"></asp:Label>
                        <br />
                        <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="OK_Button_Clicked" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="Cancel_Button_Clicked" />
                    </ContentTemplate>
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>--%>


        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

        <div>
            <div>
                <h1 class="heading">Students Registration Portal</h1>
            </div>
            <div class="panel_color">
                <table>
                    <tr>
                        <td>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblEmailID" runat="server" Width="150px" Font-Bold="true" Font-Size="Medium" Text="Student EmailID"></asp:Label>
                            <telerik:RadTextBox ID="radtxtboxEmailID" runat="server" RenderMode="Lightweight" Height="30px" Width="200px" EmptyMessage="Enter your EmailID"></telerik:RadTextBox>
                            <%-- <asp:RegularExpressionValidator ID="reEmailID" runat="server" ControlToValidate="radtxtboxEmailID" ErrorMessage="Enter your Valid EmailID" ValidationExpression="^[a-zA-Z]+[0-9a-zA-z\.]+[@][a-zA-Z0-9]+\.[a-z]{2,}$"></asp:RegularExpressionValidator>--%>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;
<%--                        <telerik:RadButton ID="radbtndelete" runat="server" Font-Bold="true" Font-Size="Medium" RenderMode="Lightweight" Text="Delete" Visible="false" Width="80px" OnClick="Delete_Button_Clicked" OnClientClick="ShowDeletePanel(); return false;"></telerik:RadButton>--%>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <telerik:RadButton ID="radbtnsearch" runat="server" Font-Bold="true" Font-Size="Medium" RenderMode="Lightweight" Text="Search" Width="80px" OnClick="Search_Button_Clicked"></telerik:RadButton>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                        
                       <telerik:RadButton ID="radbtnadd" runat="server" Font-Bold="true" Font-Size="Medium" RenderMode="Lightweight" Text="Add" Width="80px" OnClick="Add_Button_Clicked"></telerik:RadButton>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <telerik:RadButton ID="radbtnreset" runat="server" Font-Bold="true" Font-Size="Medium" RenderMode="Lightweight" Text="Reset" Width="80px" OnClick="Reset_Button_Clicked"></telerik:RadButton>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      
                            <telerik:RadButton ID="btnToggle" runat="server" Height="40px" Checked="true" ButtonType="ToggleButton" CssClass="btnIcon" ToggleType="CheckBox" Skin="Metro" AutoPostBack="true" Visible="false" OnClick="btnToggle_Clicked" >
                                <ToggleStates>
                                    <telerik:RadButtonToggleState Text="Yes" Selected="true"  />
                                    <telerik:RadButtonToggleState Text="No" Selected="false" />
                                </ToggleStates>
                            </telerik:RadButton>


                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                        <asp:ImageButton ID="img_Pdf" runat="server" ImageUrl="~/Images/Pdf_Icon.png" AlternateText="PDF"
                            ToolTip="PDF" Visible="false" OnClick="img_Pdf_Click" CssClass="btnIcon" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                        <asp:ImageButton ID="img_excel" Visible="false" runat="server" ImageUrl="~/Images/Excel.jpg"
                            ToolTip="Excel" AlternateText="Excel" OnClick="img_excel_Click" CssClass="btnIcon"></asp:ImageButton>

                            <br />
                            <br />
                        </td>

                    </tr>
                </table>
            </div>
        </div>
        <div class="wrapper">
            <div class="menu">
                <div id="tblgridreport" runat="server" visible="false" class="tblMain">

                    <telerik:RadGrid ID="RadGrid1" runat="server" PageSize="10" RenderMode="Lightweight" AllowMultiRowSelection="true" AllowPaging="true" AllowSorting="true" AllowFilteringByColumn="false"
                        AutoGenerateColumns="false" OnItemCommand="RadGrid1_OnItemCommand" OnNeedDataSource="RadGrid1_OnNeedDataSource" OnItemCreated="RadGrid1_OnItemCreated"
                        OnDetailTableDataBind="RadGrid1_OnDetailTableDataBind" CssClass="divradgrid">
                        <ClientSettings Selecting-AllowRowSelect="true"></ClientSettings>
                        <%--<GroupingSettings CaseSensitive="false" />--%>
                        <MasterTableView Name="MasterTable" AutoGenerateColumns="false" DataKeyNames="Student_ID,EmailID,Course_Name" BackColor="SteelBlue">
                            <DetailTables>

                                <telerik:GridTableView Name="Details" Width="100%" Visible="true" AllowFilteringByColumn="false" AllowCustomSorting="false">
                                    <Columns>    
                                          <telerik:GridTemplateColumn UniqueName="IsSelected" ItemStyle-Width="60" HeaderStyle-Width="60" DataField="IsSelected">
                                    <HeaderTemplate>
                                          <asp:ImageButton ID="Course_Header_Img" runat="server" ImageUrl="~/Images/Delete_Button.png" OnClick="Course_Delete_Button_Clicked" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                          <asp:CheckBox ID="Check_Box_Course" runat="server" />
                                    </ItemTemplate>
                                 </telerik:GridTemplateColumn>


                                     <telerik:GridBoundColumn HeaderText="Course Name" DataField="Course_Name" HeaderStyle-Width="80px" ItemStyle-Width="80px"> </telerik:GridBoundColumn>                                                                   
                                    </Columns>

                                </telerik:GridTableView>
                            </DetailTables>

                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="IsSelected" ItemStyle-Width="60" HeaderStyle-Width="60" DataField="IsSelected">
                                 <HeaderTemplate>
                                        <asp:ImageButton ID="imgHeader"  runat="server" ImageUrl="~/Images/Delete_Button.png" OnClick="Student_Detail_Delete_Button_Clicked" />
                                  </HeaderTemplate>
                                  <ItemTemplate>
                                          <asp:CheckBox ID="chkBoolean" Checked="false" runat="server" />
                                  </ItemTemplate>
                                 </telerik:GridTemplateColumn>

                               <%-- <telerik:GridTemplateColumn UniqueName="IsSelected" ItemStyle-Width="60" HeaderStyle-Width="60" DataField="IsSelected">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkBoolean" Checked="false" runat="server" />
                                        <asp:LinkButton ID="LinkButton" runat="server" OnClientClick="return confirm('Are you sure to Delete Your Details?');"></asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>--%>

                                <telerik:GridButtonColumn HeaderText="Edit" ButtonType="ImageButton" Text="Edit" CommandName="EditStudentDetails" UniqueName="EditStudentDetails"
                                    HeaderStyle-Width="60" ItemStyle-Width="60" ImageUrl="~/Images/Edit_Button.png">
                                </telerik:GridButtonColumn>
                                <%--                              <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn" HeaderText="Delete" HeaderStyle-Width="60" ItemStyle-Width="60" ConfirmTitle="Delete" Text="Delete" ConfirmText="Do You Want's To Delete Your Data"/>        --%>
                                <%--<telerik:GridButtonColumn HeaderText="Delete" ButtonType="ImageButton" ConfirmText="Do You Want's To Delete Your Data"
                                ConfirmTitle="Delete" Text="Delete" CommandName="DeleteStudentDetails" UniqueName="DeleteStudentDetails" HeaderStyle-Width="60"
                                ItemStyle-Width="60" ImageUrl="~/Images/Delete_Button.png">
                            </telerik:GridButtonColumn>   --%>
                                <telerik:GridBoundColumn HeaderText="Student_ID" DataField="Student_ID" HeaderStyle-Width="80px" ItemStyle-Width="80px"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Student Name" DataField="Student_Name" HeaderStyle-Width="80px" ItemStyle-Width="80px"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Qualification" UniqueName="Qualification" DataField="Qualification" HeaderStyle-Width="120px" ItemStyle-Width="80px"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="EmailID" DataField="EmailID" HeaderStyle-Width="80px" ItemStyle-Width="80px"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Student Address" DataField="Student_Address" HeaderStyle-Width="80px" ItemStyle-Width="80px"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Mobile No" DataField="MobileNo" HeaderStyle-Width="80px" ItemStyle-Width="80px"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Age" DataField="Age" HeaderStyle-Width="80px" ItemStyle-Width="80px"></telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </div>
        </div>
        <div>
            <asp:Panel runat="server" ID="pAddNew" Visible="false" CssClass="popup_0107">
                <div class="  popup_form2  dvpopupwidAddPO">
                    <h1 class="pagetitle newpgtitle">
                        <asp:Label ID="lblAddPOTitle" runat="server">ADD NEW STUDENT</asp:Label>
                    </h1>
                    <table class="panel_color">
                        <tr>
                           <td>
                                <asp:Label ID="lblpanelstudentname" runat="server" Width="150px" Text="Student Name" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <telerik:RadTextBox ID="RadTextBoxStudentName" OnTextChanged="RadTextBoxStudentName_TextChanged" runat="server" RenderMode="Lightweight" Width="200px" InputType="Text" EmptyMessage="First Letter In Capital"></telerik:RadTextBox>
                                <%--                    <asp:RegularExpressionValidator ID="RegularExpressionValidator_Panel_StudentName" runat="server"  ControlToValidate="RadTextBoxStudentName"  ErrorMessage="Enter your Name In Alphabets" ValidationExpression="^([A-Z]{1}[a-z]{2,})$"></asp:RegularExpressionValidator>--%>
                               <br />
                            </td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblpanelstudentqualification" runat="server" Text="Qualification" Font-Bold="true" Font-Size="Medium" Width="100px"></asp:Label>
                                <telerik:RadComboBox ID="RadComboBoxQualification" runat="server" Skin="Office2010Silver" EmptyMessage="Select your Qualification" DropDownWidth="210px" Filter="None" HighlightTemplatedItems="true" Font-Bold="false" Font-Size="Small" RenderMode="Lightweight" Width="250px" CheckBoxes="false"></telerik:RadComboBox>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblpanelemailid" runat="server" Width="150px" Font-Bold="true" Font-Size="Medium" Text="Student EmailID"></asp:Label>
                                <telerik:RadTextBox ID="RadTextBoxEmailId" runat="server" RenderMode="Lightweight" Width="200px" EmptyMessage="Enter your EmailID"></telerik:RadTextBox>
                                <%--                        <asp:RegularExpressionValidator ID="RegularExpressionValidator_Panel_EmailID" runat="server" ControlToValidate="RadTextBoxEmailId" ErrorMessage="Enter your Valid EmailID" ValidationExpression="^[a-zA-Z]+[0-9a-zA-z\.]+[@][a-zA-Z0-9]+\.[a-z]{2,}$"></asp:RegularExpressionValidator>--%>
                                <br />
                            </td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblpanelcourses" runat="server" Text="Courses" Font-Bold="true" Font-Size="Medium" Width="100px"></asp:Label>
                                <telerik:RadComboBox ID="RadComboBoxCourse" DropDownWidth="210px" AllowMultipleSelection="True" DropDownHeight="400px" CheckedItemsTexts="DisplayAllInInput" EnableCheckAllItemsCheckBox="true" EmptyMessage="Select your Courses" runat="server" Skin="Office2010Silver" Font-Bold="false" Font-Size="Small" RenderMode="Lightweight" CheckBoxes="true" Width="250px"></telerik:RadComboBox>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblpanelmobileno" runat="server" Text="MobileNo" Font-Bold="true" Font-Size="Medium" Width="150px"></asp:Label>
                                <telerik:RadNumericTextBox ID="RadNumericTextBoxMobileNo" EmptyMessage="Enter your 10 Digits MobileNo" runat="server" Width="200px" MaxLength="10" ValidationGroup="formValidation">
                                    <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                </telerik:RadNumericTextBox>
                                <%--                        <asp:RegularExpressionValidator ID="RegularExpressionValidator_Panel_MobileNo" runat="server" ControlToValidate="RadNumericTextBoxMobileNo"  ErrorMessage="Enter your Valid 10 Digits MobileNo" ValidationExpression="^(6|7|8|9)([0-9]{9})$"></asp:RegularExpressionValidator>--%>
                                <%--                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1"runat="server" ErrorMessage="Please enter a phone number" ControlToValidate="RadTextBoxMobileNo"></asp:RequiredFieldValidator>--%>
                                <br />

                            </td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblpaneladdress" runat="server" Text="Address" Font-Bold="true" Font-Size="Medium" Width="100px"></asp:Label>
                                <telerik:RadComboBox RenderMode="Lightweight" ID="RadComboBoxAddress" EmptyMessage="Select your Address" DropDownWidth="210px" Filter="None" HighlightTemplatedItems="true" Skin="Office2010Silver" Font-Bold="false" Font-Size="Small" runat="server" CheckBoxes="false" Width="250px">
                                </telerik:RadComboBox>
                                <br />
                            </td>
                        </tr>
                        <tr>
                           
                            <td>
                                <asp:Label ID="lblpanelpassword" runat="server" Font-Bold="true" Font-Size="Medium" Width="150px" Text="Password"></asp:Label>
                                <telerik:RadTextBox ID="RadTextBoxPassword" EmptyMessage="Password Type (Abcde@12345)" runat="server" TextMode="Password" RenderMode="Lightweight" Width="200px" ></telerik:RadTextBox>
                             
                                <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator_Panel_Password" runat="server" ControlToValidate="RadTextBoxPassword" ErrorMessage="Enter your Valid Password" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$"></asp:RegularExpressionValidator>--%>
                                <br />
                            </td>
                             <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblpanelage" runat="server" Width="100px" Font-Bold="true" Font-Size="Medium" Text="Age"></asp:Label>
                                <telerik:RadNumericTextBox ID="RadTextBoxAge" Width="250px" MaximunValue="1000" MinValue="10" EmptyMessage="Enter your Age Between (10-100)" MaxLength="3" runat="server" Type="Number">
                                    <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                </telerik:RadNumericTextBox>
                                <%--  <asp:RangeValidator ID="RangeValidator_Panel_Age" runat="server" ControlToValidate="RadTextBoxAge" ErrorMessage="Age should be between 10 and 100" Display="Dynamic" MaximumValue="100" MinimumValue="10" CultureInvariantValues="false" Type="Integer"></asp:RangeValidator>    --%>
                                <br />
                            </td>
                        </tr>
                      
                       <%-- <tr>
                            <td>
                      <asp:Label ID="Confirm_Password" runat="server" Font-Bold="true" Font-Size="Medium" Width="150px" Text="Password"></asp:Label>
                             <telerik:RadTextBox ID="RadTextBoxConfirmPassword" runat="server" RenderMode="Lightweight" Width="200px" TextMode="Password" EmptyMessage="Confirm Password"></telerik:RadTextBox>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidatorPassword" runat="server" ControlToValidate="RadTextBoxPassword" ErrorMessage="Password must be at least 8 characters long, contain at least one upper case letter, one lower case letter, one number and one special character (@#$%^&*)" ValidationExpression="^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^\w\s]).{8,}$"></asp:RegularExpressionValidator>
                             <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ControlToValidate="RadTextBoxConfirmPassword" ControlToCompare="RadTextBoxPassword" ErrorMessage="Passwords do not match"></asp:CompareValidator>
                            </td>
                        </tr>--%>


                        <tr>
                            <td class="align_center PaddingTop15px" colspan="2">
                                <asp:ValidationSummary ID="vsAddNewPO" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="addNewPO" />

                                <asp:Button ID="btn_Update" runat="server" CssClass="form_btn" Text="Update" OnClick="Panel_Update_Click" ValidationGroup="addNewPO" />&nbsp;&nbsp;

                     <asp:Button ID="btn_Save" runat="server" CssClass="form_btn" Text="Save" OnClick="Panel_Save_Click" ValidationGroup="addNewPO" />&nbsp;&nbsp;
                               
                     <asp:Button ID="btn_Reset" runat="server" CssClass="form_btn" Text="Reset" OnClick="Panel_Reset_Click" />&nbsp;&nbsp;
                                                                 
                     <asp:Button ID="btn_Close" runat="server" CssClass="form_btn" Text="Close" OnClick="Panel_Close_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </telerik:RadAjaxPanel>

</asp:Content>
