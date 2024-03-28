using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using IDCSSecurityMembership;
using IDCSUtil_2010;
using System.Web.Security;

/// <summary>
/// Summary description for ApplicationWorker
/// </summary>
public class ApplicationWorker : IDCSApplicationWorker_2010
{
    protected IDCSMembershipProvider securityProvider;
    protected string applicationName;
    public int clientId;

    public ApplicationWorker() : base(Resources.Application.ApplicationName)
    {
        clientId = Convert.ToInt32(Resources.Application.ApplicationClientID);
        applicationName = Resources.Application.ApplicationName;//"IDCS User Maintenance";
        securityProvider = (IDCSMembershipProvider)Membership.Provider;
        securityProvider.DataSource = new MembershipDataSourceDirect(dbWorker.Provider, dbWorker.ConnectionString, dbWorker.Dbms);
        securityProvider.ApplicationName = Resources.Application.ApplicationName;
    }

    public DataTable InsertStudentDetails(string RadTextBoxStudentName, string RadComboBoxQualification, string RadTextBoxEmailId, string RadTextBoxPassword, string RadComboBoxcourses,
       string RadComboBoxAddress, string RadTextBoxAge, string RadTextBoxMobileNo)
    {
        try
        {
            string procName = "Save_Student_Data";
            IDCSDbParameters parameters = new IDCSDbParameters();
            parameters.Add(new IDCSDbParameter("@Student_Name", DbType.String, RadTextBoxStudentName));
            parameters.Add(new IDCSDbParameter("@Qualification", DbType.String, RadComboBoxQualification));
            parameters.Add(new IDCSDbParameter("@EmailID", DbType.String, RadTextBoxEmailId));
            parameters.Add(new IDCSDbParameter("@Student_Password", DbType.String, RadTextBoxPassword));
            parameters.Add(new IDCSDbParameter("@Course_Name", DbType.String, RadComboBoxcourses));
            parameters.Add(new IDCSDbParameter("@Student_Address", DbType.String, RadComboBoxAddress));
            parameters.Add(new IDCSDbParameter("@Age", DbType.String, RadTextBoxAge));
            parameters.Add(new IDCSDbParameter("@MobileNo", DbType.String, RadTextBoxMobileNo));
            return dbWorker.GetDataTable(procName, parameters);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public DataTable GetAllStudentData(string EmailID)
    {
        try
        {
            string procName = "All_Students_Details";
            IDCSDbParameters parameters = new IDCSDbParameters();
            //  parameters.Add(new IDCSDbParameter("@Student_ID", DbType.String, Student_ID));
            //   parameters.Add(new IDCSDbParameter("@Student_Name", DbType.String, StudentName));
            //  parameters.Add(new IDCSDbParameter("@Qualification", DbType.String, Qualification));
            parameters.Add(new IDCSDbParameter("@EmailID", DbType.String, EmailID));
            //parameters.Add(new IDCSDbParameter("@Student_Password", DbType.String, Password));
            //  parameters.Add(new IDCSDbParameter("@Course_Name", DbType.String, courses));
            //  parameters.Add(new IDCSDbParameter("@Student_Address", DbType.String, Address));
            //  parameters.Add(new IDCSDbParameter("@Age", DbType.String, Age));
            //  parameters.Add(new IDCSDbParameter("@MobileNo", DbType.String, MobileNo));
            return dbWorker.GetDataTable(procName, parameters);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable DeleteStudentData(string Student_ID)
    {
        try
        {
            string procName = "Delete_Student_Data ";
            IDCSDbParameters parameters = new IDCSDbParameters();
            parameters.Add(new IDCSDbParameter("@Student_ID", DbType.String, Student_ID));
            return dbWorker.GetDataTable(procName, parameters);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable DeleteMultipleStudentData(string Student_ID)
    {
        try
        {
            string procName = "Delete_Multiple_Student_Data ";
            IDCSDbParameters parameters = new IDCSDbParameters();
            parameters.Add(new IDCSDbParameter("@Student_ID", DbType.String, Student_ID));
            return dbWorker.GetDataTable(procName, parameters);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable Delete_Multiple_Course(string Student_ID, string Course_Name)
    {
        try
        {
            string procName = "Delete_Course";
            IDCSDbParameters parameters = new IDCSDbParameters();
            parameters.Add(new IDCSDbParameter("@Student_ID", DbType.String, Student_ID));
            parameters.Add(new IDCSDbParameter("@Course_Name", DbType.String, Course_Name));

            return dbWorker.GetDataTable(procName, parameters);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable EditStudentDetails(string _student_id)
    {
        try
        {
            string procName = "Edit_Student_Details";
            IDCSDbParameters parameters = new IDCSDbParameters();
            parameters.Add(new IDCSDbParameter("@Student_ID", DbType.String, _student_id));
            return dbWorker.GetDataTable(procName, parameters);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public DataTable UpdateStudentData(string RadTextBoxsStudentName, string RadComboBoxQualification, string RadTextBoxEmailId, string RadComboBoxcourses, string RadComboBoxAddress,
        string RadTextBoxAge, string RadTextBoxMobileNo)
    {
        try
        {
            string procName = "Update_Student_Data";
            IDCSDbParameters parameters = new IDCSDbParameters();
            parameters.Add(new IDCSDbParameter("@Student_Name", DbType.String, RadTextBoxsStudentName));
            parameters.Add(new IDCSDbParameter("@Qualification", DbType.String, RadComboBoxQualification));
            parameters.Add(new IDCSDbParameter("@EmailID", DbType.String, RadTextBoxEmailId));
            parameters.Add(new IDCSDbParameter("@Course_Name", DbType.String, RadComboBoxcourses));
            parameters.Add(new IDCSDbParameter("@Student_Address", DbType.String, RadComboBoxAddress));
            //parameters.Add(new IDCSDbParameter("@Student_Password", DbType.String, RadTextBoxPassword));
            parameters.Add(new IDCSDbParameter("@Age", DbType.String, RadTextBoxAge));
            parameters.Add(new IDCSDbParameter("@MobileNo", DbType.String, RadTextBoxMobileNo));
            return dbWorker.GetDataTable(procName, parameters);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable BindData_RadGrid1()
    {
        try
        {
            string procName = "GetDatas";
            return dbWorker.GetDataTable(procName);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public DataTable Get_Qualification()
    {
        try
        {
            string procName = "Qualification_Proc";
            return dbWorker.GetDataTable(procName);
        }
        catch
        {
            throw;
        }
    }

    public DataTable Get_Courses()
    {
        try
        {
            string procName = "All_Courses_Proc";
            return dbWorker.GetDataTable(procName);
        }
        catch
        {
            throw;
        }
    }

    public DataTable Get_Address()
    {
        try
        {
            string procName = "All_Address_Proc";
            return dbWorker.GetDataTable(procName);
        }
        catch
        {
            throw;
        }
    }
    public DataTable get_heirarical_grid(string Student_ID)
    {
        try
        {
            string procName = "Heirarical_Grid";
            IDCSDbParameters parameters = new IDCSDbParameters();
            parameters.Add(new IDCSDbParameter("@Student_ID", DbType.String, Student_ID));
            return dbWorker.GetDataTable(procName, parameters);
        }
        catch (Exception)
        {
            throw;
        }
    }
}