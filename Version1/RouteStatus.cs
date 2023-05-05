using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class RouteStatus
    {
        public int SourceID { get; set; }
        public int DestinationID { get; set; }
        public string Status { get; set; } // "Delay" or "Closure"
        public int Delay { get; set; } // Delay time or -1 for closures
        public string Reason { get; set; } // Reason for delay

        public RouteStatus(int sourceID, int destinationID, string status, int delay, string reason)
        {
            SourceID = sourceID;
            DestinationID = destinationID;
            Status = status;
            Delay = delay;
            Reason = reason;
        }
    }

}
