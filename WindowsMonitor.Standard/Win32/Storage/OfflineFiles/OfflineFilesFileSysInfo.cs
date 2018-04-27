using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class OfflineFilesFileSysInfo
    {
		public uint LocalAttributes { get; private set; }
		public DateTime LocalChangeTime { get; private set; }
		public DateTime LocalCreationTime { get; private set; }
		public DateTime LocalLastAccessTime { get; private set; }
		public DateTime LocalLastWriteTime { get; private set; }
		public long LocalSize { get; private set; }
		public uint OriginalAttributes { get; private set; }
		public DateTime OriginalChangeTime { get; private set; }
		public DateTime OriginalCreationTime { get; private set; }
		public DateTime OriginalLastAccessTime { get; private set; }
		public DateTime OriginalLastWriteTime { get; private set; }
		public long OriginalSize { get; private set; }
		public uint RemoteAttributes { get; private set; }
		public DateTime RemoteChangeTime { get; private set; }
		public DateTime RemoteCreationTime { get; private set; }
		public DateTime RemoteLastAccessTime { get; private set; }
		public DateTime RemoteLastWriteTime { get; private set; }
		public long RemoteSize { get; private set; }

        public static IEnumerable<OfflineFilesFileSysInfo> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<OfflineFilesFileSysInfo> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<OfflineFilesFileSysInfo> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_OfflineFilesFileSysInfo");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new OfflineFilesFileSysInfo
                {
                     LocalAttributes = (uint) (managementObject.Properties["LocalAttributes"]?.Value ?? default(uint)),
		 LocalChangeTime = (DateTime) (managementObject.Properties["LocalChangeTime"]?.Value ?? default(DateTime)),
		 LocalCreationTime = (DateTime) (managementObject.Properties["LocalCreationTime"]?.Value ?? default(DateTime)),
		 LocalLastAccessTime = (DateTime) (managementObject.Properties["LocalLastAccessTime"]?.Value ?? default(DateTime)),
		 LocalLastWriteTime = (DateTime) (managementObject.Properties["LocalLastWriteTime"]?.Value ?? default(DateTime)),
		 LocalSize = (long) (managementObject.Properties["LocalSize"]?.Value ?? default(long)),
		 OriginalAttributes = (uint) (managementObject.Properties["OriginalAttributes"]?.Value ?? default(uint)),
		 OriginalChangeTime = (DateTime) (managementObject.Properties["OriginalChangeTime"]?.Value ?? default(DateTime)),
		 OriginalCreationTime = (DateTime) (managementObject.Properties["OriginalCreationTime"]?.Value ?? default(DateTime)),
		 OriginalLastAccessTime = (DateTime) (managementObject.Properties["OriginalLastAccessTime"]?.Value ?? default(DateTime)),
		 OriginalLastWriteTime = (DateTime) (managementObject.Properties["OriginalLastWriteTime"]?.Value ?? default(DateTime)),
		 OriginalSize = (long) (managementObject.Properties["OriginalSize"]?.Value ?? default(long)),
		 RemoteAttributes = (uint) (managementObject.Properties["RemoteAttributes"]?.Value ?? default(uint)),
		 RemoteChangeTime = (DateTime) (managementObject.Properties["RemoteChangeTime"]?.Value ?? default(DateTime)),
		 RemoteCreationTime = (DateTime) (managementObject.Properties["RemoteCreationTime"]?.Value ?? default(DateTime)),
		 RemoteLastAccessTime = (DateTime) (managementObject.Properties["RemoteLastAccessTime"]?.Value ?? default(DateTime)),
		 RemoteLastWriteTime = (DateTime) (managementObject.Properties["RemoteLastWriteTime"]?.Value ?? default(DateTime)),
		 RemoteSize = (long) (managementObject.Properties["RemoteSize"]?.Value ?? default(long))
                };
        }
    }
}