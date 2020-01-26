using System;
using System.Data;
using DotNetNuke;
using DotNetNuke.Framework;

namespace GIBS.FBEvents.Components
{
    public abstract class DataProvider
    {

        #region common methods

        /// <summary>
        /// var that is returned in the this singleton
        /// pattern
        /// </summary>
        private static DataProvider instance = null;

        /// <summary>
        /// private static cstor that is used to init an
        /// instance of this class as a singleton
        /// </summary>
        static DataProvider()
        {
            instance = (DataProvider)Reflection.CreateObject("data", "GIBS.FBEvents.Components", "");
        }

        /// <summary>
        /// Exposes the singleton object used to access the database with
        /// the conrete dataprovider
        /// </summary>
        /// <returns></returns>
        public static DataProvider Instance()
        {
            return instance;
        }

        #endregion


        #region Abstract methods

        /* implement the methods that the dataprovider should */

        public abstract IDataReader EventsSignupsGetAllEvents(int moduleId, int portalId, DateTime startDate, DateTime endDate);
        public abstract IDataReader EventsSignupsGetAllEventsShortages(int moduleId, DateTime startDate, DateTime endDate);
        public abstract IDataReader Events_GetRolesByGroupID(int roleGroupID);
        public abstract IDataReader Events_GetUsersByRoleName(int portalId, string roleName);
        public abstract IDataReader Events_GetUserSignups(int moduleId, int portalId, DateTime startDate, DateTime endDate, int userID);
        public abstract IDataReader Events_GetAvailableShifts(int moduleId, int portalId, DateTime startDate, DateTime endDate, int userID);
        public abstract void Events_AddSignup(int eventId, int moduleId, int userId);
        public abstract IDataReader Events_GetEventSignups(int eventId, int moduleId, int portalId);
        public abstract IDataReader Events_GetDistinctShifts(int moduleId, DateTime startDate, DateTime endDate);
        public abstract IDataReader Events_GetAvailableSignups(int moduleId, string shiftName, string shiftDayOfWeek, DateTime startDate, DateTime endDate, int userID);
        public abstract void Events_DeleteSignup(int signupID);
        public abstract IDataReader Events_GetVolunteerInfo(int userID, int portalID);
        public abstract void Events_AddPropertyDefinition(int portalId, string propertyCategory, string propertyName);
        //public abstract IDataReader GetFBEvents(int moduleId, int itemId);
        //public abstract void AddFBEvents(int moduleId, string content, int userId);
        //public abstract void UpdateFBEvents(int moduleId, int itemId, string content, int userId);
        //public abstract void DeleteFBEvents(int moduleId, int itemId);

        #endregion

    }



}
