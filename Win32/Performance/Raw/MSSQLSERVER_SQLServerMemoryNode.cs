using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSERVER_SQLServerMemoryNode
    {
		public string Caption { get; private set; }
		public ulong DatabaseNodeMemoryKB { get; private set; }
		public string Description { get; private set; }
		public ulong ForeignNodeMemoryKB { get; private set; }
		public ulong FreeNodeMemoryKB { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong StolenNodeMemoryKB { get; private set; }
		public ulong TargetNodeMemoryKB { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong TotalNodeMemoryKB { get; private set; }

        public static IEnumerable<MSSQLSERVER_SQLServerMemoryNode> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSERVER_SQLServerMemoryNode> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSERVER_SQLServerMemoryNode> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerMemoryNode");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSERVER_SQLServerMemoryNode
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 DatabaseNodeMemoryKB = (ulong) (managementObject.Properties["DatabaseNodeMemoryKB"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 ForeignNodeMemoryKB = (ulong) (managementObject.Properties["ForeignNodeMemoryKB"]?.Value ?? default(ulong)),
		 FreeNodeMemoryKB = (ulong) (managementObject.Properties["FreeNodeMemoryKB"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 StolenNodeMemoryKB = (ulong) (managementObject.Properties["StolenNodeMemoryKB"]?.Value ?? default(ulong)),
		 TargetNodeMemoryKB = (ulong) (managementObject.Properties["TargetNodeMemoryKB"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalNodeMemoryKB = (ulong) (managementObject.Properties["TotalNodeMemoryKB"]?.Value ?? default(ulong))
                };
        }
    }
}