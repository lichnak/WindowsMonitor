using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class PBAStore
    {
		public uint AllocSize { get; private set; }
		public string ClientIP { get; private set; }
		public string ClientName { get; private set; }
		public string CompleteTime { get; private set; }
		public string ExpireTime { get; private set; }
		public string Path { get; private set; }
		public string ShareName { get; private set; }
		public string StartTime { get; private set; }
		public string UserName { get; private set; }

        public static IEnumerable<PBAStore> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PBAStore> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PBAStore> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM PBAStore");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PBAStore
                {
                     AllocSize = (uint) (managementObject.Properties["AllocSize"]?.Value ?? default(uint)),
		 ClientIP = (string) (managementObject.Properties["ClientIP"]?.Value ?? default(string)),
		 ClientName = (string) (managementObject.Properties["ClientName"]?.Value ?? default(string)),
		 CompleteTime = (string) (managementObject.Properties["CompleteTime"]?.Value ?? default(string)),
		 ExpireTime = (string) (managementObject.Properties["ExpireTime"]?.Value ?? default(string)),
		 Path = (string) (managementObject.Properties["Path"]?.Value ?? default(string)),
		 ShareName = (string) (managementObject.Properties["ShareName"]?.Value ?? default(string)),
		 StartTime = (string) (managementObject.Properties["StartTime"]?.Value ?? default(string)),
		 UserName = (string) (managementObject.Properties["UserName"]?.Value ?? default(string))
                };
        }
    }
}