using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RevaShare.DataClient.Models {
    [DataContract]
    public class RoleDAO {
        [DataMember]
        public string Type { get; set; }
    }
}