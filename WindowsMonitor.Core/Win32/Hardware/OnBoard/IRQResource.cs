using System;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.OnBoard
{
    /// <summary>
    /// </summary>
    public sealed class IRQResource
    {
		public ushort Availability { get; private set; }
		public string Caption { get; private set; }
		public string CreationClassName { get; private set; }
		public string CSCreationClassName { get; private set; }
		public string CSName { get; private set; }
		public string Description { get; private set; }
		public bool Hardware { get; private set; }
		public DateTime InstallDate { get; private set; }
		public uint IRQNumber { get; private set; }
		public string Name { get; private set; }
		public bool Shareable { get; private set; }
		public string Status { get; private set; }
		public ushort TriggerLevel { get; private set; }
		public ushort TriggerType { get; private set; }
		public uint Vector { get; private set; }

        public static IEnumerable<IRQResource> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<IRQResource> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<IRQResource> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_IRQResource");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new IRQResource
                {
                     Availability = (ushort) (managementObject.Properties["Availability"]?.Value ?? default(ushort)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 CSCreationClassName = (string) (managementObject.Properties["CSCreationClassName"]?.Value ?? default(string)),
		 CSName = (string) (managementObject.Properties["CSName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Hardware = (bool) (managementObject.Properties["Hardware"]?.Value ?? default(bool)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 IRQNumber = (uint) (managementObject.Properties["IRQNumber"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Shareable = (bool) (managementObject.Properties["Shareable"]?.Value ?? default(bool)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 TriggerLevel = (ushort) (managementObject.Properties["TriggerLevel"]?.Value ?? default(ushort)),
		 TriggerType = (ushort) (managementObject.Properties["TriggerType"]?.Value ?? default(ushort)),
		 Vector = (uint) (managementObject.Properties["Vector"]?.Value ?? default(uint))
                };
        }
    }
}