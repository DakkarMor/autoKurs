using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kursovik.Models
{
    public class Records
    {
        public string Id { get; set; }
        public string DeparturePoint { get; set; }
        public string ArrivalPoint { get; set; }
        public string TimeDeparture { get; set; }
        public string TimeArrival { get; set; }
        public string TransportId { get; set; }

        public List<Route> RecordsList { get; set; }
    }

    
}