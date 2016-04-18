using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeRadMVC5.Models
{
    public class AccessLog
    {
        public Int64 RadAcctId { get; set; }
        public string AcctSessionId { get; set; }
        public string AcctUniqueId { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public string Realm { get; set; }
        public string NasIpAddress { get; set; }
        public string NasPortId { get; set; }
        public string NasPortType { get; set; }
        public DateTime AcctStartTime { get; set; }
        public DateTime AcctUpdateTime { get; set; }
        public DateTime AcctStopTime { get; set; }
        public int? AcctInterval { get; set; }
        public int? AcctSessionTime { get; set; }
        public string AcctAuthentic { get; set; }
        public string ConnectInfo_start { get; set; }
        public string ConnectInfo_stop { get; set; }
        public Int64? AcctInputOctets { get; set; }
        public Int64? AcctOutputOctets { get; set; }
        public string CalledStationId { get; set; }
        public string CallingStationId { get; set; }
        public string AcctTerminateCause { get; set; }
        public string ServiceType { get; set; }
        public string FramedProtocol { get; set; }
        public string FramedIpAddress { get; set; }        
    }
}