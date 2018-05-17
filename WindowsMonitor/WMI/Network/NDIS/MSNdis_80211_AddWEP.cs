using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.WMI
{
    /// <summary>
    /// </summary>
    public sealed class MSNdis_80211_AddWEP
    {
		public bool Active { get; private set; }
		public string InstanceName { get; private set; }
		public uint KeyIndex { get; private set; }
		public uint KeyLength { get; private set; }
		public byte[] KeyMaterial { get; private set; }
		public uint Length { get; private set; }

        public static IEnumerable<MSNdis_80211_AddWEP> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MSNdis_80211_AddWEP> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MSNdis_80211_AddWEP> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSNdis_80211_AddWEP");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MSNdis_80211_AddWEP
                {
                     Active = (bool) (managementObject.Properties["Active"]?.Value ?? default(bool)),
		 InstanceName = (string) (managementObject.Properties["InstanceName"]?.Value ?? default(string)),
		 KeyIndex = (uint) (managementObject.Properties["KeyIndex"]?.Value ?? default(uint)),
		 KeyLength = (uint) (managementObject.Properties["KeyLength"]?.Value ?? default(uint)),
		 KeyMaterial = (byte[]) (managementObject.Properties["KeyMaterial"]?.Value ?? new byte[0]),
		 Length = (uint) (managementObject.Properties["Length"]?.Value ?? default(uint))
                };
        }
    }
}