using System;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

using GIBS.FBEvents.Components;
using DotNetNuke.Framework.JavaScriptLibraries;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Profile;

namespace GIBS.Modules.FBEvents
{
    public partial class ManageUserSchedule : PortalModuleBase
    {
        static int _eventMID = 0;
        static int _roleGroupID = 0;
        static string _roleName = "Registered Users";

        private GridViewHelper helper;
        // To show custom operations...
        private List<int> mQuantities = new List<int>();


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            JavaScript.RequestRegistration(CommonJs.jQuery);
            JavaScript.RequestRegistration(CommonJs.jQueryUI);
            // JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            //<link rel="stylesheet" href="//code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css">
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "Style", ("https://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/redmond/jquery-ui.css"));

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (this.IsPostBack == false)
                {
                    txtStartDate.Text = DateTime.Today.ToShortDateString();
                    txtEndDate.Text = DateTime.Today.AddDays(30).ToShortDateString();
                    LoadSettings();
                    GetRoles();
                    GetUsers();
                    GetAvailableShifts();
                    GetDistinctShifts();
                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        public void GetRoles()
        {

            try
            {
                //  string roleName = _ClientManagerUserRole.ToString();

                List<FBEventsInfo> items;
                FBEventsController controller = new FBEventsController();

                items = controller.Events_GetRolesByGroupID(_roleGroupID);


                ddlRolesDropdown.DataSource = items;
                ddlRolesDropdown.DataTextField = "RoleName";
                ddlRolesDropdown.DataValueField = "RoleName";

                ddlRolesDropdown.DataBind();
                ddlRolesDropdown.Items.Insert(0, new ListItem("All Registered Users", "Registered Users"));

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void GetUsers()
        {

            try
            {
                List<FBEventsInfo> items;
                FBEventsController controller = new FBEventsController();

                items = controller.Events_GetUsersByRoleName(this.PortalId, _roleName.ToString());


                ddlUserDropdown.DataSource = items;
                ddlUserDropdown.DataTextField = "VolunteerName";
                ddlUserDropdown.DataValueField = "UserID";

                ddlUserDropdown.DataBind();
                ddlUserDropdown.Items.Insert(0, new ListItem("-- Select User --", "0"));

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }






        public void LoadSettings()
        {

            try
            {

                FBEventsSettings settingsData = new FBEventsSettings(this.TabModuleId);

                if (settingsData.RoleGroupID != null)
                {
                    if (settingsData.RoleGroupID.ToString().Trim().Length > 0)
                    {
                        _roleGroupID = Int32.Parse(settingsData.RoleGroupID.ToString());
                    }

                }
                if (settingsData.EventMID != null)
                {
                    _eventMID = Int32.Parse(settingsData.EventMID.ToString());

                }


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void ddlRolesDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            _roleName = ddlRolesDropdown.SelectedValue.ToString();
            GetUsers();
        }

        public void FillVolunteerInfo(int userID)
        {

            try
            {

                //load the item
                FBEventsController controller = new FBEventsController();
                FBEventsInfo item = controller.Events_GetVolunteerInfo(userID, PortalId);
                if (item != null)
                {
                    lblVolunteerEmail.Text = item.VolunteerEmail.ToString();
                    lblVolunteerName.Text = item.VolunteerName.ToString();
                    lblVolunteerPhone.Text = item.PrimaryTelephone.ToString();
                    lblPrimaryJob.Text = item.PrimaryJob.ToString();
                    divVolunteerInfo.Visible = true;
                }
                else 
                {
                    divVolunteerInfo.Visible = false;
                }



            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void Fill_Report()
        {

            try
            {
                List<FBEventsInfo> items;
                FBEventsController controller = new FBEventsController();

                items = controller.Events_GetUserSignups(_eventMID, this.PortalId, Convert.ToDateTime(txtStartDate.Text.ToString()), Convert.ToDateTime(txtEndDate.Text.ToString()), Int32.Parse(ddlUserDropdown.SelectedValue.ToString()));

                gv_Report.DataSource = items;
                gv_Report.DataBind();

                if (items.Count > 0)
                {
                    lbRemoveShift.Visible = true;
                    //lblWelcomeMsg.Visible = false;
                    //btnLoadShifts.Visible = true;
                    //btnAddShift.Visible = true;
                }
                else
                {
                    lbRemoveShift.Visible = false;
                    //lblWelcomeMsg.Visible = true;
                    //btnLoadShifts.Visible = false;
                    //btnAddShift.Visible = false;
                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void GetAvailableShifts()
        {

            try
            {
                List<FBEventsInfo> items;
                FBEventsController controller = new FBEventsController();

                items = controller.Events_GetAvailableShifts(_eventMID, this.PortalId, Convert.ToDateTime(txtStartDate.Text.ToString()), Convert.ToDateTime(txtEndDate.Text.ToString()), Int32.Parse(ddlUserDropdown.SelectedValue.ToString()));


                ddlEventDropdown.DataSource = items;
                ddlEventDropdown.DataTextField = "ShiftName";
                ddlEventDropdown.DataValueField = "EventID";

                ddlEventDropdown.DataBind();
                ddlEventDropdown.Items.Insert(0, new ListItem("-- Select Shift --", "0"));

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void GetDistinctShifts()
        {
            try
            {
                FBEventsController controller = new FBEventsController();
                List<FBEventsInfo> items1;
                items1 = controller.Events_GetDistinctShifts(_eventMID, Convert.ToDateTime(txtStartDate.Text.ToString()), Convert.ToDateTime(txtEndDate.Text.ToString()));

                ddlShiftName.DataSource = items1;
                ddlShiftName.DataTextField = "ShiftName";
                ddlShiftName.DataValueField = "ShiftName";
                ddlShiftName.DataBind();
                ddlShiftName.Items.Insert(0, new ListItem("-- Select Shift --", ""));

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void gv_Report_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gv_BulkEnrollShifts_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        public void GroupIt()
        {

            try
            {

                helper = new GridViewHelper(this.gv_Report);
                helper.RegisterSummary("Duration", SummaryOperation.Sum);
                helper.GeneralSummary += new FooterEvent(helper_GeneralSummary);

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        void helper_GeneralSummary(GridViewRow row)
        {

            row.Cells[0].HorizontalAlign = HorizontalAlign.Right;

            row.Cells[0].Text = "Totals: ";
            row.BackColor = Color.BlanchedAlmond;
            row.ForeColor = Color.Black;

        }

        private void helper_ManualSummary(GridViewRow row)
        {
            GridViewRow newRow = helper.InsertGridRow(row);
            newRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            newRow.Cells[0].Text = String.Format("Total: {0} items, ", helper.GeneralSummaries["Duration"].Value, helper.GeneralSummaries["VolunteerName"].Value);
        }

        private void helper_GroupSummary(string groupName, object[] values, GridViewRow row)
        {
            row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            row.Cells[0].Text = "Média";
        }

        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == "ShiftDate")
            {
                DateTime dt;
                dt = Convert.ToDateTime(row.Cells[0].Text);
                row.BackColor = Color.LightGray;
                row.Cells[0].Text = "&nbsp;&nbsp;<b>" + dt.DayOfWeek.ToString() + " - " + Convert.ToDateTime(row.Cells[0].Text).ToShortDateString() + "</b>";


            }
            else if (groupName == "ShipName")
            {
                row.BackColor = Color.FromArgb(236, 236, 236);
                row.Cells[0].Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + row.Cells[0].Text;
            }
        }

        private void SaveQuantity(string column, string group, object value)
        {
            mQuantities.Add(Convert.ToInt32(value));
        }

        private object GetMinQuantity(string column, string group)
        {
            int[] qArray = new int[mQuantities.Count];
            mQuantities.CopyTo(qArray);
            Array.Sort(qArray);
            return qArray[0];
        }

        private void helper_Bug(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == null) return;

            DateTime dt;
            dt = Convert.ToDateTime(values[0]);

            row.BackColor = Color.Lavender;
            row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            row.Cells[0].Text = dt.DayOfWeek.ToString() + " - " + Convert.ToDateTime(values[0]).ToShortDateString() + " Totals&nbsp;";
        }

        protected void ddlUserDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupIt();
            Fill_Report();
            GetAvailableShifts();
            FillVolunteerInfo(Int32.Parse(ddlUserDropdown.SelectedValue.ToString()));
            divVolunteerInfo.Visible = true;
            lblWelcomeMsg.Visible = false;
            btnLoadShifts.Visible = true;
            btnAddShift.Visible = true;
        }

        protected void btnAddShift_Click(object sender, EventArgs e)
        {
            SaveSignUp();
            GroupIt();
            Fill_Report();
            GetAvailableShifts();
        }

        public void SaveSignUp()
        {

            try
            {

                FBEventsController controller = new FBEventsController();

                FBEventsInfo item = new FBEventsInfo();

                item.ModuleId = _eventMID;
                item.EventID = Int32.Parse(ddlEventDropdown.SelectedValue.ToString());
                item.UserID = Int32.Parse(ddlUserDropdown.SelectedValue.ToString());

                controller.Events_AddSignup(item);


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void lbRemoveShift_Click(object sender, EventArgs e)
        {
            ProcessBulkDelete();
            GroupIt();
            Fill_Report();
        }

        protected void btnLoadShifts_Click(object sender, EventArgs e)
        {
          //  GetAvailableShifts();
            //Events_GetAvailableSignups"), moduleId, shiftName, shiftDayOfWeek, startDate, endDate, userID);
            Fill_BulkEnrollShifts();
            GroupIt();
            Fill_Report();

        }

        public void Fill_BulkEnrollShifts()
        {

            try
            {
                List<FBEventsInfo> items;
                FBEventsController controller = new FBEventsController();

                items = controller.Events_GetAvailableSignups(_eventMID, ddlShiftName.SelectedValue.ToString(), ddlShiftDay.SelectedValue.ToString(), Convert.ToDateTime(txtStartDate.Text.ToString()), Convert.ToDateTime(txtEndDate.Text.ToString()), Int32.Parse(ddlUserDropdown.SelectedValue.ToString()));

                gv_BulkEnrollShifts.DataSource = items;
                gv_BulkEnrollShifts.DataBind();
                
                if (items.Count > 0)
                {
                    lbAddBulkShift.Visible = true;
                }
                else
                {
                    lbAddBulkShift.Visible = false;
                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        public void SaveBulkEnrollment(int _EventID, int _UserID)
        {
            try
            {
                FBEventsController controller = new FBEventsController();
                FBEventsInfo item = new FBEventsInfo();

                item.ModuleId = _eventMID;
                item.EventID = _EventID;
                item.UserID = _UserID;

                controller.Events_AddSignup(item);
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void ProcessGrid()
        {

            try
            {

                foreach (GridViewRow row in gv_BulkEnrollShifts.Rows)
                {
                    if (((CheckBox)row.FindControl("CheckBox1")).Checked)
                    {
                        string temp = Convert.ToString(((HiddenField)row.FindControl("hidEventID")).Value);
                        SaveBulkEnrollment(Int32.Parse(temp.ToString()),Int32.Parse(ddlUserDropdown.SelectedValue.ToString()));
                    }

                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void ProcessBulkDelete()
        {
            
            try
            {

                foreach (GridViewRow row in gv_Report.Rows)
                {
                    if (((CheckBox)row.FindControl("CheckBox1")).Checked)
                    {
                        string temp = Convert.ToString(((HiddenField)row.FindControl("hidSignupID")).Value);
                        DeleteBulkEnrollment(Int32.Parse(temp.ToString()));
                    }

                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void DeleteBulkEnrollment(int _SignupID)
        {
            try
            {
                FBEventsController controller = new FBEventsController();
                controller.Events_DeleteSignup(_SignupID);
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void lbAddBulkShift_Click(object sender, EventArgs e)
        {
            ProcessGrid();
            GroupIt();
            Fill_Report();
            //ddlShiftName.SelectedIndex = 0;
            //ddlShiftDay.SelectedIndex = 0;
            Fill_BulkEnrollShifts();
        }


    }
}