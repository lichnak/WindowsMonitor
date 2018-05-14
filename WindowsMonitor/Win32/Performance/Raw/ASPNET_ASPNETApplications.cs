using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Raw
{
    /// <summary>
    /// </summary>
    public sealed class ASPNET_ASPNETApplications
    {
		public uint AnonymousRequests { get; private set; }
		public uint AnonymousRequestsPerSec { get; private set; }
		public uint ApplicationLifetimeEvents { get; private set; }
		public uint ApplicationLifetimeEventsPerSec { get; private set; }
		public uint AuditFailureEventsRaised { get; private set; }
		public uint AuditSuccessEventsRaised { get; private set; }
		public uint CacheAPIEntries { get; private set; }
		public uint CacheAPIHitRatio { get; private set; }
		public uint CacheAPIHitRatio_Base { get; private set; }
		public uint CacheAPIHits { get; private set; }
		public uint CacheAPIMisses { get; private set; }
		public uint CacheAPITrims { get; private set; }
		public uint CacheAPITurnoverRate { get; private set; }
		public uint CachePercentMachineMemoryLimitUsed { get; private set; }
		public uint CachePercentMachineMemoryLimitUsed_Base { get; private set; }
		public uint CachePercentProcessMemoryLimitUsed { get; private set; }
		public uint CachePercentProcessMemoryLimitUsed_Base { get; private set; }
		public uint CacheTotalEntries { get; private set; }
		public uint CacheTotalHitRatio { get; private set; }
		public uint CacheTotalHitRatio_Base { get; private set; }
		public uint CacheTotalHits { get; private set; }
		public uint CacheTotalMisses { get; private set; }
		public uint CacheTotalTrims { get; private set; }
		public uint CacheTotalTurnoverRate { get; private set; }
		public string Caption { get; private set; }
		public uint CompilationsTotal { get; private set; }
		public uint DebuggingRequests { get; private set; }
		public string Description { get; private set; }
		public uint ErrorEventsRaised { get; private set; }
		public uint ErrorEventsRaisedPerSec { get; private set; }
		public uint ErrorsDuringCompilation { get; private set; }
		public uint ErrorsDuringExecution { get; private set; }
		public uint ErrorsDuringPreprocessing { get; private set; }
		public uint ErrorsTotal { get; private set; }
		public uint ErrorsTotalPerSec { get; private set; }
		public uint ErrorsUnhandledDuringExecution { get; private set; }
		public uint ErrorsUnhandledDuringExecutionPerSec { get; private set; }
		public uint EventsRaised { get; private set; }
		public uint EventsRaisedPerSec { get; private set; }
		public uint FormsAuthenticationFailure { get; private set; }
		public uint FormsAuthenticationSuccess { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint InfrastructureErrorEventsRaised { get; private set; }
		public uint InfrastructureErrorEventsRaisedPerSec { get; private set; }
		public uint ManagedMemoryUsedestimated { get; private set; }
		public uint MembershipAuthenticationFailure { get; private set; }
		public uint MembershipAuthenticationSuccess { get; private set; }
		public string Name { get; private set; }
		public uint OutputCacheEntries { get; private set; }
		public uint OutputCacheHitRatio { get; private set; }
		public uint OutputCacheHitRatio_Base { get; private set; }
		public uint OutputCacheHits { get; private set; }
		public uint OutputCacheMisses { get; private set; }
		public uint OutputCacheTrims { get; private set; }
		public uint OutputCacheTurnoverRate { get; private set; }
		public uint PercentManagedProcessorTimeestimated { get; private set; }
		public uint PercentManagedProcessorTimeestimated_Base { get; private set; }
		public uint PipelineInstanceCount { get; private set; }
		public uint RequestBytesInTotal { get; private set; }
		public uint RequestBytesInTotalWebSockets { get; private set; }
		public uint RequestBytesOutTotal { get; private set; }
		public uint RequestBytesOutTotalWebSockets { get; private set; }
		public uint RequestErrorEventsRaised { get; private set; }
		public uint RequestErrorEventsRaisedPerSec { get; private set; }
		public uint RequestEventsRaised { get; private set; }
		public uint RequestEventsRaisedPerSec { get; private set; }
		public uint RequestExecutionTime { get; private set; }
		public uint RequestsDisconnected { get; private set; }
		public uint RequestsExecuting { get; private set; }
		public uint RequestsExecutingWebSockets { get; private set; }
		public uint RequestsFailed { get; private set; }
		public uint RequestsFailedWebSockets { get; private set; }
		public uint RequestsInApplicationQueue { get; private set; }
		public uint RequestsNotAuthorized { get; private set; }
		public uint RequestsNotFound { get; private set; }
		public uint RequestsPerSec { get; private set; }
		public uint RequestsRejected { get; private set; }
		public uint RequestsSucceeded { get; private set; }
		public uint RequestsSucceededWebSockets { get; private set; }
		public uint RequestsTimedOut { get; private set; }
		public uint RequestsTotal { get; private set; }
		public uint RequestsTotalWebSockets { get; private set; }
		public uint RequestWaitTime { get; private set; }
		public uint SessionsAbandoned { get; private set; }
		public uint SessionsActive { get; private set; }
		public uint SessionSQLServerconnectionstotal { get; private set; }
		public uint SessionStateServerconnectionstotal { get; private set; }
		public uint SessionsTimedOut { get; private set; }
		public uint SessionsTotal { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public uint TransactionsAborted { get; private set; }
		public uint TransactionsCommitted { get; private set; }
		public uint TransactionsPending { get; private set; }
		public uint TransactionsPerSec { get; private set; }
		public uint TransactionsTotal { get; private set; }
		public uint ViewstateMACValidationFailure { get; private set; }

        public static IEnumerable<ASPNET_ASPNETApplications> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ASPNET_ASPNETApplications> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ASPNET_ASPNETApplications> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfRawData_ASPNET_ASPNETApplications");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ASPNET_ASPNETApplications
                {
                     AnonymousRequests = (uint) (managementObject.Properties["AnonymousRequests"]?.Value ?? default(uint)),
		 AnonymousRequestsPerSec = (uint) (managementObject.Properties["AnonymousRequestsPerSec"]?.Value ?? default(uint)),
		 ApplicationLifetimeEvents = (uint) (managementObject.Properties["ApplicationLifetimeEvents"]?.Value ?? default(uint)),
		 ApplicationLifetimeEventsPerSec = (uint) (managementObject.Properties["ApplicationLifetimeEventsPerSec"]?.Value ?? default(uint)),
		 AuditFailureEventsRaised = (uint) (managementObject.Properties["AuditFailureEventsRaised"]?.Value ?? default(uint)),
		 AuditSuccessEventsRaised = (uint) (managementObject.Properties["AuditSuccessEventsRaised"]?.Value ?? default(uint)),
		 CacheAPIEntries = (uint) (managementObject.Properties["CacheAPIEntries"]?.Value ?? default(uint)),
		 CacheAPIHitRatio = (uint) (managementObject.Properties["CacheAPIHitRatio"]?.Value ?? default(uint)),
		 CacheAPIHitRatio_Base = (uint) (managementObject.Properties["CacheAPIHitRatio_Base"]?.Value ?? default(uint)),
		 CacheAPIHits = (uint) (managementObject.Properties["CacheAPIHits"]?.Value ?? default(uint)),
		 CacheAPIMisses = (uint) (managementObject.Properties["CacheAPIMisses"]?.Value ?? default(uint)),
		 CacheAPITrims = (uint) (managementObject.Properties["CacheAPITrims"]?.Value ?? default(uint)),
		 CacheAPITurnoverRate = (uint) (managementObject.Properties["CacheAPITurnoverRate"]?.Value ?? default(uint)),
		 CachePercentMachineMemoryLimitUsed = (uint) (managementObject.Properties["CachePercentMachineMemoryLimitUsed"]?.Value ?? default(uint)),
		 CachePercentMachineMemoryLimitUsed_Base = (uint) (managementObject.Properties["CachePercentMachineMemoryLimitUsed_Base"]?.Value ?? default(uint)),
		 CachePercentProcessMemoryLimitUsed = (uint) (managementObject.Properties["CachePercentProcessMemoryLimitUsed"]?.Value ?? default(uint)),
		 CachePercentProcessMemoryLimitUsed_Base = (uint) (managementObject.Properties["CachePercentProcessMemoryLimitUsed_Base"]?.Value ?? default(uint)),
		 CacheTotalEntries = (uint) (managementObject.Properties["CacheTotalEntries"]?.Value ?? default(uint)),
		 CacheTotalHitRatio = (uint) (managementObject.Properties["CacheTotalHitRatio"]?.Value ?? default(uint)),
		 CacheTotalHitRatio_Base = (uint) (managementObject.Properties["CacheTotalHitRatio_Base"]?.Value ?? default(uint)),
		 CacheTotalHits = (uint) (managementObject.Properties["CacheTotalHits"]?.Value ?? default(uint)),
		 CacheTotalMisses = (uint) (managementObject.Properties["CacheTotalMisses"]?.Value ?? default(uint)),
		 CacheTotalTrims = (uint) (managementObject.Properties["CacheTotalTrims"]?.Value ?? default(uint)),
		 CacheTotalTurnoverRate = (uint) (managementObject.Properties["CacheTotalTurnoverRate"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CompilationsTotal = (uint) (managementObject.Properties["CompilationsTotal"]?.Value ?? default(uint)),
		 DebuggingRequests = (uint) (managementObject.Properties["DebuggingRequests"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 ErrorEventsRaised = (uint) (managementObject.Properties["ErrorEventsRaised"]?.Value ?? default(uint)),
		 ErrorEventsRaisedPerSec = (uint) (managementObject.Properties["ErrorEventsRaisedPerSec"]?.Value ?? default(uint)),
		 ErrorsDuringCompilation = (uint) (managementObject.Properties["ErrorsDuringCompilation"]?.Value ?? default(uint)),
		 ErrorsDuringExecution = (uint) (managementObject.Properties["ErrorsDuringExecution"]?.Value ?? default(uint)),
		 ErrorsDuringPreprocessing = (uint) (managementObject.Properties["ErrorsDuringPreprocessing"]?.Value ?? default(uint)),
		 ErrorsTotal = (uint) (managementObject.Properties["ErrorsTotal"]?.Value ?? default(uint)),
		 ErrorsTotalPerSec = (uint) (managementObject.Properties["ErrorsTotalPerSec"]?.Value ?? default(uint)),
		 ErrorsUnhandledDuringExecution = (uint) (managementObject.Properties["ErrorsUnhandledDuringExecution"]?.Value ?? default(uint)),
		 ErrorsUnhandledDuringExecutionPerSec = (uint) (managementObject.Properties["ErrorsUnhandledDuringExecutionPerSec"]?.Value ?? default(uint)),
		 EventsRaised = (uint) (managementObject.Properties["EventsRaised"]?.Value ?? default(uint)),
		 EventsRaisedPerSec = (uint) (managementObject.Properties["EventsRaisedPerSec"]?.Value ?? default(uint)),
		 FormsAuthenticationFailure = (uint) (managementObject.Properties["FormsAuthenticationFailure"]?.Value ?? default(uint)),
		 FormsAuthenticationSuccess = (uint) (managementObject.Properties["FormsAuthenticationSuccess"]?.Value ?? default(uint)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 InfrastructureErrorEventsRaised = (uint) (managementObject.Properties["InfrastructureErrorEventsRaised"]?.Value ?? default(uint)),
		 InfrastructureErrorEventsRaisedPerSec = (uint) (managementObject.Properties["InfrastructureErrorEventsRaisedPerSec"]?.Value ?? default(uint)),
		 ManagedMemoryUsedestimated = (uint) (managementObject.Properties["ManagedMemoryUsedestimated"]?.Value ?? default(uint)),
		 MembershipAuthenticationFailure = (uint) (managementObject.Properties["MembershipAuthenticationFailure"]?.Value ?? default(uint)),
		 MembershipAuthenticationSuccess = (uint) (managementObject.Properties["MembershipAuthenticationSuccess"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 OutputCacheEntries = (uint) (managementObject.Properties["OutputCacheEntries"]?.Value ?? default(uint)),
		 OutputCacheHitRatio = (uint) (managementObject.Properties["OutputCacheHitRatio"]?.Value ?? default(uint)),
		 OutputCacheHitRatio_Base = (uint) (managementObject.Properties["OutputCacheHitRatio_Base"]?.Value ?? default(uint)),
		 OutputCacheHits = (uint) (managementObject.Properties["OutputCacheHits"]?.Value ?? default(uint)),
		 OutputCacheMisses = (uint) (managementObject.Properties["OutputCacheMisses"]?.Value ?? default(uint)),
		 OutputCacheTrims = (uint) (managementObject.Properties["OutputCacheTrims"]?.Value ?? default(uint)),
		 OutputCacheTurnoverRate = (uint) (managementObject.Properties["OutputCacheTurnoverRate"]?.Value ?? default(uint)),
		 PercentManagedProcessorTimeestimated = (uint) (managementObject.Properties["PercentManagedProcessorTimeestimated"]?.Value ?? default(uint)),
		 PercentManagedProcessorTimeestimated_Base = (uint) (managementObject.Properties["PercentManagedProcessorTimeestimated_Base"]?.Value ?? default(uint)),
		 PipelineInstanceCount = (uint) (managementObject.Properties["PipelineInstanceCount"]?.Value ?? default(uint)),
		 RequestBytesInTotal = (uint) (managementObject.Properties["RequestBytesInTotal"]?.Value ?? default(uint)),
		 RequestBytesInTotalWebSockets = (uint) (managementObject.Properties["RequestBytesInTotalWebSockets"]?.Value ?? default(uint)),
		 RequestBytesOutTotal = (uint) (managementObject.Properties["RequestBytesOutTotal"]?.Value ?? default(uint)),
		 RequestBytesOutTotalWebSockets = (uint) (managementObject.Properties["RequestBytesOutTotalWebSockets"]?.Value ?? default(uint)),
		 RequestErrorEventsRaised = (uint) (managementObject.Properties["RequestErrorEventsRaised"]?.Value ?? default(uint)),
		 RequestErrorEventsRaisedPerSec = (uint) (managementObject.Properties["RequestErrorEventsRaisedPerSec"]?.Value ?? default(uint)),
		 RequestEventsRaised = (uint) (managementObject.Properties["RequestEventsRaised"]?.Value ?? default(uint)),
		 RequestEventsRaisedPerSec = (uint) (managementObject.Properties["RequestEventsRaisedPerSec"]?.Value ?? default(uint)),
		 RequestExecutionTime = (uint) (managementObject.Properties["RequestExecutionTime"]?.Value ?? default(uint)),
		 RequestsDisconnected = (uint) (managementObject.Properties["RequestsDisconnected"]?.Value ?? default(uint)),
		 RequestsExecuting = (uint) (managementObject.Properties["RequestsExecuting"]?.Value ?? default(uint)),
		 RequestsExecutingWebSockets = (uint) (managementObject.Properties["RequestsExecutingWebSockets"]?.Value ?? default(uint)),
		 RequestsFailed = (uint) (managementObject.Properties["RequestsFailed"]?.Value ?? default(uint)),
		 RequestsFailedWebSockets = (uint) (managementObject.Properties["RequestsFailedWebSockets"]?.Value ?? default(uint)),
		 RequestsInApplicationQueue = (uint) (managementObject.Properties["RequestsInApplicationQueue"]?.Value ?? default(uint)),
		 RequestsNotAuthorized = (uint) (managementObject.Properties["RequestsNotAuthorized"]?.Value ?? default(uint)),
		 RequestsNotFound = (uint) (managementObject.Properties["RequestsNotFound"]?.Value ?? default(uint)),
		 RequestsPerSec = (uint) (managementObject.Properties["RequestsPerSec"]?.Value ?? default(uint)),
		 RequestsRejected = (uint) (managementObject.Properties["RequestsRejected"]?.Value ?? default(uint)),
		 RequestsSucceeded = (uint) (managementObject.Properties["RequestsSucceeded"]?.Value ?? default(uint)),
		 RequestsSucceededWebSockets = (uint) (managementObject.Properties["RequestsSucceededWebSockets"]?.Value ?? default(uint)),
		 RequestsTimedOut = (uint) (managementObject.Properties["RequestsTimedOut"]?.Value ?? default(uint)),
		 RequestsTotal = (uint) (managementObject.Properties["RequestsTotal"]?.Value ?? default(uint)),
		 RequestsTotalWebSockets = (uint) (managementObject.Properties["RequestsTotalWebSockets"]?.Value ?? default(uint)),
		 RequestWaitTime = (uint) (managementObject.Properties["RequestWaitTime"]?.Value ?? default(uint)),
		 SessionsAbandoned = (uint) (managementObject.Properties["SessionsAbandoned"]?.Value ?? default(uint)),
		 SessionsActive = (uint) (managementObject.Properties["SessionsActive"]?.Value ?? default(uint)),
		 SessionSQLServerconnectionstotal = (uint) (managementObject.Properties["SessionSQLServerconnectionstotal"]?.Value ?? default(uint)),
		 SessionStateServerconnectionstotal = (uint) (managementObject.Properties["SessionStateServerconnectionstotal"]?.Value ?? default(uint)),
		 SessionsTimedOut = (uint) (managementObject.Properties["SessionsTimedOut"]?.Value ?? default(uint)),
		 SessionsTotal = (uint) (managementObject.Properties["SessionsTotal"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TransactionsAborted = (uint) (managementObject.Properties["TransactionsAborted"]?.Value ?? default(uint)),
		 TransactionsCommitted = (uint) (managementObject.Properties["TransactionsCommitted"]?.Value ?? default(uint)),
		 TransactionsPending = (uint) (managementObject.Properties["TransactionsPending"]?.Value ?? default(uint)),
		 TransactionsPerSec = (uint) (managementObject.Properties["TransactionsPerSec"]?.Value ?? default(uint)),
		 TransactionsTotal = (uint) (managementObject.Properties["TransactionsTotal"]?.Value ?? default(uint)),
		 ViewstateMACValidationFailure = (uint) (managementObject.Properties["ViewstateMACValidationFailure"]?.Value ?? default(uint))
                };
        }
    }
}