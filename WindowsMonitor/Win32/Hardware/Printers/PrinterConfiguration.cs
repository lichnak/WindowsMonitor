using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Win32.Hardware.Printers
{
    /// <summary>
    /// </summary>
    public sealed class PrinterConfiguration
    {
		public uint BitsPerPel { get; private set; }
		public string Caption { get; private set; }
		public bool Collate { get; private set; }
		public uint Color { get; private set; }
		public uint Copies { get; private set; }
		public string Description { get; private set; }
		public string DeviceName { get; private set; }
		public uint DisplayFlags { get; private set; }
		public uint DisplayFrequency { get; private set; }
		public uint DitherType { get; private set; }
		public uint DriverVersion { get; private set; }
		public bool Duplex { get; private set; }
		public string FormName { get; private set; }
		public uint HorizontalResolution { get; private set; }
		public uint ICMIntent { get; private set; }
		public uint ICMMethod { get; private set; }
		public uint LogPixels { get; private set; }
		public uint MediaType { get; private set; }
		public string Name { get; private set; }
		public uint Orientation { get; private set; }
		public uint PaperLength { get; private set; }
		public string PaperSize { get; private set; }
		public uint PaperWidth { get; private set; }
		public uint PelsHeight { get; private set; }
		public uint PelsWidth { get; private set; }
		public uint PrintQuality { get; private set; }
		public uint Scale { get; private set; }
		public string SettingID { get; private set; }
		public uint SpecificationVersion { get; private set; }
		public uint TTOption { get; private set; }
		public uint VerticalResolution { get; private set; }
		public uint XResolution { get; private set; }
		public uint YResolution { get; private set; }

        public static IEnumerable<PrinterConfiguration> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<PrinterConfiguration> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<PrinterConfiguration> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PrinterConfiguration");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new PrinterConfiguration
                {
                     BitsPerPel = (uint) (managementObject.Properties["BitsPerPel"]?.Value ?? default(uint)),
		 Caption = (string) (managementObject.Properties["Caption"]?.Value ?? default(string)),
		 Collate = (bool) (managementObject.Properties["Collate"]?.Value ?? default(bool)),
		 Color = (uint) (managementObject.Properties["Color"]?.Value ?? default(uint)),
		 Copies = (uint) (managementObject.Properties["Copies"]?.Value ?? default(uint)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DeviceName = (string) (managementObject.Properties["DeviceName"]?.Value ?? default(string)),
		 DisplayFlags = (uint) (managementObject.Properties["DisplayFlags"]?.Value ?? default(uint)),
		 DisplayFrequency = (uint) (managementObject.Properties["DisplayFrequency"]?.Value ?? default(uint)),
		 DitherType = (uint) (managementObject.Properties["DitherType"]?.Value ?? default(uint)),
		 DriverVersion = (uint) (managementObject.Properties["DriverVersion"]?.Value ?? default(uint)),
		 Duplex = (bool) (managementObject.Properties["Duplex"]?.Value ?? default(bool)),
		 FormName = (string) (managementObject.Properties["FormName"]?.Value ?? default(string)),
		 HorizontalResolution = (uint) (managementObject.Properties["HorizontalResolution"]?.Value ?? default(uint)),
		 ICMIntent = (uint) (managementObject.Properties["ICMIntent"]?.Value ?? default(uint)),
		 ICMMethod = (uint) (managementObject.Properties["ICMMethod"]?.Value ?? default(uint)),
		 LogPixels = (uint) (managementObject.Properties["LogPixels"]?.Value ?? default(uint)),
		 MediaType = (uint) (managementObject.Properties["MediaType"]?.Value ?? default(uint)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 Orientation = (uint) (managementObject.Properties["Orientation"]?.Value ?? default(uint)),
		 PaperLength = (uint) (managementObject.Properties["PaperLength"]?.Value ?? default(uint)),
		 PaperSize = (string) (managementObject.Properties["PaperSize"]?.Value ?? default(string)),
		 PaperWidth = (uint) (managementObject.Properties["PaperWidth"]?.Value ?? default(uint)),
		 PelsHeight = (uint) (managementObject.Properties["PelsHeight"]?.Value ?? default(uint)),
		 PelsWidth = (uint) (managementObject.Properties["PelsWidth"]?.Value ?? default(uint)),
		 PrintQuality = (uint) (managementObject.Properties["PrintQuality"]?.Value ?? default(uint)),
		 Scale = (uint) (managementObject.Properties["Scale"]?.Value ?? default(uint)),
		 SettingID = (string) (managementObject.Properties["SettingID"]?.Value ?? default(string)),
		 SpecificationVersion = (uint) (managementObject.Properties["SpecificationVersion"]?.Value ?? default(uint)),
		 TTOption = (uint) (managementObject.Properties["TTOption"]?.Value ?? default(uint)),
		 VerticalResolution = (uint) (managementObject.Properties["VerticalResolution"]?.Value ?? default(uint)),
		 XResolution = (uint) (managementObject.Properties["XResolution"]?.Value ?? default(uint)),
		 YResolution = (uint) (managementObject.Properties["YResolution"]?.Value ?? default(uint))
                };
        }
    }
}