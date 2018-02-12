using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class SerialPort
    {
		public ushort Availability { get; private set; }
		public bool Binary { get; private set; }
		public ushort[] Capabilities { get; private set; }
		public string[] CapabilityDescriptions { get; private set; }
		public string Caption { get; private set; }
		public uint ConfigManagerErrorCode { get; private set; }
		public bool ConfigManagerUserConfig { get; private set; }
		public string CreationClassName { get; private set; }
		public string Description { get; private set; }
		public string DeviceID { get; private set; }
		public bool ErrorCleared { get; private set; }
		public string ErrorDescription { get; private set; }
		public DateTime InstallDate { get; private set; }
		public uint LastErrorCode { get; private set; }
		public uint MaxBaudRate { get; private set; }
		public uint MaximumInputBufferSize { get; private set; }
		public uint MaximumOutputBufferSize { get; private set; }
		public uint MaxNumberControlled { get; private set; }
		public string Name { get; private set; }
		public bool OSAutoDiscovered { get; private set; }
		public string PNPDeviceID { get; private set; }
		public ushort[] PowerManagementCapabilities { get; private set; }
		public bool PowerManagementSupported { get; private set; }
		public ushort ProtocolSupported { get; private set; }
		public string ProviderType { get; private set; }
		public bool SettableBaudRate { get; private set; }
		public bool SettableDataBits { get; private set; }
		public bool SettableFlowControl { get; private set; }
		public bool SettableParity { get; private set; }
		public bool SettableParityCheck { get; private set; }
		public bool SettableRLSD { get; private set; }
		public bool SettableStopBits { get; private set; }
		public string Status { get; private set; }
		public ushort StatusInfo { get; private set; }
		public bool Supports16BitMode { get; private set; }
		public bool SupportsDTRDSR { get; private set; }
		public bool SupportsElapsedTimeouts { get; private set; }
		public bool SupportsIntTimeouts { get; private set; }
		public bool SupportsParityCheck { get; private set; }
		public bool SupportsRLSD { get; private set; }
		public bool SupportsRTSCTS { get; private set; }
		public bool SupportsSpecialCharacters { get; private set; }
		public bool SupportsXOnXOff { get; private set; }
		public bool SupportsXOnXOffSet { get; private set; }
		public string SystemCreationClassName { get; private set; }
		public string SystemName { get; private set; }
		public DateTime TimeOfLastReset { get; private set; }

        public static IEnumerable<SerialPort> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SerialPort> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SerialPort> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_SerialPort");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SerialPort
                {
                     Availability = (ushort) (managementObject.Properties["Availability"]?.Value ?? default(ushort)),
		 Binary = (bool) (managementObject.Properties["Binary"]?.Value ?? default(bool)),
		 Capabilities = (ushort[]) (managementObject.Properties["Capabilities"]?.Value ?? new ushort[0]),
		 CapabilityDescriptions = (string[]) (managementObject.Properties["CapabilityDescriptions"]?.Value ?? new string[0]),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 ConfigManagerErrorCode = (uint) (managementObject.Properties["ConfigManagerErrorCode"]?.Value ?? default(uint)),
		 ConfigManagerUserConfig = (bool) (managementObject.Properties["ConfigManagerUserConfig"]?.Value ?? default(bool)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DeviceID = (string) (managementObject.Properties["DeviceID"]?.Value ?? default(string)),
		 ErrorCleared = (bool) (managementObject.Properties["ErrorCleared"]?.Value ?? default(bool)),
		 ErrorDescription = (string) (managementObject.Properties["ErrorDescription"]?.Value ?? default(string)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 LastErrorCode = (uint) (managementObject.Properties["LastErrorCode"]?.Value ?? default(uint)),
		 MaxBaudRate = (uint) (managementObject.Properties["MaxBaudRate"]?.Value ?? default(uint)),
		 MaximumInputBufferSize = (uint) (managementObject.Properties["MaximumInputBufferSize"]?.Value ?? default(uint)),
		 MaximumOutputBufferSize = (uint) (managementObject.Properties["MaximumOutputBufferSize"]?.Value ?? default(uint)),
		 MaxNumberControlled = (uint) (managementObject.Properties["MaxNumberControlled"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OSAutoDiscovered = (bool) (managementObject.Properties["OSAutoDiscovered"]?.Value ?? default(bool)),
		 PNPDeviceID = (string) (managementObject.Properties["PNPDeviceID"]?.Value ?? default(string)),
		 PowerManagementCapabilities = (ushort[]) (managementObject.Properties["PowerManagementCapabilities"]?.Value ?? new ushort[0]),
		 PowerManagementSupported = (bool) (managementObject.Properties["PowerManagementSupported"]?.Value ?? default(bool)),
		 ProtocolSupported = (ushort) (managementObject.Properties["ProtocolSupported"]?.Value ?? default(ushort)),
		 ProviderType = (string) (managementObject.Properties["ProviderType"]?.Value ?? default(string)),
		 SettableBaudRate = (bool) (managementObject.Properties["SettableBaudRate"]?.Value ?? default(bool)),
		 SettableDataBits = (bool) (managementObject.Properties["SettableDataBits"]?.Value ?? default(bool)),
		 SettableFlowControl = (bool) (managementObject.Properties["SettableFlowControl"]?.Value ?? default(bool)),
		 SettableParity = (bool) (managementObject.Properties["SettableParity"]?.Value ?? default(bool)),
		 SettableParityCheck = (bool) (managementObject.Properties["SettableParityCheck"]?.Value ?? default(bool)),
		 SettableRLSD = (bool) (managementObject.Properties["SettableRLSD"]?.Value ?? default(bool)),
		 SettableStopBits = (bool) (managementObject.Properties["SettableStopBits"]?.Value ?? default(bool)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 StatusInfo = (ushort) (managementObject.Properties["StatusInfo"]?.Value ?? default(ushort)),
		 Supports16BitMode = (bool) (managementObject.Properties["Supports16BitMode"]?.Value ?? default(bool)),
		 SupportsDTRDSR = (bool) (managementObject.Properties["SupportsDTRDSR"]?.Value ?? default(bool)),
		 SupportsElapsedTimeouts = (bool) (managementObject.Properties["SupportsElapsedTimeouts"]?.Value ?? default(bool)),
		 SupportsIntTimeouts = (bool) (managementObject.Properties["SupportsIntTimeouts"]?.Value ?? default(bool)),
		 SupportsParityCheck = (bool) (managementObject.Properties["SupportsParityCheck"]?.Value ?? default(bool)),
		 SupportsRLSD = (bool) (managementObject.Properties["SupportsRLSD"]?.Value ?? default(bool)),
		 SupportsRTSCTS = (bool) (managementObject.Properties["SupportsRTSCTS"]?.Value ?? default(bool)),
		 SupportsSpecialCharacters = (bool) (managementObject.Properties["SupportsSpecialCharacters"]?.Value ?? default(bool)),
		 SupportsXOnXOff = (bool) (managementObject.Properties["SupportsXOnXOff"]?.Value ?? default(bool)),
		 SupportsXOnXOffSet = (bool) (managementObject.Properties["SupportsXOnXOffSet"]?.Value ?? default(bool)),
		 SystemCreationClassName = (string) (managementObject.Properties["SystemCreationClassName"]?.Value ?? default(string)),
		 SystemName = (string) (managementObject.Properties["SystemName"]?.Value ?? default(string)),
		 TimeOfLastReset = (DateTime) (managementObject.Properties["TimeOfLastReset"]?.Value ?? default(DateTime))
                };
        }
    }
}