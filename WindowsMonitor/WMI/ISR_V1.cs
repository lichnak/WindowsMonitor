using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class ISR_V1
    {
		public uint Flags { get; private set; }
		public dynamic InitialTime { get; private set; }
		public uint ReturnValue { get; private set; }
		public uint Routine { get; private set; }

        public static IEnumerable<ISR_V1> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<ISR_V1> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ISR_V1> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM ISR_V1");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ISR_V1
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 InitialTime = (dynamic) (managementObject.Properties["InitialTime"]?.Value ?? default(dynamic)),
		 ReturnValue = (uint) (managementObject.Properties["ReturnValue"]?.Value ?? default(uint)),
		 Routine = (uint) (managementObject.Properties["Routine"]?.Value ?? default(uint))
                };
        }
    }
}