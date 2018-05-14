using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class TapiSrvTelephony
    {
		public uint ActiveLines { get; private set; }
		public uint ActiveTelephones { get; private set; }
		public string Caption { get; private set; }
		public uint ClientApps { get; private set; }
		public uint CurrentIncomingCalls { get; private set; }
		public uint CurrentOutgoingCalls { get; private set; }
		public string Description { get; private set; }
		public ulong FrequencyObject { get; private set; }
		public ulong FrequencyPerfTime { get; private set; }
		public ulong FrequencySys100Ns { get; private set; }
		public uint IncomingCallsPersec { get; private set; }
		public uint Lines { get; private set; }
		public string Name { get; private set; }
		public uint OutgoingCallsPersec { get; private set; }
		public uint TelephoneDevices { get; private set; }
		public ulong TimestampObject { get; private set; }
		public ulong TimestampPerfTime { get; private set; }
		public ulong TimestampSys100Ns { get; private set; }

        public static IEnumerable<TapiSrvTelephony> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<TapiSrvTelephony> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<TapiSrvTelephony> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_TapiSrv_Telephony");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new TapiSrvTelephony
                {
                     ActiveLines = (uint) (managementObject.Properties["ActiveLines"]?.Value ?? default(uint)),
		 ActiveTelephones = (uint) (managementObject.Properties["ActiveTelephones"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 ClientApps = (uint) (managementObject.Properties["ClientApps"]?.Value ?? default(uint)),
		 CurrentIncomingCalls = (uint) (managementObject.Properties["CurrentIncomingCalls"]?.Value ?? default(uint)),
		 CurrentOutgoingCalls = (uint) (managementObject.Properties["CurrentOutgoingCalls"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 FrequencyObject = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 FrequencyPerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 FrequencySys100Ns = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 IncomingCallsPersec = (uint) (managementObject.Properties["IncomingCallsPersec"]?.Value ?? default(uint)),
		 Lines = (uint) (managementObject.Properties["Lines"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 OutgoingCallsPersec = (uint) (managementObject.Properties["OutgoingCallsPersec"]?.Value ?? default(uint)),
		 TelephoneDevices = (uint) (managementObject.Properties["TelephoneDevices"]?.Value ?? default(uint)),
		 TimestampObject = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 TimestampPerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 TimestampSys100Ns = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}