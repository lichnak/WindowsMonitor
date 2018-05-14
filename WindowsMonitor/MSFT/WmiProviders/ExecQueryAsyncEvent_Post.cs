using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.MSFT.WmiProviders
{
    /// <summary>
    /// </summary>
    public sealed class ExecQueryAsyncEventPost
    {
		public uint Flags { get; private set; }
		public string HostingGroup { get; private set; }
		public uint HostingSpecification { get; private set; }
		public string Locale { get; private set; }
		public string Namespace { get; private set; }
		public dynamic ObjectParameter { get; private set; }
		public string Provider { get; private set; }
		public string Query { get; private set; }
		public string QueryLanguage { get; private set; }
		public uint ResultCode { get; private set; }
		public byte[] SecurityDescriptor { get; private set; }
		public string StringParameter { get; private set; }
		public ulong TimeCreated { get; private set; }
		public string TransactionIdentifer { get; private set; }
		public string User { get; private set; }

        public static IEnumerable<ExecQueryAsyncEventPost> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ExecQueryAsyncEventPost> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ExecQueryAsyncEventPost> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Msft_WmiProvider_ExecQueryAsyncEvent_Post");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ExecQueryAsyncEventPost
                {
                     Flags = (uint) (managementObject.Properties["Flags"]?.Value ?? default(uint)),
		 HostingGroup = (string) (managementObject.Properties["HostingGroup"]?.Value),
		 HostingSpecification = (uint) (managementObject.Properties["HostingSpecification"]?.Value ?? default(uint)),
		 Locale = (string) (managementObject.Properties["Locale"]?.Value),
		 Namespace = (string) (managementObject.Properties["Namespace"]?.Value),
		 ObjectParameter = (dynamic) (managementObject.Properties["ObjectParameter"]?.Value ?? default(dynamic)),
		 Provider = (string) (managementObject.Properties["provider"]?.Value),
		 Query = (string) (managementObject.Properties["Query"]?.Value),
		 QueryLanguage = (string) (managementObject.Properties["QueryLanguage"]?.Value),
		 ResultCode = (uint) (managementObject.Properties["ResultCode"]?.Value ?? default(uint)),
		 SecurityDescriptor = (byte[]) (managementObject.Properties["SECURITY_DESCRIPTOR"]?.Value ?? new byte[0]),
		 StringParameter = (string) (managementObject.Properties["StringParameter"]?.Value),
		 TimeCreated = (ulong) (managementObject.Properties["TIME_CREATED"]?.Value ?? default(ulong)),
		 TransactionIdentifer = (string) (managementObject.Properties["TransactionIdentifer"]?.Value),
		 User = (string) (managementObject.Properties["User"]?.Value)
                };
        }
    }
}