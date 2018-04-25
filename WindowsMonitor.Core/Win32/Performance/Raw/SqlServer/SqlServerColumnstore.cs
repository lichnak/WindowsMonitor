using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class SqlServerColumnstore
    {
		public string Caption { get; private set; }
		public ulong DeltaRowgroupsClosed { get; private set; }
		public ulong DeltaRowgroupsCompressed { get; private set; }
		public ulong DeltaRowgroupsCreated { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public string Name { get; private set; }
		public ulong SegmentCacheHitRatio { get; private set; }
		public ulong SegmentCacheHitRatio_Base { get; private set; }
		public ulong SegmentReadsPerSec { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public ulong TotalDeleteBuffersMigrated { get; private set; }
		public ulong TotalMergePolicyEvaluations { get; private set; }
		public ulong TotalRowgroupsCompressed { get; private set; }
		public ulong TotalRowgroupsFitForMerge { get; private set; }
		public ulong TotalRowgroupsMergeCompressed { get; private set; }
		public ulong TotalSourceRowgroupsMerged { get; private set; }

        public static IEnumerable<SqlServerColumnstore> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlServerColumnstore> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlServerColumnstore> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_MSSQLSERVER_SQLServerColumnstore");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlServerColumnstore
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 DeltaRowgroupsClosed = (ulong) (managementObject.Properties["DeltaRowgroupsClosed"]?.Value ?? default(ulong)),
		 DeltaRowgroupsCompressed = (ulong) (managementObject.Properties["DeltaRowgroupsCompressed"]?.Value ?? default(ulong)),
		 DeltaRowgroupsCreated = (ulong) (managementObject.Properties["DeltaRowgroupsCreated"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 SegmentCacheHitRatio = (ulong) (managementObject.Properties["SegmentCacheHitRatio"]?.Value ?? default(ulong)),
		 SegmentCacheHitRatio_Base = (ulong) (managementObject.Properties["SegmentCacheHitRatio_Base"]?.Value ?? default(ulong)),
		 SegmentReadsPerSec = (ulong) (managementObject.Properties["SegmentReadsPerSec"]?.Value ?? default(ulong)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TotalDeleteBuffersMigrated = (ulong) (managementObject.Properties["TotalDeleteBuffersMigrated"]?.Value ?? default(ulong)),
		 TotalMergePolicyEvaluations = (ulong) (managementObject.Properties["TotalMergePolicyEvaluations"]?.Value ?? default(ulong)),
		 TotalRowgroupsCompressed = (ulong) (managementObject.Properties["TotalRowgroupsCompressed"]?.Value ?? default(ulong)),
		 TotalRowgroupsFitForMerge = (ulong) (managementObject.Properties["TotalRowgroupsFitForMerge"]?.Value ?? default(ulong)),
		 TotalRowgroupsMergeCompressed = (ulong) (managementObject.Properties["TotalRowgroupsMergeCompressed"]?.Value ?? default(ulong)),
		 TotalSourceRowgroupsMerged = (ulong) (managementObject.Properties["TotalSourceRowgroupsMerged"]?.Value ?? default(ulong))
                };
        }
    }
}