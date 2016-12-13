using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RevaShare.DataClient.Models
{
    [DataContract]
    public class RideDAO
    {
        [DataMember]
        public int RideID { get; set; }
        [DataMember]
        public VehicleDAO Vehicle { get; set; }
        [DataMember]
        public DateTime StartOfWeek { get; set; }
        [DataMember]
        public bool IsOnTime { get; set; }
    }
}