using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class DiskDrive
    {
		public ushort Availability { get; private set; }
		public uint BytesPerSector { get; private set; }
		public ushort[] Capabilities { get; private set; }
		public string[] CapabilityDescriptions { get; private set; }
		public string Caption { get; private set; }
		public string CompressionMethod { get; private set; }
		public uint ConfigManagerErrorCode { get; private set; }
		public bool ConfigManagerUserConfig { get; private set; }
		public string CreationClassName { get; private set; }
		public ulong DefaultBlockSize { get; private set; }
		public string Description { get; private set; }
		public string DeviceID { get; private set; }
		public bool ErrorCleared { get; private set; }
		public string ErrorDescription { get; private set; }
		public string ErrorMethodology { get; private set; }
		public string FirmwareRevision { get; private set; }
		public uint Index { get; private set; }
		public DateTime InstallDate { get; private set; }
		public string InterfaceType { get; private set; }
		public uint LastErrorCode { get; private set; }
		public string Manufacturer { get; private set; }
		public ulong MaxBlockSize { get; private set; }
		public ulong MaxMediaSize { get; private set; }
		public bool MediaLoaded { get; private set; }
		public string MediaType { get; private set; }
		public ulong MinBlockSize { get; private set; }
		public string Model { get; private set; }
		public string Name { get; private set; }
		public bool NeedsCleaning { get; private set; }
		public uint NumberOfMediaSupported { get; private set; }
		public uint Partitions { get; private set; }
		public string PNPDeviceID { get; private set; }
		public ushort[] PowerManagementCapabilities { get; private set; }
		public bool PowerManagementSupported { get; private set; }
		public uint SCSIBus { get; private set; }
		public ushort SCSILogicalUnit { get; private set; }
		public ushort SCSIPort { get; private set; }
		public ushort SCSITargetId { get; private set; }
		public uint SectorsPerTrack { get; private set; }
		public string SerialNumber { get; private set; }
		public uint Signature { get; private set; }
		public ulong Size { get; private set; }
		public string Status { get; private set; }
		public ushort StatusInfo { get; private set; }
		public string SystemCreationClassName { get; private set; }
		public string SystemName { get; private set; }
		public ulong TotalCylinders { get; private set; }
		public uint TotalHeads { get; private set; }
		public ulong TotalSectors { get; private set; }
		public ulong TotalTracks { get; private set; }
		public uint TracksPerCylinder { get; private set; }

        public static IEnumerable<DiskDrive> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<DiskDrive> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<DiskDrive> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_DiskDrive");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new DiskDrive
                {
                     Availability = (ushort) (managementObject.Properties["Availability"]?.Value ?? default(ushort)),
		 BytesPerSector = (uint) (managementObject.Properties["BytesPerSector"]?.Value ?? default(uint)),
		 Capabilities = (ushort[]) (managementObject.Properties["Capabilities"]?.Value ?? new ushort[0]),
		 CapabilityDescriptions = (string[]) (managementObject.Properties["CapabilityDescriptions"]?.Value ?? new string[0]),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CompressionMethod = (string) (managementObject.Properties["CompressionMethod"]?.Value ?? default(string)),
		 ConfigManagerErrorCode = (uint) (managementObject.Properties["ConfigManagerErrorCode"]?.Value ?? default(uint)),
		 ConfigManagerUserConfig = (bool) (managementObject.Properties["ConfigManagerUserConfig"]?.Value ?? default(bool)),
		 CreationClassName = (string) (managementObject.Properties["CreationClassName"]?.Value ?? default(string)),
		 DefaultBlockSize = (ulong) (managementObject.Properties["DefaultBlockSize"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DeviceID = (string) (managementObject.Properties["DeviceID"]?.Value ?? default(string)),
		 ErrorCleared = (bool) (managementObject.Properties["ErrorCleared"]?.Value ?? default(bool)),
		 ErrorDescription = (string) (managementObject.Properties["ErrorDescription"]?.Value ?? default(string)),
		 ErrorMethodology = (string) (managementObject.Properties["ErrorMethodology"]?.Value ?? default(string)),
		 FirmwareRevision = (string) (managementObject.Properties["FirmwareRevision"]?.Value ?? default(string)),
		 Index = (uint) (managementObject.Properties["Index"]?.Value ?? default(uint)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 InterfaceType = (string) (managementObject.Properties["InterfaceType"]?.Value ?? default(string)),
		 LastErrorCode = (uint) (managementObject.Properties["LastErrorCode"]?.Value ?? default(uint)),
		 Manufacturer = (string) (managementObject.Properties["Manufacturer"]?.Value ?? default(string)),
		 MaxBlockSize = (ulong) (managementObject.Properties["MaxBlockSize"]?.Value ?? default(ulong)),
		 MaxMediaSize = (ulong) (managementObject.Properties["MaxMediaSize"]?.Value ?? default(ulong)),
		 MediaLoaded = (bool) (managementObject.Properties["MediaLoaded"]?.Value ?? default(bool)),
		 MediaType = (string) (managementObject.Properties["MediaType"]?.Value ?? default(string)),
		 MinBlockSize = (ulong) (managementObject.Properties["MinBlockSize"]?.Value ?? default(ulong)),
		 Model = (string) (managementObject.Properties["Model"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 NeedsCleaning = (bool) (managementObject.Properties["NeedsCleaning"]?.Value ?? default(bool)),
		 NumberOfMediaSupported = (uint) (managementObject.Properties["NumberOfMediaSupported"]?.Value ?? default(uint)),
		 Partitions = (uint) (managementObject.Properties["Partitions"]?.Value ?? default(uint)),
		 PNPDeviceID = (string) (managementObject.Properties["PNPDeviceID"]?.Value ?? default(string)),
		 PowerManagementCapabilities = (ushort[]) (managementObject.Properties["PowerManagementCapabilities"]?.Value ?? new ushort[0]),
		 PowerManagementSupported = (bool) (managementObject.Properties["PowerManagementSupported"]?.Value ?? default(bool)),
		 SCSIBus = (uint) (managementObject.Properties["SCSIBus"]?.Value ?? default(uint)),
		 SCSILogicalUnit = (ushort) (managementObject.Properties["SCSILogicalUnit"]?.Value ?? default(ushort)),
		 SCSIPort = (ushort) (managementObject.Properties["SCSIPort"]?.Value ?? default(ushort)),
		 SCSITargetId = (ushort) (managementObject.Properties["SCSITargetId"]?.Value ?? default(ushort)),
		 SectorsPerTrack = (uint) (managementObject.Properties["SectorsPerTrack"]?.Value ?? default(uint)),
		 SerialNumber = (string) (managementObject.Properties["SerialNumber"]?.Value ?? default(string)),
		 Signature = (uint) (managementObject.Properties["Signature"]?.Value ?? default(uint)),
		 Size = (ulong) (managementObject.Properties["Size"]?.Value ?? default(ulong)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 StatusInfo = (ushort) (managementObject.Properties["StatusInfo"]?.Value ?? default(ushort)),
		 SystemCreationClassName = (string) (managementObject.Properties["SystemCreationClassName"]?.Value ?? default(string)),
		 SystemName = (string) (managementObject.Properties["SystemName"]?.Value ?? default(string)),
		 TotalCylinders = (ulong) (managementObject.Properties["TotalCylinders"]?.Value ?? default(ulong)),
		 TotalHeads = (uint) (managementObject.Properties["TotalHeads"]?.Value ?? default(uint)),
		 TotalSectors = (ulong) (managementObject.Properties["TotalSectors"]?.Value ?? default(ulong)),
		 TotalTracks = (ulong) (managementObject.Properties["TotalTracks"]?.Value ?? default(ulong)),
		 TracksPerCylinder = (uint) (managementObject.Properties["TracksPerCylinder"]?.Value ?? default(uint))
                };
        }
    }
}