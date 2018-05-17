using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class TerminateIOThread
    {
		public uint IOThreadCount { get; private set; }
		public uint RetiredIOs { get; private set; }

        public static IEnumerable<TerminateIOThread> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<TerminateIOThread> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TerminateIOThread> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM TerminateIOThread");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TerminateIOThread
                {
                     IOThreadCount = (uint) (managementObject.Properties["IOThreadCount"]?.Value ?? default(uint)),
		 RetiredIOs = (uint) (managementObject.Properties["RetiredIOs"]?.Value ?? default(uint))
                };
        }
    }
}