using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class MSSQLSERVER_SQLServerLocks
    {
		public ulong AverageWaitTimems { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong LockRequestsPersec { get; private set; }
		public ulong LockTimeoutsPersec { get; private set; }
		public ulong LockTimeoutstimeout0Persec { get; private set; }
		public ulong LockWaitsPersec { get; private set; }
		public ulong LockWaitTimems { get; private set; }
		public string Name { get; private set; }
		public ulong NumberofDeadlocksPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<MSSQLSERVER_SQLServerLocks> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSSQLSERVER_SQLServerLocks> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSSQLSERVER_SQLServerLocks> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSERVER_SQLServerLocks");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSSQLSERVER_SQLServerLocks
                {
                     AverageWaitTimems = (ulong) (managementObject.Properties["AverageWaitTimems"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 LockRequestsPersec = (ulong) (managementObject.Properties["LockRequestsPersec"]?.Value ?? default(ulong)),
		 LockTimeoutsPersec = (ulong) (managementObject.Properties["LockTimeoutsPersec"]?.Value ?? default(ulong)),
		 LockTimeoutstimeout0Persec = (ulong) (managementObject.Properties["LockTimeoutstimeout0Persec"]?.Value ?? default(ulong)),
		 LockWaitsPersec = (ulong) (managementObject.Properties["LockWaitsPersec"]?.Value ?? default(ulong)),
		 LockWaitTimems = (ulong) (managementObject.Properties["LockWaitTimems"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumberofDeadlocksPersec = (ulong) (managementObject.Properties["NumberofDeadlocksPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}