using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class StartupCommand
    {
		public string Caption { get; private set; }
		public string Command { get; private set; }
		public string Description { get; private set; }
		public string Location { get; private set; }
		public string Name { get; private set; }
		public string SettingID { get; private set; }
		public string User { get; private set; }
		public string UserSID { get; private set; }

        public static IEnumerable<StartupCommand> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<StartupCommand> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<StartupCommand> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_StartupCommand");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new StartupCommand
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Command = (string) (managementObject.Properties["Command"]?.Value ?? default(string)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 Location = (string) (managementObject.Properties["Location"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value ?? default(string)),
		 User = (string) (managementObject.Properties["User"]?.Value ?? default(string)),
		 UserSID = (string) (managementObject.Properties["UserSID"]?.Value ?? default(string))
                };
        }
    }
}