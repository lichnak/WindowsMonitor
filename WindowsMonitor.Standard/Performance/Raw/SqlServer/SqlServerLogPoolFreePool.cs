using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw.SqlServer
{
    /// <summary>
    /// </summary>
    public sealed class SqlServerLogPoolFreePool
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong FreeBufferRefillsPersec { get; private set; }
		public ulong FreeListLength { get; private set; }
		public ulong FrequencyObject { get; private set; }
		public ulong FrequencyPerfTime { get; private set; }
		public ulong FrequencySys100Ns { get; private set; }
		public string Name { get; private set; }
		public ulong TimestampObject { get; private set; }
		public ulong TimestampPerfTime { get; private set; }
		public ulong TimestampSys100Ns { get; private set; }

        public static IEnumerable<SqlServerLogPoolFreePool> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlServerLogPoolFreePool> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlServerLogPoolFreePool> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerLogPoolFreePool");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlServerLogPoolFreePool
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 FreeBufferRefillsPersec = (ulong) (managementObject.Properties["FreeBufferRefillsPersec"]?.Value ?? default(ulong)),
		 FreeListLength = (ulong) (managementObject.Properties["FreeListLength"]?.Value ?? default(ulong)),
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