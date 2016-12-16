using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RevaShare.DataClient.Models
{
    [DataContract]
    public class IdentityDAO
    {
        [DataMember]
        public int IdentityID { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}