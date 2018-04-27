using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class Patch
    {
		public ushort Attributes { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public string File { get; private set; }
		public uint PatchSize { get; private set; }
		public string ProductCode { get; private set; }
		public short Sequence { get; private set; }
		public string SettingID { get; private set; }

        public static IEnumerable<Patch> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Patch> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Patch> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_Patch");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Patch
                {
                     Attributes = (ushort) (managementObject.Properties["Attributes"]?.Value ?? default(ushort)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 File = (string) (managementObject.Properties["File"]?.Value ?? default(string)),
		 PatchSize = (uint) (managementObject.Properties["PatchSize"]?.Value ?? default(uint)),
		 ProductCode = (string) (managementObject.Properties["ProductCode"]?.Value ?? default(string)),
		 Sequence = (short) (managementObject.Properties["Sequence"]?.Value ?? default(short)),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value ?? default(string))
                };
        }
    }
}