using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Performance.Formatted
{
    /// <summary>
    /// </summary>
    public sealed class ServiceModel4000_ServiceModelService4000
    {
		public uint Calls { get; private set; }
		public uint CallsDuration { get; private set; }
		public uint CallsFailed { get; private set; }
		public uint CallsFailedPerSecond { get; private set; }
		public uint CallsFaulted { get; private set; }
		public uint CallsFaultedPerSecond { get; private set; }
		public uint CallsOutstanding { get; private set; }
		public uint CallsPerSecond { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }
		public ulong Frequency_Object { get; private set; }
		public ulong Frequency_PerfTime { get; private set; }
		public ulong Frequency_Sys100NS { get; private set; }
		public uint Instances { get; private set; }
		public uint InstancesCreatedPerSecond { get; private set; }
		public string Name { get; private set; }
		public uint PercentOfMaxConcurrentCalls { get; private set; }
		public uint PercentOfMaxConcurrentInstances { get; private set; }
		public uint PercentOfMaxConcurrentSessions { get; private set; }
		public uint QueuedMessagesDropped { get; private set; }
		public uint QueuedMessagesDroppedPerSecond { get; private set; }
		public uint QueuedMessagesRejected { get; private set; }
		public uint QueuedMessagesRejectedPerSecond { get; private set; }
		public uint QueuedPoisonMessages { get; private set; }
		public uint QueuedPoisonMessagesPerSecond { get; private set; }
		public uint ReliableMessagingMessagesDropped { get; private set; }
		public uint ReliableMessagingMessagesDroppedPerSecond { get; private set; }
		public uint ReliableMessagingSessionsFaulted { get; private set; }
		public uint ReliableMessagingSessionsFaultedPerSecond { get; private set; }
		public uint SecurityCallsNotAuthorized { get; private set; }
		public uint SecurityCallsNotAuthorizedPerSecond { get; private set; }
		public uint SecurityValidationandAuthenticationFailures { get; private set; }
		public uint SecurityValidationandAuthenticationFailuresPerSecond { get; private set; }
		public ulong Timestamp_Object { get; private set; }
		public ulong Timestamp_PerfTime { get; private set; }
		public ulong Timestamp_Sys100NS { get; private set; }
		public uint TransactedOperationsAborted { get; private set; }
		public uint TransactedOperationsAbortedPerSecond { get; private set; }
		public uint TransactedOperationsCommitted { get; private set; }
		public uint TransactedOperationsCommittedPerSecond { get; private set; }
		public uint TransactedOperationsInDoubt { get; private set; }
		public uint TransactedOperationsInDoubtPerSecond { get; private set; }
		public uint TransactionsFlowed { get; private set; }
		public uint TransactionsFlowedPerSecond { get; private set; }

        public static IEnumerable<ServiceModel4000_ServiceModelService4000> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ServiceModel4000_ServiceModelService4000> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ServiceModel4000_ServiceModelService4000> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_ServiceModel4000_ServiceModelService4000");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ServiceModel4000_ServiceModelService4000
                {
                     Calls = (uint) (managementObject.Properties["Calls"]?.Value ?? default(uint)),
		 CallsDuration = (uint) (managementObject.Properties["CallsDuration"]?.Value ?? default(uint)),
		 CallsFailed = (uint) (managementObject.Properties["CallsFailed"]?.Value ?? default(uint)),
		 CallsFailedPerSecond = (uint) (managementObject.Properties["CallsFailedPerSecond"]?.Value ?? default(uint)),
		 CallsFaulted = (uint) (managementObject.Properties["CallsFaulted"]?.Value ?? default(uint)),
		 CallsFaultedPerSecond = (uint) (managementObject.Properties["CallsFaultedPerSecond"]?.Value ?? default(uint)),
		 CallsOutstanding = (uint) (managementObject.Properties["CallsOutstanding"]?.Value ?? default(uint)),
		 CallsPerSecond = (uint) (managementObject.Properties["CallsPerSecond"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Frequency_Object = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 Frequency_PerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 Frequency_Sys100NS = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 Instances = (uint) (managementObject.Properties["Instances"]?.Value ?? default(uint)),
		 InstancesCreatedPerSecond = (uint) (managementObject.Properties["InstancesCreatedPerSecond"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 PercentOfMaxConcurrentCalls = (uint) (managementObject.Properties["PercentOfMaxConcurrentCalls"]?.Value ?? default(uint)),
		 PercentOfMaxConcurrentInstances = (uint) (managementObject.Properties["PercentOfMaxConcurrentInstances"]?.Value ?? default(uint)),
		 PercentOfMaxConcurrentSessions = (uint) (managementObject.Properties["PercentOfMaxConcurrentSessions"]?.Value ?? default(uint)),
		 QueuedMessagesDropped = (uint) (managementObject.Properties["QueuedMessagesDropped"]?.Value ?? default(uint)),
		 QueuedMessagesDroppedPerSecond = (uint) (managementObject.Properties["QueuedMessagesDroppedPerSecond"]?.Value ?? default(uint)),
		 QueuedMessagesRejected = (uint) (managementObject.Properties["QueuedMessagesRejected"]?.Value ?? default(uint)),
		 QueuedMessagesRejectedPerSecond = (uint) (managementObject.Properties["QueuedMessagesRejectedPerSecond"]?.Value ?? default(uint)),
		 QueuedPoisonMessages = (uint) (managementObject.Properties["QueuedPoisonMessages"]?.Value ?? default(uint)),
		 QueuedPoisonMessagesPerSecond = (uint) (managementObject.Properties["QueuedPoisonMessagesPerSecond"]?.Value ?? default(uint)),
		 ReliableMessagingMessagesDropped = (uint) (managementObject.Properties["ReliableMessagingMessagesDropped"]?.Value ?? default(uint)),
		 ReliableMessagingMessagesDroppedPerSecond = (uint) (managementObject.Properties["ReliableMessagingMessagesDroppedPerSecond"]?.Value ?? default(uint)),
		 ReliableMessagingSessionsFaulted = (uint) (managementObject.Properties["ReliableMessagingSessionsFaulted"]?.Value ?? default(uint)),
		 ReliableMessagingSessionsFaultedPerSecond = (uint) (managementObject.Properties["ReliableMessagingSessionsFaultedPerSecond"]?.Value ?? default(uint)),
		 SecurityCallsNotAuthorized = (uint) (managementObject.Properties["SecurityCallsNotAuthorized"]?.Value ?? default(uint)),
		 SecurityCallsNotAuthorizedPerSecond = (uint) (managementObject.Properties["SecurityCallsNotAuthorizedPerSecond"]?.Value ?? default(uint)),
		 SecurityValidationandAuthenticationFailures = (uint) (managementObject.Properties["SecurityValidationandAuthenticationFailures"]?.Value ?? default(uint)),
		 SecurityValidationandAuthenticationFailuresPerSecond = (uint) (managementObject.Properties["SecurityValidationandAuthenticationFailuresPerSecond"]?.Value ?? default(uint)),
		 Timestamp_Object = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 Timestamp_PerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 Timestamp_Sys100NS = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong)),
		 TransactedOperationsAborted = (uint) (managementObject.Properties["TransactedOperationsAborted"]?.Value ?? default(uint)),
		 TransactedOperationsAbortedPerSecond = (uint) (managementObject.Properties["TransactedOperationsAbortedPerSecond"]?.Value ?? default(uint)),
		 TransactedOperationsCommitted = (uint) (managementObject.Properties["TransactedOperationsCommitted"]?.Value ?? default(uint)),
		 TransactedOperationsCommittedPerSecond = (uint) (managementObject.Properties["TransactedOperationsCommittedPerSecond"]?.Value ?? default(uint)),
		 TransactedOperationsInDoubt = (uint) (managementObject.Properties["TransactedOperationsInDoubt"]?.Value ?? default(uint)),
		 TransactedOperationsInDoubtPerSecond = (uint) (managementObject.Properties["TransactedOperationsInDoubtPerSecond"]?.Value ?? default(uint)),
		 TransactionsFlowed = (uint) (managementObject.Properties["TransactionsFlowed"]?.Value ?? default(uint)),
		 TransactionsFlowedPerSecond = (uint) (managementObject.Properties["TransactionsFlowedPerSecond"]?.Value ?? default(uint))
                };
        }
    }
}