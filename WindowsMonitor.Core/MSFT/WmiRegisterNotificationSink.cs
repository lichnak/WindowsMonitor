using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Msft
{
    /// <summary>
    /// </summary>
    public sealed class WmiRegisterNotificationSink
    {
		public string Namespace { get; private set; }
		public string Query { get; private set; }
		public string QueryLanguage { get; private set; }
		public byte[] SECURITY_DESCRIPTOR { get; private set; }
		public ulong Sink { get; private set; }
		public ulong TIME_CREATED { get; private set; }

        public static IEnumerable<WmiRegisterNotificationSink> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<WmiRegisterNotificationSink> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<WmiRegisterNotificationSink> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFT_WmiRegisterNotificationSink");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new WmiRegisterNotificationSink
                {
                     Namespace = (string) (managementObject.Properties["Namespace"]?.Value ?? default(string)),
		 Query = (string) (managementObject.Properties["Query"]?.Value ?? default(string)),
		 QueryLanguage = (string) (managementObject.Properties["QueryLanguage"]?.Value ?? default(string)),
		 SECURITY_DESCRIPTOR = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 Sink = (ulong) (managementObject.Properties["Sink"]?.Value ?? default(ulong)),
		 TIME_CREATED = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong))
                };
        }
    }
}