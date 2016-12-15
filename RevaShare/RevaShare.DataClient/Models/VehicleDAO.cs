using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RevaShare.DataClient.Models
{
    [DataContract]
    public class VehicleDAO
    {
        [DataMember]
        public int VehicleID { get; set; }
        [DataMember]
        public UserDAO Owner { get; set; }
        [DataMember]
        public string Make { get; set; }
        [DataMember]
        public string Model { get;set;}
        [DataMember]
        public string LicensePlate { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public int Capacity { get; set; }
    }
}