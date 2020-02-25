using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

using GIBS.FBEvents.Components;
using DotNetNuke.Entities.Tabs;
using System.Collections;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Security;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Profile;

namespace GIBS.Modules.FBEvents
{
    public partial class Settings : FBEventsSettings
    {

        /// <summary>
        /// handles the loading of the module setting for this
        /// control
        /// </summary>
        public override void LoadSettings()
        {
            try
            {
                if (!IsPostBack)
                {
                    BindModules();


                    if (Settings.Contains("eventMID"))
                    {

                        ListItem _checkForValue = drpModuleID.Items.FindByValue(EventMID);
                        if (_checkForValue != null)
                        {
                            // value found
                            drpModuleID.SelectedValue = EventMID;   
                        }
                        
                    }
                    if (Settings.Contains("roleGroupID"))
                    {
                        txtRoleGroupID.Text = RoleGroupID;
                    }

                    txtProfileCheck.Text = CheckProfilePropertyExists("PrimaryJob").ToString();

                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        public string CheckProfilePropertyExists(string propertyName)
        {
            string value = null;
           
            ProfilePropertyDefinition ppd = ProfileController.GetPropertyDefinitionByName(this.PortalId, propertyName.ToString());

            if (ppd == null)
            {
                // IT DOESN'T EXIST - -  CREATE IT
                FBEventsController controller = new FBEventsController();
                controller.Events_AddPropertyDefinition(this.PortalId, "Volunteer Information", propertyName.ToString());

                value = "Profile Property Created for PrimaryJob!";
            }
            else
            {
                value = "PrimaryJob Profile Property Exists!";

            }
            return value;
        }


        //private void BindModules()
        //{
        //    DesktopModuleController objDesktopModuleController = new DesktopModuleController();
        //    DesktopModuleInfo objDesktopModuleInfo = objDesktopModuleController.GetDesktopModuleByModuleName("DNN_Events");



        //    if ((objDesktopModuleInfo != null))
        //    {
        //        TabController objTabController = new TabController();
        //        ArrayList objTabs = objTabController.GetTabs(PortalId);
        //     //   ArrayList objTabs = objTabController.GetTabsByPortal(PortalId);
        //        foreach (DotNetNuke.Entities.Tabs.TabInfo objTab in objTabs)
        //        {
        //            if ((objTab != null))
        //            {
        //                if ((objTab.IsDeleted == false))
        //                {
        //                    ModuleController objModules = new ModuleController();
        //                    foreach (KeyValuePair<int, ModuleInfo> pair in objModules.GetTabModules(objTab.TabID))
        //                    {
        //                        ModuleInfo objModule = pair.Value;
        //                        if ((objModule.IsDeleted == false))
        //                        {
        //                            if ((objModule.DesktopModuleID == objDesktopModuleInfo.DesktopModuleID))
        //                            {
        //                                if (PortalSecurity.IsInRoles("Administrator") == true & objModule.IsDeleted == false)
        //                                {
        //                                    string strPath = objTab.TabName;
        //                                    TabInfo objTabSelected = objTab;
        //                                    while (objTabSelected.ParentId != Null.NullInteger)
        //                                    {
        //                                        objTabSelected = objTabController.GetTab(objTabSelected.ParentId, objTab.PortalID, false);
        //                                        if ((objTabSelected == null))
        //                                        {
        //                                            break; // TODO: might not be correct. Was : Exit While
        //                                        }
        //                                        strPath = objTabSelected.TabName + " -> " + strPath;
        //                                    }

        //                                    ListItem objListItem = new ListItem();

        //                                    //    objListItem.Value = objModule.TabID.ToString() + "-" + objModule.ModuleID.ToString();     // TabID & ModuleID
        //                                    objListItem.Value = objModule.ModuleID.ToString();
        //                                    objListItem.Text = strPath + " -> " + objModule.ModuleTitle;

        //                                    drpModuleID.Items.Add(objListItem);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        drpModuleID.Items.Insert(0, new ListItem(Localization.GetString("SelectModule", this.LocalResourceFile), "-1"));

        //    }
        //}

        // GET THE DROPDOWN FOR GIBS - FlexMLS MODULES
        private void BindModules()
        {

            DotNetNuke.Entities.Modules.ModuleController mc = new ModuleController();
            ArrayList existMods = mc.GetModulesByDefinition(this.PortalId, "Events");

            foreach (DotNetNuke.Entities.Modules.ModuleInfo mi in existMods)
            {
                if (!mi.IsDeleted)
                {
                    ListItem objListItem = new ListItem();

                    objListItem.Value = mi.ModuleID.ToString();
                    objListItem.Text = mi.ModuleTitle.ToString();

                    drpModuleID.Items.Add(objListItem);

                    ListItem objListItemPage = new ListItem();

                    objListItemPage.Value = mi.ModuleID.ToString();
                    objListItemPage.Text = mi.ModuleTitle.ToString();

                    drpModuleID.Items.Add(objListItemPage);

                }
            }

            drpModuleID.Items.Insert(0, new ListItem(Localization.GetString("SelectModule", this.LocalResourceFile), "-1"));
            //ddlFlexMLSModule.Items.Insert(0, new ListItem(Localization.GetString("SelectModule", this.LocalResourceFile), "-1"));
            //ddlFlexMLSModulePage.Items.Insert(0, new ListItem("Select Module Page", "-1"));
        }

        /// <summary>
        /// handles updating the module settings for this control
        /// </summary>
        public override void UpdateSettings()
        {
            try
            {

                EventMID = drpModuleID.SelectedValue.ToString();
                RoleGroupID = txtRoleGroupID.Text.ToString();
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
    }
}