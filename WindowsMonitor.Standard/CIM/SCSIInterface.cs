using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.CIM
{
    /// <summary>
    /// </summary>
    public sealed class SCSIInterface
    {
		public ushort AccessState { get; private set; }
		public short Antecedent { get; private set; }
		public short Dependent { get; private set; }
		public uint NegotiatedDataWidth { get; private set; }
		public ulong NegotiatedSpeed { get; private set; }
		public uint NumberOfHardResets { get; private set; }
		public uint NumberOfSoftResets { get; private set; }
		public uint SCSIRetries { get; private set; }
		public uint SCSITimeouts { get; private set; }

        public static IEnumerable<SCSIInterface> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SCSIInterface> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SCSIInterface> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM CIM_SCSIInterface");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SCSIInterface
                {
                     AccessState = (ushort) (managementObject.Properties["AccessState"]?.Value ?? default(ushort)),
		 Antecedent = (short) (managementObject.Properties["Antecedent"]?.Value ?? default(short)),
		 Dependent = (short) (managementObject.Properties["Dependent"]?.Value ?? default(short)),
		 NegotiatedDataWidth = (uint) (managementObject.Properties["NegotiatedDataWidth"]?.Value ?? default(uint)),
		 NegotiatedSpeed = (ulong) (managementObject.Properties["NegotiatedSpeed"]?.Value ?? default(ulong)),
		 NumberOfHardResets = (uint) (managementObject.Properties["NumberOfHardResets"]?.Value ?? default(uint)),
		 NumberOfSoftResets = (uint) (managementObject.Properties["NumberOfSoftResets"]?.Value ?? default(uint)),
		 SCSIRetries = (uint) (managementObject.Properties["SCSIRetries"]?.Value ?? default(uint)),
		 SCSITimeouts = (uint) (managementObject.Properties["SCSITimeouts"]?.Value ?? default(uint))
                };
        }
    }
}