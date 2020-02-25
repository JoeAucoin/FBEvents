using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace GIBS.FBEvents.Components
{
    public class FBEventsController :  IPortable
    {

        #region public method

        /// <summary>
        /// Gets all the FBEventsInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        /// 
        public List<FBEventsInfo> EventsSignupsGetAllEvents(int moduleId, int portalId, DateTime startDate, DateTime endDate)
        {
            return CBO.FillCollection<FBEventsInfo>(DataProvider.Instance().EventsSignupsGetAllEvents(moduleId, portalId, startDate, endDate));
        }

        public List<FBEventsInfo> EventsSignupsGetAllEventsShortages(int moduleId, DateTime startDate, DateTime endDate)
        {
            return CBO.FillCollection<FBEventsInfo>(DataProvider.Instance().EventsSignupsGetAllEventsShortages(moduleId, startDate, endDate));
        }

        public List<FBEventsInfo> Events_GetRolesByGroupID(int roleGroupID)
        {
            return CBO.FillCollection<FBEventsInfo>(DataProvider.Instance().Events_GetRolesByGroupID(roleGroupID));
        }

        public List<FBEventsInfo> Events_GetUsersByRoleName(int portalId, string roleName)
        {
            return CBO.FillCollection<FBEventsInfo>(DataProvider.Instance().Events_GetUsersByRoleName(portalId, roleName));
        }

        public List<FBEventsInfo> Events_GetUserSignups(int moduleId, int portalId, DateTime startDate, DateTime endDate, int userID)
        {
            return CBO.FillCollection<FBEventsInfo>(DataProvider.Instance().Events_GetUserSignups(moduleId, portalId, startDate, endDate, userID));
        }

        public List<FBEventsInfo> Events_GetAvailableShifts(int moduleId, int portalId, DateTime startDate, DateTime endDate, int userID)
        {
            return CBO.FillCollection<FBEventsInfo>(DataProvider.Instance().Events_GetAvailableShifts(moduleId, portalId, startDate, endDate, userID));
        }

        public void Events_AddSignup(FBEventsInfo info)
        {
            //check we have some content to store
            if (info.EventID != 0)
            {
                DataProvider.Instance().Events_AddSignup(info.EventID, info.ModuleId, info.UserID);
            }
        }

        public List<FBEventsInfo> Events_GetEventSignups(int eventId, int moduleId, int portalId)
        {
            return CBO.FillCollection<FBEventsInfo>(DataProvider.Instance().Events_GetEventSignups(eventId, moduleId, portalId));
        }

        public List<FBEventsInfo> Events_GetDistinctShifts(int moduleId, DateTime startDate, DateTime endDate)
        {
            return CBO.FillCollection<FBEventsInfo>(DataProvider.Instance().Events_GetDistinctShifts(moduleId, startDate, endDate));
        }

        public List<FBEventsInfo> Events_GetAvailableSignups(int moduleId, string shiftName, string shiftDayOfWeek, DateTime startDate, DateTime endDate, int userID)
        {
            return CBO.FillCollection<FBEventsInfo>(DataProvider.Instance().Events_GetAvailableSignups(moduleId, shiftName, shiftDayOfWeek, startDate, endDate, userID));
        }

        public void Events_DeleteSignup(int signupID)
        {
            DataProvider.Instance().Events_DeleteSignup(signupID);
        }

        public FBEventsInfo Events_GetVolunteerInfo(int userID, int portalID)
        {
   
            return CBO.FillObject<FBEventsInfo>(DataProvider.Instance().Events_GetVolunteerInfo(userID, portalID));
        }

        public void Events_AddPropertyDefinition(int portalId, string propertyCategory, string propertyName)
        {
            DataProvider.Instance().Events_AddPropertyDefinition(portalId, propertyCategory, propertyName);
        }



        //return (FBEventsInfo)CBO.FillObject(DataProvider.Instance().Events_GetVolunteerInfo(userID, portalID), typeof(FBEventsInfo));

        //public abstract IDataReader EventsSignupsGetAllEvents(int moduleId, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
    //public FBEventsInfo GetFBEvents(int moduleId, int itemId)
    //{
    //    return (FBEventsInfo)CBO.FillObject(DataProvider.Instance().GetFBEvents(moduleId, itemId), typeof(FBEventsInfo));
    //}


        /// <summary>
        /// Adds a new FBEventsInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        //public void AddFBEvents(FBEventsInfo info)
        //{
        //    //check we have some content to store
        //    if (info.Content != string.Empty)
        //    {
        //        DataProvider.Instance().AddFBEvents(info.ModuleId, info.Content, info.CreatedByUser);
        //    }
        //}

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
    //public void UpdateFBEvents(FBEventsInfo info)
    //{
    //    //check we have some content to update
    //    if (info.Content != string.Empty)
    //    {
    //        DataProvider.Instance().UpdateFBEvents(info.ModuleId, info.ItemId, info.Content, info.CreatedByUser);
    //    }
    //}


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        //public void DeleteFBEvents(int moduleId, int itemId)
        //{
        //    DataProvider.Instance().DeleteFBEvents(moduleId, itemId);
        //}


        #endregion

       

        #region IPortable Members

        /// <summary>
        /// Exports a module to xml
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public string ExportModule(int moduleID)
        {
            StringBuilder sb = new StringBuilder();

            //List<FBEventsInfo> infos = GetFBEventss(moduleID);

            //if (infos.Count > 0)
            //{
            //    sb.Append("<FBEventss>");
            //    foreach (FBEventsInfo info in infos)
            //    {
            //        sb.Append("<FBEvents>");
            //        sb.Append("<content>");
            //        sb.Append(XmlUtils.XMLEncode(info.Content));
            //        sb.Append("</content>");
            //        sb.Append("</FBEvents>");
            //    }
            //    sb.Append("</FBEventss>");
            //}

            return sb.ToString();
        }

        /// <summary>
        /// imports a module from an xml file
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <param name="Content"></param>
        /// <param name="Version"></param>
        /// <param name="UserID"></param>
        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            //XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "FBEventss");

            //foreach (XmlNode info in infos.SelectNodes("FBEvents"))
            //{
            //    FBEventsInfo FBEventsInfo = new FBEventsInfo();
            //    FBEventsInfo.ModuleId = ModuleID;
            //    FBEventsInfo.Content = info.SelectSingleNode("content").InnerText;
            //    FBEventsInfo.CreatedByUser = UserID;

            //    AddFBEvents(FBEventsInfo);
            //}
        }

        #endregion
    }
}
