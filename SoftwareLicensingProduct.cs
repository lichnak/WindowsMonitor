using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor
{
    /// <summary>
    /// </summary>
    public sealed class SoftwareLicensingProduct
    {
		public string ADActivationCsvlkPid { get; private set; }
		public string ADActivationCsvlkSkuId { get; private set; }
		public string ADActivationObjectDN { get; private set; }
		public string ADActivationObjectName { get; private set; }
		public string ApplicationID { get; private set; }
		public string AutomaticVMActivationHostDigitalPid2 { get; private set; }
		public string AutomaticVMActivationHostMachineName { get; private set; }
		public DateTime AutomaticVMActivationLastActivationTime { get; private set; }
		public string Description { get; private set; }
		public string DiscoveredKeyManagementServiceMachineIpAddress { get; private set; }
		public string DiscoveredKeyManagementServiceMachineName { get; private set; }
		public uint DiscoveredKeyManagementServiceMachinePort { get; private set; }
		public DateTime EvaluationEndDate { get; private set; }
		public uint ExtendedGrace { get; private set; }
		public uint GenuineStatus { get; private set; }
		public uint GracePeriodRemaining { get; private set; }
		public string IAID { get; private set; }
		public string ID { get; private set; }
		public uint IsKeyManagementServiceMachine { get; private set; }
		public uint KeyManagementServiceCurrentCount { get; private set; }
		public uint KeyManagementServiceFailedRequests { get; private set; }
		public uint KeyManagementServiceLicensedRequests { get; private set; }
		public string KeyManagementServiceLookupDomain { get; private set; }
		public string KeyManagementServiceMachine { get; private set; }
		public uint KeyManagementServiceNonGenuineGraceRequests { get; private set; }
		public uint KeyManagementServiceNotificationRequests { get; private set; }
		public uint KeyManagementServiceOOBGraceRequests { get; private set; }
		public uint KeyManagementServiceOOTGraceRequests { get; private set; }
		public uint KeyManagementServicePort { get; private set; }
		public string KeyManagementServiceProductKeyID { get; private set; }
		public uint KeyManagementServiceTotalRequests { get; private set; }
		public uint KeyManagementServiceUnlicensedRequests { get; private set; }
		public string LicenseDependsOn { get; private set; }
		public string LicenseFamily { get; private set; }
		public bool LicenseIsAddon { get; private set; }
		public uint LicenseStatus { get; private set; }
		public uint LicenseStatusReason { get; private set; }
		public string MachineURL { get; private set; }
		public string Name { get; private set; }
		public string OfflineInstallationId { get; private set; }
		public string PartialProductKey { get; private set; }
		public string ProcessorURL { get; private set; }
		public string ProductKeyChannel { get; private set; }
		public string ProductKeyID { get; private set; }
		public string ProductKeyID2 { get; private set; }
		public string ProductKeyURL { get; private set; }
		public uint RemainingAppReArmCount { get; private set; }
		public uint RemainingSkuReArmCount { get; private set; }
		public uint RequiredClientCount { get; private set; }
		public string TokenActivationAdditionalInfo { get; private set; }
		public string TokenActivationCertificateThumbprint { get; private set; }
		public uint TokenActivationGrantNumber { get; private set; }
		public string TokenActivationILID { get; private set; }
		public uint TokenActivationILVID { get; private set; }
		public DateTime TrustedTime { get; private set; }
		public string UseLicenseURL { get; private set; }
		public string ValidationURL { get; private set; }
		public uint VLActivationInterval { get; private set; }
		public uint VLActivationType { get; private set; }
		public uint VLActivationTypeEnabled { get; private set; }
		public uint VLRenewalInterval { get; private set; }

        public static IEnumerable<SoftwareLicensingProduct> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SoftwareLicensingProduct> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SoftwareLicensingProduct> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM SoftwareLicensingProduct");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SoftwareLicensingProduct
                {
                     ADActivationCsvlkPid = (string) (managementObject.Properties["ADActivationCsvlkPid"]?.Value ?? default(string)),
		 ADActivationCsvlkSkuId = (string) (managementObject.Properties["ADActivationCsvlkSkuId"]?.Value ?? default(string)),
		 ADActivationObjectDN = (string) (managementObject.Properties["ADActivationObjectDN"]?.Value ?? default(string)),
		 ADActivationObjectName = (string) (managementObject.Properties["ADActivationObjectName"]?.Value ?? default(string)),
		 ApplicationID = (string) (managementObject.Properties["ApplicationID"]?.Value ?? default(string)),
		 AutomaticVMActivationHostDigitalPid2 = (string) (managementObject.Properties["AutomaticVMActivationHostDigitalPid2"]?.Value ?? default(string)),
		 AutomaticVMActivationHostMachineName = (string) (managementObject.Properties["AutomaticVMActivationHostMachineName"]?.Value ?? default(string)),
		 AutomaticVMActivationLastActivationTime = (DateTime) (managementObject.Properties["AutomaticVMActivationLastActivationTime"]?.Value ?? default(DateTime)),
		 Description = (string) (managementObject.Properties["Description"]?.Value ?? default(string)),
		 DiscoveredKeyManagementServiceMachineIpAddress = (string) (managementObject.Properties["DiscoveredKeyManagementServiceMachineIpAddress"]?.Value ?? default(string)),
		 DiscoveredKeyManagementServiceMachineName = (string) (managementObject.Properties["DiscoveredKeyManagementServiceMachineName"]?.Value ?? default(string)),
		 DiscoveredKeyManagementServiceMachinePort = (uint) (managementObject.Properties["DiscoveredKeyManagementServiceMachinePort"]?.Value ?? default(uint)),
		 EvaluationEndDate = (DateTime) (managementObject.Properties["EvaluationEndDate"]?.Value ?? default(DateTime)),
		 ExtendedGrace = (uint) (managementObject.Properties["ExtendedGrace"]?.Value ?? default(uint)),
		 GenuineStatus = (uint) (managementObject.Properties["GenuineStatus"]?.Value ?? default(uint)),
		 GracePeriodRemaining = (uint) (managementObject.Properties["GracePeriodRemaining"]?.Value ?? default(uint)),
		 IAID = (string) (managementObject.Properties["IAID"]?.Value ?? default(string)),
		 ID = (string) (managementObject.Properties["ID"]?.Value ?? default(string)),
		 IsKeyManagementServiceMachine = (uint) (managementObject.Properties["IsKeyManagementServiceMachine"]?.Value ?? default(uint)),
		 KeyManagementServiceCurrentCount = (uint) (managementObject.Properties["KeyManagementServiceCurrentCount"]?.Value ?? default(uint)),
		 KeyManagementServiceFailedRequests = (uint) (managementObject.Properties["KeyManagementServiceFailedRequests"]?.Value ?? default(uint)),
		 KeyManagementServiceLicensedRequests = (uint) (managementObject.Properties["KeyManagementServiceLicensedRequests"]?.Value ?? default(uint)),
		 KeyManagementServiceLookupDomain = (string) (managementObject.Properties["KeyManagementServiceLookupDomain"]?.Value ?? default(string)),
		 KeyManagementServiceMachine = (string) (managementObject.Properties["KeyManagementServiceMachine"]?.Value ?? default(string)),
		 KeyManagementServiceNonGenuineGraceRequests = (uint) (managementObject.Properties["KeyManagementServiceNonGenuineGraceRequests"]?.Value ?? default(uint)),
		 KeyManagementServiceNotificationRequests = (uint) (managementObject.Properties["KeyManagementServiceNotificationRequests"]?.Value ?? default(uint)),
		 KeyManagementServiceOOBGraceRequests = (uint) (managementObject.Properties["KeyManagementServiceOOBGraceRequests"]?.Value ?? default(uint)),
		 KeyManagementServiceOOTGraceRequests = (uint) (managementObject.Properties["KeyManagementServiceOOTGraceRequests"]?.Value ?? default(uint)),
		 KeyManagementServicePort = (uint) (managementObject.Properties["KeyManagementServicePort"]?.Value ?? default(uint)),
		 KeyManagementServiceProductKeyID = (string) (managementObject.Properties["KeyManagementServiceProductKeyID"]?.Value ?? default(string)),
		 KeyManagementServiceTotalRequests = (uint) (managementObject.Properties["KeyManagementServiceTotalRequests"]?.Value ?? default(uint)),
		 KeyManagementServiceUnlicensedRequests = (uint) (managementObject.Properties["KeyManagementServiceUnlicensedRequests"]?.Value ?? default(uint)),
		 LicenseDependsOn = (string) (managementObject.Properties["LicenseDependsOn"]?.Value ?? default(string)),
		 LicenseFamily = (string) (managementObject.Properties["LicenseFamily"]?.Value ?? default(string)),
		 LicenseIsAddon = (bool) (managementObject.Properties["LicenseIsAddon"]?.Value ?? default(bool)),
		 LicenseStatus = (uint) (managementObject.Properties["LicenseStatus"]?.Value ?? default(uint)),
		 LicenseStatusReason = (uint) (managementObject.Properties["LicenseStatusReason"]?.Value ?? default(uint)),
		 MachineURL = (string) (managementObject.Properties["MachineURL"]?.Value ?? default(string)),
		 Name = (string) (managementObject.Properties["Name"]?.Value ?? default(string)),
		 OfflineInstallationId = (string) (managementObject.Properties["OfflineInstallationId"]?.Value ?? default(string)),
		 PartialProductKey = (string) (managementObject.Properties["PartialProductKey"]?.Value ?? default(string)),
		 ProcessorURL = (string) (managementObject.Properties["ProcessorURL"]?.Value ?? default(string)),
		 ProductKeyChannel = (string) (managementObject.Properties["ProductKeyChannel"]?.Value ?? default(string)),
		 ProductKeyID = (string) (managementObject.Properties["ProductKeyID"]?.Value ?? default(string)),
		 ProductKeyID2 = (string) (managementObject.Properties["ProductKeyID2"]?.Value ?? default(string)),
		 ProductKeyURL = (string) (managementObject.Properties["ProductKeyURL"]?.Value ?? default(string)),
		 RemainingAppReArmCount = (uint) (managementObject.Properties["RemainingAppReArmCount"]?.Value ?? default(uint)),
		 RemainingSkuReArmCount = (uint) (managementObject.Properties["RemainingSkuReArmCount"]?.Value ?? default(uint)),
		 RequiredClientCount = (uint) (managementObject.Properties["RequiredClientCount"]?.Value ?? default(uint)),
		 TokenActivationAdditionalInfo = (string) (managementObject.Properties["TokenActivationAdditionalInfo"]?.Value ?? default(string)),
		 TokenActivationCertificateThumbprint = (string) (managementObject.Properties["TokenActivationCertificateThumbprint"]?.Value ?? default(string)),
		 TokenActivationGrantNumber = (uint) (managementObject.Properties["TokenActivationGrantNumber"]?.Value ?? default(uint)),
		 TokenActivationILID = (string) (managementObject.Properties["TokenActivationILID"]?.Value ?? default(string)),
		 TokenActivationILVID = (uint) (managementObject.Properties["TokenActivationILVID"]?.Value ?? default(uint)),
		 TrustedTime = (DateTime) (managementObject.Properties["TrustedTime"]?.Value ?? default(DateTime)),
		 UseLicenseURL = (string) (managementObject.Properties["UseLicenseURL"]?.Value ?? default(string)),
		 ValidationURL = (string) (managementObject.Properties["ValidationURL"]?.Value ?? default(string)),
		 VLActivationInterval = (uint) (managementObject.Properties["VLActivationInterval"]?.Value ?? default(uint)),
		 VLActivationType = (uint) (managementObject.Properties["VLActivationType"]?.Value ?? default(uint)),
		 VLActivationTypeEnabled = (uint) (managementObject.Properties["VLActivationTypeEnabled"]?.Value ?? default(uint)),
		 VLRenewalInterval = (uint) (managementObject.Properties["VLRenewalInterval"]?.Value ?? default(uint))
                };
        }
    }
}