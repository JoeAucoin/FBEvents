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

namespace GIBS.Modules.FBEvents
{
    public partial class ReportShortages : FBEventsSettings
    {
        static int _eventMID = 0;

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
                    GroupIt();
                    Fill_Report();
                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }



        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(Globals.NavigateURL(), true);
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        protected void btnGetSchedule_Click(object sender, EventArgs e)
        {
            //  GroupIt();
            Fill_Report();
        }


        public void Fill_Report()
        {

            try
            {
                List<FBEventsInfo> items;
                FBEventsController controller = new FBEventsController();

                items = controller.EventsSignupsGetAllEventsShortages(_eventMID, Convert.ToDateTime(txtStartDate.Text.ToString()), Convert.ToDateTime(txtEndDate.Text.ToString()));

                gv_Report.DataSource = items;
                gv_Report.DataBind();





            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void gv_Report_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        public void GroupIt()
        {

            try
            {

                helper = new GridViewHelper(this.gv_Report);
                helper.RegisterSummary("MaxEnrollment", SummaryOperation.Sum);
                helper.RegisterSummary("Enrolled", SummaryOperation.Sum);
                helper.RegisterSummary("Duration", SummaryOperation.Sum);
                helper.RegisterSummary("ShiftName", SummaryOperation.Count);
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
            newRow.Cells[0].Text = String.Format("Total: {0} items, ", helper.GeneralSummaries["ClientCity"].Value, helper.GeneralSummaries["HouseholdTotal"].Value);
        }

        private void helper_GroupSummary(string groupName, object[] values, GridViewRow row)
        {
            row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            row.Cells[0].Text = "Média";
        }

        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == "ClientCity")
            {
                row.BackColor = Color.LightGray;
                row.Cells[0].Text = "&nbsp;&nbsp;<b>" + row.Cells[0].Text + "</b>";

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

            row.BackColor = Color.Lavender;
            row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            row.Cells[0].Text = values[0] + " TOTALS&nbsp;";
        }

        public void GetSettings()
        {

            try
            {


                if (Settings.Contains("eventMID"))
                {
                    _eventMID = Int32.Parse(EventMID.ToString());

                }


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }
    }
}