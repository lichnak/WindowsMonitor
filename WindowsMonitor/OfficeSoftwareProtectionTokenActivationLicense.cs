using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class OfficeSoftwareProtectionTokenActivationLicense
    {
		public string AdditionalInfo { get; private set; }
		public uint AuthorizationStatus { get; private set; }
		public string Description { get; private set; }
		public DateTime ExpirationDate { get; private set; }
		public string Id { get; private set; }
		public string Ilid { get; private set; }
		public uint Ilvid { get; private set; }

        public static IEnumerable<OfficeSoftwareProtectionTokenActivationLicense> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<OfficeSoftwareProtectionTokenActivationLicense> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<OfficeSoftwareProtectionTokenActivationLicense> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM OfficeSoftwareProtectionTokenActivationLicense");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new OfficeSoftwareProtectionTokenActivationLicense
                {
                     AdditionalInfo = (string) (managementObject.Properties["AdditionalInfo"]?.Value ?? default(string)),
		 AuthorizationStatus = (uint) (managementObject.Properties["AuthorizationStatus"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 ExpirationDate = (DateTime) (managementObject.Properties["ExpirationDate"]?.Value ?? default(DateTime)),
		 Id = (string) (managementObject.Properties["ID"]?.Value ?? default(string)),
		 Ilid = (string) (managementObject.Properties["ILID"]?.Value ?? default(string)),
		 Ilvid = (uint) (managementObject.Properties["ILVID"]?.Value ?? default(uint))
                };
        }
    }
}