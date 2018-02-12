using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32
{
    /// <summary>
    /// </summary>
    public sealed class ScheduledJob
    {
		public string Caption { get; private set; }
		public string Command { get; private set; }
		public uint DaysOfMonth { get; private set; }
		public uint DaysOfWeek { get; private set; }
		public string Description { get; private set; }
		public DateTime ElapsedTime { get; private set; }
		public DateTime InstallDate { get; private set; }
		public bool InteractWithDesktop { get; private set; }
		public uint JobId { get; private set; }
		public string JobStatus { get; private set; }
		public string Name { get; private set; }
		public string Notify { get; private set; }
		public string Owner { get; private set; }
		public uint Priority { get; private set; }
		public bool RunRepeatedly { get; private set; }
		public DateTime StartTime { get; private set; }
		public string Status { get; private set; }
		public DateTime TimeSubmitted { get; private set; }
		public DateTime UntilTime { get; private set; }

        public static IEnumerable<ScheduledJob> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<ScheduledJob> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<ScheduledJob> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_ScheduledJob");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new ScheduledJob
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Command = (string) (managementObject.Properties["Command"]?.Value ?? default(string)),
		 DaysOfMonth = (uint) (managementObject.Properties["DaysOfMonth"]?.Value ?? default(uint)),
		 DaysOfWeek = (uint) (managementObject.Properties["DaysOfWeek"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 ElapsedTime = (DateTime) (managementObject.Properties["ElapsedTime"]?.Value ?? default(DateTime)),
		 InstallDate = (DateTime) (managementObject.Properties["InstallDate"]?.Value ?? default(DateTime)),
		 InteractWithDesktop = (bool) (managementObject.Properties["InteractWithDesktop"]?.Value ?? default(bool)),
		 JobId = (uint) (managementObject.Properties["JobId"]?.Value ?? default(uint)),
		 JobStatus = (string) (managementObject.Properties["JobStatus"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Notify = (string) (managementObject.Properties["Notify"]?.Value ?? default(string)),
		 Owner = (string) (managementObject.Properties["Owner"]?.Value ?? default(string)),
		 Priority = (uint) (managementObject.Properties["Priority"]?.Value ?? default(uint)),
		 RunRepeatedly = (bool) (managementObject.Properties["RunRepeatedly"]?.Value ?? default(bool)),
		 StartTime = (DateTime) (managementObject.Properties["StartTime"]?.Value ?? default(DateTime)),
		 Status = (string) (managementObject.Properties["Status"]?.Value ?? default(string)),
		 TimeSubmitted = (DateTime) (managementObject.Properties["TimeSubmitted"]?.Value ?? default(DateTime)),
		 UntilTime = (DateTime) (managementObject.Properties["UntilTime"]?.Value ?? default(DateTime))
                };
        }
    }
}