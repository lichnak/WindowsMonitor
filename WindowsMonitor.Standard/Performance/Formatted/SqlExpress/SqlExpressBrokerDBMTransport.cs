using System.Collections.Generic;
using System.Management;

namespace WindowsMonitor.Performance.Formatted.SqlExpress
{
    /// <summary>
    /// </summary>
    public sealed class SqlExpressBrokerDbmTransport
    {
		public string Caption { get; private set; }
		public ulong CurrentBytesforRecvIo { get; private set; }
		public ulong CurrentBytesforSendIo { get; private set; }
		public ulong CurrentMsgFragsforSendIo { get; private set; }
		public string Description { get; private set; }
		public ulong FrequencyObject { get; private set; }
		public ulong FrequencyPerfTime { get; private set; }
		public ulong FrequencySys100Ns { get; private set; }
		public ulong MessageFragmentP10SendsPersec { get; private set; }
		public ulong MessageFragmentP1SendsPersec { get; private set; }
		public ulong MessageFragmentP2SendsPersec { get; private set; }
		public ulong MessageFragmentP3SendsPersec { get; private set; }
		public ulong MessageFragmentP4SendsPersec { get; private set; }
		public ulong MessageFragmentP5SendsPersec { get; private set; }
		public ulong MessageFragmentP6SendsPersec { get; private set; }
		public ulong MessageFragmentP7SendsPersec { get; private set; }
		public ulong MessageFragmentP8SendsPersec { get; private set; }
		public ulong MessageFragmentP9SendsPersec { get; private set; }
		public ulong MessageFragmentReceivesPersec { get; private set; }
		public ulong MessageFragmentSendsPersec { get; private set; }
		public ulong MsgFragmentRecvSizeAvg { get; private set; }
		public ulong MsgFragmentSendSizeAvg { get; private set; }
		public string Name { get; private set; }
		public ulong OpenConnectionCount { get; private set; }
		public ulong PendingBytesforRecvIo { get; private set; }
		public ulong PendingBytesforSendIo { get; private set; }
		public ulong PendingMsgFragsforRecvIo { get; private set; }
		public ulong PendingMsgFragsforSendIo { get; private set; }
		public ulong ReceiveIObytesPersec { get; private set; }
		public ulong ReceiveIoLenAvg { get; private set; }
		public ulong ReceiveIPerOsPersec { get; private set; }
		public ulong RecvIoBufferCopiesbytesPersec { get; private set; }
		public ulong RecvIoBufferCopiesCount { get; private set; }
		public ulong SendIObytesPersec { get; private set; }
		public ulong SendIoLenAvg { get; private set; }
		public ulong SendIPerOsPersec { get; private set; }
		public ulong TimestampObject { get; private set; }
		public ulong TimestampPerfTime { get; private set; }
		public ulong TimestampSys100Ns { get; private set; }

        public static IEnumerable<SqlExpressBrokerDbmTransport> Retrieve(string remote, string username, string password)
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

        public static IEnumerable<SqlExpressBrokerDbmTransport> Retrieve()
        {
            var managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
            return Retrieve(managementScope);
        }

        public static IEnumerable<SqlExpressBrokerDbmTransport> Retrieve(ManagementScope managementScope)
        {
            var objectQuery = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_MSSQLSQLEXPRESS_MSSQLSQLEXPRESSBrokerDBMTransport");
            var objectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            var objectCollection = objectSearcher.Get();

            foreach (ManagementObject managementObject in objectCollection)
                yield return new SqlExpressBrokerDbmTransport
                {
                     Caption = (string) (managementObject.Properties["Caption"]?.Value),
		 CurrentBytesforRecvIo = (ulong) (managementObject.Properties["CurrentBytesforRecvIO"]?.Value ?? default(ulong)),
		 CurrentBytesforSendIo = (ulong) (managementObject.Properties["CurrentBytesforSendIO"]?.Value ?? default(ulong)),
		 CurrentMsgFragsforSendIo = (ulong) (managementObject.Properties["CurrentMsgFragsforSendIO"]?.Value ?? default(ulong)),
		 Description = (string) (managementObject.Properties["Description"]?.Value),
		 FrequencyObject = (ulong) (managementObject.Properties["Frequency_Object"]?.Value ?? default(ulong)),
		 FrequencyPerfTime = (ulong) (managementObject.Properties["Frequency_PerfTime"]?.Value ?? default(ulong)),
		 FrequencySys100Ns = (ulong) (managementObject.Properties["Frequency_Sys100NS"]?.Value ?? default(ulong)),
		 MessageFragmentP10SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP10SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP1SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP1SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP2SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP2SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP3SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP3SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP4SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP4SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP5SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP5SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP6SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP6SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP7SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP7SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP8SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP8SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentP9SendsPersec = (ulong) (managementObject.Properties["MessageFragmentP9SendsPersec"]?.Value ?? default(ulong)),
		 MessageFragmentReceivesPersec = (ulong) (managementObject.Properties["MessageFragmentReceivesPersec"]?.Value ?? default(ulong)),
		 MessageFragmentSendsPersec = (ulong) (managementObject.Properties["MessageFragmentSendsPersec"]?.Value ?? default(ulong)),
		 MsgFragmentRecvSizeAvg = (ulong) (managementObject.Properties["MsgFragmentRecvSizeAvg"]?.Value ?? default(ulong)),
		 MsgFragmentSendSizeAvg = (ulong) (managementObject.Properties["MsgFragmentSendSizeAvg"]?.Value ?? default(ulong)),
		 Name = (string) (managementObject.Properties["Name"]?.Value),
		 OpenConnectionCount = (ulong) (managementObject.Properties["OpenConnectionCount"]?.Value ?? default(ulong)),
		 PendingBytesforRecvIo = (ulong) (managementObject.Properties["PendingBytesforRecvIO"]?.Value ?? default(ulong)),
		 PendingBytesforSendIo = (ulong) (managementObject.Properties["PendingBytesforSendIO"]?.Value ?? default(ulong)),
		 PendingMsgFragsforRecvIo = (ulong) (managementObject.Properties["PendingMsgFragsforRecvIO"]?.Value ?? default(ulong)),
		 PendingMsgFragsforSendIo = (ulong) (managementObject.Properties["PendingMsgFragsforSendIO"]?.Value ?? default(ulong)),
		 ReceiveIObytesPersec = (ulong) (managementObject.Properties["ReceiveIObytesPersec"]?.Value ?? default(ulong)),
		 ReceiveIoLenAvg = (ulong) (managementObject.Properties["ReceiveIOLenAvg"]?.Value ?? default(ulong)),
		 ReceiveIPerOsPersec = (ulong) (managementObject.Properties["ReceiveIPerOsPersec"]?.Value ?? default(ulong)),
		 RecvIoBufferCopiesbytesPersec = (ulong) (managementObject.Properties["RecvIOBufferCopiesbytesPersec"]?.Value ?? default(ulong)),
		 RecvIoBufferCopiesCount = (ulong) (managementObject.Properties["RecvIOBufferCopiesCount"]?.Value ?? default(ulong)),
		 SendIObytesPersec = (ulong) (managementObject.Properties["SendIObytesPersec"]?.Value ?? default(ulong)),
		 SendIoLenAvg = (ulong) (managementObject.Properties["SendIOLenAvg"]?.Value ?? default(ulong)),
		 SendIPerOsPersec = (ulong) (managementObject.Properties["SendIPerOsPersec"]?.Value ?? default(ulong)),
		 TimestampObject = (ulong) (managementObject.Properties["Timestamp_Object"]?.Value ?? default(ulong)),
		 TimestampPerfTime = (ulong) (managementObject.Properties["Timestamp_PerfTime"]?.Value ?? default(ulong)),
		 TimestampSys100Ns = (ulong) (managementObject.Properties["Timestamp_Sys100NS"]?.Value ?? default(ulong))
                };
        }
    }
}