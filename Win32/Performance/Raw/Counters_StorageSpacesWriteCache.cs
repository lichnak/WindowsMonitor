using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class Counters_StorageSpacesWriteCache
    {
		public ulong AvgCacheBytesPerEvict { get; private set; }
		public uint AvgCacheBytesPerEvict_Base { get; private set; }
		public ulong AvgCacheBytesPerOverwrite { get; private set; }
		public uint AvgCacheBytesPerOverwrite_Base { get; private set; }
		public ulong AvgCacheBytesPerWrite { get; private set; }
		public uint AvgCacheBytesPerWrite_Base { get; private set; }
		public ulong AvgDestageBytesPerEvict { get; private set; }
		public uint AvgDestageBytesPerEvict_Base { get; private set; }
		public ulong AvgDestageBytesPerTransfer { get; private set; }
		public uint AvgDestageBytesPerTransfer_Base { get; private set; }
		public ulong AvgDestageEvictBytesPerOperation { get; private set; }
		public uint AvgDestageEvictBytesPerOperation_Base { get; private set; }
		public ulong AvgDestageEvictsPerOperation { get; private set; }
		public uint AvgDestageEvictsPerOperation_Base { get; private set; }
		public ulong AvgDestageQueueLength { get; private set; }
		public uint AvgDestagesecPerOperation { get; private set; }
		public uint AvgDestagesecPerOperation_Base { get; private set; }
		public ulong AvgDestageTransferBytesPerOperation { get; private set; }
		public uint AvgDestageTransferBytesPerOperation_Base { get; private set; }
		public ulong AvgDestageTransfersPerEvict { get; private set; }
		public uint AvgDestageTransfersPerEvict_Base { get; private set; }
		public ulong AvgDestageTransfersPerOperation { get; private set; }
		public uint AvgDestageTransfersPerOperation_Base { get; private set; }
		public ulong BytesCached { get; private set; }
		public ulong BytesReclaimable { get; private set; }
		public ulong BytesReserved { get; private set; }
		public ulong BytesUsed { get; private set; }
		public ulong CacheEvictBytesPersec { get; private set; }
		public ulong CacheEvictsPersec { get; private set; }
		public ulong CacheOverwriteBytesPersec { get; private set; }
		public ulong CacheOverwritesPersec { get; private set; }
		public ulong CacheSize { get; private set; }
		public ulong CacheWriteBytesPersec { get; private set; }
		public ulong CacheWritesPersec { get; private set; }
		public string Caption { get; private set; }
		public uint CurrentDestageQueueLength { get; private set; }
		public string Description { get; private set; }
		public ulong DestageEvictBytesPersec { get; private set; }
		public ulong DestageEvictsPersec { get; private set; }
		public ulong DestageOperationsPersec { get; private set; }
		public ulong DestageOptimizedOperationsPersec { get; private set; }
		public ulong DestageTransferBytesPersec { get; private set; }
		public ulong DestageTransfersPersec { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }

        public static IEnumerable<Counters_StorageSpacesWriteCache> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<Counters_StorageSpacesWriteCache> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<Counters_StorageSpacesWriteCache> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_Counters_StorageSpacesWriteCache");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new Counters_StorageSpacesWriteCache
                {
                     AvgCacheBytesPerEvict = (ulong) (managementObject.Properties["AvgCacheBytesPerEvict"]?.Value ?? default(ulong)),
		 AvgCacheBytesPerEvict_Base = (uint) (managementObject.Properties["AvgCacheBytesPerEvict_Base"]?.Value ?? default(uint)),
		 AvgCacheBytesPerOverwrite = (ulong) (managementObject.Properties["AvgCacheBytesPerOverwrite"]?.Value ?? default(ulong)),
		 AvgCacheBytesPerOverwrite_Base = (uint) (managementObject.Properties["AvgCacheBytesPerOverwrite_Base"]?.Value ?? default(uint)),
		 AvgCacheBytesPerWrite = (ulong) (managementObject.Properties["AvgCacheBytesPerWrite"]?.Value ?? default(ulong)),
		 AvgCacheBytesPerWrite_Base = (uint) (managementObject.Properties["AvgCacheBytesPerWrite_Base"]?.Value ?? default(uint)),
		 AvgDestageBytesPerEvict = (ulong) (managementObject.Properties["AvgDestageBytesPerEvict"]?.Value ?? default(ulong)),
		 AvgDestageBytesPerEvict_Base = (uint) (managementObject.Properties["AvgDestageBytesPerEvict_Base"]?.Value ?? default(uint)),
		 AvgDestageBytesPerTransfer = (ulong) (managementObject.Properties["AvgDestageBytesPerTransfer"]?.Value ?? default(ulong)),
		 AvgDestageBytesPerTransfer_Base = (uint) (managementObject.Properties["AvgDestageBytesPerTransfer_Base"]?.Value ?? default(uint)),
		 AvgDestageEvictBytesPerOperation = (ulong) (managementObject.Properties["AvgDestageEvictBytesPerOperation"]?.Value ?? default(ulong)),
		 AvgDestageEvictBytesPerOperation_Base = (uint) (managementObject.Properties["AvgDestageEvictBytesPerOperation_Base"]?.Value ?? default(uint)),
		 AvgDestageEvictsPerOperation = (ulong) (managementObject.Properties["AvgDestageEvictsPerOperation"]?.Value ?? default(ulong)),
		 AvgDestageEvictsPerOperation_Base = (uint) (managementObject.Properties["AvgDestageEvictsPerOperation_Base"]?.Value ?? default(uint)),
		 AvgDestageQueueLength = (ulong) (managementObject.Properties["AvgDestageQueueLength"]?.Value ?? default(ulong)),
		 AvgDestagesecPerOperation = (uint) (managementObject.Properties["AvgDestagesecPerOperation"]?.Value ?? default(uint)),
		 AvgDestagesecPerOperation_Base = (uint) (managementObject.Properties["AvgDestagesecPerOperation_Base"]?.Value ?? default(uint)),
		 AvgDestageTransferBytesPerOperation = (ulong) (managementObject.Properties["AvgDestageTransferBytesPerOperation"]?.Value ?? default(ulong)),
		 AvgDestageTransferBytesPerOperation_Base = (uint) (managementObject.Properties["AvgDestageTransferBytesPerOperation_Base"]?.Value ?? default(uint)),
		 AvgDestageTransfersPerEvict = (ulong) (managementObject.Properties["AvgDestageTransfersPerEvict"]?.Value ?? default(ulong)),
		 AvgDestageTransfersPerEvict_Base = (uint) (managementObject.Properties["AvgDestageTransfersPerEvict_Base"]?.Value ?? default(uint)),
		 AvgDestageTransfersPerOperation = (ulong) (managementObject.Properties["AvgDestageTransfersPerOperation"]?.Value ?? default(ulong)),
		 AvgDestageTransfersPerOperation_Base = (uint) (managementObject.Properties["AvgDestageTransfersPerOperation_Base"]?.Value ?? default(uint)),
		 BytesCached = (ulong) (managementObject.Properties["BytesCached"]?.Value ?? default(ulong)),
		 BytesReclaimable = (ulong) (managementObject.Properties["BytesReclaimable"]?.Value ?? default(ulong)),
		 BytesReserved = (ulong) (managementObject.Properties["BytesReserved"]?.Value ?? default(ulong)),
		 BytesUsed = (ulong) (managementObject.Properties["BytesUsed"]?.Value ?? default(ulong)),
		 CacheEvictBytesPersec = (ulong) (managementObject.Properties["CacheEvictBytesPersec"]?.Value ?? default(ulong)),
		 CacheEvictsPersec = (ulong) (managementObject.Properties["CacheEvictsPersec"]?.Value ?? default(ulong)),
		 CacheOverwriteBytesPersec = (ulong) (managementObject.Properties["CacheOverwriteBytesPersec"]?.Value ?? default(ulong)),
		 CacheOverwritesPersec = (ulong) (managementObject.Properties["CacheOverwritesPersec"]?.Value ?? default(ulong)),
		 CacheSize = (ulong) (managementObject.Properties["CacheSize"]?.Value ?? default(ulong)),
		 CacheWriteBytesPersec = (ulong) (managementObject.Properties["CacheWriteBytesPersec"]?.Value ?? default(ulong)),
		 CacheWritesPersec = (ulong) (managementObject.Properties["CacheWritesPersec"]?.Value ?? default(ulong)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 CurrentDestageQueueLength = (uint) (managementObject.Properties["CurrentDestageQueueLength"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DestageEvictBytesPersec = (ulong) (managementObject.Properties["DestageEvictBytesPersec"]?.Value ?? default(ulong)),
		 DestageEvictsPersec = (ulong) (managementObject.Properties["DestageEvictsPersec"]?.Value ?? default(ulong)),
		 DestageOperationsPersec = (ulong) (managementObject.Properties["DestageOperationsPersec"]?.Value ?? default(ulong)),
		 DestageOptimizedOperationsPersec = (ulong) (managementObject.Properties["DestageOptimizedOperationsPersec"]?.Value ?? default(ulong)),
		 DestageTransferBytesPersec = (ulong) (managementObject.Properties["DestageTransferBytesPersec"]?.Value ?? default(ulong)),
		 DestageTransfersPersec = (ulong) (managementObject.Properties["DestageTransfersPersec"]?.Value ?? default(ulong)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}