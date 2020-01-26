using System;
using System.Data;
using DotNetNuke.Framework.Providers;
using Microsoft.ApplicationBlocks.Data;

namespace GIBS.FBEvents.Components
{
    public class SqlDataProvider : DataProvider
    {


        #region vars

        private const string providerType = "data";
        private const string moduleQualifier = "GIBS_";

        private ProviderConfiguration providerConfiguration = ProviderConfiguration.GetProviderConfiguration(providerType);
        private string connectionString;
        private string providerPath;
        private string objectQualifier;
        private string databaseOwner;

        #endregion

        #region cstor

        /// <summary>
        /// cstor used to create the sqlProvider with required parameters from the configuration
        /// section of web.config file
        /// </summary>
        public SqlDataProvider()
        {
            Provider provider = (Provider)providerConfiguration.Providers[providerConfiguration.DefaultProvider];
            connectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();

            if (connectionString == string.Empty)
                connectionString = provider.Attributes["connectionString"];

            providerPath = provider.Attributes["providerPath"];

            objectQualifier = provider.Attributes["objectQualifier"];
            if (objectQualifier != string.Empty && !objectQualifier.EndsWith("_"))
                objectQualifier += "_";

            databaseOwner = provider.Attributes["databaseOwner"];
            if (databaseOwner != string.Empty && !databaseOwner.EndsWith("."))
                databaseOwner += ".";
        }

        #endregion

        #region properties

        public string ConnectionString
        {
            get { return connectionString; }
        }


        public string ProviderPath
        {
            get { return providerPath; }
        }

        public string ObjectQualifier
        {
            get { return objectQualifier; }
        }


        public string DatabaseOwner
        {
            get { return databaseOwner; }
        }

        #endregion

        #region private methods

        private string GetFullyQualifiedName(string name)
        {
            return DatabaseOwner + ObjectQualifier + moduleQualifier + name;
        }

        private object GetNull(object field)
        {
            return DotNetNuke.Common.Utilities.Null.GetNull(field, DBNull.Value);
        }

        #endregion

        #region override methods

        public override IDataReader EventsSignupsGetAllEvents(int moduleId, int portalId, DateTime startDate, DateTime endDate)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("EventsSignupsGetAllEvents"), moduleId, portalId, startDate, endDate);
        }

        public override IDataReader EventsSignupsGetAllEventsShortages(int moduleId, DateTime startDate, DateTime endDate)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("EventsSignupsGetAllEventsShortages"), moduleId, startDate, endDate);
        }

        public override IDataReader Events_GetRolesByGroupID(int roleGroupID)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Events_GetRolesByGroupID"), roleGroupID);
        }

        public override IDataReader Events_GetUsersByRoleName(int portalId, string roleName)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Events_GetUsersByRoleName"), portalId, roleName);
        }

        public override IDataReader Events_GetUserSignups(int moduleId, int portalId, DateTime startDate, DateTime endDate, int userID)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Events_GetUserSignups"), moduleId, portalId, startDate, endDate, userID);
        }

        public override IDataReader Events_GetAvailableShifts(int moduleId, int portalId, DateTime startDate, DateTime endDate, int userID)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Events_GetAvailableShifts"), moduleId, portalId, startDate, endDate, userID);
        }

        public override void Events_AddSignup(int eventId, int moduleId, int userId)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("Events_AddSignup"), eventId, moduleId, userId);
        }

        public override IDataReader Events_GetEventSignups(int eventId, int moduleId, int portalId)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Events_GetEventSignups"), eventId, moduleId, portalId);
        }

        public override IDataReader Events_GetDistinctShifts(int moduleId, DateTime startDate, DateTime endDate)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Events_GetDistinctShifts"), moduleId, startDate, endDate);
        }

        public override IDataReader Events_GetAvailableSignups(int moduleId, string shiftName, string shiftDayOfWeek, DateTime startDate, DateTime endDate, int userID)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Events_GetAvailableSignups"), moduleId, shiftName, shiftDayOfWeek, startDate, endDate, userID);
        }

        public override void Events_DeleteSignup(int signupID)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("Events_DeleteSignup"), signupID);
        }

        public override IDataReader Events_GetVolunteerInfo(int userID, int portalID)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("Events_GetVolunteerInfo"), userID, portalID);
        }

        public override void Events_AddPropertyDefinition(int portalId, string propertyCategory, string propertyName)
        {
            SqlHelper.ExecuteNonQuery(connectionString, GetFullyQualifiedName("Events_AddPropertyDefinition"), portalId, propertyCategory, propertyName);
        }


        #endregion
    }
}
