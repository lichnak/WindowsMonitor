using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted.Esent
{
    /// <summary>
    /// </summary>
    public sealed class EsentDatabaseInstances
    {
		public string Caption { get; private set; }
		public ulong DatabaseCacheMissAttachedAverageLatency { get; private set; }
		public uint DatabaseCacheMissesPersec { get; private set; }
		public uint DatabaseCachePercentHit { get; private set; }
		public uint DatabaseCachePercentHitUncorrelated { get; private set; }
		public uint DatabaseCacheRequestsPersec { get; private set; }
		public ulong DatabaseCacheSizeMb { get; private set; }
		public uint DatabaseMaintenanceDuration { get; private set; }
		public uint DatabaseMaintenancePagesBadChecksums { get; private set; }
		public uint DefragmentationTasks { get; private set; }
		public uint DefragmentationTasksPending { get; private set; }
		public string Description { get; private set; }
		public ulong FrequencyObject { get; private set; }
		public ulong FrequencyPerfTime { get; private set; }
		public ulong FrequencySys100Ns { get; private set; }
		public ulong IoDatabaseReadsAttachedAverageLatency { get; private set; }
		public uint IoDatabaseReadsAttachedPersec { get; private set; }
		public ulong IoDatabaseReadsAverageLatency { get; private set; }
		public uint IoDatabaseReadsPersec { get; private set; }
		public ulong IoDatabaseReadsRecoveryAverageLatency { get; private set; }
		public uint IoDatabaseReadsRecoveryPersec { get; private set; }
		public ulong IoDatabaseWritesAttachedAverageLatency { get; private set; }
		public uint IoDatabaseWritesAttachedPersec { get; private set; }
		public ulong IoDatabaseWritesAverageLatency { get; private set; }
		public uint IoDatabaseWritesPersec { get; private set; }
		public ulong IoDatabaseWritesRecoveryAverageLatency { get; private set; }
		public uint IoDatabaseWritesRecoveryPersec { get; private set; }
		public ulong IoFlushMapWritesAverageLatency { get; private set; }
		public uint IoFlushMapWritesPersec { get; private set; }
		public ulong IoLogReadsAverageLatency { get; private set; }
		public uint IoLogReadsPersec { get; private set; }
		public ulong IoLogWritesAverageLatency { get; private set; }
		public uint IoLogWritesPersec { get; private set; }
		public uint LogBytesGeneratedPersec { get; private set; }
		public uint LogBytesWritePersec { get; private set; }
		public uint LogCheckpointDepthasaPercentofTarget { get; private set; }
		public uint LogFileCurrentGeneration { get; private set; }
		public uint LogFilesGenerated { get; private set; }
		public uint LogFilesGeneratedPrematurely { get; private set; }
		public uint LogGenerationCheckpointDepth { get; private set; }
		public uint LogGenerationCheckpointDepthMax { get; private set; }
		public uint LogGenerationCheckpointDepthTarget { get; private set; }
		public uint LogGenerationLossResiliencyDepth { get; private set; }
		public uint LogRecordStallsPersec { get; private set; }
		public uint LogThreadsWaiting { get; private set; }
		public uint LogWritesPersec { get; private set; }
		public string Name { get; private set; }
		public uint SessionsInUse { get; private set; }
		public uint SessionsPercentUsed { get; private set; }
		public uint StreamingBackupPagesReadPersec { get; private set; }
		public uint TableClosesPersec { get; private set; }
		public uint TableOpenCacheHitsPersec { get; private set; }
		public uint TableOpenCacheMissesPersec { get; private set; }
		public uint TableOpenCachePercentHit { get; private set; }
		public uint TableOpensPersec { get; private set; }
		public uint TablesOpen { get; private set; }
		public ulong TimestampObject { get; private set; }
		public ulong TimestampPerfTime { get; private set; }
		public ulong TimestampSys100Ns { get; private set; }
		public uint Versionbucketsallocated { get; private set; }

        public static IEnumerable<EsentDatabaseInstances> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<EsentDatabaseInstances> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<EsentDatabaseInstances> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_ESENT_DatabaseInstances");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new EsentDatabaseInstances
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 DatabaseCacheMissAttachedAverageLatency = (ulong) (managementObject.Properties["DatabaseCacheMissAttachedAverageLatency"]?.Value ?? default(ulong)),
		 DatabaseCacheMissesPersec = (uint) (managementObject.Properties["DatabaseCacheMissesPersec"]?.Value ?? default(uint)),
		 DatabaseCachePercentHit = (uint) (managementObject.Properties["DatabaseCachePercentHit"]?.Value ?? default(uint)),
		 DatabaseCachePercentHitUncorrelated = (uint) (managementObject.Properties["DatabaseCachePercentHitUncorrelated"]?.Value ?? default(uint)),
		 DatabaseCacheRequestsPersec = (uint) (managementObject.Properties["DatabaseCacheRequestsPersec"]?.Value ?? default(uint)),
		 DatabaseCacheSizeMb = (ulong) (managementObject.Properties["DatabaseCacheSizeMB"]?.Value ?? default(ulong)),
		 DatabaseMaintenanceDuration = (uint) (managementObject.Properties["DatabaseMaintenanceDuration"]?.Value ?? default(uint)),
		 DatabaseMaintenancePagesBadChecksums = (uint) (managementObject.Properties["DatabaseMaintenancePagesBadChecksums"]?.Value ?? default(uint)),
		 DefragmentationTasks = (uint) (managementObject.Properties["DefragmentationTasks"]?.Value ?? default(uint)),
		 DefragmentationTasksPending = (uint) (managementObject.Properties["DefragmentationTasksPending"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 FrequencyObject = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 FrequencyPerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 FrequencySys100Ns = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 IoDatabaseReadsAttachedAverageLatency = (ulong) (managementObject.Properties["IODatabaseReadsAttachedAverageLatency"]?.Value ?? default(ulong)),
		 IoDatabaseReadsAttachedPersec = (uint) (managementObject.Properties["IODatabaseReadsAttachedPersec"]?.Value ?? default(uint)),
		 IoDatabaseReadsAverageLatency = (ulong) (managementObject.Properties["IODatabaseReadsAverageLatency"]?.Value ?? default(ulong)),
		 IoDatabaseReadsPersec = (uint) (managementObject.Properties["IODatabaseReadsPersec"]?.Value ?? default(uint)),
		 IoDatabaseReadsRecoveryAverageLatency = (ulong) (managementObject.Properties["IODatabaseReadsRecoveryAverageLatency"]?.Value ?? default(ulong)),
		 IoDatabaseReadsRecoveryPersec = (uint) (managementObject.Properties["IODatabaseReadsRecoveryPersec"]?.Value ?? default(uint)),
		 IoDatabaseWritesAttachedAverageLatency = (ulong) (managementObject.Properties["IODatabaseWritesAttachedAverageLatency"]?.Value ?? default(ulong)),
		 IoDatabaseWritesAttachedPersec = (uint) (managementObject.Properties["IODatabaseWritesAttachedPersec"]?.Value ?? default(uint)),
		 IoDatabaseWritesAverageLatency = (ulong) (managementObject.Properties["IODatabaseWritesAverageLatency"]?.Value ?? default(ulong)),
		 IoDatabaseWritesPersec = (uint) (managementObject.Properties["IODatabaseWritesPersec"]?.Value ?? default(uint)),
		 IoDatabaseWritesRecoveryAverageLatency = (ulong) (managementObject.Properties["IODatabaseWritesRecoveryAverageLatency"]?.Value ?? default(ulong)),
		 IoDatabaseWritesRecoveryPersec = (uint) (managementObject.Properties["IODatabaseWritesRecoveryPersec"]?.Value ?? default(uint)),
		 IoFlushMapWritesAverageLatency = (ulong) (managementObject.Properties["IOFlushMapWritesAverageLatency"]?.Value ?? default(ulong)),
		 IoFlushMapWritesPersec = (uint) (managementObject.Properties["IOFlushMapWritesPersec"]?.Value ?? default(uint)),
		 IoLogReadsAverageLatency = (ulong) (managementObject.Properties["IOLogReadsAverageLatency"]?.Value ?? default(ulong)),
		 IoLogReadsPersec = (uint) (managementObject.Properties["IOLogReadsPersec"]?.Value ?? default(uint)),
		 IoLogWritesAverageLatency = (ulong) (managementObject.Properties["IOLogWritesAverageLatency"]?.Value ?? default(ulong)),
		 IoLogWritesPersec = (uint) (managementObject.Properties["IOLogWritesPersec"]?.Value ?? default(uint)),
		 LogBytesGeneratedPersec = (uint) (managementObject.Properties["LogBytesGeneratedPersec"]?.Value ?? default(uint)),
		 LogBytesWritePersec = (uint) (managementObject.Properties["LogBytesWritePersec"]?.Value ?? default(uint)),
		 LogCheckpointDepthasaPercentofTarget = (uint) (managementObject.Properties["LogCheckpointDepthasaPercentofTarget"]?.Value ?? default(uint)),
		 LogFileCurrentGeneration = (uint) (managementObject.Properties["LogFileCurrentGeneration"]?.Value ?? default(uint)),
		 LogFilesGenerated = (uint) (managementObject.Properties["LogFilesGenerated"]?.Value ?? default(uint)),
		 LogFilesGeneratedPrematurely = (uint) (managementObject.Properties["LogFilesGeneratedPrematurely"]?.Value ?? default(uint)),
		 LogGenerationCheckpointDepth = (uint) (managementObject.Properties["LogGenerationCheckpointDepth"]?.Value ?? default(uint)),
		 LogGenerationCheckpointDepthMax = (uint) (managementObject.Properties["LogGenerationCheckpointDepthMax"]?.Value ?? default(uint)),
		 LogGenerationCheckpointDepthTarget = (uint) (managementObject.Properties["LogGenerationCheckpointDepthTarget"]?.Value ?? default(uint)),
		 LogGenerationLossResiliencyDepth = (uint) (managementObject.Properties["LogGenerationLossResiliencyDepth"]?.Value ?? default(uint)),
		 LogRecordStallsPersec = (uint) (managementObject.Properties["LogRecordStallsPersec"]?.Value ?? default(uint)),
		 LogThreadsWaiting = (uint) (managementObject.Properties["LogThreadsWaiting"]?.Value ?? default(uint)),
		 LogWritesPersec = (uint) (managementObject.Properties["LogWritesPersec"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 SessionsInUse = (uint) (managementObject.Properties["SessionsInUse"]?.Value ?? default(uint)),
		 SessionsPercentUsed = (uint) (managementObject.Properties["SessionsPercentUsed"]?.Value ?? default(uint)),
		 StreamingBackupPagesReadPersec = (uint) (managementObject.Properties["StreamingBackupPagesReadPersec"]?.Value ?? default(uint)),
		 TableClosesPersec = (uint) (managementObject.Properties["TableClosesPersec"]?.Value ?? default(uint)),
		 TableOpenCacheHitsPersec = (uint) (managementObject.Properties["TableOpenCacheHitsPersec"]?.Value ?? default(uint)),
		 TableOpenCacheMissesPersec = (uint) (managementObject.Properties["TableOpenCacheMissesPersec"]?.Value ?? default(uint)),
		 TableOpenCachePercentHit = (uint) (managementObject.Properties["TableOpenCachePercentHit"]?.Value ?? default(uint)),
		 TableOpensPersec = (uint) (managementObject.Properties["TableOpensPersec"]?.Value ?? default(uint)),
		 TablesOpen = (uint) (managementObject.Properties["TablesOpen"]?.Value ?? default(uint)),
		 TimestampObject = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 TimestampPerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 TimestampSys100Ns = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 Versionbucketsallocated = (uint) (managementObject.Properties["Versionbucketsallocated"]?.Value ?? default(uint))
                };
        }
    }
}