using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class __Trustee
    {
		public string Domain { get; private set; }
		public string Name { get; private set; }
		public byte[] SID { get; private set; }
		public uint SidLength { get; private set; }
		public string SIDString { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<__Trustee> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<__Trustee> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<__Trustee> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM __Trustee");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new __Trustee
                {
                     Domain = (string) (managementObject.Properties["Domain"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 SID = (byte[]) (managementObject.Properties["SID"]?.Value ?? new byte[0]),
		 SidLength = (uint) (managementObject.Properties["SidLength"]?.Value ?? default(uint)),
		 SIDString = (string) (managementObject.Properties["SIDString"]?.Value ?? default(string)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}