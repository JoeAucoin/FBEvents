using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

using GIBS.FBEvents.Components;
using DotNetNuke.Common;
using DotNetNuke.Framework.JavaScriptLibraries;


namespace GIBS.Modules.FBEvents
{
    public partial class ViewFBEvents : PortalModuleBase, IActionable
    {

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
                

                
                if (!IsPostBack)
                {
                    //JavaScript.RequestRegistration(CommonJs.jQuery);
                    //JavaScript.RequestRegistration(CommonJs.jQueryUI);

                    HyperLink1.NavigateUrl = Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "ReportSchedule", "mid=" + ModuleId.ToString());
                    HyperLink1.Text = Localization.GetString("ReportSchedule", LocalResourceFile);
                    HyperLink2.NavigateUrl = Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "ReportShortage", "mid=" + ModuleId.ToString());
                    HyperLink2.Text = Localization.GetString("ReportShortage", LocalResourceFile);
                    //HyperLink3.NavigateUrl = Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "UserSchedule", "mid=" + ModuleId.ToString());
                    //HyperLink3.Text = Localization.GetString("UserSchedule", LocalResourceFile);
                    HyperLink4.NavigateUrl = Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "ManageShift", "mid=" + ModuleId.ToString());
                    HyperLink4.Text = Localization.GetString("ManageShift", LocalResourceFile);
                    HyperLink5.NavigateUrl = Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "ManageUserSchedule", "mid=" + ModuleId.ToString());
                    HyperLink5.Text = Localization.GetString("ManageUserSchedule", LocalResourceFile);
                    //HyperLink6.NavigateUrl = Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "FoodReport", "mid=" + ModuleId.ToString());
                    //HyperLink6.Text = "Food Inventory Report";

                    //
                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        #region IActionable Members

        public DotNetNuke.Entities.Modules.Actions.ModuleActionCollection ModuleActions
        {
            get
            {
                //create a new action to add an item, this will be added to the controls
                //dropdown menu
                ModuleActionCollection actions = new ModuleActionCollection();
                //actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, this.LocalResourceFile),
                //    ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit,
                //     true, false);

                return actions;
            }
        }

        #endregion


        /// <summary>
        /// Handles the items being bound to the datalist control. In this method we merge the data with the
        /// template defined for this control to produce the result to display to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



    }
}