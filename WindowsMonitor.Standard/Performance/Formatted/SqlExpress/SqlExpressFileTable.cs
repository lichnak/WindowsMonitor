using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted.SqlExpress
{
    /// <summary>
    /// </summary>
    public sealed class SqlExpressFileTable
    {
		public ulong AvgtimedeleteFileTableitem { get; private set; }
		public ulong AvgtimeFileTableenumeration { get; private set; }
		public ulong AvgtimeFileTablehandlekill { get; private set; }
		public ulong AvgtimemoveFileTableitem { get; private set; }
		public ulong AvgtimeperfileIOrequest { get; private set; }
		public ulong AvgtimeperfileIOresponse { get; private set; }
		public ulong AvgtimerenameFileTableitem { get; private set; }
		public ulong AvgtimetogetFileTableitem { get; private set; }
		public ulong AvgtimeupdateFileTableitem { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong FileTabledboperationsPersec { get; private set; }
		public ulong FileTableenumerationreqsPersec { get; private set; }
		public ulong FileTablefileIOrequestsPersec { get; private set; }
		public ulong FileTablefileIOresponsePersec { get; private set; }
		public ulong FileTableitemdeletereqsPersec { get; private set; }
		public ulong FileTableitemgetrequestsPersec { get; private set; }
		public ulong FileTableitemmovereqsPersec { get; private set; }
		public ulong FileTableitemrenamereqsPersec { get; private set; }
		public ulong FileTableitemupdatereqsPersec { get; private set; }
		public ulong FileTablekillhandleopsPersec { get; private set; }
		public ulong FileTabletableoperationsPersec { get; private set; }
		public ulong FrequencyObject { get; private set; }
		public ulong FrequencyPerfTime { get; private set; }
		public ulong FrequencySys100Ns { get; private set; }
		public string Name { get; private set; }
		public ulong TimestampObject { get; private set; }
		public ulong TimestampPerfTime { get; private set; }
		public ulong TimestampSys100Ns { get; private set; }

        public static IEnumerable<SqlExpressFileTable> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\cimv2"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlExpressFileTable> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlExpressFileTable> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSFileTable");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlExpressFileTable
                {
                     AvgtimedeleteFileTableitem = (ulong) (managementObject.Properties["AvgtimedeleteFileTableitem"]?.Value ?? default(ulong)),
		 AvgtimeFileTableenumeration = (ulong) (managementObject.Properties["AvgtimeFileTableenumeration"]?.Value ?? default(ulong)),
		 AvgtimeFileTablehandlekill = (ulong) (managementObject.Properties["AvgtimeFileTablehandlekill"]?.Value ?? default(ulong)),
		 AvgtimemoveFileTableitem = (ulong) (managementObject.Properties["AvgtimemoveFileTableitem"]?.Value ?? default(ulong)),
		 AvgtimeperfileIOrequest = (ulong) (managementObject.Properties["AvgtimeperfileIOrequest"]?.Value ?? default(ulong)),
		 AvgtimeperfileIOresponse = (ulong) (managementObject.Properties["AvgtimeperfileIOresponse"]?.Value ?? default(ulong)),
		 AvgtimerenameFileTableitem = (ulong) (managementObject.Properties["AvgtimerenameFileTableitem"]?.Value ?? default(ulong)),
		 AvgtimetogetFileTableitem = (ulong) (managementObject.Properties["AvgtimetogetFileTableitem"]?.Value ?? default(ulong)),
		 AvgtimeupdateFileTableitem = (ulong) (managementObject.Properties["AvgtimeupdateFileTableitem"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 FileTabledboperationsPersec = (ulong) (managementObject.Properties["FileTabledboperationsPersec"]?.Value ?? default(ulong)),
		 FileTableenumerationreqsPersec = (ulong) (managementObject.Properties["FileTableenumerationreqsPersec"]?.Value ?? default(ulong)),
		 FileTablefileIOrequestsPersec = (ulong) (managementObject.Properties["FileTablefileIOrequestsPersec"]?.Value ?? default(ulong)),
		 FileTablefileIOresponsePersec = (ulong) (managementObject.Properties["FileTablefileIOresponsePersec"]?.Value ?? default(ulong)),
		 FileTableitemdeletereqsPersec = (ulong) (managementObject.Properties["FileTableitemdeletereqsPersec"]?.Value ?? default(ulong)),
		 FileTableitemgetrequestsPersec = (ulong) (managementObject.Properties["FileTableitemgetrequestsPersec"]?.Value ?? default(ulong)),
		 FileTableitemmovereqsPersec = (ulong) (managementObject.Properties["FileTableitemmovereqsPersec"]?.Value ?? default(ulong)),
		 FileTableitemrenamereqsPersec = (ulong) (managementObject.Properties["FileTableitemrenamereqsPersec"]?.Value ?? default(ulong)),
		 FileTableitemupdatereqsPersec = (ulong) (managementObject.Properties["FileTableitemupdatereqsPersec"]?.Value ?? default(ulong)),
		 FileTablekillhandleopsPersec = (ulong) (managementObject.Properties["FileTablekillhandleopsPersec"]?.Value ?? default(ulong)),
		 FileTabletableoperationsPersec = (ulong) (managementObject.Properties["FileTabletableoperationsPersec"]?.Value ?? default(ulong)),
		 FrequencyObject = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 FrequencyPerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 FrequencySys100Ns = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 TimestampObject = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 TimestampPerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 TimestampSys100Ns = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}