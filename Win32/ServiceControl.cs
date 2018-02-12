using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ServiceControl
    {
		public string Arguments { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public string Event { get; private set; }
		public string ID { get; private set; }
		public string Name { get; private set; }
		public string ProductCode { get; private set; }
		public string SettingID { get; private set; }
		public ushort Wait { get; private set; }

        public static IEnumerable<ServiceControl> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ServiceControl> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ServiceControl> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ServiceControl");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ServiceControl
                {
                     Arguments = (string) (managementObject.Properties["Arguments"]?.Value ?? default(string)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Event = (string) (managementObject.Properties["Event"]?.Value ?? default(string)),
		 ID = (string) (managementObject.Properties["ID"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 ProductCode = (string) (managementObject.Properties["ProductCode"]?.Value ?? default(string)),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value ?? default(string)),
		 Wait = (ushort) (managementObject.Properties["Wait"]?.Value ?? default(ushort))
                };
        }
    }
}