using IDCSUtil_2010;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


using System.Windows;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected ApplicationWorker worker = null;
    // protected DataTable get_qualification;
    // protected DataTable radgridalldetails;
    // protected DataTable get_courses;
    //  protected DataTable get_address;
    protected DataTable ListResult;
    protected DataTable get_qualification_panel;
    protected DataTable get_courses_panel;
    protected DataTable get_address_panel;
    //  protected DataTable radgridselecteddata;
    protected DataTable dtstudentdetail;
    protected DataTable editstudentdetails;
    public bool isPdfExport = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //RadNotifySuccessfully.VisibleOnPageLoad = false;
            RadNotifySuccessfully.Visible = false;
            worker = new ApplicationWorker();
            if (!IsPostBack)
            {
                //Bind_RadGrid1();
                this.Panel_Retrive_Address();
                this.Panel_Retrive_Courses();
                this.Panel_Retrive_Qualifications();
                //btnToggle.SelectedToggleStateIndex = 1;
            }
           
        }
        catch
        {
            throw;
        }
    }



    protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        try
        {
            Retrieve(false);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public void RadGrid1_OnDetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
    {
        try
        {
            GridDataItem item = (GridDataItem)e.DetailTableView.ParentItem;
            string Student_ID = Convert.ToString(item.GetDataKeyValue("Student_ID"));

            switch (e.DetailTableView.Name)
            {
                case "Details":
                    {
                        DataTable table = new DataTable();
                        table = worker.get_heirarical_grid(Student_ID);
                        e.DetailTableView.DataSource = table;
                        break;

                        //e.DetailTableView.DataSource = BindDetailTable(Student_ID);
                        //break;
                    }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }



    protected void RadGrid1_OnItemCommand(object sender, GridCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditStudentDetails")
            {
                if (e.Item.OwnerTableView.Name == "MasterTable")
                {
                    GridDataItem item = (GridDataItem)e.Item;

                    string Student_id = Convert.ToString(item.GetDataKeyValue("Student_ID"));
                    lblpanelpassword.Visible = false;
                    RadTextBoxPassword.Visible = false;
                    editstudentdetails = worker.EditStudentDetails(Student_id);

                    if (editstudentdetails.Rows.Count > 0)
                    {
                        ClearControls();
                        RadTextBoxStudentName.Text = Convert.ToString(editstudentdetails.Rows[0]["Student_Name"]);
                        RadComboBoxQualification.Text = Convert.ToString(editstudentdetails.Rows[0]["Qualification"]);
                        RadTextBoxEmailId.Text = Convert.ToString(editstudentdetails.Rows[0]["EmailID"]);
                        RadComboBoxCourse.Text = Convert.ToString(editstudentdetails.Rows[0]["Course_Name"]);

                        string[] arr = RadComboBoxCourse.Text.Split(',');
                        foreach (string Course_Name in arr)
                        {
                            foreach (RadComboBoxItem items in RadComboBoxCourse.Items)
                            {
                                if (Course_Name.Trim() == items.Text)
                                {
                                    items.Checked = true;
                                    break;
                                }
                            }
                        }

                        RadNumericTextBoxMobileNo.Text = Convert.ToString(editstudentdetails.Rows[0]["MobileNo"]);
                        RadComboBoxAddress.Text = Convert.ToString(editstudentdetails.Rows[0]["Student_Address"]);
                        //RadTextBoxPassword.Text = Convert.ToString(editstudentdetails.Rows[0]["Student_Password"]);
                        RadTextBoxAge.Text = Convert.ToString(editstudentdetails.Rows[0]["Age"]);

                        lblAddPOTitle.Text = "Update Student Details";
                        pAddNew.Visible = true;
                        btn_Update.Visible = true;
                        btn_Reset.Visible = true;
                        btn_Close.Visible = true;
                        btn_Save.Visible = false;
                    }
                    e.Item.Selected = true;
                }
            }

            //if (e.CommandName == "DeleteStudentDetails")
            //{
            //    if (e.Item.OwnerTableView.Name == "MasterTable")
            //    {
            //        GridDataItem item = (GridDataItem)e.Item;
            //        string Student_ID = Convert.ToString(item.GetDataKeyValue("Student_ID"));
            //        ListResult = worker.DeleteStudentData(Student_ID);
            //        ShowMessage(Resources.InfoViewer.DeletedSuccess);
            //        Retrieve(true);
            //    }
            //}

        }
        catch (Exception)
        {
            throw;
        }
    }


    private void Panel_Retrive_Qualifications()
    {
        try
        {
            DataTable get_qualification_panel = worker.Get_Qualification();
            RadComboBoxQualification.DataSource = get_qualification_panel;
            RadComboBoxQualification.DataValueField = "Qualification_ID";
            RadComboBoxQualification.DataTextField = "Qualification";
            RadComboBoxQualification.DataBind();
            //RadComboBoxQualification.Items.Insert(0, new RadComboBoxItem("All", "0"));
        }
        catch
        {
            throw;
        }
    }
    public void Panel_Retrive_Courses()
    {
        try
        {
            DataTable get_courses_panel = worker.Get_Courses();
            RadComboBoxCourse.DataSource = get_courses_panel;
            RadComboBoxCourse.DataValueField = "Course_ID";
            RadComboBoxCourse.DataTextField = "Course_Name";
            RadComboBoxCourse.DataBind();
            //this.RadComboBoxCourse.Items.Insert(0, new RadComboBoxItem("All", "0"));
        }
        catch
        {
            throw;
        }
    }

    public void Panel_Retrive_Address()
    {
        try
        {
            DataTable get_address_panel = worker.Get_Address();
            RadComboBoxAddress.DataSource = get_address_panel;
            RadComboBoxAddress.DataValueField = "Address_ID";
            RadComboBoxAddress.DataTextField = "Student_Address";
            RadComboBoxAddress.DataBind();
            // this.RadComboBoxAddress.Items.Insert(0, new RadComboBoxItem("All", "0"));
        }
        catch
        {
            throw;
        }
    }



    protected void RadTextBoxStudentName_TextChanged(object sender, EventArgs e)
    {
        string inputName = RadTextBoxStudentName.Text.Trim();
        string capitalizedname = inputName.Length > 0 ? char.ToUpper(inputName[0]) + inputName.Substring(1) : "";
        RadTextBoxStudentName.Text = capitalizedname;
    }

    public bool AddNewPOValidation_1()
    {
        try
        {
            string ResultsMessage = "";

            if (string.IsNullOrEmpty(Convert.ToString(RadTextBoxStudentName.Text)))
            {
                ResultsMessage = Resources.InfoViewer.StudentName;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.StudentName);
                return false;
            }

            else if (!string.IsNullOrEmpty(Convert.ToString(RadTextBoxStudentName.Text)))
            {
                RadTextBoxStudentName_TextChanged(RadTextBoxStudentName, EventArgs.Empty);
                string name = RadTextBoxStudentName.Text;
                Regex regex = new Regex(@"^[a-zA-Z]+(?: [a-zA-Z]+)*$");
                Match match = regex.Match(name);
                if (match.Success)
                {
                }
                else
                {
                    ResultsMessage = Resources.InfoViewer.StudentNameMustBeInCharacters;
                    RadNotifySuccessfully.VisibleOnPageLoad = true;
                    RadNotifySuccessfully.Visible = true;
                    RadNotifySuccessfully.Title = "Info";
                    RadNotifySuccessfully.Text = ResultsMessage;
                    RadNotifySuccessfully.AutoCloseDelay = 2000;
                    RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                    //ShowMessage(Resources.InfoViewer.StudentNameMustBeInCharacters);
                    return false;
                }
            }


            if (string.IsNullOrEmpty(Convert.ToString(RadComboBoxQualification.Text)))
            {
                ResultsMessage = Resources.InfoViewer.Qualification;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.Qualification);
                return false;
            }


            if (string.IsNullOrEmpty(Convert.ToString(RadTextBoxEmailId.Text)))
            {
                ResultsMessage = Resources.InfoViewer.EmailID;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.EmailID);
                return false;
            }

            else if (!string.IsNullOrEmpty(Convert.ToString(RadTextBoxEmailId.Text)))
            {
                string email = RadTextBoxEmailId.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                {
                }
                else
                {
                    ResultsMessage = Resources.InfoViewer.EmailIDIsNotInFormat;
                    RadNotifySuccessfully.VisibleOnPageLoad = true;
                    RadNotifySuccessfully.Visible = true;
                    RadNotifySuccessfully.Title = "Info";
                    RadNotifySuccessfully.Text = ResultsMessage;
                    RadNotifySuccessfully.AutoCloseDelay = 2000;
                    RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                    //ShowMessage(Resources.InfoViewer.EmailIDIsNotInFormat);
                    return false;
                }
            }


            if (string.IsNullOrEmpty(Convert.ToString(RadComboBoxCourse.Text)))
            {
                ResultsMessage = Resources.InfoViewer.CourseName;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.CourseName);
                return false;
            }


            if (string.IsNullOrEmpty(Convert.ToString(RadNumericTextBoxMobileNo.Text)))
            {
                ResultsMessage = Resources.InfoViewer.MobileNo;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.MobileNo);
                return false;
            }

            else if (!string.IsNullOrEmpty(Convert.ToString(RadNumericTextBoxMobileNo.Text)))
            {
                string mobileNumber = RadNumericTextBoxMobileNo.Text;
                Regex regex = new Regex(@"^(6|7|8|9)([0-9]{9})$");
                Match match = regex.Match(mobileNumber);
                if (match.Success)
                {
                }
                else
                {
                    ResultsMessage = Resources.InfoViewer.MobileNoMustBeInNumbers;
                    RadNotifySuccessfully.VisibleOnPageLoad = true;
                    RadNotifySuccessfully.Visible = true;
                    RadNotifySuccessfully.Title = "Info";
                    RadNotifySuccessfully.Text = ResultsMessage;
                    RadNotifySuccessfully.AutoCloseDelay = 2000;
                    RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                    //ShowMessage(Resources.InfoViewer.MobileNoMustBeInNumbers);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(Convert.ToString(RadComboBoxAddress.Text)))
            {
                ResultsMessage = Resources.InfoViewer.StudentAddress;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.StudentAddress);
                return false;
            }


            if (string.IsNullOrEmpty(Convert.ToString(RadTextBoxPassword.Text)))
            {
                ResultsMessage = Resources.InfoViewer.PasswordIsRequired;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.PasswordIsRequired);
                return false;
            }

            else if (!string.IsNullOrEmpty(Convert.ToString(RadTextBoxPassword.Text)))
            {
                string password = RadTextBoxPassword.Text;
                Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
                Match match = regex.Match(password);
                if (match.Success)
                {
                }
                else
                {
                    ResultsMessage = Resources.InfoViewer.PasswordMustBeIn;
                    RadNotifySuccessfully.VisibleOnPageLoad = true;
                    RadNotifySuccessfully.Visible = true;
                    RadNotifySuccessfully.Title = "Info";
                    RadNotifySuccessfully.Text = ResultsMessage;
                    RadNotifySuccessfully.AutoCloseDelay = 2000;
                    RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                    //ShowMessage(Resources.InfoViewer.PasswordMustBeIn);
                    return false;
                }
            }


            if (!string.IsNullOrEmpty(Convert.ToString(RadTextBoxAge.Text)))
            {
                int Age1 = Convert.ToInt32(RadTextBoxAge.Text.Trim());
                if (Age1 < 10 || Age1 > 100)
                {
                    ResultsMessage = Resources.InfoViewer.AgeValidation;
                    RadNotifySuccessfully.VisibleOnPageLoad = true;
                    RadNotifySuccessfully.Visible = true;
                    RadNotifySuccessfully.Title = "Info";
                    RadNotifySuccessfully.Text = ResultsMessage;
                    RadNotifySuccessfully.AutoCloseDelay = 2000;
                    RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                    //ShowMessage(Resources.InfoViewer.AgeValidation);
                    return false;
                }
            }
            else
            {
                ResultsMessage = Resources.InfoViewer.Age;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.Age);
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Panel_Close_Click(object sender, EventArgs e)
    {
        try
        {
            pAddNew.Visible = false;
        }
        catch (Exception)
        {
            throw;
        }
    }


    protected void Course_Cancel_Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Course_Delete_Panel.Visible = false;

        }
        catch
        {
            throw;
        }


    }
    protected void Course_Delete_Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            List<string> itemsToDelete = new List<string>();
            GridItem[] nestedViewItems = RadGrid1.MasterTableView.GetItems(GridItemType.NestedView);

            foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
            {
                if (item.Expanded)
                {
                    foreach (GridNestedViewItem nestedViewItem in nestedViewItems)
                    {
                        foreach (GridTableView nestedView in nestedViewItem.NestedTableViews)
                        {
                            if (nestedView.Items.Count > 0)
                            {
                                foreach (GridItem CHitem in nestedView.Items)
                                {
                                    CheckBox check = CHitem.FindControl("Check_Box_Course") as CheckBox;

                                    if (check.Checked)
                                    {
                                        Course_Delete_Panel.Visible = true;
                                        break;
                                    }
                                    else
                                    {
                                        Course_Delete_Panel.Visible = false;
                                        string resultsMessage = Resources.InfoViewer.SelectCourseToDelete;
                                        RadNotifySuccessfully.VisibleOnPageLoad = true;
                                        RadNotifySuccessfully.Visible = true;
                                        RadNotifySuccessfully.Title = "Info";
                                        RadNotifySuccessfully.Text = resultsMessage;
                                        RadNotifySuccessfully.AutoCloseDelay = 2000;
                                        RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                                    }


                                }
                            }
                        }
                    }
                }
            }
        }

        catch
        {
            throw;
        }
    }

    protected void Course_OK_Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            List<string> itemsToDelete = new List<string>();
            GridItem[] nestedViewItems = RadGrid1.MasterTableView.GetItems(GridItemType.NestedView);

            foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
            {
                if (item.Expanded)
                {
                    bool allChecked = true; // Flag to keep track if all checkboxes are checked
                    foreach (GridNestedViewItem nestedViewItem in nestedViewItems)
                    {
                        foreach (GridTableView nestedView in nestedViewItem.NestedTableViews)
                        {
                            if (nestedView.Items.Count > 0)
                            {
                                foreach (GridItem CHitem in nestedView.Items)
                                {
                                    CheckBox check = CHitem.FindControl("Check_Box_Course") as CheckBox;


                                    if (check.Checked)
                                    {
                                        string studentId = item.GetDataKeyValue("Student_ID").ToString();
                                        string courseName = (CHitem as GridDataItem)["Course_Name"].Text;
                                        itemsToDelete.Add(string.Format("{0}|{1}", studentId, courseName));
                                    }
                                    else
                                    {
                                        allChecked = false; 
                                    }
                                }

                                if (itemsToDelete.Count > 0 && !allChecked)
                                {
                                    foreach (string itemToDelete in itemsToDelete)
                                    {
                                        string[] itemValues = itemToDelete.Split('|');
                                        string studentId = itemValues[0];
                                        string courseName = itemValues[1];
                                        ListResult = worker.Delete_Multiple_Course(studentId, courseName);
                                    }

                                    Course_Delete_Panel.Visible = false;
                                    string resultsMessage = Resources.InfoViewer.CourseDelete;
                                    RadNotifySuccessfully.VisibleOnPageLoad = true;
                                    RadNotifySuccessfully.Visible = true;
                                    RadNotifySuccessfully.Title = "Info";
                                    RadNotifySuccessfully.Text = resultsMessage;
                                    RadNotifySuccessfully.AutoCloseDelay = 2000;
                                    RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                                    //Retrieve(true);
                                }
                                else if (allChecked)
                                {
                                    Course_Delete_Panel.Visible = false;
                                    string resultsMessage = Resources.InfoViewer.AllCourseDelete;
                                    RadNotifySuccessfully.VisibleOnPageLoad = true;
                                    RadNotifySuccessfully.Visible = true;
                                    RadNotifySuccessfully.Title = "Error";
                                    RadNotifySuccessfully.Text = resultsMessage;
                                    RadNotifySuccessfully.AutoCloseDelay = 2000;
                                    RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                                }
                                else
                                {
                                    Course_Delete_Panel.Visible = false;
                                    string resultsMessage = Resources.InfoViewer.SelectCourseToDelete;
                                    RadNotifySuccessfully.VisibleOnPageLoad = true;
                                    RadNotifySuccessfully.Visible = true;
                                    RadNotifySuccessfully.Title = "Info";
                                    RadNotifySuccessfully.Text = resultsMessage;
                                    RadNotifySuccessfully.AutoCloseDelay = 2000;
                                    RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                                }
                            }
                        }
                    }
                }
            }
        }
        catch
        {
            throw;
        }
    }


    protected void Student_Detail_OK_Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            string ResultsMessage = "";
            List<GridDataItem> itemsToDelete = new List<GridDataItem>();

            foreach (GridItem item in RadGrid1.MasterTableView.Items)
            {
                GridDataItem dataitem = item as GridDataItem;
                CheckBox check = item.FindControl("chkBoolean") as CheckBox;

                if (dataitem != null && check.Checked)
                {
                    itemsToDelete.Add(dataitem);
                }
            }

            if (itemsToDelete.Count > 0)
            {
                foreach (GridDataItem itemToDelete in itemsToDelete)
                {
                    string Student_id = Convert.ToString(itemToDelete.GetDataKeyValue("Student_ID"));
                    ListResult = worker.DeleteMultipleStudentData(Student_id);
                }

                //RadWindowManager1.Visible = false;
                Delete_Panel.Visible = false;
                ResultsMessage = Resources.InfoViewer.DeletedSuccess;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                Retrieve(true);
            }
            //Response.Redirect(Request.RawUrl);

        }

        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void Student_Detail_Delete_Button_Clicked(object sender, EventArgs e)
    {
        try
        {

            string ResultsMessage = "";
            List<GridDataItem> itemsToDelete = new List<GridDataItem>();

            foreach (GridItem item in RadGrid1.MasterTableView.Items)
            {
                GridDataItem dataitem = item as GridDataItem;
                CheckBox check = item.FindControl("chkBoolean") as CheckBox;

                if (dataitem != null && check.Checked)
                {
                    itemsToDelete.Add(dataitem);
                }

            }

            if (itemsToDelete.Count > 0)
            {
                Delete_Panel.Visible = true;
                //RadWindowManager1.Visible = true;
                //RadWindowManager1.Windows[0].VisibleOnPageLoad = true;
                //RadWindow1.NavigateUrl = null;
                //RadWindow1.VisibleTitlebar = true;
                //RadWindow1.VisibleStatusbar = false;
                //RadWindow1.VisibleOnPageLoad = true;
            }

            else
            {
                //RadWindowManager1.Visible = false;
                Delete_Panel.Visible = false;
                ResultsMessage = Resources.InfoViewer.SelectDataToDelete;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";

            }
        }
        catch
        {
            throw;
        }
    }


    protected void Student_Detail_Cancel_Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            //RadWindowManager1.Visible = false;
            Delete_Panel.Visible = false;
            Retrieve(true);
        }
        catch
        {
            throw;
        }

    }

    protected void Panel_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (!AddNewPOValidation_1())
            {
                return;
            }

            string StudentName = RadTextBoxStudentName.Text.Trim();
            string Qualification = RadComboBoxQualification.SelectedValue.Trim();
            string EmailID = !string.IsNullOrEmpty(RadTextBoxEmailId.Text.Trim()) ? RadTextBoxEmailId.Text.Trim() : null;
            string Course_Name = RadComboBoxCourse.SelectedValue.Trim();
            string Student_Address = RadComboBoxAddress.SelectedValue.Trim().Equals(string.Empty) ? null : RadComboBoxAddress.SelectedValue.Trim();
            string Password = !string.IsNullOrEmpty(RadTextBoxPassword.Text.Trim()) ? RadTextBoxPassword.Text.Trim() : null;
            int Age = Convert.ToInt32(RadTextBoxAge.Text.Trim());
            string MobileNo = !string.IsNullOrEmpty(RadNumericTextBoxMobileNo.Text.Trim()) ? RadNumericTextBoxMobileNo.Text.Trim() : null;

            ListResult = worker.InsertStudentDetails(StudentName, Convert.ToString(RadComboBoxQualification.Text), EmailID, Password, Convert.ToString(RadComboBoxCourse.Text), Convert.ToString(RadComboBoxAddress.Text), Convert.ToString(Age), MobileNo);
            if (ListResult.Rows.Count > 0)
            {
                if (Convert.ToString(ListResult.Rows[0]["AlreadyExists"]) == "false")
                {
                    ShowMessage(Resources.InfoViewer.EmailIDAlreadyExists);
                    pAddNew.Visible = true;
                }
            }

            string ResultsMessage = "";
            ResultsMessage = Resources.InfoViewer.InsertNewSuccess;
            RadNotifySuccessfully.VisibleOnPageLoad = true;
            RadNotifySuccessfully.Visible = true;
            RadNotifySuccessfully.Title = "Info";
            RadNotifySuccessfully.Text = ResultsMessage;
            RadNotifySuccessfully.AutoCloseDelay = 2000;
            RadNotifySuccessfully.CloseButtonToolTip = "Click to close";

            //ShowMessage(Resources.InfoViewer.InsertNewSuccess);
            pAddNew.Visible = false;

            Retrieve(true);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void Panel_Update_Click(object sender, EventArgs e)
    {
        try
        {
            if (!AddNewPOValidation_2())
            {
                return;
            }



            string StudentName = RadTextBoxStudentName.Text.Trim();
            string Qualification = RadComboBoxQualification.SelectedValue.Trim();
            string EmailID = !string.IsNullOrEmpty(RadTextBoxEmailId.Text.Trim()) ? RadTextBoxEmailId.Text.Trim() : null;
            string Course_Name = RadComboBoxCourse.SelectedValue.Trim();
            string Student_Address = RadComboBoxAddress.SelectedValue.Trim().Equals(string.Empty) ? null : RadComboBoxAddress.SelectedValue.Trim();
            //string Password = !string.IsNullOrEmpty(RadTextBoxPassword.Text.Trim()) ? RadTextBoxPassword.Text.Trim() : null;
            int Age = Convert.ToInt32(RadTextBoxAge.Text.Trim());
            string MobileNo = !string.IsNullOrEmpty(RadNumericTextBoxMobileNo.Text.Trim()) ? RadNumericTextBoxMobileNo.Text.Trim() : null;

            ListResult = worker.UpdateStudentData(StudentName, Convert.ToString(RadComboBoxQualification.Text), EmailID, Convert.ToString(RadComboBoxCourse.Text), Convert.ToString(RadComboBoxAddress.Text), Convert.ToString(Age), MobileNo);

            string ResultsMessage = "";
            ResultsMessage = Resources.InfoViewer.UpdateSuccess;
            RadNotifySuccessfully.VisibleOnPageLoad = true;
            RadNotifySuccessfully.Visible = true;
            RadNotifySuccessfully.Title = "Info";
            RadNotifySuccessfully.Text = ResultsMessage;
            RadNotifySuccessfully.AutoCloseDelay = 2000;
            RadNotifySuccessfully.CloseButtonToolTip = "Click to close";

            //ShowMessage(Resources.InfoViewer.UpdateSuccess);

            pAddNew.Visible = false;
            Retrieve(true);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public bool AddNewPOValidation_Email()
    {
        try
        {
            if (!string.IsNullOrEmpty(Convert.ToString(radtxtboxEmailID.Text)))
            {
                string email = radtxtboxEmailID.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                {
                    return true;
                }
                else
                {
                    ShowMessage(Resources.InfoViewer.EmailIDIsNotInFormat);
                    return false;
                }
            }
        }

        catch
        {
            throw;
        }
        return true;
    }

    private void Retrieve(bool issort)
    {
        try
        {

            if (!AddNewPOValidation_Email())
            {
                return;
            }

            //  string Student_ID = !string.IsNullOrEmpty(radtxtboxStudent_Id.Text.Trim()) ? radtxtboxStudent_Id.Text.Trim() : null;
            //  string StudentName = !string.IsNullOrEmpty(radtxtboxStudent_Name.Text.Trim()) ? radtxtboxStudent_Name.Text.Trim() : null;
            // string Qualification = radcmbboxQualification.SelectedValue.Trim().Equals(string.Empty) ? null : radcmbboxQualification.SelectedValue.Trim();
            string EmailID = !string.IsNullOrEmpty(radtxtboxEmailID.Text.Trim()) ? radtxtboxEmailID.Text.Trim() : null;
            //  string Password = !string.IsNullOrEmpty(radtxtStudent_Password.Text.Trim()) ? radtxtStudent_Password.Text.Trim() : null;
            // string Course_Name = radcbmboxCourse_Name.SelectedValue.Trim().Equals(string.Empty) ? null : radcbmboxCourse_Name.SelectedValue.Trim();
            // string Student_Address = radcmbboxStudent_Address.SelectedValue.Trim().Equals(string.Empty) ? null : radcmbboxStudent_Address.SelectedValue.Trim();
            //  string Age = !string.IsNullOrEmpty(radtxtboxAge.Text.Trim()) ? radtxtboxAge.Text.Trim() : null;
            //  string MobileNo = !string.IsNullOrEmpty(radtxtboxMobileNo.Text.Trim()) ? radtxtboxMobileNo.Text.Trim() : null;

            DataTable dtstudentdetail = worker.GetAllStudentData(EmailID);

            if (btnToggle.Checked)
            {
                DataView view = dtstudentdetail.DefaultView;
                view.RowFilter = "Qualification <> 'Arts'";
                dtstudentdetail = view.ToTable();
            }
            else
            {                
                RadGrid1.DataSource = dtstudentdetail;
                RadGrid1.DataBind();
            }

            if (dtstudentdetail.Rows.Count > 0)
            {
                tblgridreport.Visible = true;
                RadGrid1.Visible = true;
                //radbtndelete.Visible = true;
                btnToggle.Visible = true;
                img_Pdf.Visible = true;
                img_excel.Visible = true;
                RadGrid1.DataSource = dtstudentdetail;
                if (issort)
                    RadGrid1.DataBind();
            }
            else
            {
                tblgridreport.Visible = false;
                img_Pdf.Visible = false;
                img_excel.Visible = false;
                ShowMessage(Resources.Summary.NoRecordsAvailable);
                return;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void btnToggle_Clicked(object sender, EventArgs e)
    {
        try
        {
            if(btnToggle.Checked == true || btnToggle.Checked == false)
            {
                Retrieve(true);
            }
        }
        catch
        {
            throw;
        }
    }


    public void ShowMessage(string strMessage)
    {
        try
        {
            Regex Pattern = new Regex(@"['\\\n\r\t\b\f]");
            strMessage = Pattern.Replace(strMessage, "");
            string strScript = "<script language='javascript' type='text/javascript'>";
            strScript += "alert('" + strMessage + "')";
            strScript += "</script>";
            AjaxControlToolkit.ToolkitScriptManager.RegisterStartupScript(Page, typeof(Page), "scrpt1", strScript, false);

        }
        catch
        {
            throw;
        }
    }

    //public void Bind_RadGrid1()
    //{
    //    try
    //    {
    //       tblgridreport.Visible = true;
    //       RadGrid1.Visible = true;
    //       this.radgridalldetails = worker.BindData_RadGrid1();
    //       this.RadGrid1.DataSource = this.radgridalldetails;
    //       this.RadGrid1.DataBind();
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}

    protected void Search_Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Retrieve(true);
        }
        catch
        {
            throw;
        }
    }

    protected void Add_Button_Clicked(object sender, EventArgs e)
    {
        try
        {

            lblAddPOTitle.Text = "Add New Student Details";
            lblpanelpassword.Visible = true;
            RadTextBoxPassword.Visible = true;
            pAddNew.Visible = true;
            btn_Update.Visible = false;
            btn_Save.Visible = true;
            btn_Reset.Visible = true;
            btn_Close.Visible = true;
            ClearControls();
        }
        catch
        {
            throw;
        }
    }

    protected void Reset_Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect(Request.RawUrl);
        }
        catch
        {
            throw;
        }
    }


    protected void Panel_Reset_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void ClearControls()
    {
        try
        {
            RadTextBoxStudentName.Text = string.Empty;
            RadComboBoxQualification.ClearSelection();
            RadComboBoxQualification.Text = string.Empty;
            RadTextBoxEmailId.Text = string.Empty;
            //RadComboBoxCourse.ClearSelection();
            //RadComboBoxCourse.Text = string.Empty;
            //RadComboBoxCourse.Text = null;

            foreach (RadComboBoxItem item in RadComboBoxCourse.Items)
            {
                item.Checked = false;
            }
            RadComboBoxCourse.SelectedValue = null;

            RadNumericTextBoxMobileNo.Text = string.Empty;
            RadComboBoxAddress.ClearSelection();
            RadComboBoxAddress.Text = string.Empty;
            RadTextBoxPassword.Text = string.Empty;
            RadTextBoxAge.Text = string.Empty;
        }
        catch
        {
            throw;
        }
    }

    protected void img_Pdf_Click(object sender, EventArgs e)
    {
        try
        {
            //RadGrid exportGrid = RadGrid1;
            //isPdfExport = true;
            RadGrid1.MasterTableView.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            RadGrid1.MasterTableView.Caption = "Student Data - Report Date :" + DateTime.Now.ToString();
            RadGrid1.MasterTableView.GetColumn("EditStudentDetails").Visible = false;
            //RadGrid1.MasterTableView.GetColumn("DeleteStudentDetails").Visible = false;
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.IgnorePaging = true;
            RadGrid1.ExportSettings.OpenInNewWindow = true;
            RadGrid1.ExportSettings.Pdf.PageTitle = RadGrid1.MasterTableView.Caption;
            RadGrid1.ExportSettings.FileName = "StudentData_" + DateTime.Now.ToString("dd_MMM_yyyy");
            RadGrid1.MasterTableView.ExportToPdf();

        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void RadGrid1_OnItemCreated(object sender, GridItemEventArgs e)
    {
        try
        {
            if (isPdfExport == true)
            {
                FormatGridItem(e.Item);
            }
        }
        catch (Exception)
        {
            throw;
        }

    }
    protected void FormatGridItem(GridItem item)
    {
        try
        {
            if (item is GridDataItem)
            {
                item.Style["vertical-align"] = "middle";
                item.Style["text-align"] = "center";
                item.Style["font-size"] = "10px";
            }
            switch (item.ItemType)
            {
                case GridItemType.Item: item.Style["font-size"] = "10px"; item.Style["text-align"] = "center"; break;
                case GridItemType.AlternatingItem: item.Style["font-size"] = "10px"; item.Style["text-align"] = "center"; break;
                case GridItemType.Header: item.Style["font-size"] = "11px"; item.Style["text-align"] = "center"; break;
                case GridItemType.Footer: item.Style["font-size"] = "10px"; item.Style["text-align"] = "center"; break;
                case GridItemType.CommandItem: item.Style["font-size"] = "10px"; item.Style["text-align"] = "center"; break;
            }
            if (item is GridCommandItem)
            {
                item.PrepareItemStyle();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }


    protected void img_excel_Click(object sender, EventArgs e)
    {
        try
        {

            RadGrid exportGrid = RadGrid1;
            isPdfExport = true;
            RadGrid1.MasterTableView.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            RadGrid1.MasterTableView.Caption = "Student Data - Report Date :" + DateTime.UtcNow.ToString();
            RadGrid1.MasterTableView.GetColumn("EditStudentDetails").Visible = false;
            //RadGrid1.MasterTableView.GetColumn("DeleteStudentDetails").Visible = false;
            //RadGrid1.MasterTableView.GetHeaderCellByColumnUniqueName("imgHeader").Visible = false;
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.IgnorePaging = true;
            RadGrid1.ExportSettings.OpenInNewWindow = true;
            RadGrid1.ExportSettings.Pdf.PageTitle = exportGrid.MasterTableView.Caption;
            RadGrid1.ExportSettings.FileName = "StudentData_" + DateTime.Now.ToString("dd_MMM_yyyy");
            RadGrid1.MasterTableView.ExportToExcel();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool AddNewPOValidation_2()
    {
        try
        {
            string ResultsMessage = "";

            if (string.IsNullOrEmpty(Convert.ToString(RadTextBoxStudentName.Text)))
            {
                ResultsMessage = Resources.InfoViewer.StudentName;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.StudentName);
                return false;
            }

            else if (!string.IsNullOrEmpty(Convert.ToString(RadTextBoxStudentName.Text)))
            {
                RadTextBoxStudentName_TextChanged(RadTextBoxStudentName, EventArgs.Empty);
                string name = RadTextBoxStudentName.Text;
                Regex regex = new Regex(@"^[a-zA-Z]+(?: [a-zA-Z]+)*$");
                Match match = regex.Match(name);
                if (match.Success)
                {
                }
                else
                {
                    ResultsMessage = Resources.InfoViewer.StudentNameMustBeInCharacters;
                    RadNotifySuccessfully.VisibleOnPageLoad = true;
                    RadNotifySuccessfully.Visible = true;
                    RadNotifySuccessfully.Title = "Info";
                    RadNotifySuccessfully.Text = ResultsMessage;
                    RadNotifySuccessfully.AutoCloseDelay = 2000;
                    RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                    //ShowMessage(Resources.InfoViewer.StudentNameMustBeInCharacters);
                    return false;
                }
            }


            if (string.IsNullOrEmpty(Convert.ToString(RadComboBoxQualification.Text)))
            {
                ResultsMessage = Resources.InfoViewer.Qualification;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.Qualification);
                return false;
            }


            if (string.IsNullOrEmpty(Convert.ToString(RadTextBoxEmailId.Text)))
            {
                ResultsMessage = Resources.InfoViewer.EmailID;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.EmailID);
                return false;
            }

            else if (!string.IsNullOrEmpty(Convert.ToString(RadTextBoxEmailId.Text)))
            {
                string email = RadTextBoxEmailId.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                {
                }
                else
                {
                    ResultsMessage = Resources.InfoViewer.EmailIDIsNotInFormat;
                    RadNotifySuccessfully.VisibleOnPageLoad = true;
                    RadNotifySuccessfully.Visible = true;
                    RadNotifySuccessfully.Title = "Info";
                    RadNotifySuccessfully.Text = ResultsMessage;
                    RadNotifySuccessfully.AutoCloseDelay = 2000;
                    RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                    //ShowMessage(Resources.InfoViewer.EmailIDIsNotInFormat);
                    return false;
                }
            }


            if (string.IsNullOrEmpty(Convert.ToString(RadComboBoxCourse.Text)))
            {
                ResultsMessage = Resources.InfoViewer.CourseName;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.CourseName);
                return false;
            }


            if (string.IsNullOrEmpty(Convert.ToString(RadNumericTextBoxMobileNo.Text)))
            {
                ResultsMessage = Resources.InfoViewer.MobileNo;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.MobileNo);
                return false;
            }

            else if (!string.IsNullOrEmpty(Convert.ToString(RadNumericTextBoxMobileNo.Text)))
            {
                string mobileNumber = RadNumericTextBoxMobileNo.Text;
                Regex regex = new Regex(@"^(6|7|8|9)([0-9]{9})$");
                Match match = regex.Match(mobileNumber);
                if (match.Success)
                {
                }
                else
                {
                    ResultsMessage = Resources.InfoViewer.MobileNoMustBeInNumbers;
                    RadNotifySuccessfully.VisibleOnPageLoad = true;
                    RadNotifySuccessfully.Visible = true;
                    RadNotifySuccessfully.Title = "Info";
                    RadNotifySuccessfully.Text = ResultsMessage;
                    RadNotifySuccessfully.AutoCloseDelay = 2000;
                    RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                    //ShowMessage(Resources.InfoViewer.MobileNoMustBeInNumbers);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(Convert.ToString(RadComboBoxAddress.Text)))
            {
                ResultsMessage = Resources.InfoViewer.StudentAddress;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.StudentAddress);
                return false;
            }


            //if (string.IsNullOrEmpty(Convert.ToString(RadTextBoxPassword.Text)))
            //{
            //    ResultsMessage = Resources.InfoViewer.PasswordIsRequired;
            //    RadNotifySuccessfully.VisibleOnPageLoad = true;
            //    RadNotifySuccessfully.Visible = true;
            //    RadNotifySuccessfully.Title = "Info";
            //    RadNotifySuccessfully.Text = ResultsMessage;
            //    RadNotifySuccessfully.AutoCloseDelay = 2000;
            //    RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
            //    //ShowMessage(Resources.InfoViewer.PasswordIsRequired);
            //    return false;
            //}

            //else if (!string.IsNullOrEmpty(Convert.ToString(RadTextBoxPassword.Text)))
            //{
            //    string password = RadTextBoxPassword.Text;
            //    Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
            //    Match match = regex.Match(password);
            //    if (match.Success)
            //    {
            //    }
            //    else
            //    {
            //        ResultsMessage = Resources.InfoViewer.PasswordMustBeIn;
            //        RadNotifySuccessfully.VisibleOnPageLoad = true;
            //        RadNotifySuccessfully.Visible = true;
            //        RadNotifySuccessfully.Title = "Info";
            //        RadNotifySuccessfully.Text = ResultsMessage;
            //        RadNotifySuccessfully.AutoCloseDelay = 2000;
            //        RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
            //        //ShowMessage(Resources.InfoViewer.PasswordMustBeIn);
            //        return false;
            //    }
            //}


            if (!string.IsNullOrEmpty(Convert.ToString(RadTextBoxAge.Text)))
            {
                int Age1 = Convert.ToInt32(RadTextBoxAge.Text.Trim());
                if (Age1 < 10 || Age1 > 100)
                {
                    ResultsMessage = Resources.InfoViewer.AgeValidation;
                    RadNotifySuccessfully.VisibleOnPageLoad = true;
                    RadNotifySuccessfully.Visible = true;
                    RadNotifySuccessfully.Title = "Info";
                    RadNotifySuccessfully.Text = ResultsMessage;
                    RadNotifySuccessfully.AutoCloseDelay = 2000;
                    RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                    //ShowMessage(Resources.InfoViewer.AgeValidation);
                    return false;
                }
            }
            else
            {
                ResultsMessage = Resources.InfoViewer.Age;
                RadNotifySuccessfully.VisibleOnPageLoad = true;
                RadNotifySuccessfully.Visible = true;
                RadNotifySuccessfully.Title = "Info";
                RadNotifySuccessfully.Text = ResultsMessage;
                RadNotifySuccessfully.AutoCloseDelay = 2000;
                RadNotifySuccessfully.CloseButtonToolTip = "Click to close";
                //ShowMessage(Resources.InfoViewer.Age);
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}