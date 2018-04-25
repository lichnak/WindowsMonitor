using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class MappedLogicalDisk
    {
		public ushort Access { get; private set; }
		public ushort Availability { get; private set; }
		public ulong BlockSize { get; private set; }
		public string Caption { get; private set; }
		public bool Compressed { get; private set; }
		public uint ConfigManagerErrorCode { get; private set; }
		public bool ConfigManagerUserConfig { get; private set; }
		public string CreationClassName { get; private set; }
		public string Description { get; private set; }
		public string DeviceID { get; private set; }
		public bool ErrorCleared { get; private set; }
		public string ErrorDescription { get; private set; }
		public string ErrorMethodology { get; private set; }
		public string FileSystem { get; private set; }
		public ulong FreeSpace { get; private set; }
		public DateTime InstallDate { get; private set; }
		public uint LastErrorCode { get; private set; }
		public uint MaximumComponentLength { get; private set; }
		public string Name { get; private set; }
		public ulong NumberOfBlocks { get; private set; }
		public string PNPDeviceID { get; private set; }
		public ushort[] PowerManagementCapabilities { get; private set; }
		public bool PowerManagementSupported { get; private set; }
		public string ProviderName { get; private set; }
		public string Purpose { get; private set; }
		public bool QuotasDisabled { get; private set; }
		public bool QuotasIncomplete { get; private set; }
		public bool QuotasRebuilding { get; private set; }
		public string SessionID { get; private set; }
		public ulong Size { get; private set; }
		public string Status { get; private set; }
		public ushort StatusInfo { get; private set; }
		public bool SupportsDiskQuotas { get; private set; }
		public bool SupportsFileBasedCompression { get; private set; }
		public string SystemCreationClassName { get; private set; }
		public string SystemName { get; private set; }
		public string VolumeName { get; private set; }
		public string VolumeSerialNumber { get; private set; }

        public static IEnumerable<MappedLogicalDisk> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<MappedLogicalDisk> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<MappedLogicalDisk> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_MappedLogicalDisk");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new MappedLogicalDisk
                {
                     Access = (ushort) (managementObject.Properties["Access"]?.Value ?? default(ushort)),
		 Availability = (ushort) (managementObject.Properties["Availability"]?.Value ?? default(ushort)),
		 BlockSize = (ulong) (managementObject.Properties["BlockSize"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Compressed = (bool) (managementObject.Properties["Compressed"]?.Value ?? default(bool)),
		 ConfigManagerErrorCode = (uint) (managementObject.Properties["ConfigManagerErrorCode"]?.Value ?? default(uint)),
		 ConfigManagerUserConfig = (bool) (managementObject.Properties["ConfigManagerUserConfig"]?.Value ?? default(bool)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DeviceID = (string) (managementObject.Properties["DeviceID"]?.Value ?? default(string)),
		 ErrorCleared = (bool) (managementObject.Properties["ErrorCleared"]?.Value ?? default(bool)),
		 ErrorDescription = (string) (managementObject.Properties["ErrorDescription"]?.Value ?? default(string)),
		 ErrorMethodology = (string) (managementObject.Properties["ErrorMethodology"]?.Value ?? default(string)),
		 FileSystem = (string) (managementObject.Properties["FileSystem"]?.Value ?? default(string)),
		 FreeSpace = (ulong) (managementObject.Properties["FreeSpace"]?.Value ?? default(ulong)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 LastErrorCode = (uint) (managementObject.Properties["LastErrorCode"]?.Value ?? default(uint)),
		 MaximumComponentLength = (uint) (managementObject.Properties["MaximumComponentLength"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NumberOfBlocks = (ulong) (managementObject.Properties["NumberOfBlocks"]?.Value ?? default(ulong)),
		 PNPDeviceID = (string) (managementObject.Properties["PNPDeviceID"]?.Value ?? default(string)),
		 PowerManagementCapabilities = (ushort[]) (managementObject.Properties["PowerManagementCapabilities"]?.Value ?? new ushort[0]),
		 PowerManagementSupported = (bool) (managementObject.Properties["PowerManagementSupported"]?.Value ?? default(bool)),
		 ProviderName = (string) (managementObject.Properties["ProviderName"]?.Value ?? default(string)),
		 Purpose = (string) (managementObject.Properties["Purpose"]?.Value ?? default(string)),
		 QuotasDisabled = (bool) (managementObject.Properties["QuotasDisabled"]?.Value ?? default(bool)),
		 QuotasIncomplete = (bool) (managementObject.Properties["QuotasIncomplete"]?.Value ?? default(bool)),
		 QuotasRebuilding = (bool) (managementObject.Properties["QuotasRebuilding"]?.Value ?? default(bool)),
		 SessionID = (string) (managementObject.Properties["SessionID"]?.Value ?? default(string)),
		 Size = (ulong) (managementObject.Properties["Size"]?.Value ?? default(ulong)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 StatusInfo = (ushort) (managementObject.Properties["StatusInfo"]?.Value ?? default(ushort)),
		 SupportsDiskQuotas = (bool) (managementObject.Properties["SupportsDiskQuotas"]?.Value ?? default(bool)),
		 SupportsFileBasedCompression = (bool) (managementObject.Properties["SupportsFileBasedCompression"]?.Value ?? default(bool)),
		 SystemCreationClassName = (string) (managementObject.Properties["SystemCreationClassName"]?.Value ?? default(string)),
		 SystemName = (string) (managementObject.Properties["SystemName"]?.Value ?? default(string)),
		 VolumeName = (string) (managementObject.Properties["VolumeName"]?.Value ?? default(string)),
		 VolumeSerialNumber = (string) (managementObject.Properties["VolumeSerialNumber"]?.Value ?? default(string))
                };
        }
    }
}