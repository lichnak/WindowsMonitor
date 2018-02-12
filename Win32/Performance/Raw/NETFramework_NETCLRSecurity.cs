using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class NETFramework_NETCLRSecurity
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public uint NumberLinkTimeChecks { get; private set; }
		public uint PercentTimeinRTchecks { get; private set; }
		public uint PercentTimeinRTchecks_Base { get; private set; }
		public ulong PercentTimeSigAuthenticating { get; private set; }
		public uint StackWalkDepth { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public uint TotalRuntimeChecks { get; private set; }

        public static IEnumerable<NETFramework_NETCLRSecurity> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<NETFramework_NETCLRSecurity> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<NETFramework_NETCLRSecurity> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_NETFramework_NETCLRSecurity");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new NETFramework_NETCLRSecurity
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumberLinkTimeChecks = (uint) (managementObject.Properties["NumberLinkTimeChecks"]?.Value ?? default(uint)),
		 PercentTimeinRTchecks = (uint) (managementObject.Properties["PercentTimeinRTchecks"]?.Value ?? default(uint)),
		 PercentTimeinRTchecks_Base = (uint) (managementObject.Properties["PercentTimeinRTchecks_Base"]?.Value ?? default(uint)),
		 PercentTimeSigAuthenticating = (ulong) (managementObject.Properties["PercentTimeSigAuthenticating"]?.Value ?? default(ulong)),
		 StackWalkDepth = (uint) (managementObject.Properties["StackWalkDepth"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalRuntimeChecks = (uint) (managementObject.Properties["TotalRuntimeChecks"]?.Value ?? default(uint))
                };
        }
    }
}