using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RevaShare.DataClient.Models
{
    [DataContract]
    public class RideRidersDAO
    {
        [DataMember]
        public RideDAO Ride { get; set; }
        [DataMember]
        public UserDAO Rider { get; set; }
        [DataMember]
        public bool Accepted { get; set; }
    }
}