﻿using System;
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

using System.Collections;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Social.Notifications;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Social.Messaging;

namespace GIBS.Modules.FBEvents
{
    public partial class ManageShift : PortalModuleBase
    {
        static int _eventMID = 0;
        static int _roleGroupID = 0;
        static string _roleName = "Registered Users";

        private GridViewHelper helper;
        // To show custom operations...
        private List<int> mQuantities = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {
                    txtStartDate.Text = DateTime.Today.ToShortDateString();
                    txtEndDate.Text = DateTime.Today.AddDays(30).ToShortDateString();
                    LoadSettings();
              //      GetRoles();
               //     GetUsers();
                    GetAvailableShifts();
                }
                else
                { 
                
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
                    _roleGroupID = Int32.Parse(settingsData.RoleGroupID.ToString());

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


        public void Fill_Report()
        {

            try
            {
                List<FBEventsInfo> items;
                FBEventsController controller = new FBEventsController();

                items = controller.Events_GetUserSignups(_eventMID, this.PortalId, Convert.ToDateTime(txtStartDate.Text.ToString()), Convert.ToDateTime(txtEndDate.Text.ToString()), Int32.Parse(ddlUserDropdown.SelectedValue.ToString()));

                gv_Report.DataSource = items;
                gv_Report.DataBind();





            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void Fill_Schedule()
        {

            try
            {
                List<FBEventsInfo> items;
                FBEventsController controller = new FBEventsController();

                items = controller.Events_GetEventSignups(Int32.Parse(ddlEventDropdown.SelectedValue.ToString()), _eventMID, this.PortalId);
          

                gv_EventSchedule.DataSource = items;
                gv_EventSchedule.DataBind();


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

               // items = controller.Events_GetAvailableShifts(_eventMID, this.PortalId, Convert.ToDateTime(txtStartDate.Text.ToString()), Convert.ToDateTime(txtEndDate.Text.ToString()), Int32.Parse(ddlUserDropdown.SelectedValue.ToString()));
                items = controller.Events_GetAvailableShifts(_eventMID, this.PortalId, Convert.ToDateTime(txtStartDate.Text.ToString()), Convert.ToDateTime(txtEndDate.Text.ToString()), 0);


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

        protected void gv_Report_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gv_EventSchedule_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        public void GroupIt()
        {

            try
            {

                helper = new GridViewHelper(this.gv_Report);
                helper.RegisterGroup("ShiftDate", true, true);


                helper.RegisterSummary("Duration", SummaryOperation.Sum);
                //       helper.RegisterSummary("VolunteerName", SummaryOperation.Count);


                // helper.RegisterGroup("ClientZipCode", true, true);
                helper.GroupHeader += new GroupEvent(helper_GroupHeader);
                helper.GroupSummary += new GroupEvent(helper_Bug);
                helper.GeneralSummary += new FooterEvent(helper_GeneralSummary);
                helper.ApplyGroupSort();



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
            //GetAvailableShifts();
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

        protected void ddlEventDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   GroupIt();
            Fill_Schedule();
       //     GetAvailableShifts();
        }

        protected void btnSendMessage_Click(object sender, EventArgs e)
        {

            ProcessGrid();

         

        }


        public void ProcessGrid()
        {

            try
            {

                foreach (GridViewRow row in gv_EventSchedule.Rows)
                {
                    if (((CheckBox)row.FindControl("CheckBox1")).Checked)
                    {
                        string temp = Convert.ToString(((HiddenField)row.FindControl("hidUserID")).Value);
                        SendMessage(Int32.Parse(temp.ToString()));
                    }

                }

                lblErrorDiv.Visible = true;
                lblError.Text = "Message Sent Successfully";
                gv_EventSchedule.Enabled = false;
                btnSendMessage.Enabled = false;


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void SendMessage(int userID)
        {

            try
            {
                // ======= SEND DNN NOTIFICATION ===========
                //string body = txtMessage.Text.ToString();
                //string subject = txtSubject.Text.ToString();
                //// NEED THE PORTALID HERE INSTEAD OF A ZERO
                //UserInfo _currentUser = DotNetNuke.Entities.Users.UserController.GetUserById(this.PortalId, userID);
                //var notificationType = NotificationsController.Instance.GetNotificationType("HtmlNotification");
                //var portalSettings = PortalController.GetCurrentPortalSettings();
                //var sender = UserController.GetUserById(portalSettings.PortalId, portalSettings.AdministratorId);

                //var notification = new Notification { NotificationTypeID = notificationType.NotificationTypeId, Subject = subject, Body = body, IncludeDismissAction = true, SenderUserID = sender.UserID };
                //NotificationsController.Instance.SendNotification(notification, portalSettings.PortalId, null, new List<UserInfo> { _currentUser });

                // ======= SEND DNN MESSAGE ===========
                DotNetNuke.Services.Social.Messaging.Message message = new Message();
                List<UserInfo> users = new List<DotNetNuke.Entities.Users.UserInfo>();
                users.Add(UserController.GetUserById(this.PortalId, userID));
                message.Body = txtMessage.Text.ToString();
                message.Subject = txtSubject.Text.ToString();
                MessagingController.Instance.SendMessage(message, null, users, null, this.UserInfo);



           //     txtMessage.Text += " send-result";



            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }




        protected void btnRefreshShifts_Click(object sender, EventArgs e)
        {
            btnSendMessage.Enabled = true;
            lblErrorDiv.Visible = false;
            gv_EventSchedule.Enabled = true;
            gv_EventSchedule.DataSource = null;
            gv_EventSchedule.DataBind();
            
            GetAvailableShifts();
        }

    }
}