using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class ProductFRU
    {
		public short FRU { get; private set; }
		public short Product { get; private set; }

        public static IEnumerable<ProductFRU> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ProductFRU> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ProductFRU> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_ProductFRU");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ProductFRU
                {
                     FRU = (short) (managementObject.Properties["FRU"]?.Value ?? default(short)),
		 Product = (short) (managementObject.Properties["Product"]?.Value ?? default(short))
                };
        }
    }
}