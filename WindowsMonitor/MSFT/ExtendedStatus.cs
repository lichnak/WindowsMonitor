using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Msft
{
    /// <summary>
    /// </summary>
    public sealed class ExtendedStatus
    {
		public uint CIMStatusCode { get; private set; }
		public string CIMStatusCodeDescription { get; private set; }
		public ushort error_Category { get; private set; }
		public uint error_Code { get; private set; }
		public string error_Type { get; private set; }
		public string error_WindowsErrorMessage { get; private set; }
		public string ErrorSource { get; private set; }
		public ushort ErrorSourceFormat { get; private set; }
		public ushort ErrorType { get; private set; }
		public string Message { get; private set; }
		public string[] MessageArguments { get; private set; }
		public string MessageID { get; private set; }
		public dynamic original_error { get; private set; }
		public string OtherErrorSourceFormat { get; private set; }
		public string OtherErrorType { get; private set; }
		public string OWningEntity { get; private set; }
		public ushort PerceivedSeverity { get; private set; }
		public ushort ProbableCause { get; private set; }
		public string ProbableCauseDescription { get; private set; }
		public string[] RecommendedActions { get; private set; }

        public static IEnumerable<ExtendedStatus> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ExtendedStatus> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ExtendedStatus> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM MSFT_ExtendedStatus");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ExtendedStatus
                {
                     CIMStatusCode = (uint) (managementObject.Properties["CIMStatusCode"]?.Value ?? default(uint)),
		 CIMStatusCodeDescription = (string) (managementObject.Properties["CIMStatusCodeDescription"]?.Value),
		 error_Category = (ushort) (managementObject.Properties["error_Category"]?.Value ?? default(ushort)),
		 error_Code = (uint) (managementObject.Properties["error_Code"]?.Value ?? default(uint)),
		 error_Type = (string) (managementObject.Properties["error_Type"]?.Value),
		 error_WindowsErrorMessage = (string) (managementObject.Properties["error_WindowsErrorMessage"]?.Value),
		 ErrorSource = (string) (managementObject.Properties["ErrorSource"]?.Value),
		 ErrorSourceFormat = (ushort) (managementObject.Properties["ErrorSourceFormat"]?.Value ?? default(ushort)),
		 ErrorType = (ushort) (managementObject.Properties["ErrorType"]?.Value ?? default(ushort)),
		 Message = (string) (managementObject.Properties["Message"]?.Value),
		 MessageArguments = (string[]) (managementObject.Properties["MessageArguments"]?.Value ?? new string[0]),
		 MessageID = (string) (managementObject.Properties["MessageID"]?.Value),
		 original_error = (dynamic) (managementObject.Properties["original_error"]?.Value ?? default(dynamic)),
		 OtherErrorSourceFormat = (string) (managementObject.Properties["OtherErrorSourceFormat"]?.Value),
		 OtherErrorType = (string) (managementObject.Properties["OtherErrorType"]?.Value),
		 OWningEntity = (string) (managementObject.Properties["OWningEntity"]?.Value),
		 PerceivedSeverity = (ushort) (managementObject.Properties["PerceivedSeverity"]?.Value ?? default(ushort)),
		 ProbableCause = (ushort) (managementObject.Properties["ProbableCause"]?.Value ?? default(ushort)),
		 ProbableCauseDescription = (string) (managementObject.Properties["ProbableCauseDescription"]?.Value),
		 RecommendedActions = (string[]) (managementObject.Properties["RecommendedActions"]?.Value ?? new string[0])
                };
        }
    }
}