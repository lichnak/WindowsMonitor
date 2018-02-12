using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class SMS_AI_InstalledSoftwareDupDetect
    {
		public string EntryNameKey { get; private set; }
		public string Software1 { get; private set; }
		public string Software2 { get; private set; }

        public static IEnumerable<SMS_AI_InstalledSoftwareDupDetect> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SMS_AI_InstalledSoftwareDupDetect> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SMS_AI_InstalledSoftwareDupDetect> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SMS_AI_InstalledSoftwareDupDetect");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SMS_AI_InstalledSoftwareDupDetect
                {
                     EntryNameKey = (string) (managementObject.Properties["EntryNameKey"]?.Value ?? default(string)),
		 Software1 = (string) (managementObject.Properties["Software1"]?.Value ?? default(string)),
		 Software2 = (string) (managementObject.Properties["Software2"]?.Value ?? default(string))
                };
        }
    }
}