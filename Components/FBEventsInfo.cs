using System;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace GIBS.FBEvents.Components
{
    public class FBEventsInfo
    {
        //private vars exposed thro the
        //properties

        //COMMON
        private int moduleId;
        private int portalId;
        private int createdByUserID;
        private DateTime createdOnDate;
        private int lastModifiedByUserID;
        private DateTime lastModifiedOnDate;
  //      private string createdByUserName = null;
        private string lastModifiedByUserName = null;

        private string roleName;
        private int userCount;
        private int eventID;


        private DateTime startDate;
        private DateTime endDate;

        private string shiftDayOfWeek; 
        private DateTime shiftDate;
        private DateTime shiftDateTime;
        private string shiftStartTime;
        private string shiftName;
        private double duration;
        private string volunteerName;
        private string volunteerEmail;
        private string primaryTelephone;
        private int maxEnrollment;
        private int enrolled;
        private int userID;
        private int signupID;
        private bool pastShift;
        
        private string primaryJob;
        private bool fullEnrollment;
        /// <summary>
        /// empty cstor
        /// </summary>
        public FBEventsInfo()
        {
        }


        #region properties

        // COMMON
       // #region Common
        public int ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }

        public int PortalId
        {
            get { return portalId; }
            set { portalId = value; }
        }

        //
        public int EventID
        {
            get { return eventID; }
            set { eventID = value; }
        }
        
        public int SignupID
        {
            get { return signupID; }
            set { signupID = value; }
        }

        public bool PastShift
        {
            get { return pastShift; }
            set { pastShift = value; }
        }

        public int CreatedByUserID
        {
            get { return createdByUserID; }
            set { createdByUserID = value; }
        }

        public DateTime CreatedOnDate
        {
            get { return createdOnDate; }
            set { createdOnDate = value; }
        }

        public int LastModifiedByUserID
        {
            get { return lastModifiedByUserID; }
            set { lastModifiedByUserID = value; }
        }

        public DateTime LastModifiedOnDate
        {
            get { return lastModifiedOnDate; }
            set { lastModifiedOnDate = value; }
        }

        public string LastModifiedByUserName
        {

            get { return lastModifiedByUserName; }
            set { lastModifiedByUserName = value; }

        }


        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }

        public int UserCount
        {
            get { return userCount; }
            set { userCount = value; }
        }	

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public string ShiftDayOfWeek
        {

            get { return shiftDayOfWeek; }
            set { shiftDayOfWeek = value; }

        }

        public DateTime ShiftDate
        {
            get { return shiftDate; }
            set { shiftDate = value; }
        }

        public DateTime ShiftDateTime
        {
            get { return shiftDateTime; }
            set { shiftDateTime = value; }
        }

        public string ShiftStartTime 
        {

            get { return shiftStartTime; }
            set { shiftStartTime = value; }

        }

        public string ShiftName
        {

            get { return shiftName; }
            set { shiftName = value; }

        }

        public double Duration
        {

            get { return duration; }
            set { duration = value; }

        }

        public string VolunteerName
        {

            get { return volunteerName; }
            set { volunteerName = value; }

        }

        public string VolunteerEmail
        {

            get { return volunteerEmail; }
            set { volunteerEmail = value; }

        }

        public string PrimaryTelephone
        {

            get { return primaryTelephone; }
            set { primaryTelephone = value; }

        }

        public int MaxEnrollment
        {

            get { return maxEnrollment; }
            set { maxEnrollment = value; }

        }

        public int Enrolled
        {

            get { return enrolled; }
            set { enrolled = value; }

        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        
        public string PrimaryJob
        {

            get { return primaryJob; }
            set { primaryJob = value; }

        }

        public bool FullEnrollment
        {
            get { return fullEnrollment; }
            set { fullEnrollment = value; }
        }

        #endregion
    }
}
