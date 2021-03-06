using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.HyperVisor
{
    /// <summary>
    /// </summary>
    public sealed class HvApicAccess
    {
		public ulong GuestRip { get; private set; }

        public static IEnumerable<HvApicAccess> Retrieve(string remote, string username, string password)
        {
            var options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Username = username,
                Password = password
            };

            var managementScope = new ManagementScope(new ManagementPath($"\\\\{remote}\\root\\wmi"), options);
            managementScope.Connect();

            return Retrieve(managementScope);
        }

        public static IEnumerable<HvApicAccess> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\wmi"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<HvApicAccess> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM HvApicAccess");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new HvApicAccess
                {
                     GuestRip = (ulong) (managementObject.Properties["GuestRip"]?.Value ?? default(ulong))
                };
        }
    }
}