using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSERVER_SQLServerTransactionManager_Costly
    {
		public ulong AGEresponsesreceivedPersec { get; private set; }
		public ulong AveragelifeofAGEbroadcast { get; private set; }
		public uint AveragelifeofAGEbroadcast_Base { get; private set; }
		public ulong AvgAGEhardeningtime { get; private set; }
		public uint AvgAGEhardeningtime_Base { get; private set; }
		public ulong AvgsizeofAGEMessage { get; private set; }
		public uint AvgsizeofAGEMessage_Base { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong NumberofAGEbroadcastsPersec { get; private set; }
		public ulong OrdersbroadcastPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<MSSQLSERVER_SQLServerTransactionManager_Costly> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSERVER_SQLServerTransactionManager_Costly> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSERVER_SQLServerTransactionManager_Costly> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerTransactionManager_Costly");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSERVER_SQLServerTransactionManager_Costly
                {
                     AGEresponsesreceivedPersec = (ulong) (managementObject.Properties["AGEresponsesreceivedPersec"]?.Value ?? default(ulong)),
		 AveragelifeofAGEbroadcast = (ulong) (managementObject.Properties["AveragelifeofAGEbroadcast"]?.Value ?? default(ulong)),
		 AveragelifeofAGEbroadcast_Base = (uint) (managementObject.Properties["AveragelifeofAGEbroadcast_Base"]?.Value ?? default(uint)),
		 AvgAGEhardeningtime = (ulong) (managementObject.Properties["AvgAGEhardeningtime"]?.Value ?? default(ulong)),
		 AvgAGEhardeningtime_Base = (uint) (managementObject.Properties["AvgAGEhardeningtime_Base"]?.Value ?? default(uint)),
		 AvgsizeofAGEMessage = (ulong) (managementObject.Properties["AvgsizeofAGEMessage"]?.Value ?? default(ulong)),
		 AvgsizeofAGEMessage_Base = (uint) (managementObject.Properties["AvgsizeofAGEMessage_Base"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumberofAGEbroadcastsPersec = (ulong) (managementObject.Properties["NumberofAGEbroadcastsPersec"]?.Value ?? default(ulong)),
		 OrdersbroadcastPersec = (ulong) (managementObject.Properties["OrdersbroadcastPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}