using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class PatchPackage
    {
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public string PatchID { get; private set; }
		public string ProductCode { get; private set; }
		public string SettingID { get; private set; }

        public static IEnumerable<PatchPackage> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PatchPackage> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PatchPackage> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PatchPackage");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PatchPackage
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 PatchID = (string) (managementObject.Properties["PatchID"]?.Value),
		 ProductCode = (string) (managementObject.Properties["ProductCode"]?.Value),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value)
                };
        }
    }
}