using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_SMBServerShares
    {
		public ulong AvgBytesPerRead { get; private set; }
		public uint AvgBytesPerRead_Base { get; private set; }
		public ulong AvgBytesPerWrite { get; private set; }
		public uint AvgBytesPerWrite_Base { get; private set; }
		public ulong AvgDataBytesPerRequest { get; private set; }
		public uint AvgDataBytesPerRequest_Base { get; private set; }
		public ulong AvgDataQueueLength { get; private set; }
		public ulong AvgReadQueueLength { get; private set; }
		public uint AvgsecPerDataRequest { get; private set; }
		public uint AvgsecPerDataRequest_Base { get; private set; }
		public uint AvgsecPerRead { get; private set; }
		public uint AvgsecPerRead_Base { get; private set; }
		public uint AvgsecPerRequest { get; private set; }
		public uint AvgsecPerRequest_Base { get; private set; }
		public uint AvgsecPerWrite { get; private set; }
		public uint AvgsecPerWrite_Base { get; private set; }
		public ulong AvgWriteQueueLength { get; private set; }
		public string Caption { get; private set; }
		public ulong CurrentDataQueueLength { get; private set; }
		public ulong CurrentDurableOpenFileCount { get; private set; }
		public ulong CurrentOpenFileCount { get; private set; }
		public ulong CurrentPendingRequests { get; private set; }
		public ulong DataBytesPersec { get; private set; }
		public uint DataRequestsPersec { get; private set; }
		public string Description { get; private set; }
		public ulong FilesOpenedPersec { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public ulong MetadataRequestsPersec { get; private set; }
		public string Name { get; private set; }
		public ulong PercentPersistentHandles { get; private set; }
		public ulong PercentPersistentHandles_Base { get; private set; }
		public ulong PercentResilientHandles { get; private set; }
		public ulong PercentResilientHandles_Base { get; private set; }
		public ulong ReadBytesPersec { get; private set; }
		public uint ReadRequestsPersec { get; private set; }
		public ulong ReceivedBytesPersec { get; private set; }
		public ulong RequestsPersec { get; private set; }
		public ulong SentBytesPersec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong TotalDurableHandleReopenCount { get; private set; }
		public ulong TotalFailedDurableHandleReopenCount { get; private set; }
		public ulong TotalFailedPersistentHandleReopenCount { get; private set; }
		public ulong TotalFailedResilientHandleReopenCount { get; private set; }
		public ulong TotalFileOpenCount { get; private set; }
		public ulong TotalPersistentHandleReopenCount { get; private set; }
		public ulong TotalResilientHandleReopenCount { get; private set; }
		public ulong TransferredBytesPersec { get; private set; }
		public ulong TreeConnectCount { get; private set; }
		public ulong WriteBytesPersec { get; private set; }
		public uint WriteRequestsPersec { get; private set; }

        public static IEnumerable<Counters_SMBServerShares> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_SMBServerShares> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_SMBServerShares> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_SMBServerShares");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_SMBServerShares
                {
                     AvgBytesPerRead = (ulong) (managementObject.Properties["AvgBytesPerRead"]?.Value ?? default(ulong)),
		 AvgBytesPerRead_Base = (uint) (managementObject.Properties["AvgBytesPerRead_Base"]?.Value ?? default(uint)),
		 AvgBytesPerWrite = (ulong) (managementObject.Properties["AvgBytesPerWrite"]?.Value ?? default(ulong)),
		 AvgBytesPerWrite_Base = (uint) (managementObject.Properties["AvgBytesPerWrite_Base"]?.Value ?? default(uint)),
		 AvgDataBytesPerRequest = (ulong) (managementObject.Properties["AvgDataBytesPerRequest"]?.Value ?? default(ulong)),
		 AvgDataBytesPerRequest_Base = (uint) (managementObject.Properties["AvgDataBytesPerRequest_Base"]?.Value ?? default(uint)),
		 AvgDataQueueLength = (ulong) (managementObject.Properties["AvgDataQueueLength"]?.Value ?? default(ulong)),
		 AvgReadQueueLength = (ulong) (managementObject.Properties["AvgReadQueueLength"]?.Value ?? default(ulong)),
		 AvgsecPerDataRequest = (uint) (managementObject.Properties["AvgsecPerDataRequest"]?.Value ?? default(uint)),
		 AvgsecPerDataRequest_Base = (uint) (managementObject.Properties["AvgsecPerDataRequest_Base"]?.Value ?? default(uint)),
		 AvgsecPerRead = (uint) (managementObject.Properties["AvgsecPerRead"]?.Value ?? default(uint)),
		 AvgsecPerRead_Base = (uint) (managementObject.Properties["AvgsecPerRead_Base"]?.Value ?? default(uint)),
		 AvgsecPerRequest = (uint) (managementObject.Properties["AvgsecPerRequest"]?.Value ?? default(uint)),
		 AvgsecPerRequest_Base = (uint) (managementObject.Properties["AvgsecPerRequest_Base"]?.Value ?? default(uint)),
		 AvgsecPerWrite = (uint) (managementObject.Properties["AvgsecPerWrite"]?.Value ?? default(uint)),
		 AvgsecPerWrite_Base = (uint) (managementObject.Properties["AvgsecPerWrite_Base"]?.Value ?? default(uint)),
		 AvgWriteQueueLength = (ulong) (managementObject.Properties["AvgWriteQueueLength"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CurrentDataQueueLength = (ulong) (managementObject.Properties["CurrentDataQueueLength"]?.Value ?? default(ulong)),
		 CurrentDurableOpenFileCount = (ulong) (managementObject.Properties["CurrentDurableOpenFileCount"]?.Value ?? default(ulong)),
		 CurrentOpenFileCount = (ulong) (managementObject.Properties["CurrentOpenFileCount"]?.Value ?? default(ulong)),
		 CurrentPendingRequests = (ulong) (managementObject.Properties["CurrentPendingRequests"]?.Value ?? default(ulong)),
		 DataBytesPersec = (ulong) (managementObject.Properties["DataBytesPersec"]?.Value ?? default(ulong)),
		 DataRequestsPersec = (uint) (managementObject.Properties["DataRequestsPersec"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 FilesOpenedPersec = (ulong) (managementObject.Properties["FilesOpenedPersec"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 MetadataRequestsPersec = (ulong) (managementObject.Properties["MetadataRequestsPersec"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PercentPersistentHandles = (ulong) (managementObject.Properties["PercentPersistentHandles"]?.Value ?? default(ulong)),
		 PercentPersistentHandles_Base = (ulong) (managementObject.Properties["PercentPersistentHandles_Base"]?.Value ?? default(ulong)),
		 PercentResilientHandles = (ulong) (managementObject.Properties["PercentResilientHandles"]?.Value ?? default(ulong)),
		 PercentResilientHandles_Base = (ulong) (managementObject.Properties["PercentResilientHandles_Base"]?.Value ?? default(ulong)),
		 ReadBytesPersec = (ulong) (managementObject.Properties["ReadBytesPersec"]?.Value ?? default(ulong)),
		 ReadRequestsPersec = (uint) (managementObject.Properties["ReadRequestsPersec"]?.Value ?? default(uint)),
		 ReceivedBytesPersec = (ulong) (managementObject.Properties["ReceivedBytesPersec"]?.Value ?? default(ulong)),
		 RequestsPersec = (ulong) (managementObject.Properties["RequestsPersec"]?.Value ?? default(ulong)),
		 SentBytesPersec = (ulong) (managementObject.Properties["SentBytesPersec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalDurableHandleReopenCount = (ulong) (managementObject.Properties["TotalDurableHandleReopenCount"]?.Value ?? default(ulong)),
		 TotalFailedDurableHandleReopenCount = (ulong) (managementObject.Properties["TotalFailedDurableHandleReopenCount"]?.Value ?? default(ulong)),
		 TotalFailedPersistentHandleReopenCount = (ulong) (managementObject.Properties["TotalFailedPersistentHandleReopenCount"]?.Value ?? default(ulong)),
		 TotalFailedResilientHandleReopenCount = (ulong) (managementObject.Properties["TotalFailedResilientHandleReopenCount"]?.Value ?? default(ulong)),
		 TotalFileOpenCount = (ulong) (managementObject.Properties["TotalFileOpenCount"]?.Value ?? default(ulong)),
		 TotalPersistentHandleReopenCount = (ulong) (managementObject.Properties["TotalPersistentHandleReopenCount"]?.Value ?? default(ulong)),
		 TotalResilientHandleReopenCount = (ulong) (managementObject.Properties["TotalResilientHandleReopenCount"]?.Value ?? default(ulong)),
		 TransferredBytesPersec = (ulong) (managementObject.Properties["TransferredBytesPersec"]?.Value ?? default(ulong)),
		 TreeConnectCount = (ulong) (managementObject.Properties["TreeConnectCount"]?.Value ?? default(ulong)),
		 WriteBytesPersec = (ulong) (managementObject.Properties["WriteBytesPersec"]?.Value ?? default(ulong)),
		 WriteRequestsPersec = (uint) (managementObject.Properties["WriteRequestsPersec"]?.Value ?? default(uint))
                };
        }
    }
}